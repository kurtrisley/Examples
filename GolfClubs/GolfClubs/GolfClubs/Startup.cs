using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GolfClubs.Startup))]
namespace GolfClubs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
