using System;
using Xunit;
using VendingMachineLogic.Products;

namespace VendingMachineLogic.Tests
{
    public class ProductTest
    {
        [Fact]
        public void Purchase_PurchasingProduct_FlagsItPurchased()
        {
            //Arrange
            IProduct product = new Hamburger();

            //Act
            Assert.False(product.IsPurchased);
            product.Purchase();

            //Assert
            Assert.True(product.IsPurchased);
        }
    }
}
