using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineLogic
{
    public interface IVMLogic
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

        /// <summary>
        /// Your credit in the machine (Does not retrieve it, just read)
        /// </summary>
        public int GetCredit();

        public ProductInfo[] GetAvailableProducts();

        public IProduct Purchase(ProductInfo product);
        public int[] GetAcceptableMoneyDenominators();
    }
}
