using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using _21century.Models.Metadata;
using _21century.Models.Interface;

namespace _21century.Models
{
    [MetadataType(typeof(OrderStatusMetadata))]
    public partial class OrderStatus : IOrdered
    {
        public bool CanBeDeleted()
        {
            return true;
        }
    }
}