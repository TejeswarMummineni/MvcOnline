using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnline.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            string[] countrynames = { "Canada", "UK", "US","India","france","Russia","china","Mexico","Nepal","Sri Lanka" };
            ViewBag.st = countrynames;

            string[] cnames = { "Canada", "UK", "US", "India", "france", "Russia", "china", "Mexico", "Nepal", "Sri Lanka" };
            ViewData["cnames"] = cnames;        
            return View();
        }
        public string hello()
        {
            return "<font color=red> <b>Hello World</b><font>";
        }
        public ViewResult AboutUs()
        {
            return View();
        }
        public ViewResult Contactus()
        {
            return View();
        }
        
    }
}