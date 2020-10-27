using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21century.Service.Interface;
using _21century.Models.Interface;

namespace _21century.Service.Abstract
{
    public abstract class UrlFriendlyEntityService<T> : OrderedEntityService<T>, IUrlFriendlyService<T> where T : class,IUrlFriendly,new()
    {
        public virtual T Get(string shortName)
        {
            return (from obj in EntitySet where obj.ShortName == shortName select obj).FirstOrDefault();
        }
    }
}