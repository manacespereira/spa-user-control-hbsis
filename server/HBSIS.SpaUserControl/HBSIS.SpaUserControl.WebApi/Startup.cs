
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HBSIS.SpaUserControl.WebApi.StartUp))]
namespace HBSIS.SpaUserControl.WebApi
{
    public partial class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            ConfigureOAuth(app);
            ConfigureWebApi(app, config);
            ConfigureSimpleInjector(app, config);
            ConfigureAutoMapper();
        }
    }
}