using pittools.Models;
using pittools.Service.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace pittools.Service.Factory
{
    public static class CollectionServiceFactory
    {
        public static IUrlFriendlyService<Collection> Create()
        {
            return new CollectionEntityService();
        }
    }
}