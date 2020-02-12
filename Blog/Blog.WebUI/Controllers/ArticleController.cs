using Blog.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Blog.Domain.Concrete;
using Blog.Domain.Entities;
using Blog.WebUI.Models;

namespace Blog.WebUI.Controllers
{
    public class ArticleController : Controller
    {  
        
        
        private IArticleRepository repository;
        private IReviewRepository repository2;
        public ArticleController(IArticleRepository repo, IReviewRepository repo2 )
        {
            repository = repo;
            repository2 = repo2;
        }
        //Testing how to bind review to articles
        public ViewResult List()
        {
          
            
           
            return View();
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
            var rev = repository2.Reviews.Where(r => r.ArticleId == art.ArticleId);
            ArticleReviewViewModel model = new ArticleReviewViewModel(rev, art);

            
            return View(model);
        }

    }
}