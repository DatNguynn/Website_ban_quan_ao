using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZunezxShop_Web.Startup))]
namespace ZunezxShop_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
