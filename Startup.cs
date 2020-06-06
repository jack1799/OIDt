using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OIDt.Startup))]
namespace OIDt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
