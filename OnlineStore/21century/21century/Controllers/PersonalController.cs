﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _21century.Controllers
{
    [Authorize]
    public class PersonalController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}