using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MMH.App.Startup))]
namespace MMH.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
