using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NegociacaoMerca.Startup))]
namespace NegociacaoMerca
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
