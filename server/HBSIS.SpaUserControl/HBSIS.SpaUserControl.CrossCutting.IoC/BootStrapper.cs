using HBSIS.SpaUserControl.Application.Interfaces;
using HBSIS.SpaUserControl.Application.Services;
using HBSIS.SpaUserControl.CrossCutting.Identity.Context;
using HBSIS.SpaUserControl.CrossCutting.Identity.Entities;
using HBSIS.SpaUserControl.CrossCutting.Identity.Services;
using HBSIS.SpaUserControl.Data.Repositories;
using HBSIS.SpaUserControl.Domain.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using SimpleInjector;

namespace HBSIS.SpaUserControl.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // iniciando contexto
            container.Register<SpaIdentityContext>(Lifestyle.Scoped);

            // iniciando serviços do identity
            container.Register<IUserStore<User>>(() => new UserStore<User>(container.GetInstance<SpaIdentityContext>()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(container.GetInstance<SpaIdentityContext>()), Lifestyle.Scoped);
            container.Register(() => new OwinRequest().Context.Authentication, Lifestyle.Scoped);
            container.Register<User>(Lifestyle.Scoped);
            container.Register<RoleService>(Lifestyle.Scoped);
            container.Register<UserService>(Lifestyle.Scoped);
            container.Register<SmsService>(Lifestyle.Scoped);
            container.Register<MailService>(Lifestyle.Scoped);
            container.Register<ClaimService>(Lifestyle.Scoped);

            container.Register<IClientRepository, ClientRepository>(Lifestyle.Scoped);
            container.Register<IClientAppService, ClientAppService>(Lifestyle.Scoped);
        }
    }
}
