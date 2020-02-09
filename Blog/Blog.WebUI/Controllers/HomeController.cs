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
            
            return View(repository.Articles);
        }

       
    }
}