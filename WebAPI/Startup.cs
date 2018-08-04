using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebAPI.Startup))]

namespace WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}