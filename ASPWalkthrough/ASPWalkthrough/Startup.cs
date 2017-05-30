using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPWalkthrough.Startup))]
namespace ASPWalkthrough
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
