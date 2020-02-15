using Blog.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class VoteController : Controller
    {
        private IArticleRepository repository;
        public VoteController(IArticleRepository repo)
        {
            repository = repo;
        }
        [HttpGet]
        public ActionResult VotingRes()
        {


            return PartialView();
        }

        [HttpPost]
        public ActionResult VotingResShow(string answ ,string ArticleId="1")
        {
            
            var art = repository.FindArticle(Convert.ToInt32(ArticleId));
            var res="";
            if (answ == "yes")
            {
                 res = "We are very pleased!";
                art.Yes++;
               
            }
            else if (answ == "no")
            {
                 res = "It's sad. We'll work harder.";
                art.No++;
            }
            else
            {
                res = "Tell us how to improve blog in comments.";
                art.So_so++;
            }
            repository.SaveArticle(art);
            
            ViewBag.Res = res;
            ViewBag.Yes = art.Yes;
            ViewBag.No = art.No;
            ViewBag.So_so = art.So_so;

            return PartialView();
        }
    }
}