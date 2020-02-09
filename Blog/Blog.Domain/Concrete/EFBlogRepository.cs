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
    public class EFBlogRepository : IArticleRepository 
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Article> Articles
        {
            get { return context.Articles; }
           
       
        }
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
        public IEnumerable<Review> Reviews
        {
            get { return context.Reviews; }
        }
    }
}
