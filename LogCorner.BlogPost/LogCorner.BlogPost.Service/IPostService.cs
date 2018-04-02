using LogCorner.BlogPost.Data.Model;

namespace LogCorner.BlogPost.Service
{
    public interface IPostService
    {
        void Create(Post post);

        Post Get(int id);

        void Update(Post post);

        void Delete(int id);
    }
}