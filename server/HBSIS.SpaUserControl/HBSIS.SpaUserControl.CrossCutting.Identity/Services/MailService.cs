using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.Services
{
    public class MailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return SendMail(message);
        }

        private Task SendMail(IdentityMessage message)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["AppMail"], ConfigurationManager.AppSettings["AppMailPassword"]);
            smtpClient.EnableSsl = true;
            smtpClient.Send(GetMailMessage(ConfigurationManager.AppSettings["AppMail"], ConfigurationManager.AppSettings["AppMailName"], message.Destination, message.Subject, message.Body));

            return Task.FromResult(0);
        }

        private MailMessage GetMailMessage(string fromMail, string fromName, string to, string subject, string body)
        {
            var mail = new MailMessage { From = new MailAddress(fromMail, fromName) };
            mail.To.Add(new MailAddress(to));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            return mail;
        }

    }
}
