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
    public class EFBlogRepository : IArticleRepository , IReviewRepository, IAuthorRepository,ITagRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Article> Articles
        {
            get { return context.Articles; }
           
       
        }
        public IEnumerable<Review> Reviews { get { return context.Reviews; } }

        public IEnumerable<Author> Authors { get { return context.Authors; } }
        public IEnumerable<Tag> Tags { get { return context.Tags; } }
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
        public void SaveAuthor(Author author)
        {
            if (author.AuthorId == 0)
                context.Authors.Add(author);
            else
            {
                Author dbEntry = context.Authors.Find(author.AuthorId);
                if (dbEntry != null)
                {
                    dbEntry.Name = author.Name;
                    dbEntry.AuthorId = author.AuthorId;

                }
            }
            context.SaveChanges();
        }
        public void SaveTag(Tag tag)
        {
            if (tag.TagId== 0)
                context.Tags.Add(tag);
            else
            {
                Tag dbEntry = context.Tags.Find(tag.TagId);
                if (dbEntry != null)
                {
                    dbEntry.Name = tag.Name;
                    dbEntry.TagId = tag.TagId;

                }
            }
            context.SaveChanges();
        }
        public Article FindArticle(int artId)
        {
            var art = context.Articles.Find(artId);
            return (art);
        }
       
        public Review FindReview(int revId)
        {
            var rev = context.Reviews.Find(revId);
            return (rev);
        }
        public Author FindAuthor(int authId)
        {
            var auth = context.Authors.Find(authId);
            return (auth);
        }
        public Tag FindTag(int TagId)
        {
            var tag = context.Tags.Find(TagId);
            return (tag);
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
        public Author DeleteAuthor(int authId)
        {
            Author dbEntry = context.Authors.Find(authId);
            if (dbEntry != null)
            {
                context.Authors.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public Tag DeleteTag(int TagId)
        {
            Tag dbEntry = context.Tags.Find(TagId);
            if (dbEntry != null)
            {
                context.Tags.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
