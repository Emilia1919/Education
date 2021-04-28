using pittools.Models.Interface;
using pittools.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pittools.Models
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product : IUrlFriendly
    {
        public bool CanBeDeleted()
        {
            return true;
        }
    }
}