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

            MailMessage mailMessage = new MailMessage();
        }
    }
}
