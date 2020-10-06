using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineLogic.Products
{
    class Cookie : Product
    {
        int _id = 6337;
        string _name = "Cookie";
        string _info = "Round as the moon and big as the palm of your hand.";
        string _useMessage = "...And thats the way the cookie crumbles!";
        int _price = 5;

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
