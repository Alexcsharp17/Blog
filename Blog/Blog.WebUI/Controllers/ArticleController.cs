using Blog.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Blog.Domain.Concrete;
using Blog.Domain.Entities;

namespace Blog.WebUI.Controllers
{
    public class ArticleController : Controller
    {  
        EFDbContext db = new EFDbContext();
        
        private IArticleRepository repository;
        public ArticleController(IArticleRepository repo )
        {
            repository = repo;
        }
        //Testing how to bind review to articles
        public ViewResult List()
        {
          
            var rev = db.Reviews.Include(r => r.Article);
           
            return View(rev);
        }
        [HttpGet]
        public ActionResult AddArticle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddArticle(Article article)
        {
            if (ModelState.IsValid)
            {
                article.Date = DateTime.Now.Date;
                repository.SaveArticle(article);
                ViewBag.AddStatus = true;
                return RedirectToAction("Index", "Home");
            }
            else{ 
            return View(article);
            }
        }
        [HttpPost]
        public ActionResult ArtDetails(int artId)
        {
            var art = repository.FindArticle(artId);
            return View(art);
        }

    }
}