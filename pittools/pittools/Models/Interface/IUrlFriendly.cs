using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pittools.Models.Interface
{
    public interface IUrlFriendly : IOrdered
    {
        string ShortName { get; set; }
    }
}