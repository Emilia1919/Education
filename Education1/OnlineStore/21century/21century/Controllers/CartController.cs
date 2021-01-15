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

        // Сохранение заказа
        public ActionResult Save()
        {
            UserProfile profile = new UserProfile(User.Identity.Name);
            Dictionary<int, int> cart = Session[Constants.SESSION_CART] as Dictionary<int, int>;

            if (cart != null)
            {
                Order order = new Order();
                order.Date = DateTime.Now;
                order.FirstName = profile.FirstName;
                order.MiddleName = profile.MiddleName;
                order.LastName = profile.LastName;
                order.Phone = profile.Phone;
                order.Address = profile.Address;

                order.OrderStatus = string.Empty;
                int iOrderStatusesNumber = OrderStatusServiceFactory.Create().Get().Count();
                if (iOrderStatusesNumber > 0) order.OrderStatus = OrderStatusServiceFactory.Create().Get().OrderByDescending(item => item.Sequence).First().Name;

                IBaseService<Order> orderService = OrderServiceFactory.Create();
                orderService.Add(order);
                orderService.Save();

                List<OrderItem> orderItems = new List<OrderItem>();
                IUrlFriendlyService<Product> productService = ProductServiceFactory.Create();

                foreach (int key in cart.Keys)
                {
                    Product product = productService.Get(key);

                    OrderItem orderItem = new OrderItem();
                    orderItem.OrderID = order.ID;
                    orderItem.ProductID = key;
                    orderItem.Name = product.Name;
                    orderItem.Manufacturer = product.Manufacturer.Name;
                    orderItem.Number = cart[key];
                    orderItem.Price = product.Price;
                    orderItems.Add(orderItem);
                }

                IBaseService<OrderItem> orderItemService = OrderItemServiceFactory.Create();

                foreach (OrderItem orderItem in orderItems)
                {
                    orderItemService.Add(orderItem);
                }

                orderItemService.Save();

                Session.Remove(Constants.SESSION_CART);
            }

            return View("ThankYou");
        }
    }
}