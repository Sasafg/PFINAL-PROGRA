using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PFINAL_PROGRA.Startup))]
namespace PFINAL_PROGRA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
