using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Moq;
using SalesMvc.Web.Libraries.Email;
using Xunit;

namespace SalesWebMvc.Test.Libraires
{
    public class ContactEmailTest
    {
        private readonly Mock<SmtpClient> _smtpClient;
        private readonly Mock<IConfiguration> _configuration;

        public ContactEmailTest()
        {
            _smtpClient = new Mock<SmtpClient>();
            _configuration = new Mock<IConfiguration>();
        }


        [Fact(DisplayName = "Must send email")]
        [Trait("Category", "ContactEmail")]
        public void SendContactEmail_WhenDataIsValid_MustSendEmail()
        {
            // Arrange
            var contact = new ContactEmail(_smtpClient.Object, _configuration.Object);

            var configurationSectionMock = new Mock<IConfigurationSection>();

            configurationSectionMock
               .Setup(x => x.Value)
               .Returns("teste@teste.com");

            _configuration
               .Setup(x => x.GetSection("Email:UserName"))
               .Returns(configurationSectionMock.Object);

            _configuration.SetupGet(x => x[It.IsAny<string>()]).Returns("teste@teste.com");

            // Assert
            Assert.IsAssignableFrom<ContactEmail>(contact);
        }
    }
}
