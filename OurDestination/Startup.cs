using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OurDestination.Startup))]
namespace OurDestination
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
