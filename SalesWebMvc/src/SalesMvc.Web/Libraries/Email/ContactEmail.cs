using System.Net;
using System.Net.Mail;
using SalesMvc.Web.Models;

namespace SalesMvc.Web.Libraries.Email
{
    public class ContactEmail
    {
        public static void SendContactEmail(Contact contact)
        {
            /*
             * Server tha send email 
             */
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("","");
            smtpClient.EnableSsl = true;



            /*
             * Body message
             */

            string bodyMessage = string.Format($"<h2> Virtual Sale </h2> <br/> {contact.Name} <br/> {contact.Email} <br/> {contact.Text}");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("");
            mailMessage.To.Add("");
            mailMessage.Subject = "Teste" + contact.Email;
            mailMessage.Body = bodyMessage;
            mailMessage.IsBodyHtml = true;
            
            smtpClient.Send(mailMessage);
        }
    }
}
