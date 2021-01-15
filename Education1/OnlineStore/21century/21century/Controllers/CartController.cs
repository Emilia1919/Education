using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _21century.Models;
using _21century.Service.Interface;
using _21century.Service.Factory;

namespace _21century.Controllers
{
    public class CartController : Controller
    {
        // Открытие страницы корзины
        public ActionResult Index()
        {
            return View(Session[Constants.SESSION_CART] as Dictionary<int, int>);
        }

        // Добавление товара в корзину
        public ActionResult Add(int id)
        {
            Dictionary<int, int> cart = Session[Constants.SESSION_CART] as Dictionary<int, int>;
            if (cart == null) cart = new Dictionary<int, int>();

            if (cart.ContainsKey(id)) cart[id] = cart[id] + 1;
            else cart[id] = 1;

            Session[Constants.SESSION_CART] = cart;

            return RedirectToAction("Index");
        }

        // Изменение количества товара
        public ActionResult ChangeValue(int id, string number)
        {
            int iNumber = 0;

            if (int.TryParse(number, out iNumber) && iNumber > 0)
            {
                Dictionary<int, int> cart = Session[Constants.SESSION_CART] as Dictionary<int, int>;
                if (cart != null && cart.ContainsKey(id)) cart[id] = iNumber;
                Session[Constants.SESSION_CART] = cart;
            }

            return RedirectToAction("Index");
        }

        // Удаление товара из корзины
        public ActionResult Delete(int id)
        {
            Dictionary<int, int> cart = Session[Constants.SESSION_CART] as Dictionary<int, int>;
            if (cart != null && cart.ContainsKey(id)) cart.Remove(id);
            Session[Constants.SESSION_CART] = cart;

            return RedirectToAction("Index");
        }
    }
}