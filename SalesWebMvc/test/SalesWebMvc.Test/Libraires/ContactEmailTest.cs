using Microsoft.Extensions.Configuration;
using SalesMvc.Web.Libraries.Email;
using System.Net.Mail;
using Xunit;
using Moq;

namespace SalesWebMvc.Test.Libraires
{
    public class ContactEmailTest
    {
        private readonly SmtpClient _smtpClient;
        private readonly Mock<IConfiguration> _configuration;

        public ContactEmailTest()
        {
            _smtpClient = new SmtpClient();
            _configuration = new Mock<IConfiguration>();
        }


        [Fact(DisplayName = "Must send email")]
        [Trait("Category", "ContactEmail")]
        public void SendContactEmail_WhenDataIsValid_MustSendEmail()
        {
            // Arrange
            var contact = new ContactEmail(_smtpClient, _configuration.Object);

            // Act

            // Assert
        }
    }
}
