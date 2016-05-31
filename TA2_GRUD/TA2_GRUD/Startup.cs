using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TA2_GRUD.Startup))]
namespace TA2_GRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
