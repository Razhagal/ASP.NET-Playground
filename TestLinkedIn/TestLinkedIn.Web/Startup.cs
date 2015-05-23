using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestLinkedIn.Web.Startup))]
namespace TestLinkedIn.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
