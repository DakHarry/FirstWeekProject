using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FirstWeekProject.Startup))]
namespace FirstWeekProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }
    }
}
