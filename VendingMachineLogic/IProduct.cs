using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineLogic
{
    /*
     * 
     * Each product type should be its own class.o
     * These classes should all inherit form the same interface or abstract class, to get the methods they have in common.
     * This base class is the type the vending machine itself should look for.
     * */
    public interface IProduct
    {
        bool IsPurchased { get;}

        /// <summary>
        /// Buys the product
        /// </summary>
        public void Purchase();



        /// <summary>
        /// Gets productinfo of product
        /// </summary>
        public ProductInfo Examine();

        /// <summary>
        /// Use the product
        /// </summary>
        public string Use();
    }
}
