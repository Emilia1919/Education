using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21century.Service.Abstract;
using _21century.Models;

namespace _21century.Service
{
    public class OrderItemEntityService : BaseEntityService<OrderItem>
    {
        OnlineStoreEntities entities = new OnlineStoreEntities();

        public override void Save()
        {
            entities.SaveChanges();
        }

        protected override System.Data.Entity.DbSet<OrderItem> EntitySet
        {
            get { return entities.OrderItems; }
        }
    }
}