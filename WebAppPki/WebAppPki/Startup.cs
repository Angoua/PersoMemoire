using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppPki.Startup))]
namespace WebAppPki
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
