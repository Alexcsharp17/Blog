using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class AncetController : Controller
    {
        // GET: Ancet
        [HttpGet]
        public ActionResult Ancet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ancet(string q1, string q2, string[] q3, string name, string color)
        {
            if (q1 == "4" && q2 == "Donald Trump" && q3[0] == "true" && q3[2] == "true" && color.ToLower() == "yellow")
            {
                ViewBag.Res = true;
            }
            ViewBag.Name = name;
            return View("Result");
        }
        
    }
}