using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using _21century.Models.Interface;

namespace _21century.Service.Interface
{
    public interface IBaseService<T> where T : class,IBase,new()
    {
        IQueryable<T> Get();

        IQueryable<T> Get(NameValueCollection filter);
        int Count();
        int Count(NameValueCollection filter);

        T Get(int id);
        IQueryable<T> Get(int skip, int take);

        IQueryable<T> Get(NameValueCollection filter, int skip, int take);
        void Add(T dataObject);
        void Delete(T dataObject);
        void Save();
    }
}