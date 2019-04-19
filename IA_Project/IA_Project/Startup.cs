using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IA_Project.Startup))]
namespace IA_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
