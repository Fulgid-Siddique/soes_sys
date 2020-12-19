using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SOES.WebUI.Startup))]
namespace SOES.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
