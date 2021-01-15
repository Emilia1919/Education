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

        public override IQueryable<Product> Get(System.Collections.Specialized.NameValueCollection filter)
        {
            IQueryable<Product> result = Get();

            if (!string.IsNullOrWhiteSpace(filter["find"]))
            {
                string strFind = filter["find"].ToLower();
                result = result.Where(item => item.Name != null && item.Name.Contains(strFind));
            }

            return result;
        }
    }
}