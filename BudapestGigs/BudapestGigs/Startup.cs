using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BudapestGigs.Startup))]
namespace BudapestGigs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
