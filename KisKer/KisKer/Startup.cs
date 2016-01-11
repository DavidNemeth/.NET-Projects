using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KisKer.Startup))]
namespace KisKer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
