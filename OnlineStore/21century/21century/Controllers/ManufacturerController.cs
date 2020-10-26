using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21century.Models;
using _21century.Service.Interface;
using _21century.Service.Factory;
using _21century.Controllers.Abstract;

namespace _21century.Controllers
{
    public class ManufacturerController : OrderedController<Manufacturer>
    {
        public ManufacturerController(IOrderedService<Manufacturer> _service) : base(_service) { }

        public ManufacturerController() : this(ManufacturerServiceFactory.Create()) { }
    }
    /*OnlineStoreEntities entities = new OnlineStoreEntities();

    public ActionResult Index()
    {
        var objs = service.Get();
        return View(objs);
    }

    public ActionResult Details(int id)
    {
        Manufacturer obj = service.Get(id);
        if (obj == null) return View("NotFound");
        return View(obj);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
        if (ModelState.IsValid)
        {
            Manufacturer obj = new Manufacturer();
            UpdateModel(obj, collection);
            service.Add(obj);
            service.Save();
            return RedirectToAction("Details", new { id = obj.ID });
        }
        else return View();
    }

    public ActionResult Edit(int id)
    {
        Manufacturer obj = service.Get(id);
        if (obj == null) return View("NotFound");
        return View(obj);
    }

    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection)
    {
        Manufacturer obj = service.Get(id);
        if (obj == null) return View("NotFound");

        if (ModelState.IsValid)
        {
            UpdateModel(obj, collection);
            service.Save();
            return RedirectToAction("Details", new { id = obj.ID });
        }
        else return View(obj);
    }

    public ActionResult Delete(int id)
    {
        Manufacturer obj = service.Get(id);
        if (obj == null) return View("NotFound");
        return View(obj);
    }

    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection)
    {
        Manufacturer obj = service.Get(id);
        if (obj == null) return View("NotFound");
        service.Delete(obj);
        service.Save();
        return RedirectToAction("Index");
    }*/
}