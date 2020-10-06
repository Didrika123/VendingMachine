using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineLogic.Products
{
    public class Scarf : Product
    {
        int _id = 91323;
        string _name = "Scarf";
        string _info = "Cosy cottony thing to have around your neck since Winter is coming.";
        string _useMessage = "You wring the scarf around your neck. Mmmmmmmm!";
        int _price = 129;

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
