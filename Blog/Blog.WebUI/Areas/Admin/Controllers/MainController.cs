using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        private IArticleRepository repository;
        public MainController(IArticleRepository repo)
        {
            repository = repo;
        }
        public ActionResult Index()
        {
            return View(repository.Articles);
        }

        // GET: Admin/Main/Details/5
        public ActionResult Details(int id)
        {
           
            return View(repository.FindArticle(id));
        }

        // GET: Admin/Main/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Admin/Main/Create
        [HttpPost]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                article.Date = DateTime.Today;
                repository.SaveArticle(article);
                ViewBag.Res = "true";
                return View();
            }
            
            else return View(article);
        }

        // GET: Admin/Main/Edit/5
        public ActionResult Edit(int id)
        {
           
            return View(repository.FindArticle(id));
        }

        // POST: Admin/Main/Edit/5
        [HttpPost]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid) {
                repository.SaveArticle(article);
                    return View();
            }
            return View(article);
        }

        // GET: Admin/Main/Delete/5
        public ActionResult Delete(int id)
        {
            repository.DeleteArticle(id);
            return View();
        }

       
        
    }
 }
