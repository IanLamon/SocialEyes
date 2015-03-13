using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialEyes.WebUI.Startup))]
namespace SocialEyes.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
