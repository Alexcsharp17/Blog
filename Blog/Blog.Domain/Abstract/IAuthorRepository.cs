using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Abstract
{
   public interface IAuthorRepository
    {
        IEnumerable<Author> Authors { get; }
        void SaveAuthor(Author author);
        Author DeleteAuthor(int authorId);
        Author FindAuthor(int authId);
    }
}
