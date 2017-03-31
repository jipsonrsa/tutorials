using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FamilyMVC.Startup))]
namespace FamilyMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
