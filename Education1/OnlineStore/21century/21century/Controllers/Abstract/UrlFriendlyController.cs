using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21century.Models.Interface;
using _21century.Service.Interface;

namespace _21century.Controllers.Abstract
{
    public abstract class UrlFriendlyController<T> : OrderedController<T> where T : class, IUrlFriendly, new()
    {
        public UrlFriendlyController(IUrlFriendlyService<T> _service) : base(_service) { }

        public ActionResult GetShortName(string shortName)
        {
            if (string.IsNullOrWhiteSpace(shortName))
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

                return View("Index", objs);
            }
            else
            {
                T obj = (service as IUrlFriendlyService<T>).Get(shortName);
                if (obj == null) return View("NotFound");
                return View("Details", obj);
            }
        }
        #region Overridden virtual methods
        protected override void ChangeFormCollectionValues(T obj, FormCollection collection)
        {
            base.ChangeFormCollectionValues(obj, collection);

            string strAffix = "1";

            if (service.Get().Count() > 0)
                strAffix = (service.Get().Select(item => item.ID).Max() + 1).ToString();

            if (string.IsNullOrWhiteSpace(collection["ShortName"]))
                collection["ShortName"] = strAffix;

            collection["ShortName"] = CreateUniqueShortName(service.Get().Select(item => new ID_ShortName() { ID = item.ID, ShortName = item.ShortName }), collection["ShortName"], obj.ID, strAffix);
        }

        #endregion

        #region Virtual methods

        protected virtual string GetShortNameSource(FormCollection collection)
        {
            return string.Empty;
        }

        #endregion

        #region Methods

        protected string Transliterate(string param)
        {
            string strResult = string.Empty;

            foreach (char ch in param)
            {
                if (Constants.TRANSLIT.Keys.Contains(ch)) strResult += Constants.TRANSLIT[ch];
            }

            if (String.IsNullOrWhiteSpace(strResult)) strResult += "_";

            return strResult;
        }

        protected string CreateUniqueShortName(IQueryable<ID_ShortName> shortNames, string currentShortName, int currentID, string affix)
        {
            string strResult = currentShortName.ToLower();

            int iCount = (from item in shortNames where item.ShortName == currentShortName && item.ID != currentID select item).Count();
            if (iCount > 0) strResult = string.Format("{0}{1}", currentShortName, affix);
            if (Constants.RESERVED_WORDS.Contains(currentShortName.ToLower())) strResult = string.Format("{0}{1}", currentShortName, affix);

            return strResult;
        }

        #endregion

        #region Inner classes

        protected class ID_ShortName
        {
            public int ID;
            public string ShortName;
        }

        #endregion
    }
}