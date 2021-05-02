using pittools.Models;
using pittools.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Service.Factory
{
    public static class CategoryProductServiceFactory
    {
        public static IOrderedService<CategoryProduct> Create()
        {
            return new CategoryProductEntityService();
        }
    }
}