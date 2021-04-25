using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_21century.Startup))]
namespace _21century
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
