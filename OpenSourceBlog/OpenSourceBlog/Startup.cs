using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OpenSourceBlog.Startup))]
namespace OpenSourceBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
