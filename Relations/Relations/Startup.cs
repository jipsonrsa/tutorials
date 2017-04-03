using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Relations.Startup))]
namespace Relations
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
