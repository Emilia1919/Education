using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _21century.Models.Interface;

namespace _21century.Service.Interface
{
    public interface IBaseService<T> where T : class,IBase,new()
    {
        IQueryable<T> Get();
        T Get(int id);
        IQueryable<T> Get(int skip, int take);
        void Add(T dataObject);
        void Delete(T dataObject);
        void Save();
    }
}