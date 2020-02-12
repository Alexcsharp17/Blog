using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.Domain.Entities
{
    class Author
    {
        
        [HiddenInput(DisplayValue = false)]
        public int AuthorId { get; set; }
        public string Name { get; set; }

    }
}
