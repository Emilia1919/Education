using pittools.Models;
using pittools.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Service
{
    public class CategoryEntityService : UrlFriendlyEntityService<Category>
    {
        Entities entities = new Entities();

        protected override System.Data.Entity.DbSet<Category> EntitySet { get { return entities.Categories; } }

        public override void Save()
        {
            entities.SaveChanges();
        }
    }
}