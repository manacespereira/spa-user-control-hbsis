using HBSIS.SpaUserControl.CrossCutting.Identity.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.Services
{
    public class SignInService : SignInManager<User, string>
    {
        public SignInService(UserService userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {

        }
        public static SignInService Create(IdentityFactoryOptions<UserService> options, IOwinContext context)
        {
            return new SignInService(context.GetUserManager<UserService>(), context.Authentication);
        }
    }
}
