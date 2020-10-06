using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineLogic
{
    public abstract class Product : IProduct 
    {
        bool _isPurchased;
        bool IProduct.IsPurchased { get => _isPurchased; set => _isPurchased = value; }

        public void Purchase()
        {
            _isPurchased = true;
        }

        public abstract ProductInfo Examine();

        public abstract string Use();
    }
}
