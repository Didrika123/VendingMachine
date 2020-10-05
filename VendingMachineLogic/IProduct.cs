using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    /*
     * 
     * Each product type should be its own class.o
     * These classes should all inherit form the same interface or abstract class, to get the methods they have in common.
     * This base class is the type the vending machine itself should look for.
     * */
    public interface IProduct
    {
        /// <summary>
        /// Buys the product
        /// </summary>
        public void Purchase();


        /// <summary>
        /// Gets productinfo of product
        /// </summary>
        public IProductInfo Examine();

        /// <summary>
        /// After you've bought a product you can use it
        /// </summary>
        public string Use();
    }
}
