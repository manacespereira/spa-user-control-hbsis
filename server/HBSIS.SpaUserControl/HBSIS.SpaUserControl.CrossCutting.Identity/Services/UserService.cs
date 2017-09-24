using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBSIS.SpaUserControl.CrossCutting.Identity.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.Services
{
    public class UserService : UserManager<User>
    {
        public UserService(IUserStore<User> store)
            : base(store)
        {
            // Configurando validator para nome de usuario
            UserValidator = new UserValidator<User>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true,
            };

            // Logica de validação e complexidade de senha
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = false,
                RequireNonLetterOrDigit = false,

            };

            // Configuração de Lockout
            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 3;

            // Providers de Two Factor Autentication
            RegisterTwoFactorProvider("Código via SMS", new PhoneNumberTokenProvider<User>
            {
                MessageFormat = "Seu código de segurança é: {0}"
            });

            RegisterTwoFactorProvider("Código via E-mail", new EmailTokenProvider<User>
            {
                Subject = "Código de Segurança",
                BodyFormat = "Seu código de segurança é: {0}"
            });

            // Definindo a classe de serviço de e-mail
            EmailService = new MailService();

            // Definindo a classe de serviço de SMS
            SmsService = new SmsService();

            var provider = new DpapiDataProtectionProvider("RiseUp");
            var dataProtector = provider.Create("Identity");

            UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtector);
        }
        // Metodo para login async que guarda os dados Client conectado
        public async Task<IdentityResult> SignInClientAsync(User user, string clientKey)
        {
            if (string.IsNullOrEmpty(clientKey))
                throw new ArgumentNullException(nameof(clientKey));

            var client = user.Clients.SingleOrDefault(c => c.ClientKey == clientKey);
            if (client == null)
            {
                client = new Client() { ClientKey = clientKey };
                user.Clients.Add(client);
            }

            var result = await UpdateAsync(user);
            user.CurrentClientId = client.ClientId.ToString();
            return result;
        }

        // Metodo para login async que remove os dados Client conectado
        public async Task<IdentityResult> SignOutClientAsync(User user, string clientKey)
        {
            if (string.IsNullOrEmpty(clientKey))
            {
                throw new ArgumentNullException(nameof(clientKey));
            }

            var client = user.Clients.SingleOrDefault(c => c.ClientKey == clientKey);
            if (client != null)
            {
                user.Clients.Remove(client);
            }

            user.CurrentClientId = null;
            return await UpdateAsync(user);
        }
    }
}
