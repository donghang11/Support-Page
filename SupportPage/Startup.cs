using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SupportPage.Startup))]
namespace SupportPage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
