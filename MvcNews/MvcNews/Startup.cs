using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcNews.Startup))]
namespace MvcNews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
