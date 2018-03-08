using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_ATM.Startup))]
namespace E_ATM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
