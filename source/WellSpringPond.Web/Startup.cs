using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WellSpringPond.Web.Startup))]
namespace WellSpringPond.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
