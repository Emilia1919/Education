using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pittools.Models.Interface;
using pittools.Models.Metadata;

namespace pittools.Models
{
    [MetadataType(typeof(ManufacturerMetadata))]
    public partial class Manufacturer : IUrlFriendly
    {
        public bool CanBeDeleted()
        {
            if (Products.Count > 0) return false;
            return true;
        }
        //public int? Sequence { get; set; } 
    }
}