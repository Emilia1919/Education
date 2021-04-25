using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pittools.Startup))]
namespace pittools
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
