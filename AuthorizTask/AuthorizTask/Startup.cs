using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthorizTask.Startup))]
namespace AuthorizTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
