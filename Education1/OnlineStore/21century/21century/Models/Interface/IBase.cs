using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _21century.Models.Interface
{
    public interface IBase
    {
        int ID { get; set; }
        bool CanBeDeleted();
    }
}