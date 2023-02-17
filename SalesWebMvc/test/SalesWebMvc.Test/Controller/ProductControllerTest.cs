using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Moq;
using SalesMvc.Web.Areas.Employee.Controllers;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;
using X.PagedList;
using Xunit;

namespace SalesWebMvc.Test.Controller
{
    public class ProductControllerTest
    {
        private readonly Mock<IProductRepository> _productRepository;

        public ProductControllerTest()
        {
            _productRepository = new Mock<IProductRepository>();
        }


        [Fact(DisplayName ="")]
        [Trait("category","Controller test")]
        public async Task Index_WhenFindData_MustReturnSuccess()
        {
            // Arrange
            var controller = GetController();
            IPagedList<Product> products = null;

            // Act
            _productRepository.Setup(x => x.GetAllProduct(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(products);
            var result = await controller.Index(0, "");
            
            // Assert

        }

        private ProductController GetController()
            => new ProductController(_productRepository.Object);
    }
}
