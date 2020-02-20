using Blog.Domain.Abstract;
using Blog.Domain.Concrete;
using Blog.Domain.Entities;
using Blog.WebUI.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;

namespace Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public int pageSize = 3;
        private IArticleRepository repository;
        public HomeController(IArticleRepository repo )
        {
            repository = repo;
        }

        public ActionResult Index(int? page, int tag = 0)
        {
            int pageNumber = (page ?? 1);

            IEnumerable<Article> articles;
            if (tag == 0)
            {
                articles = repository.Articles.ToList();
            }
            else
            {
                Tag tagg = new Tag { TagId = tag };
               // articles = repository.Articles.ToList();
               articles = repository.Articles.ToList().Where(a => a.Tags.FirstOrDefault(t=>t.TagId==tag)!=null).ToList();
            }
            
            PageInfo pageInfo = new PageInfo { PageNumber = pageNumber, PageSize = pageSize, TotalItems = articles.Count() };
            articles = articles.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Articles = articles };

            return View(ivm);
        }

        public ActionResult Details(int id=1)
        {
            Article article = repository.FindArticle(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }
       

       
    }
}