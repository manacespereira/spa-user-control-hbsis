using System.Web.Http;
using HBSIS.SpaUserControl.CrossCutting.IoC;
using HBSIS.SpaUserControl.WebApi.Security;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace HBSIS.SpaUserControl.WebApi
{
    public partial class StartUp
    {
        public void ConfigureSimpleInjector(IAppBuilder app, HttpConfiguration config)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            BootStrapper.RegisterServices(container);

            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}