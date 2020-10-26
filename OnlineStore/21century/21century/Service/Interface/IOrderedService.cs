using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21century.Models.Interface;

namespace _21century.Service.Interface
{
    public interface IOrderedService<T> : IBaseService<T> where T : class,IOrdered,new()
    {
        T GetPrevious(T dataObject);
        T GetNext(T dataObject);
    }
}