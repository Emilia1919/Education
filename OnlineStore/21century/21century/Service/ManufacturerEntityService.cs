using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using _21century.Models;
using _21century.Service.Abstract;

namespace _21century.Service
{
    public class ManufacturerEntityService : BaseEntityService<Manufacturer>
    {
        OnlineStoreEntities entities = new OnlineStoreEntities();
        protected override System.Data.Entity.DbSet<Manufacturer> EntitySet { get { return entities.Manufacturers; } }

        public override void Save()
        {
            entities.SaveChanges();
        }
    }
}