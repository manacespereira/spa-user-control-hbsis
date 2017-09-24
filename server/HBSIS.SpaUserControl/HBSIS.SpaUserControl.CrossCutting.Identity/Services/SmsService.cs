using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Twilio;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.Services
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            const string accountSid = "AC1b3cd8608f23b2acbbb41d9f1fc72049";
            const string authToken = "f12ffbb8be72b96ea9e0908a16e67a12";

            var client = new TwilioRestClient(accountSid, authToken);

            client.SendMessage("Seu Telefone", message.Destination, message.Body);

            return Task.FromResult(0);
        }
    }
}
