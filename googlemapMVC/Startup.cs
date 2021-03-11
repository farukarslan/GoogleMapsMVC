using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(googlemapMVC.Startup))]
namespace googlemapMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
