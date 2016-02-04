using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestoRapido.Startup))]
namespace RestoRapido
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
