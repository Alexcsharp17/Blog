using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Concrete
{
   public class EFDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasMany(a => a.Authors)
               .WithMany(au => au.Articles)
               .Map(a => a.MapLeftKey("ArtlicleId")
               .MapRightKey("AuthorId")
               .ToTable("ArticleAuthor"));

            modelBuilder.Entity<Article>().HasMany(a => a.Tags)
                .WithMany(t => t.Articles)
                .Map(t => t.MapLeftKey("ArtlicleId")
                .MapRightKey("TagId")
                .ToTable("ArticleStudent"));
           
        }
    }
}
