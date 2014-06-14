using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AgileTaskKeeper.Startup))]
namespace AgileTaskKeeper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
