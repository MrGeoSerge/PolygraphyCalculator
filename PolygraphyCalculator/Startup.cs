using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PolygraphyCalculator.Startup))]
namespace PolygraphyCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
