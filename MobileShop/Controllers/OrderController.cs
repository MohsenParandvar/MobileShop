using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using MobileShop.Models;
using WebMatrix.WebData;

namespace MobileShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        public ActionResult Checkout()
        {
            Order order = db.Orders.FirstOrDefault(o => o.UserProfileId == WebSecurity.CurrentUserId && o.Status == "in_process");
            if (order == null)
                return View(order);
            List<OrderItem> orderItems = order.Items;
            return View(orderItems);
        }

        /// <summary>
        /// change order status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        // [HttpPost, ActionName("ChangeStatus")]
        // public ActionResult ChangeStatus(int status)
        // {
        //     Order order = db.Orders.FirstOrDefault(o => o.UserProfileId == WebSecurity.CurrentUserId);
        //     if (order != null)
        //     {
        //         db.Entry(order).State = EntityState.Modified;
        //         // order.Status = status;
        //         db.SaveChanges();
        //     }
        //
        //     return RedirectToAction("Index", "Home");
        // }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Order/Create

        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        //
        // GET: /Order/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /Order/Edit/5

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        //
        // GET: /Order/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /Order/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// POST: /Order/AddOrderItem
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult AddOrderItem(int productId)
        {
            Order order = db.Orders.FirstOrDefault(o => o.UserProfileId == WebSecurity.CurrentUserId);
            OrderItem orderItem = new OrderItem();
            orderItem.ProductId = productId;
            if (order == null)
            {
                Order newOrder = new Order();
                newOrder.UserProfileId = WebSecurity.CurrentUserId;
                newOrder.Status = "in_process";
                newOrder.CreatedAt = DateTime.Now;

                // Add Order Items
                orderItem.Order = newOrder;
                newOrder.Items = new List<OrderItem>();
                newOrder.Items.Add(orderItem);
                db.Orders.Add(newOrder);
                db.SaveChanges();
            }
            
            // Order is exists and we must add items to order
            orderItem.Order = order;
            db.OrderItems.Add(orderItem);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}