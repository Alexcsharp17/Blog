using Blog.Domain.Abstract;
using Blog.Domain.Concrete;
using Blog.Domain.Entities;
using Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public int pageSize = 3;
        private IArticleRepository repository;
        public HomeController(IArticleRepository repo)
        {
            repository = repo;
        }
     
        public ActionResult Index(string category,int page=1)
        {

            IEnumerable<Article> articles  ;
            if (category == null)
            {
               articles = repository.Articles;
            }
            else
            {
               articles = repository.FindArticle(category);
            }
            foreach (var a in articles)
            {
                if (a.Description.Length > 200)
                {
                    a.Slug = a.Description.Substring(0, 200) + "...";


                }
                else
                {
                    a.Slug = a.Description;
                }
                
            }
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = articles.Count() };
            articles = articles.Skip((page - 1) * pageSize).Take(pageSize);
         
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Articles = articles };

            return View(ivm);
        }
       

       
    }
}