using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using HBSIS.SpaUserControl.CrossCutting.Identity.Context;
using HBSIS.SpaUserControl.CrossCutting.Identity.Entities;
using HBSIS.SpaUserControl.CrossCutting.Identity.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Claim = System.Security.Claims.Claim;

namespace HBSIS.SpaUserControl.WebApi.Security
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                var username = context.UserName;
                var password = context.Password;
                

                User user;
                var passwordHasher = new PasswordHasher();
                
                using (var ctx = SpaIdentityContext.Create())
                    user = ctx.Users.FirstOrDefault(x => x.UserName == username || x.Email == username);
            
                if (user == null || passwordHasher.VerifyHashedPassword(user.PasswordHash, password) == PasswordVerificationResult.Failed)
                {
                    context.SetError("invalid_grant", "Usuário ou senha inválidos");
                    return;
                }
                
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, username));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, user.UserName));

                // TODO: Workaround para setar permissões do usuário. O ideal é gravar na base as permissões e listá-las aqui.
                var roles = new List<string> { "User" };

                foreach (var role in roles)
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));

                var principal = new GenericPrincipal(identity, roles.ToArray());

                Thread.CurrentPrincipal = principal;
                context.Validated(identity);
            }
            catch (Exception ex)
            {
                //Caso alguma coisa dê errada dispara um erro
                context.SetError("invalid_grant", $"Falha ao autenticar:  {ex.Message}");
            }
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var newId = new ClaimsIdentity(context.Ticket.Identity);
            newId.AddClaim(new Claim("newClaim", "refreshToken"));

            await Task.Run(() =>
            {
                var newTicket = new AuthenticationTicket(newId, context.Ticket.Properties);
                context.Validated(newTicket);
            });
        }
    }
}