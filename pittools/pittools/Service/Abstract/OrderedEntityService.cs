using pittools.Models.Interface;
using pittools.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Service.Abstract
{
    public abstract class OrderedEntityService<T> : BaseEntityService<T>, IOrderedService<T> where T : class, IOrdered, new()
    {
        // В списке объекты должны располагаться в порядке уменьшения Sequence
        public override IQueryable<T> Get()
        {
            return base.Get().OrderByDescending(item => item.Sequence);
        }

        // Получение ближайшего объекта с меньшим Sequence
        public virtual T GetPrevious(T dataObject)
        {
            return (from obj in EntitySet where obj.Sequence < dataObject.Sequence orderby obj.Sequence descending select obj).FirstOrDefault();
        }

        // Получение ближайшего объекта с большим Sequence
        public virtual T GetNext(T dataObject)
        {
            return (from obj in EntitySet where obj.Sequence > dataObject.Sequence orderby obj.Sequence ascending select obj).FirstOrDefault();
        }
    }
}