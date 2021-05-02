using pittools.Models;
using pittools.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Service
{
    public class CollectionProductEntityService : OrderedEntityService<CollectionProduct>
    {
        Entities entities = new Entities();

        protected override System.Data.Entity.DbSet<CollectionProduct> EntitySet { get { return entities.CollectionProducts; } }

        public override CollectionProduct GetPrevious(CollectionProduct dataObject)
        {
            return (from obj in EntitySet where obj.Sequence < dataObject.Sequence && obj.CollectionID == dataObject.CollectionID orderby obj.Sequence descending select obj).FirstOrDefault();
        }

        public override CollectionProduct GetNext(CollectionProduct dataObject)
        {
            return (from obj in EntitySet where obj.Sequence > dataObject.Sequence && obj.CollectionID == dataObject.CollectionID orderby obj.Sequence ascending select obj).FirstOrDefault();
        }
        public override void Save()
        {
            entities.SaveChanges();
        }
    }
}