using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21century.Models.Interface;
using _21century.Service.Interface;

namespace _21century.Controllers.Abstract
{
    public abstract class BaseController<T> : Controller where T : class, IBase, new()
    {
        protected IBaseService<T> service;

        public BaseController(IBaseService<T> _service)
        {
            service = _service;
        }

        #region

        public virtual ActionResult Index()
        {
            IEnumerable<T> objs = service.Get();
            return View(objs);
        }

        public virtual ActionResult Details(int id)
        {
            T obj = service.Get(id);
            if (obj == null) return View("NotFound");
            return View(obj);
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                T obj = new T();
                ChangeFormCollectionValues(obj, collection);
                UpdateModel(obj, collection);
                AddValuesOnCreate(obj);

                service.Add(obj);
                service.Save();

                return OnCreated(obj);
            }
            else return View();
        }

        public virtual ActionResult Edit(int id)
        {
            T obj = service.Get(id);
            if (obj == null) return View("NotFound");
            return View(obj);
        }

        [HttpPost]
        public virtual ActionResult Edit(int id, FormCollection collection)
        {
            T obj = service.Get(id);

            if (ModelState.IsValid)
            {
                ChangeFormCollectionValues(obj, collection);
                UpdateModel(obj, collection);
                service.Save();

                return OnEdited(obj);
            }
            else return View(obj);
        }

        public virtual ActionResult Delete(int id)
        {
            T obj = service.Get(id);
            if (obj == null) return View("NotFound");
            return View(obj);
        }

        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection collection)
        {
            T obj = service.Get(id);
            if (obj == null) return View("NotFound");

            if (!obj.CanBeDeleted()) return View("DeleteFail", obj);

            ActionResult onDeleted = OnDeleted(obj);

            OnDeleted(obj);
            service.Delete(obj);
            service.Save();
            return onDeleted;
        }
        #endregion
        #region Virtual methods

        protected virtual ActionResult ReturnToList(T obj)
        {
            return RedirectToAction("Index");
        }

        protected virtual ActionResult ReturnToObject(T obj)
        {
            return RedirectToAction("Details", new { id = obj.ID });
        }

        protected virtual ActionResult OnCreated(T obj)
        {
            return ReturnToObject(obj);
        }

        protected virtual ActionResult OnEdited(T obj)
        {
            return ReturnToObject(obj);
        }

        protected virtual ActionResult OnDeleted(T obj)
        {
            return ReturnToList(obj);
        }

        protected virtual void ChangeFormCollectionValues(T obj, FormCollection collection) { }

        protected virtual void AddValuesOnCreate(T obj) { }

        protected virtual void OnDelete(T obj) { }

        #endregion
    }
}