using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheatreMVC.Startup))]
namespace TheatreMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
