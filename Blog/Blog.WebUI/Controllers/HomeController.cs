using Blog.Domain.Abstract;
using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IArticleRepository repository;
        public HomeController(IArticleRepository repo)
        {
            repository = repo;
        }
        public ActionResult Index()
        {
            var articles = repository.Articles;
            foreach(var a in articles)
            {
                if (a.Description.Length > 200)
                {
                    a.Slug = a.Description.Substring(0, 200) + "...";


                }
                else
                {
                    a.Slug = a.Description;
                }
                char sep = Convert.ToChar(" ");
                string res="";
                if (a.Categories != null)
                {
                    string[] cat = a.Categories.Split(sep);
                    foreach (var c in cat)
                    {
                        string s = "#" + c.ToString()+" ";
                      
                        res += s;
                    }
                    a.Categories = res;
                }
            }
            
            return View(articles);
        }
        [HttpGet]
        public ActionResult Test()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Test2(string name)
        {
            ViewBag.Name = name;
            return PartialView();
        }

       
    }
}