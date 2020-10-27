using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21century.Models.Interface;

namespace _21century.Service.Interface
{
    public interface IUrlFriendlyService<T> : IOrderedService<T> where T : class,IUrlFriendly,new()
    {
        T Get(string shortName);
    }
}