using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.Domain.Entities
{
   public class Article
    {
        [HiddenInput(DisplayValue = false)]
        public int ArticleId { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please input article title")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Text")]
        [Required(ErrorMessage = "Please input article description")]
        public string Description { get; set; }
       
        
        public IEnumerable<Review> Reviews { get; set; }
        public Article()
        {
            Reviews = new List<Review>();
        }
        [HiddenInput(DisplayValue = false)]
        public DateTime Date { get; set; }
        
    }
}
