using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kevin_main.com.Startup))]
namespace kevin_main.com
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
