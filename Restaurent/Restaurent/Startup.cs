using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Restaurent.Startup))]
namespace Restaurent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
