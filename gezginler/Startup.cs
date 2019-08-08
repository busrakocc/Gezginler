using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(gezginler.Startup))]
namespace gezginler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
