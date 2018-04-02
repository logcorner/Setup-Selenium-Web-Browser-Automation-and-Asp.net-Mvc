using LogCorner.BlogPost.Data.Model;
using LogCorner.BlogPost.Data.Repository;
using LogCorner.BlogPost.Service;
using LogCorner.BlogPost.Web.Mvc.Controllers;
using LogCorner.BlogPost.Web.Mvc.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace LogCorner.BlogPost.Web.Mvc
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());

            container.RegisterType(typeof(IRepository<>), typeof(Repository<>), new InjectionConstructor(new BlogModel()));
            container.RegisterType<IBlogService, BlogService>();
            container.RegisterType<IPostService, PostService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}