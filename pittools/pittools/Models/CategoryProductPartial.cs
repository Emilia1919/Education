using pittools.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Models
{
    public partial class CategoryProduct : IOrdered
    {
        public bool CanBeDeleted()
        {
            return true;
        }
    }
}