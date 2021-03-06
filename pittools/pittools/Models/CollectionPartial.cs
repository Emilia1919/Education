﻿using pittools.Models.Interface;
using pittools.Models.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pittools.Models
{
    [MetadataType(typeof(CollectionMetadata))]
    public partial class Collection : IUrlFriendly
    {
        public bool CanBeDeleted()
        {
            if (CollectionImages.Count > 0) return false;
            return true;
        }
    }
}