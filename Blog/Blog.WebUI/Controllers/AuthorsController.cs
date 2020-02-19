using Blog.Domain.Abstract;
using Blog.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class AuthorsController : Controller
    {    
        private IAuthorRepository repository;
        public AuthorsController(IAuthorRepository repo)
        {
            repository = repo;
        }
        EFDbContext db = new EFDbContext();
        public ActionResult Details(int aId)
        {  
            
            return View(repository.FindAuthor(aId));
        }
    }
}