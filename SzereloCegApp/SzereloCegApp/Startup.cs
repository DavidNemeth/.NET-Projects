using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SzereloCegApp.Startup))]
namespace SzereloCegApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
