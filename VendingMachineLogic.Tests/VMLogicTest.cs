using System;
using Xunit;
using VendingMachineLogic.Products;

namespace VendingMachineLogic.Tests
{
    public class VMLogicTest
    {
        [Fact]
        public void InsertMoney_GivenAcceptableMoney_StoresMyMoney()
        {
            // Arrange
            IVMLogic vml = new VMLogic();

            // Act
            int[] okMoney = vml.GetAcceptableMoneyDenominators();
            int sum = 0;
            foreach (var item in okMoney)
            {
                vml.InsertMoney(item);
                sum += item;
            }

            // Assert
            Assert.Equal(sum, vml.RetrieveChange());
            Assert.Equal(0, vml.RetrieveChange()); //Retrieving the change should remove money from system
        }
        [Fact]
        public void InsertMoney_GivenUnacceptableMoney_ThrowsException()
        {
            // Arrange
            IVMLogic vml = new VMLogic();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => vml.InsertMoney(-1));
        }
        [Fact]
        public void Purchase_InsufficientMoney_ReturnsNull()
        {
            // Arrange
            IVMLogic vml = new VMLogic();


            // Act & Assert
            Assert.Throws<ArgumentException>(() => vml.Purchase(1));
        }

        [Fact]
        public void Purchase_SufficientMoney_ReturnsTheProduct()
        {
            // Arrange
            IVMLogic vml = new VMLogic();

            // Act
            int bignumber = 999;
            while (bignumber-- > 0)
                vml.InsertMoney(vml.GetAcceptableMoneyDenominators()[0]); //Add tons of acceptable money to the system

            ProductInfo pinfo = vml.GetAvailableProducts()[0];
            IProduct result = vml.Purchase(1);

            // Assert
            Assert.Equal(pinfo.Id, result.Examine().Id);
        }


        [Fact]
        public void Restock_BadStuff_ThrowsException()
        {
            // Arrange
            IVMLogic vml = new VMLogic();


            // Act & Assert
            Assert.Throws<ArgumentException>(() => vml.Restock(0, new Cookie()));
            Assert.Throws<ArgumentException>(() => vml.Restock(vml.GetAvailableProducts().Length + 1, new Cookie()));
            Assert.Throws<ArgumentException>(() => vml.Restock(1, null));

        }
        [Fact]
        public void Restock_GoodStuff_ItsAddedInTheSystem()
        {
            // Arrange
            IVMLogic vml = new VMLogic();
            IProduct newProduct = new Cookie();
            int bignumber = 999;
            while (bignumber-- > 0)
                vml.InsertMoney(vml.GetAcceptableMoneyDenominators()[0]); //Add tons of acceptable money to the system

            // Act
            vml.Restock(2, newProduct);

            // Assert
            Assert.Equal(newProduct, vml.Purchase(2));
        }
    }
}
