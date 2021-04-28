using pittools.Models;
using pittools.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Service.Factory
{
    public static class ProductServiceFactory
    {
        public static IUrlFriendlyService<Product> Create()
        {
            return new ProductEntityService();
        }
    }
}