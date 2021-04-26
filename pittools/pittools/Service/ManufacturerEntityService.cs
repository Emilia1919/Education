using pittools.Models;
using pittools.Service.Abstract;
using pittools.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Service
{
    public class ManufacturerEntityService : UrlFriendlyEntityService<Manufacturer>
    {
        Entities entities = new Entities();
        protected override System.Data.Entity.DbSet<Manufacturer> EntitySet { get { return entities.Manufacturers; } }
        public override void Save()
        {
            entities.SaveChanges();
        }
    }
}