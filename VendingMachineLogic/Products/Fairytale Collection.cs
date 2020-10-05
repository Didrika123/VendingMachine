using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineLogic.Products
{
    public class Fairytale_Collection : Product
    {
        public Fairytale_Collection() 
            : base(59129, 
                  "Fairytale Collection", 
                  "A leather-bound collection of 1001 Fairytales from all over the world.",  
                  "You open the book and read the first chapter of a goodnight-story about a cute little bird called Punpun", 
                  199)
        {
        }
    }
}
