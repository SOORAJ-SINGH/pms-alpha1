using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pms_alpha1.Startup))]
namespace pms_alpha1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
