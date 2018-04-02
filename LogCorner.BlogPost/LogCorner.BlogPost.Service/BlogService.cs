using LogCorner.BlogPost.Data.Model;
using LogCorner.BlogPost.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogCorner.BlogPost.Service
{
    public class BlogService : IBlogService
    {
        private IRepository<Blog> _blogRepository;
        private IRepository<AspNetUser> _userRepository;

        private IRepository<Post> _postRepository;

        public BlogService(IRepository<Blog> blogRepository, IRepository<Post> postRepository, IRepository<AspNetUser> userRepository)
        {
            _blogRepository = blogRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<Blog> Get()
        {
            return _blogRepository.All().ToList();
        }

        public Blog Get(int blogId)
        {
            return _blogRepository.GetById(blogId);
        }

        public void Update(Blog blog)
        {
            var old = Get(blog.BlogId);
            if (old == null)
            {
                throw new Exception($"blog : {blog.BlogId} cannot be null");
            }

            old.Url = blog.Url;
            old.Description = blog.Description;
            _blogRepository.Update(old);
            _blogRepository.SaveChanges();
        }

        public void Delete(int blogId)
        {
            var old = _blogRepository.Get(b => b.BlogId == blogId, null, "Posts").SingleOrDefault();
            if (old == null)
            {
                throw new Exception($"blog : {blogId} cannot be null");
            }

            if (old.Posts.Any())
            {
                throw new Exception("you cannot delete a blog with, delete all posts from this blog first");
            }

            _blogRepository.Delete(blogId);
            _blogRepository.SaveChanges();
        }

        public void Create(Blog blog, string owner)
        {
            if (blog == null || owner == null)
            {
                throw new ArgumentNullException();
            }

            var user = _userRepository.Get(u => u.Email == owner).SingleOrDefault();

            if (user == null)
            {
                throw new NullReferenceException("user cannot be null");
            }
            blog.Owner = user.Id;
            _blogRepository.Create(blog);
            _blogRepository.SaveChanges();
        }
    }
}