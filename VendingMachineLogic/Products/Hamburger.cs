using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineLogic.Products
{
    public class Hamburger : Product
    {
        public Hamburger()
            : base(52939592,
                  "Hamburger",
                  "Super Tasty Triple Layered Deluxe Hamburger Extravaganza TM!",
                  "Hmm some wierd green spots... You take a bite, and a thought enters your head; how long has this been sitting around in that vending machine?",
                  35)
        {
        }
    }
}
