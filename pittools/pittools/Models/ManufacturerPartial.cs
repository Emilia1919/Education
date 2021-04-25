using pittools.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pittools.Models
{
    [MetadataType(typeof(ManufacturerMetadata))]
    public partial class ManufacturerPartial
    {
    }
}