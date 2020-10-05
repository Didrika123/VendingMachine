using System;
using Xunit;

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

            // Act
            IProduct result = vml.Purchase(vml.GetAvailableProducts()[0]);

            // Assert
            Assert.Null(result);
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
            IProduct result = vml.Purchase(pinfo);

            // Assert
            Assert.Equal(pinfo.Id, result.Examine().Id);
        }
    }
}
