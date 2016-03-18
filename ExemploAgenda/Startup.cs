using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExemploAgenda.Startup))]
namespace ExemploAgenda
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
