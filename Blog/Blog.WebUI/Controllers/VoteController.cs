using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class VoteController : Controller
    {
        [HttpGet]
        public ActionResult VotingRes()
        {


            return PartialView();
        }

        [HttpPost]
        public ActionResult VotingResShow(string answ )
        {
            var res="";
            if (answ == "yes")
            {
                 res = "We are very pleased!";
            }
            else if (answ == "no")
            {
                 res = "It's sad. We'll work harder.";
            }
            else
            {
                res = "Tell us how to improve blog in comments.";
            }
            ViewBag.Res = res;
            
            return PartialView();
        }
    }
}