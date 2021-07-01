using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sang5_01_07.Startup))]
namespace Sang5_01_07
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
