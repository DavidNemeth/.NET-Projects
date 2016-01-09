using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HospitalApp.Startup))]
namespace HospitalApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
