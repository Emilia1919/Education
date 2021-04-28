using pittools.Models.Interface;
using pittools.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pittools.Controllers.Abstract
{
    public abstract class BaseController<T> : Controller where T : class, IBase, new()
    {
        // Объект для для работы с данными
        protected IBaseService<T> service;

        // Свойство, определяющее, работает ли в списке объектов постраничный вывод
        // Если постраничный вывод нужен, то в классе-потомке этому свойству устанавливается значение TRUE
        protected virtual bool IsPageable { get { return false; } }

        // Параметризованный конструктор
        public BaseController(IBaseService<T> _service)
        {
            service = _service;
        }

        #region Actions

        // Получение списка объектов
        public virtual ActionResult Index()
        {
            IEnumerable<T> objs = null;

            if (IsPageable)
            {
                int page = 1;
                if (Request.QueryString["page"] != null) page = int.Parse(Request.QueryString["page"]);
                if (page < 1) page = 1;

                objs = service.Get((page - 1) * Constants.PAGER_LINKS_PER_PAGE, Constants.PAGER_LINKS_PER_PAGE);
            }
            else objs = service.Get();

            return View(objs);
        }

        // Получение объекта по его ID
        public virtual ActionResult Details(int id)
        {
            T obj = service.Get(id);
            if (obj == null) return View("NotFound");
            return View(obj);
        }

        // Открытие формы создания объекта
        public virtual ActionResult Create()
        {
            return View();
        }

        // Обработка формы создания объекта
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

        // Открытие формы редактирование объекта
        public virtual ActionResult Edit(int id)
        {
            T obj = service.Get(id);
            if (obj == null) return View("NotFound");
            return View(obj);
        }

        // Обработка формы редактирования объекта
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

        // Открытие страницы с подтверждением удаления объекта
        public virtual ActionResult Delete(int id)
        {
            T obj = service.Get(id);
            if (obj == null) return View("NotFound");
            return View(obj);
        }

        // Удаление объекта после подтверждения
        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection collection)
        {
            T obj = service.Get(id);
            if (obj == null) return View("NotFound");

            if (!obj.CanBeDeleted()) return View("DeleteFail", obj);

            ActionResult onDeleted = OnDeleted(obj);

            OnDelete(obj);
            service.Delete(obj);
            service.Save();
            return onDeleted;
        }

        #endregion

        #region Virtual methods

        // Перенаправление к странице списка объектов
        protected virtual ActionResult ReturnToList(T obj)
        {
            return RedirectToAction("Index", new { page = Request.QueryString["page"] });
        }

        // Перенаправление к странице объекта
        protected virtual ActionResult ReturnToObject(T obj)
        {
            return RedirectToAction("Details", new { id = obj.ID, page = Request.QueryString["page"] });
        }

        // Перенаправление после создания объекта
        protected virtual ActionResult OnCreated(T obj)
        {
            return ReturnToObject(obj);
        }

        // Перенаправление после редактирования объекта
        protected virtual ActionResult OnEdited(T obj)
        {
            return ReturnToObject(obj);
        }

        // Перенаправление после удаления объекта
        protected virtual ActionResult OnDeleted(T obj)
        {
            return ReturnToList(obj);
        }

        // Изменение значений, полученных с формы создания/редактирования
        protected virtual void ChangeFormCollectionValues(T obj, FormCollection collection) { }

        // Автоматическое добавление свойств объекта, не получаемых с формы создания объекта
        protected virtual void AddValuesOnCreate(T obj) { }

        // Действия при удалении объекта
        protected virtual void OnDelete(T obj) { }

        #endregion
    }
}