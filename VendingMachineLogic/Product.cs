using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineLogic
{
    public abstract class Product : IProduct
    {
        ProductInfo _productInfo;
        string _useMessage;
        bool _isPurchased;
        bool IProduct.IsPurchased { get => _isPurchased; set => _isPurchased = value; }
        public Product(int id, string name, string info, string useMessage, int price)
        {
            _productInfo = new ProductInfo(id, name, info, price);
            _useMessage = useMessage;
        }

        public void Purchase()
        {
            _isPurchased = true;
        }

        public ProductInfo Examine()
        {
            return _productInfo;
        }

        public string Use()
        {
            return _useMessage;
        }
    }
}
