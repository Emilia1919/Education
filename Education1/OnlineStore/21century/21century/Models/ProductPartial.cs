using _21century.Models.Interface;
using _21century.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _21century.Models
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