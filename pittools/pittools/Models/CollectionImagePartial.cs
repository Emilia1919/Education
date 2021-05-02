using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using pittools.Models.Metadata;
using pittools.Models.Interface;

namespace pittools.Models
{
    public partial class CollectionImage : IOrdered
    {
        public bool CanBeDeleted()
        {
            return true;
        }
    }
}