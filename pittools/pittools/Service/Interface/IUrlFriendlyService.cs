using pittools.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Service.Interface
{
    public interface IUrlFriendlyService<T> : IOrderedService<T> where T : class, IUrlFriendly, new()
    {
        T Get(string shortName);
    }
}