using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21century.Service.Abstract;
using _21century.Models;

namespace _21century.Service
{
    public class OrderEntityService : BaseEntityService<Order>
    {
        OnlineStoreEntities entities = new OnlineStoreEntities();

        protected override System.Data.Entity.DbSet<Order> EntitySet
        {
            get { return entities.Orders; }
        }

        public override void Save()
        {
            entities.SaveChanges();
        }

        public override IQueryable<Order> Get()
        {
            return base.Get().OrderByDescending(item => item.Date);
        }
    }
}