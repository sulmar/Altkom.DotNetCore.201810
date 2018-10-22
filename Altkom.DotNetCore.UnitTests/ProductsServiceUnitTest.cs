using Altkom.DotNetCore.FakeServices;
using Altkom.DotNetCore.IServices;
using System;
using System.Linq;
using Xunit;

namespace Altkom.DotNetCore.UnitTests
{
    public class ProductsServiceUnitTest
    {
        [Fact]
        public void GetProductsTest()
        {
            // Arrange
            IProductsService productsService = new FakeProductsService();

            // Acts
            var products = productsService.Get();

            // Asserts
            Assert.NotNull(products);
            Assert.True(products.Any());
        }

        [Fact]
        public void GetProductTest()
        {
            int id = 10;

            // Arrange
            IProductsService productsService = new FakeProductsService();

            // Acts
            var product = productsService.Get(id);

            

            // Asserts
            Assert.NotNull(product);
            Assert.Equal(id, product.Id);
            Assert.False(string.IsNullOrEmpty(product.Name));
            Assert.True(product.UnitPrice > 0);
        }
    }
}
