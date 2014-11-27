using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BrentUniversity.Web.Startup))]
namespace BrentUniversity.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
