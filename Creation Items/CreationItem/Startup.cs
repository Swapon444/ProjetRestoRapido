using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CreationItem.Startup))]
namespace CreationItem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
