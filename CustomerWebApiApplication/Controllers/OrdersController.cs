using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerWebApiApplication.Models;
using CustomerWebApiApplication.Utility;

namespace CustomerWebApiApplication.Controllers
{
    public class OrdersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult List()
        {
            return Json(db.Orders.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }

            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            return Json(order, JsonRequestBehavior.AllowGet);
        }
        // /Order/Create [POST]
        public ActionResult Create([System.Web.Http.FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "Model State is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.Orders.Add(order);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Order was created."));
        }

        // Order/Change [POST]
        public ActionResult Change([System.Web.Http.FromBody] Order order)
        {
            Order order2 = db.Orders.Find(order.Id);
            order2.Description = order.Description;
            order2.Total = order.Total;
            order2.Fulfilled = order.Fulfilled;
            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Order was changed."));
        }

        // order/Remove [POST]
        public ActionResult Remove([System.Web.Http.FromBody] Order order)
        {
            Order order2 = db.Orders.Find(order.Id);
            db.Orders.Remove(order2);
            try
            {
                db.SaveChanges();

            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Order was deleted."));
        }
    }

}