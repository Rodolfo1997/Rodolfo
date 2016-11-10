using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GRUDShield.Startup))]
namespace GRUDShield
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // ConfigureAuth(app);
        }
    }
}
