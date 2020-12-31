using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnline.Models;


namespace MvcOnline.Controllers
{
    public class MphasisOnlineController : Controller
    {
        MphasisOnlineEntities ob = new MphasisOnlineEntities();
        // GET: MphasisOnline
       
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Registration r)
        {
            if (ModelState.IsValid)
            {
                ob.Registrations.Add(r);
                int rows = ob.SaveChanges();
                if (rows > 0)
                {

                    ViewData["a"] = "User created Successfully!!";

                }
                else
                {
                    ViewData["a"] = "Error Occured";
                }
            }
            else
            {
                return View();
            }

            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login");
        }


        [HttpPost]
        public ActionResult Login(Registration r)
        {


            var res = (from t in ob.Registrations
                       where t.username == r.username && r.pwd == r.pwd
                       select t).Count();
            if (res > 0)
            {
                Session["user"] = r.username;
                return RedirectToAction("Product");
            }
            else
            {

                ViewData["err"] = "Access Denied!! invalid credentials";
            }

            return View();
        }

        public ActionResult Product()
        {
            var res = from t in ob.products
                      select t;

            return View(res);

        }
        public ActionResult Buy(string st)
        {
            var res = from t in ob.products
                      where t.pcode == st
                      select t;


            foreach (var item in res)
            {
                TempData["price"] = item.price;
                TempData["pcode"] = item.pcode;

            }

            TempData.Keep();

            return View(res);
        }
        [HttpPost]
        public ActionResult Buy(FormCollection f)
        {
            if (Session["user"] != null)
            {

                string pcode = TempData["pcode"].ToString();

                string price = TempData["price"].ToString();

                int totalprice = int.Parse(price) * Convert.ToInt32(f["qty"]);

                string uname = Session["user"].ToString();

                DateTime dt = DateTime.Now;

                transactioninfo t = new transactioninfo();
                t.pcode = pcode;
                t.TotalPrice = totalprice;
                t.orderdate = dt;
                t.qty = Convert.ToInt32(f["qty"]);
                t.username = uname;


                ob.transactioninfoes.Add(t);
                ob.SaveChanges();

                ViewData["status"] = "Your order placed successfully!!";

                return View();
            }
            else
            {
                ViewData["status"] = "You need to login to buy this product";
                return View();
            }
        }
        public ActionResult feedback()
        {
            return View();
        }
        public PartialViewResult productfeedback()
        {
            return PartialView();
        }
        public PartialViewResult productfeedback(feedback f)
        {
            if (Session["user"] == null)
            {
                ViewData["err"] = "pls login to give feedback";
                return PartialView();
            }

            else
            {
                f.userid = Session["user"].ToString();

                ob.feedbacks.Add(f);
                ob.SaveChanges();

                ViewData["err"] = "Thanks for Feedback";

                return PartialView();
            }
            return PartialView();
        }

    }
}