using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineLogic.Products
{
    public class Hamburger : Product
    {
        int _id = 52939592;
        string _name = "Hamburger";
        string _info = "Super Tasty Triple Layered Deluxe Hamburger Extravaganza TM!";
        string _useMessage = "Hmm some wierd green spots... You take a bite, and a thought enters your head; how long has this been sitting around in that vending machine?";
        int _price = 35;

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
