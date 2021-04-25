using pittools.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using pittools.Models.Interface;

namespace pittools.Models
{
    [MetadataType(typeof(ManufacturerMetadata))]
    public partial class Manufacturer : IBase
    {
        public bool CanBeDeleted()
        {  
            return true;
        }
    }
}