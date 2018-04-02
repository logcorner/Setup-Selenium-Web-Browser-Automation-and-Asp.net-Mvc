using LogCorner.BlogPost.Data.Model;
using System.Collections.Generic;

namespace LogCorner.BlogPost.Service
{
    public interface IBlogService
    {
        void Create(Blog blog, string owner);

        void Delete(int blogId);

        IEnumerable<Blog> Get();

        Blog Get(int blogId);

        void Update(Blog blog);
    }
}