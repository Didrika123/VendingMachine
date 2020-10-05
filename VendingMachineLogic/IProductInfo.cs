using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public interface IProductInfo
    {
        public int Id { get; protected set; }
        public int Name { get; protected set; }
        public int Info { get; protected set; }
        public int Price { get; protected set; }
    }
}
