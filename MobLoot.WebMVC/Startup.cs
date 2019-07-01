using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobLoot.WebMVC.Startup))]
namespace MobLoot.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
