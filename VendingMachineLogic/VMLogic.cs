using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineLogic.Products;

namespace VendingMachineLogic
{
    public class VMLogic : IVMLogic
    {
        readonly int[] _moneyDenominators = new int[] { 1, 5, 10, 20, 50, 100, 500, 1000 };
        int _moneyPool;
        readonly Queue<IProduct>[] _slotStock = new Queue<IProduct>[6];

        public VMLogic()
        {
            for (int i = 0; i < _slotStock.Length; i++)
            {
                _slotStock[i] = new Queue<IProduct>();
            }

            DoVendingMachineOperatorRestockingWork();
        }
        private void DoVendingMachineOperatorRestockingWork()
        {
            //Load a bunch of dummy data
            for (int i = 0; i < 5; i++)
                Restock(1, new Cookie());
            for (int i = 0; i < 25; i++)
                Restock(3, new Hamburger());
            for (int i = 0; i < 2; i++)
                Restock(5, new Fairytale_Collection());
            for (int i = 0; i < 3; i++)
                Restock(6, new Scarf());
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

        public IProduct Purchase(int slotnumber)
        {
            int index = slotnumber - 1; //array index starts at 0, but slots start at 1
            if(index < 0 || index > _slotStock.Length - 1)
                throw new ArgumentException($"There is no slot with number {slotnumber}!");

            IProduct product;
            _slotStock[index].TryPeek(out product);

            if (product == null)
                throw new ArgumentException("The product in that slot is sold out.");

            if (_moneyPool < product.Examine().Price)
                throw new ArgumentException("Insufficient money to buy that product.");

            product = _slotStock[index].Dequeue();
            _moneyPool -= product.Examine().Price;
            return product;
        }

        public int RetrieveChange()
        {
            int temp = _moneyPool;
            _moneyPool = 0;
            return temp;
        }

        public ProductInfo[] GetAvailableProducts()
        {
            //Extract all unique infos from list of stock
            ProductInfo[] productInfos = new ProductInfo[_slotStock.Length];
            for (int i = 0; i < _slotStock.Length; i++)
            {
                IProduct product;
                _slotStock[i].TryPeek(out product);
                if (product != null)
                {
                    ProductInfo productInfo = product.Examine();
                    productInfos[i] = productInfo;
                }
                else productInfos[i] = new ProductInfo(0, "Out of stock", "", 0);
            }
            return productInfos;
        }

        public void Restock(int slotnumber, IProduct product)
        {
            int index = slotnumber - 1;
            if(product == null)
                throw new ArgumentException("Product cant be null");

            if (index < 0 || index >= _slotStock.Length)
                throw new ArgumentException("Bad slot number.");

            _slotStock[index].Enqueue(product);
        }

        public string GetCreditInMoneyDenominators()
        {
            StringBuilder strbuilder = new StringBuilder();
            int remainder = _moneyPool;
            for (int i = _moneyDenominators.Length - 1; i >= 0 ; i--)
            {
                int moneyValue = _moneyDenominators[i];
                int numberOf = remainder / moneyValue;
                if(numberOf > 0)
                {
                    strbuilder.Append(numberOf + "x " + moneyValue + " Kr, ");
                    remainder -= numberOf * moneyValue;
                }
            }
            if(strbuilder.Length > 2)
                strbuilder.Remove(strbuilder.Length - 2, 2); //remove final ", " (for aestheticism)
            return strbuilder.ToString();
        }
    }
}
