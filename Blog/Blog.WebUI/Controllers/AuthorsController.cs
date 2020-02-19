using Blog.Domain.Abstract;
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

        public ActionResult List()
        {
            
            return View(repository.Authors);
        }
    }
}