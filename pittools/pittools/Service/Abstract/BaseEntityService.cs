using pittools.Models.Interface;
using pittools.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace pittools.Service.Abstract
{
    public abstract class BaseEntityService<T> : IBaseService<T> where T : class, IBase, new()
    {
        protected abstract DbSet<T> EntitySet { get; }

        public virtual IQueryable<T> Get()
        {
            return from obj in EntitySet select obj;
        }

        public virtual T Get(int id)
        {
            return (from obj in EntitySet where obj.ID == id select obj).FirstOrDefault();
        }

        public virtual IQueryable<T> Get(int skip, int take)
        {
            return Get().Skip(skip).Take(take);
        }

        public virtual void Add(T dataObject)
        {
            EntitySet.Add(dataObject);
        }

        public virtual void Delete(T dataObject)
        {
            EntitySet.Remove(dataObject);
        }

        public abstract void Save();
    }
}
