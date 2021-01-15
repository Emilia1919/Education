using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21century.Models;
using _21century.Service.Interface;

namespace _21century.Service.Factory
{
    public static class ProductServiceFactory
    {
        public static IUrlFriendlyService<Product> Create()
        {
            return new ProductEntityService();
        }
    }
}