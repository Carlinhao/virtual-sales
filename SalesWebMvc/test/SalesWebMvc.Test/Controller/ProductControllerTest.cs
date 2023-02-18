using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesMvc.Web.Areas.Employee.Controllers;
using SalesMvc.Web.Models;
using SalesMvc.Web.Repositories.Interfaces;
using Shouldly;
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


        [Fact(DisplayName ="Should return data with success.")]
        [Trait("category","Controller test")]
        public async Task Index_WhenFindData_MustReturnSuccess()
        {
            // Arrange
            var controller = GetController();
            var test = GetProducts();
            IPagedList<Product> products = new PagedList<Product>(test, 1, 10);

            // Act
            _productRepository.Setup(x => x.GetAllProduct(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(products);
            var result = await controller.Index(0, "");
            var data = result as ViewResult;
            var model = data.Model as PagedList<Product>;
            
            // Assert
            Assert.Equal(3, model.ToList().Count);
            Assert.Collection(model.ToList(),
                item => Assert.Equal(123, item.Id),
                item => Assert.Equal(1231, item.Id),
                item => Assert.Equal(321324, item.Id));

        }

        private ProductController GetController()
            => new ProductController(_productRepository.Object);

        private IQueryable<Product>  GetProducts()
            => new List<Product>
            {
                new Product{ Category = null, CategoryId = 0, Description = "Test 0", Id = 123, ProductQuantity = 1 },
                new Product{ Category = null, CategoryId = 0, Description = "Test 1", Id = 1231, ProductQuantity = 3 },
                new Product{ Category = null, CategoryId = 0, Description = "Test 2", Id = 321324, ProductQuantity = 2 }
            }.AsQueryable();
    }
}
