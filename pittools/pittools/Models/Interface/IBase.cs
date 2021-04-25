using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pittools.Models.Interface
{
    public interface IBase
    {
        int ID { get; set; }
        bool CanBeDeleted();
    }
}