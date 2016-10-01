using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5_Pracice1002.Startup))]
namespace MVC5_Pracice1002
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
