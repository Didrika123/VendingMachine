using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public interface IVendingMachineLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <throws>Invalid Money Denominator</throws>
        public void InsertMoney(int amount);

        /// <summary>
        /// Removes all money from system and gives it to user
        /// </summary>
        public int RetrieveChange();

        public IProductInfo[] GetAvailableProducts();

        public IProduct Purchase(IProductInfo product);
        public int[] GetAcceptableMoneyDenominators();
    }
}
