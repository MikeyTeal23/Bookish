using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bookish.Website.Startup))]
namespace Bookish.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
