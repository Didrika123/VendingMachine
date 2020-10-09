using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineLogic
{
    public abstract class Product : IProduct 
    {
        public bool IsPurchased { get; private set; }

        public void Purchase()
        {
            IsPurchased = true;
        }

        public abstract ProductInfo Examine();

        public abstract string Use();
    }
}
