using pittools.Models;
using pittools.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Service
{
    public class CategoryProductEntityService : OrderedEntityService<CategoryProduct>
    {
        Entities entities = new Entities();

        protected override System.Data.Entity.DbSet<CategoryProduct> EntitySet { get { return entities.CategoryProducts; } }

        public override CategoryProduct GetPrevious(CategoryProduct dataObject)
        {
            return (from obj in EntitySet where obj.Sequence < dataObject.Sequence && obj.CategoryID == dataObject.CategoryID orderby obj.Sequence descending select obj).FirstOrDefault();
        }

        public override CategoryProduct GetNext(CategoryProduct dataObject)
        {
            return (from obj in EntitySet where obj.Sequence > dataObject.Sequence && obj.CategoryID == dataObject.CategoryID orderby obj.Sequence ascending select obj).FirstOrDefault();
        }
        public override void Save()
        {
            entities.SaveChanges();
        }
    }
}