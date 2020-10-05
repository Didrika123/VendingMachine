using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    public class VendingMachineLogic : IVendingMachineLogic
    {
        int[] _moneyDenominators = new int[] { 1, 2, 5, 10 };
        int _moneyPool;
        List<IProduct> _stock = new List<IProduct>();
        
        public int[] GetAcceptableMoneyDenominators()
        {
            return null;
        }

        public void InsertMoney(int amount)
        {
            throw new NotImplementedException();
        }

        public IProduct Purchase(IProductInfo productInfo)
        {
            int index = _stock.FindIndex(n => n.Examine().Id == productInfo.Id);
            IProduct product = _stock[index];
            _stock.RemoveAt(index);
            return product;
        }

        public int RetrieveChange()
        {
            throw new NotImplementedException();
        }

        IProductInfo[] IVendingMachineLogic.GetAvailableProducts()
        {
            //Extract all unique infos from list of stock
            throw new NotImplementedException();
        }

    }
}
