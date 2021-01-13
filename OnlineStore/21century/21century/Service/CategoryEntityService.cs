using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21century.Service.Abstract;
using _21century.Models;

namespace _21century.Service
{
    public class CategoryEntityService : UrlFriendlyEntityService<Category>
    {
        OnlineStoreEntities entities = new OnlineStoreEntities();

        protected override System.Data.Entity.DbSet<Category> EntitySet { get { return entities.Categories; } }

        public override void Save()
        {
            entities.SaveChanges();
        }
    }
}