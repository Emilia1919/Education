using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21century.Service.Abstract;
using _21century.Models;

namespace _21century.Service
{
    public class OrderStatusEntityService : OrderedEntityService<OrderStatus>
    {
        OnlineStoreEntities entities = new OnlineStoreEntities();

        public override void Save()
        {
            entities.SaveChanges();
        }

        protected override System.Data.Entity.DbSet<OrderStatus> EntitySet
        {
            get { return entities.OrderStatuses; }
        }
    }
}