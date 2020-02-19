using Blog.Domain.Concrete;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Models
{
    public class BlogDbInitializer : DropCreateDatabaseAlways<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            Article a1 = new Article
            {
                ArticleId = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam pulvinar lectus nec purus posuere, vitae egestas nunc porta. Cras maximus congue fringilla. Duis sagittis nisl eu sapien facilisis, sodales placerat ligula tempus. Curabitur orci purus, viverra sagittis lobortis ac, feugiat non diam. In id magna a velit feugia",
                Name = "Article1",
                Date = DateTime.Now.Date
            };
            Article a2 = new Article
            {
                ArticleId = 2,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam pulvinar lectus nec purus posuere, vitae egestas nunc porta. Cras maximus congue fringilla. Duis sagittis nisl eu sapien facilisis, sodales placerat ligula tempus. Curabitur orci purus, viverra sagittis lobortis ac, feugiat non diam. In id magna a velit feugia",
                Name = "Article2",
                Date = DateTime.Now.Date
            };
            Article a3 = new Article
            {
                ArticleId = 3,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam pulvinar lectus nec purus posuere, vitae egestas nunc porta. Cras maximus congue fringilla. Duis sagittis nisl eu sapien facilisis, sodales placerat ligula tempus. Curabitur orci purus, viverra sagittis lobortis ac, feugiat non diam. In id magna a velit feugia",
                Name = "Article3",
                Date = DateTime.Now.Date
            };
            Article a4 = new Article
            {
                ArticleId = 4,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam pulvinar lectus nec purus posuere, vitae egestas nunc porta. Cras maximus congue fringilla. Duis sagittis nisl eu sapien facilisis, sodales placerat ligula tempus. Curabitur orci purus, viverra sagittis lobortis ac, feugiat non diam. In id magna a velit feugia",
                Name = "Article4",
                Date = DateTime.Now.Date
            };
            Article a5 = new Article
            {
                ArticleId = 5,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam pulvinar lectus nec purus posuere, vitae egestas nunc porta. Cras maximus congue fringilla. Duis sagittis nisl eu sapien facilisis, sodales placerat ligula tempus. Curabitur orci purus, viverra sagittis lobortis ac, feugiat non diam. In id magna a velit feugia",
                Name = "Article5",
                Date = DateTime.Now.Date
            };
            Article a6 = new Article
            {
                ArticleId = 6,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam pulvinar lectus nec purus posuere, vitae egestas nunc porta. Cras maximus congue fringilla. Duis sagittis nisl eu sapien facilisis, sodales placerat ligula tempus. Curabitur orci purus, viverra sagittis lobortis ac, feugiat non diam. In id magna a velit feugia",
                Name = "Article1", Date = DateTime.Now.Date
            };





            context.Articles.Add(a1);
            context.Articles.Add(a2);
            context.Articles.Add(a3);
            context.Articles.Add(a4);
            context.Articles.Add(a5);
            context.Articles.Add(a6);


            Tag t1 = new Tag
            {
                TagId = 1,
                Name = "Games",
                Articles = new List<Article>() { a1, a2, a3 }
            };

            Tag t2 = new Tag
            {
                TagId = 2,
                Name = "Products",
                Articles = new List<Article>() { a2, a4, a6 }
            };
            Tag t3 = new Tag
            {
                TagId = 3,
                Name = "Programming",
                Articles = new List<Article>() { a5, a2, a1 }
            };
            context.Tags.Add(t1);
            context.Tags.Add(t2);
            context.Tags.Add(t3);

            Review r1 = new Review
            {
                ReviewId = 1,
                ArticleId = 1,
                Author = "Kianu",
                Text = "You are awesome"
            };
            Review r2 = new Review
            {
                ReviewId = 2,
                ArticleId = 1,
                Author = "Baby yoda",
                Text = "You are awesome guy chubaka"
            };
            Review r3 = new Review
            {
                ReviewId = 3,
                ArticleId = 1,
                Author = "Rikardo Milas",
                Text = "II would dance listening to the melody of your words",
            };
            context.Reviews.Add(r1);
            context.Reviews.Add(r2);
            context.Reviews.Add(r3);
            base.Seed(context);
        }
    }
}