using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Abstract
{
    public interface IArticleRepository
    {
        IEnumerable<Article> Articles { get; }
        void SaveArticle(Article article);
        Article DeleteArticle(int articleId);
         Article FindArticle(int artId);
       
    }
}
