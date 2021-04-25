using pittools.Models;
using pittools.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Service
{
    public class ManufacturerEntityService : IBaseService<Manufacturer>
    {
        Entities entities = new Entities();

        public IQueryable<Manufacturer> Get()
        {
            return from obj in entities.Manufacturers select obj;
        }

        public Manufacturer Get(int id)
        {
            return (from obj in entities.Manufacturers where obj.ID == id select obj).FirstOrDefault();
        }

        public IQueryable<Manufacturer> Get(int skip, int take)
        {
            return Get().Skip(skip).Take(take);
        }

        public void Add(Manufacturer dataObject)
        {
            entities.Manufacturers.Add(dataObject);
        }

        public void Delete(Manufacturer dataObject)
        {
            entities.Manufacturers.Remove(dataObject);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}