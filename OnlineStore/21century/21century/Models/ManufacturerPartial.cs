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
    [MetadataType(typeof(ManufacturerMetadata))]
    public partial class Manufacturer : IUrlFriendly
    {
        public bool CanBeDeleted()
        {
            if (Products.Count > 0) return false;
            return true;
        }
    }
}