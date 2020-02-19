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
        [HiddenInput(DisplayValue = false)]
        public virtual string Slug { get; set; }

        public IEnumerable<Review> Reviews { get; set; }
        public Article()
        {
            Reviews = new List<Review>();
            Tags = new List<Tag>();

        }

        
        
       
        [HiddenInput(DisplayValue = false)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        //Properties for feedback form
        public int Yes { get; set; }
        public int No { get; set; }

        public int So_so { get; set; }
        //navigation prop
        public virtual ICollection<Tag> Tags { get; set; }
       


    }
}
