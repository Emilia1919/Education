using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using _21century.Models.Metadata;

namespace _21century.Models
{
    public class Manufacturer1
    {
        [MetadataType(typeof(ManufacturerMetadata))]
        public partial class Manufacturer
        {
        }
    }
}