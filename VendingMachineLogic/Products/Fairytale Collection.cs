using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineLogic.Products
{
    public class Fairytale_Collection : Product
    {
        int _id = 59129;
        string _name = "Fairytale Collection";
        string _info = "A leather-bound collection of 1001 Fairytales from all over the world.";
        string _useMessage = "You open the book and read the first chapter of a goodnight-story about a cute little bird called Punpun";
        int _price = 199;

        public override ProductInfo Examine()
        {
            return new ProductInfo(_id, _name, _info, _price);
        }

        public override string Use()
        {
            return _useMessage;
        }
    }
}
