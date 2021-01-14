using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21century.Models.Interface;

namespace _21century.Models
{
    public partial class CategoryProduct : IOrdered
    {
        public bool CanBeDeleted()
        {
            return true;
        }
    }
}