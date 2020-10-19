using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21century.Models;

namespace _21century.Controllers
{
    public class ManufacturerController : Controller
    {
        OnlineStoreEntities entities = new OnlineStoreEntities();

        // Отображает список всех объектов
        public ActionResult Index()
        {
            var objs = entities.Manufacturers;
            return View(objs);
        }

        // Отображает карточку объекта, имеющего ID, задаваемый в параметре id
        public ActionResult Details(int id)
        {
            Manufacturer obj = (from item in entities.Manufacturers where item.ID == id select item).FirstOrDefault();
            if (obj == null) return View("NotFound");
            return View(obj);
        }

        // Открывает форму создания объекта
        public ActionResult Create()
        {
            return View();
        }

        // Обрабатывает данные, полученные из формы создания объекта
        // Это действие может может запускаться только для обработки данных, полученных по протоколу Http Post (на что указывает фильтр)
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                Manufacturer obj = new Manufacturer();
                UpdateModel(obj, collection);
                entities.Manufacturers.Add(obj);
                entities.SaveChanges();
                return RedirectToAction("Details", new { id = obj.ID });
            }
            else return View();
        }

        // Открывает форму редактирования объекта, имеющего ID, задаваемый в параметре id
        public ActionResult Edit(int id)
        {
            Manufacturer obj = (from item in entities.Manufacturers where item.ID == id select item).FirstOrDefault();
            if (obj == null) return View("NotFound");
            return View(obj);
        }

        // Обрабатывает данные, полученные из формы редактирования объекта
        // Запускается только при получении данных по Http Post
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Manufacturer obj = (from item in entities.Manufacturers where item.ID == id select item).FirstOrDefault();
            if (obj == null) return View("NotFound");

            if (ModelState.IsValid)
            {
                UpdateModel(obj, collection);
                entities.SaveChanges();
                return RedirectToAction("Details", new { id = obj.ID });
            }
            else return View(obj);
        }

        // Открывает форму для удаления объекта, имеющего ID, задаваемый в параметре id
        public ActionResult Delete(int id)
        {
            Manufacturer obj = (from item in entities.Manufacturers where item.ID == id select item).FirstOrDefault();
            if (obj == null) return View("NotFound");
            return View(obj);
        }

        // Обрабатывает данные, полученные из формы удаления объекта
        // Запускается только при получении данных по http Post
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Manufacturer obj = (from item in entities.Manufacturers where item.ID == id select item).FirstOrDefault();
            if (obj == null) return View("NotFound");
            entities.Manufacturers.Remove(obj);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}