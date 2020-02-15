using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Concrete
{
    public class EFBlogRepository : IArticleRepository , IReviewRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Article> Articles
        {
            get { return context.Articles; }
           
       
        }
        public IEnumerable<Review> Reviews { get { return context.Reviews; } }
        public void SaveArticle(Article article)
        {
            if (article.ArticleId == 0)
                context.Articles.Add(article);
            else
            {
                Article dbEntry = context.Articles.Find(article.ArticleId);
                if (dbEntry != null)
                {
                    dbEntry.Name = article.Name;
                    dbEntry.Description = article.Description;
                    dbEntry.ArticleId = article.ArticleId;
                    dbEntry.Date = article.Date;
                    
                }
            }
            context.SaveChanges();
        }
        public void SaveReview(Review review)
        {
            if (review.ReviewId== 0)
                context.Reviews.Add(review);
            else
            {
                Review dbEntry = context.Reviews.Find(review.ReviewId);
                if (dbEntry != null)
                {
                    dbEntry.Author =review.Author;
                    dbEntry.Text = review.Text;
                    
                }
            }
            context.SaveChanges();
        }
        public Article FindArticle(int artId)
        {
            var art = context.Articles.Find(artId);
            return (art);
        }
        public IEnumerable< Article> FindArticle(string category)
        {
            string[] cat = category.Split(' ');
           
            
            var art = context.Articles.Where(a => a.Categories.Contains(category));
            return (art);
        }
        public Review FindReview(int revId)
        {
            var rev = context.Reviews.Find(revId);
            return (rev);
        }
        public Article DeleteArticle(int articleId)
        {
            Article dbEntry = context.Articles.Find(articleId);
            if (dbEntry != null)
            {
                context.Articles.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public Review DeleteReview(int reviewId)
        {
            Review dbEntry = context.Reviews.Find(reviewId);
            if (dbEntry != null)
            {
                context.Reviews.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
