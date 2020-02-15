using Blog.Domain.Abstract;
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
        private IReviewRepository repository;
        EFDbContext db = new EFDbContext();
        public ReviewController(IReviewRepository repo)  
        {
            repository = repo;
        }

        // GET: Review
        public ActionResult ViewReiviws()
        {
            IEnumerable<Review> reviews = repository.Reviews;
            
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

                repository.SaveReview(review);
                
                ViewBag.AddStatus = true;
                return View(review);
            }
            else
            {
                return View(review);
            }

           
        }
      [HttpPost]
        public ActionResult AddReview(int ArticleId)
        {
            ViewBag.Id = ArticleId;
            return View();
        }
        [HttpPost]
        public ActionResult AddReviewRes(Review review)
        {
            
                if (ModelState.IsValid)
                {

                    repository.SaveReview(review);

                    ViewBag.AddStatus = true;
                    return View("~/Views/Review/AddReview.cshtml");
                }
                else
                {
                    return View("~/Views/Review/AddReview.cshtml",review);
                }
            
        }
    }
}