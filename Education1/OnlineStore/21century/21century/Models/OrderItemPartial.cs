using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21century.Models.Interface;

namespace _21century.Models
{
    public partial class OrderItem : IBase
    {
        public bool CanBeDeleted()
        {
            return true;
        }
    }
}