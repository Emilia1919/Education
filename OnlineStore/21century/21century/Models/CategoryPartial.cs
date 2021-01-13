using _21century.Models.Metadata;
using _21century.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace _21century.Models
{
    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category : IUrlFriendly
    {
        public bool CanBeDeleted()
        {
            return true;
        }
    }
}