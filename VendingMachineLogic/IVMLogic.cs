using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineLogic
{
    public interface IVMLogic
    {
        /// <summary>
        /// Inserts money to the vending machine.
        /// </summary>
        /// <param name="amount">A valid money denominator</param>
        /// <exception cref="ArgumentException"></exception>
        public void InsertMoney(int amount);

        /// <summary>
        /// Removes all money from system and gives it to user
        /// </summary>
        public int RetrieveChange();

        /// <summary>
        /// Your credit in the machine (Does not retrieve it, just read)
        /// </summary>
        public int GetCredit();

        /// <summary>
        /// Your credit (as denominators) in the machine (Does not retrieve it, just read)
        /// </summary>
        public string GetCreditInMoneyDenominators();

        /// <summary>
        /// Returns An array of Productinfo for each slot in the vending machine
        /// </summary>
        public ProductInfo[] GetAvailableProducts();

        /// <summary>
        /// Purchases the specified product and subtracts the price from your credit in the machine.
        /// </summary>
        /// <param name="slotnumber">The slot number of the product you want to purchase</param>
        /// <exception cref="ArgumentException">Invalid slot, insufficient money or out of stock.</exception>
        public IProduct Purchase(int slotnumber);

        /// <summary>
        /// Returns an array of integers, where each int is an accepted value to insert to the vending machine.
        /// </summary>
        public int[] GetAcceptableMoneyDenominators();

        /// <summary>
        /// Adds a product to the stock at the specified slotnumber.
        /// </summary>
        /// <param name="slotnumber">The slot number where you want to stock the product</param>
        /// <param name="product">The product you want to store</param>
        public void Restock(int slotnumber, IProduct product);
    }
}
