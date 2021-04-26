using pittools.Models.Interface;
using pittools.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Service.Abstract
{
    public abstract class UrlFriendlyEntityService<T> : OrderedEntityService<T>, IUrlFriendlyService<T> where T : class, IUrlFriendly, new()
    {
        public virtual T Get(string shortName)
        {
            return (from obj in EntitySet where obj.ShortName == shortName select obj).FirstOrDefault();
        }
    }
}