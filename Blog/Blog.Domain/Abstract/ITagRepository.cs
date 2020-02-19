using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Abstract
{
   public interface ITagRepository
    {
        IEnumerable<Tag> Tags { get; }
        void SaveTag(Tag tag);
        Tag DeleteTag(int tagId);
        Tag FindTag(int TagId);
    }
}
