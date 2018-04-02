using LogCorner.BlogPost.Data.Model;
using LogCorner.BlogPost.Web.Mvc.Models;
using Owin;

namespace LogCorner.BlogPost.Web.Mvc.Mapper
{
    public static class BloggMapper
    {
        public static void MappBlog(this IAppBuilder app)
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BlogForCreationViewModel, Blog>()
                .ForMember(dt => dt.BlogId, options => options.Ignore())
                .ForMember(dt => dt.Posts, options => options.Ignore())
                .ForMember(dt => dt.Owner, options => options.Ignore())
                .ForMember(dt => dt.AspNetUser, options => options.Ignore());

                cfg.CreateMap<BlogViewModel, Blog>()
                .ForMember(dt => dt.Posts, options => options.MapFrom(x => x.PostViewModels))
                .ForMember(dt => dt.AspNetUser, options => options.Ignore());

                cfg.CreateMap<Blog, BlogViewModel>()
               .ForMember(dt => dt.PostViewModels, options => options.MapFrom(x => x.Posts))
               .ForMember(dt => dt.Owner, options => options.MapFrom(x => x.AspNetUser.Email));

                cfg.CreateMap<Blog, BlogForDetailViewModel>()
                .ForMember(dt => dt.PostViewModels, options => options.MapFrom(x => x.Posts))
                .ForMember(dt => dt.Owner, options => options.MapFrom(x => x.AspNetUser.UserName));

                cfg.CreateMap<Blog, BlogForEditViewModel>().ReverseMap();

                cfg.CreateMap<Post, PostViewModel>()
                .ForMember(dt => dt.Url, options => options.MapFrom(x => x.Blog.Url));

                cfg.CreateMap<PostForCreationViewModel, Post>()
               .ForMember(dt => dt.Blog, options => options.Ignore())
               .ForMember(dt => dt.PostId, options => options.Ignore());

                cfg.CreateMap<PostForEditViewModel, Post>()
               .ForMember(dt => dt.Blog, options => options.Ignore())
              ;
            });

            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}