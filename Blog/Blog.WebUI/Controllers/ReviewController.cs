using Blog.Domain.Concrete;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class ReviewController : Controller
    {
        EFDbContext db = new EFDbContext();
        // GET: Review
        public ActionResult ViewReiviws()
        {
            IEnumerable<Review> reviews = db.Reviews;
            
            return View(reviews);
        }
        [HttpGet]
        public ActionResult Reviws(int ArticleId)
        {
            Review review = new Review();
            review.ArticleId = ArticleId;
            return View(review);
        }
        [HttpPost]
        public ActionResult Reviws(Review review)
        {
            if (ModelState.IsValid)
            {
                
                db.Reviews.Add(review);
                db.SaveChanges();
                ViewBag.AddStatus = true;
                return View(review);
            }
            else
            {
                return View(review);
            }

           
        }
    }
}