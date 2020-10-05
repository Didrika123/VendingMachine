using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class Product : IProduct
    {
        IProductInfo _productInfo;
        public Product(string name, string info, string useMessage, int price)
        {
            //_productInfo = new ProductInfo
        }
        public IProductInfo Examine()
        {
            return _productInfo;
        }

        public void Purchase()
        {
            throw new NotImplementedException();
        }

        public string Use()
        {
            throw new NotImplementedException();
        }
    }
}
