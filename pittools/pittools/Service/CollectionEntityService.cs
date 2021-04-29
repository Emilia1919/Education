using pittools.Models;
using pittools.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace pittools.Service
{
    public class CollectionEntityService : UrlFriendlyEntityService<Collection>
    {
        Entities entities = new Entities();

        protected override System.Data.Entity.DbSet<Collection> EntitySet { get { return entities.Collections; } }


        public override Collection GetPrevious(Collection dataObject)
        {
            return (from obj in EntitySet where obj.Sequence < dataObject.Sequence && obj.CategoryID == dataObject.CategoryID orderby obj.Sequence descending select obj).FirstOrDefault();
        }

        public override Collection GetNext(Collection dataObject)
        {
            return (from obj in EntitySet where obj.Sequence > dataObject.Sequence && obj.CategoryID == dataObject.CategoryID orderby obj.Sequence ascending select obj).FirstOrDefault();
        }

        public override void Save()
        {
            entities.SaveChanges();
        }
    }
}