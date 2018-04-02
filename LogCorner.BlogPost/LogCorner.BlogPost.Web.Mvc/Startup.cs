using LogCorner.BlogPost.Web.Mvc;
using LogCorner.BlogPost.Web.Mvc.Mapper;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace LogCorner.BlogPost.Web.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MappBlog();
        }
    }
}