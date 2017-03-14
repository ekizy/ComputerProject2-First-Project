using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nerdeeyesek.Startup))]
namespace Nerdeeyesek
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
