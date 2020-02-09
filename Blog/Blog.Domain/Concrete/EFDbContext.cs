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
    }
}
