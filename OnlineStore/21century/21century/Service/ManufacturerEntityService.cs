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
        protected override System.Data.Objects.ObjectSet<Manufacturer> EntitySet { get { return entities.Manufacturers; } }
    }
}