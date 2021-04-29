using pittools.Models.Interface;
using pittools.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pittools.Controllers.Abstract
{
    public abstract class OrderedController<T> : BaseController<T> where T : class, IOrdered, new()
    {
        public OrderedController(IOrderedService<T> _service) : base(_service) { }

        #region Actions

        // Перемещение объекта вверх
        [Authorize(Roles = Constants.ROLES_ADMIN_CONTENT_MANAGER)]
        public ActionResult Up(int id)
        {
            T obj = service.Get(id);

            if (obj == null) return View("NotFound");
            else
            {
                if (obj.Sequence.HasValue)
                {
                    T next = (service as IOrderedService<T>).GetNext(obj);

                    if (next != null)
                    {
                        int? curSeq = obj.Sequence;
                        int? nextSeq = next.Sequence;

                        obj.Sequence = nextSeq;
                        next.Sequence = curSeq;
                        service.Save();
                    }
                }

                return OnDown(obj);
            }
        }

        // Перемещение объекта вниз
        [Authorize(Roles = Constants.ROLES_ADMIN_CONTENT_MANAGER)]
        public ActionResult Down(int id)
        {
            T obj = service.Get(id);

            if (obj == null) return View("NotFound");
            else
            {
                if (obj.Sequence.HasValue)
                {
                    T previous = (service as IOrderedService<T>).GetPrevious(obj);

                    if (previous != null)
                    {
                        int? curSeq = obj.Sequence;
                        int? prevSeq = previous.Sequence;

                        obj.Sequence = prevSeq;
                        previous.Sequence = curSeq;
                        service.Save();
                    }
                }

                return OnUp(obj);
            }
        }

        #endregion

        #region Virtual methods

        // Перенаправление после перемещения объекта вверх
        protected virtual ActionResult OnUp(T obj)
        {
            return ReturnToList(obj);
        }

        // Перенаправление после перемещения объекта вниз
        protected virtual ActionResult OnDown(T obj)
        {
            return ReturnToList(obj);
        }

        #endregion

        #region Overridden virtual methods

        // При создании объекта автоматически задаём ему значение Sequence, равное следующему после наибольшего
        protected override void AddValuesOnCreate(T obj)
        {
            base.AddValuesOnCreate(obj);
            obj.Sequence = GetNextSequence(service.Get().Select(item => item.Sequence));
        }

        #endregion

        #region Methods

        // Получаем значение Sequence, следующее после наибольшего
        protected virtual int GetNextSequence(IQueryable<int?> seqs)
        {
            if (seqs.Count() == 0) return 1;
            else
            {
                int? iMax = seqs.Max();
                if (iMax.HasValue) return iMax.Value + 1;
                else return 1;
            }
        }
        #endregion
    }
}