using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Models
{
    public class ArticleReviewViewModel
    {
        public Article article;
        public IEnumerable<Review> reviews;
        public ArticleReviewViewModel(IEnumerable<Review> reviews, Article article)
        {
            this.article = article;
            this.reviews = reviews;
        }
       
    }
}