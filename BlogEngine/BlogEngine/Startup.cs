using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogEngine.Startup))]
namespace BlogEngine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
