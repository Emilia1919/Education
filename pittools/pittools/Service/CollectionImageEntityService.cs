using pittools.Models;
using pittools.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Service
{
    public class CollectionImageEntityService : OrderedEntityService<CollectionImage>
    {
        Entities entities = new Entities();

        protected override System.Data.Entity.DbSet<CollectionImage> EntitySet { get { return entities.CollectionImages; } }

        public override CollectionImage GetPrevious(CollectionImage dataObject)
        {
            return (from obj in EntitySet where obj.Sequence < dataObject.Sequence && obj.CollectionID == dataObject.CollectionID orderby obj.Sequence descending select obj).FirstOrDefault();
        }

        public override CollectionImage GetNext(CollectionImage dataObject)
        {
            return (from obj in EntitySet where obj.Sequence > dataObject.Sequence && obj.CollectionID == dataObject.CollectionID orderby obj.Sequence ascending select obj).FirstOrDefault();
        }
        public override void Save()
        {
            entities.SaveChanges();
        }
    }
}