using LogCorner.BlogPost.Data.Model;
using LogCorner.BlogPost.Data.Repository;
using System;

namespace LogCorner.BlogPost.Service
{
    public class PostService : IPostService
    {
        private IRepository<Post> _postRepository;

        public PostService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public void Create(Post post)
        {
            if (post == null)
            {
                throw (new ArgumentNullException());
            }
            _postRepository.Create(post);
            _postRepository.SaveChanges();
        }

        public Post Get(int id)
        {
            return _postRepository.GetById(id);
        }

        public void Update(Post post)
        {
            if (post == null)
            {
                throw (new ArgumentNullException());
            }

            var old = Get(post.PostId);
            if (old == null)
            {
                throw new Exception($"blog : {post.PostId} not found");
            }

            old.Title = post.Title;
            old.Content = post.Content;
            _postRepository.Update(old);
            _postRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var old = Get(id);
            if (old == null)
            {
                throw new Exception($"post : {id} not found");
            }

            _postRepository.Delete(id);
            _postRepository.SaveChanges();
        }
    }
}