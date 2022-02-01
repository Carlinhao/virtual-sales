using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.Libraries.Email
{
    public class ContactEmail
    {
        private readonly SmtpClient _smtpClient;
        private readonly IConfiguration _configuration;
        public ContactEmail(SmtpClient smtpClient,
                            IConfiguration configuration)
        {
            _smtpClient = smtpClient;
            _configuration = configuration;
        }

        public void SendContactEmail(Contact contact)
        {
            /*
             * Body message
             */

            string bodyMessage = string.Format($"<h2> Virtual Sale </h2> <br/> {contact.Name} <br/> {contact.Email} <br/> {contact.Text}");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_configuration.GetValue<string>("Email:UserName"));
            mailMessage.To.Add("");
            mailMessage.Subject = "Teste" + contact.Email;
            mailMessage.Body = bodyMessage;
            mailMessage.IsBodyHtml = true;

            _smtpClient.Send(mailMessage);
        }
    }
}
