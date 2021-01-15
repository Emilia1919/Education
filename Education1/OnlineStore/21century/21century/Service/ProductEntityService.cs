using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21century.Service.Abstract;
using _21century.Models;

namespace _21century.Service
{
    public class ProductEntityService : UrlFriendlyEntityService<Product>
    {
        OnlineStoreEntities entities = new OnlineStoreEntities();

        protected override System.Data.Entity.DbSet<Product> EntitySet { get { return entities.Products; } }

        public override void Save()
        {
            entities.SaveChanges();
        }
    }
}