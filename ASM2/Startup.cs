using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASM2.Startup))]
namespace ASM2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
