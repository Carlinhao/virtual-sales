using Microsoft.AspNetCore.Http;
using Moq;
using SalesMvc.Web.Libraries.Login;
using SalesMvc.Web.Libraries.Sessions;
using SalesMvc.Web.Models;
using Xunit;

namespace SalesWebMvc.Test.Libraires
{
    public sealed class LoginCostumerTest
    {
        private readonly Session _session;
        private readonly IHttpContextAccessor _context;
        public LoginCostumerTest()
        {
            _context = new HttpContextAccessor();
            _session = new Session(_context);
        }

        [Fact(DisplayName = "Login Customer")]
        [Trait("Category", "ContactEmail")]
        public void GetCustomer_MustReturn_Null()
        {
            // Arrange
            Mock<ISession> sessionMock = new Mock<ISession>();
            var loginCostumer = GetLoginCostumer();
            _context.HttpContext = new DefaultHttpContext
            {
                Session = sessionMock.Object
            };
            _session.Exist("Login.Customer");

            // Act
            var result = loginCostumer.GetCustomer();

            // Assert
            Assert.Null(result);

        }

        private Customer GetCustomer()
            => new Customer() {  CPF = "45798672034", Email = "teste@teste.com", Id = 87987};

        private LoginCostumer GetLoginCostumer()
            => new LoginCostumer(_session);
    }
}
