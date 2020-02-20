using Blog.Domain.Abstract;
using Blog.Domain.Concrete;
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
        EFBlogRepository db = new EFBlogRepository();
        private ITagRepository reposittag;
        private IArticleRepository repository;
        public MainController(IArticleRepository repo , ITagRepository repo2)
        {
            repository = repo;
            reposittag = repo2;
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
            var tags = db.Tags;
            List<string> tagss= new List<string>();
          
            foreach(var tag in tags)
            {
                tagss.Add(tag.Name);
            }

            ViewBag.Tag = tagss;
            return View();
        }
        public ActionResult FindAuthor(string author)
        {
           IEnumerable<Author> authors= db.FindAuthors(author);
            return View(authors);
        }

        // POST: Admin/Main/Create
        [HttpPost]
        public ActionResult Create(Article article, string[] tgs)
        {
            if (ModelState.IsValid)
            { 


                var tags = from t in db.Tags
                           where tgs.Contains(t.Name)
                           select t;
                    foreach(var tg in tags)
                {
                    article.Tags.Add(tg);
                }
                   
                article.Date = DateTime.Today;
                db.SaveArticle(article);
                ViewBag.Res = "true";
                return RedirectToAction("Index", "Main");
            }
            else
            {
                var tags = reposittag.Tags;
                List<string> tagss = new List<string>();
                foreach (var tag in tags)
                {
                    tagss.Add(tag.Name);
                }
                ViewBag.Tag = tagss;
                return View(article);
            }
        }

        // GET: Admin/Main/Edit/5
        public ActionResult Edit(int id )
        {
            Article article = db.FindArticle(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            var tags = reposittag.Tags;
            List<string> tagss = new List<string>();
            foreach (var tag in tags)
            {
                tagss.Add(tag.Name);
            }
            ViewBag.Tag = tagss;
            return View(article);
           
        }

        // POST: Admin/Main/Edit/5
        [HttpPost]
        public ActionResult Edit(Article article,string[] tgs)
        {
            if (ModelState.IsValid)
            {
                article.Date = DateTime.Now.Date;
                foreach (var t in db.Tags.Where(t => tgs.Contains(t.Name)))
                {
                    article.Tags.Add(t);
                }

                db.SaveArticle(article);
                return RedirectToAction("Index", "Main");
            }
            else
            {
                var tags = reposittag.Tags;
                List<string> tagss = new List<string>();
                foreach (var tag in tags)
                {
                    tagss.Add(tag.Name);
                }
                ViewBag.Tag = tagss;
                return View(article);
            }
        }

        // GET: Admin/Main/Delete/5
        public ActionResult Delete(int id)
        {
            db.DeleteArticle(id);
            return RedirectToAction("Index", "Main");
        }

       
        
    }
 }
