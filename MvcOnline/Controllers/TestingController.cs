using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnline.Controllers
{
    public class TestingController : Controller
    {
        // GET: Testing
        public ActionResult Index()
        {
            string[] names = { "ajay", "sachin", "Dhoni", "Virat", "Raina" };
            ViewBag.st = names;

           
            ViewData["names"] = names;
            return View();
        }
        public ActionResult Printname()
        {
            string name = "Virat";
            ViewData["name"] =name;
            ViewBag.name=name;
            return View();
        }
        public ActionResult ShowSum()
        {
            int[] data = { 3, 45, 43, 3, 23 };
            ViewBag.num = data;
            ViewData["num"] = data;
            return View();
        }

        public ActionResult printvalue()
        {
            return View();
        }
        [HttpPost]
        public ActionResult printvalue(string user)
        {
            ViewData["c"] = user;
            return View();
        }
        public ActionResult printsquare()
        {
            return View();
        }
        [HttpPost]
        public ActionResult printsquare(int num)
        {
            
            return View();
        }
        public ActionResult AcceptNprint()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AcceptNprint(int num)
        {
            for (int i = 0; i < num; i++)
            {
                ViewData["Result"] = num;
            }
            return View();
        }
        public ActionResult FindGreatest()
        {
            
            return View();
        }
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Login(string uname, string pwd)
        {
            if (uname == "admin" && pwd == "india")
            {
                ViewData["Result"] = "Valid user";
            }

            else
            {

                ViewData["Result"] = "Invalid user";
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection f)
        {
            ViewBag.a = f["empid"];
            ViewBag.b = f["empname"];
            ViewBag.c = f["dob"];
            ViewBag.d = f["gender"];
            ViewBag.e = f["Nationality"];
            return View();
        }
    }
}