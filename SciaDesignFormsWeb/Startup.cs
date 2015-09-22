using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SciaDesignFormsWeb.Startup))]
namespace SciaDesignFormsWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
