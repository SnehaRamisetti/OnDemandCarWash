using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FrontendMVC.Startup))]
namespace FrontendMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
