using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Abstract
{
   public interface IReviewRepository
    {
        IEnumerable<Review> Reviews { get; }
        void SaveReview(Review review);
        Review DeleteReview(int reviewId);
        Review FindReview(int rewId);

    }
}
