using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineLogic.Products;

namespace VendingMachineLogic
{
    public class VMLogic : IVMLogic
    {
        int[] _moneyDenominators = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
        int _moneyPool;
        List<IProduct> _stock = new List<IProduct>();

        public VMLogic()
        {
            //Load a bunch of dummy data
            for(int i = 0; i < 2; i++)
                _stock.Add(new Hamburger());
            for (int i = 0; i < 2; i++)
                _stock.Add(new Fairytale_Collection());
            for (int i = 0; i < 3; i++)
                _stock.Add(new Scarf());
        }
        
        public int[] GetAcceptableMoneyDenominators()
        {
            return _moneyDenominators;
        }

        public int GetCredit()
        {
            return _moneyPool;
        }

        public void InsertMoney(int amount)
        {
            int index = Array.IndexOf(_moneyDenominators, amount);
            if (index < 0)
                throw new ArgumentException("The inserted money is not acceptable!");

            _moneyPool += amount;
        }

        public IProduct Purchase(ProductInfo productInfo)
        {
            int index = _stock.FindIndex(n => n.Examine().Id == productInfo.Id);

            if(index < 0)
                return null;

            IProduct product = _stock[index];

            if (_moneyPool < product.Examine().Price)
                return null;

            _moneyPool -= product.Examine().Price;
            _stock.RemoveAt(index);
            return product;
        }

        public int RetrieveChange()
        {
            int temp = _moneyPool;
            _moneyPool = 0;
            return temp;
        }

        ProductInfo[] IVMLogic.GetAvailableProducts()
        {
            //Extract all unique infos from list of stock
            List<ProductInfo> temp = new List<ProductInfo>();
            foreach (var item in _stock)
            {
                ProductInfo productInfo = item.Examine();
                if (!temp.Exists(n => n.Id == productInfo.Id))
                {
                    temp.Add(productInfo);
                }
            }
            return temp.ToArray();
        }

    }
}
