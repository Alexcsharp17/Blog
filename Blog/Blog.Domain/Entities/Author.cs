using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.Domain.Entities
{
   public class Author
    {     
        [HiddenInput(DisplayValue = false)]
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public Author()
        {
            this.Articles = new List<Article>();
        }
    }
}
