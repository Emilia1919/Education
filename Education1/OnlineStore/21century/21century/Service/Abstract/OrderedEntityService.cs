using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21century.Service.Interface;
using _21century.Models.Interface;

namespace _21century.Service.Abstract
{
    public abstract class OrderedEntityService<T> : BaseEntityService<T>, IOrderedService<T> where T : class,IOrdered,new()
    {
        public override IQueryable<T> Get()
        {
            return base.Get().OrderByDescending(item => item.Sequence);
        }

        public virtual T GetPrevious(T dataObject)
        {
            return (from obj in EntitySet where obj.Sequence < dataObject.Sequence orderby obj.Sequence descending select obj).FirstOrDefault();
        }

        public virtual T GetNext(T dataObject)
        {
            return (from obj in EntitySet where obj.Sequence > dataObject.Sequence orderby obj.Sequence ascending select obj).FirstOrDefault();
        }
    }
}