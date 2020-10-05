using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineLogic
{
    public class ProductInfo
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Info { get; private set; }
        public int Price { get; private set; }

        public ProductInfo(int id, string name, string info, int price)
        {
            Id = id;
            Name = name;
            Info = info;
            Price = price;
        }
    }
}
