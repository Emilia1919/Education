using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21century.Service.Abstract;
using _21century.Models;

namespace _21century.Service
{
    public class CategoryProductEntityService : OrderedEntityService<CategoryProduct>
    {
        OnlineStoreEntities entities = new OnlineStoreEntities();

        protected override System.Data.Entity.DbSet<CategoryProduct> EntitySet { get { return entities.CategoryProducts; } }

        public override void Save()
        {
            entities.SaveChanges();
        }

        public override CategoryProduct GetPrevious(CategoryProduct dataObject)
        {
            return (from obj in EntitySet where obj.Sequence < dataObject.Sequence && obj.CategoryID == dataObject.CategoryID orderby obj.Sequence descending select obj).FirstOrDefault();
        }

        public override CategoryProduct GetNext(CategoryProduct dataObject)
        {
            return (from obj in EntitySet where obj.Sequence > dataObject.Sequence && obj.CategoryID == dataObject.CategoryID orderby obj.Sequence ascending select obj).FirstOrDefault();
        }
    }
}