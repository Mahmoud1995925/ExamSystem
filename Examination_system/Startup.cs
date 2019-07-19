using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Examination_system.Startup))]
namespace Examination_system
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
