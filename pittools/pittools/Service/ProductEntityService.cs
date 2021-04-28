using pittools.Models;
using pittools.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Service
{
    public class ProductEntityService : UrlFriendlyEntityService<Product>
    {
        Entities entities = new Entities();
        protected override System.Data.Entity.DbSet<Product> EntitySet { get { return entities.Products; } }

        public override void Save()
        {
            entities.SaveChanges();
        }
    }
}