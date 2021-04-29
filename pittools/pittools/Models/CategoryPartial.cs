using pittools.Models.Interface;
using pittools.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pittools.Models
{
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category : IUrlFriendly
    {
        public bool CanBeDeleted()
        {
            if (Collections.Count > 0) return false;
            return true;
        }
    }
}