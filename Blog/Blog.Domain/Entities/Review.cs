using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.Domain.Entities
{
   public class Review
    {
        [HiddenInput(DisplayValue = false)]
        public int ReviewId { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please input author name")]
        public string Author { get; set; }
        [Display(Name = "Text")]
        [Required(ErrorMessage = "Please leave your comment")]
        public string Text { get; set; }
        [HiddenInput(DisplayValue = false)]
        public Article Article { get; set; }
        
        public int ArticleId { get; set; }
        
    }
}
