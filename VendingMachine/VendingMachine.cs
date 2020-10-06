using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineLogic;

namespace VendingMachine
{
    class VendingMachine
    {
        IVMLogic _vendingMachineLogic = new VMLogic();
        readonly List<IProduct> _myProducts = new List<IProduct>();

        public void Run()
        {
            MainMenu();
        }
        private int AskUserForSelection(int min, int max)
        {
            int sel = 0;
            Console.Write("\nYour selection: ");
            while (!int.TryParse(Console.ReadLine(), out sel) || sel < min || sel > max) ;
            return sel;
        }

        private void MainMenu()
        {
            int selection;
            int minSelection = 1;
            int maxSelection = 4;
            do
            {
                Header();
                Console.WriteLine("1. Insert Money");
                Console.WriteLine("2. Buy Stuff");
                Console.WriteLine("3. My Stuff");
                Console.WriteLine("4. Exit");
                selection = AskUserForSelection(minSelection, maxSelection);
                switch (selection)
                {
                    case 1:
                        InsertMoneyMenu();
                        break;
                    case 2:
                        BuyMenu();
                        break;
                    case 3:
                        MyStuffMenu();
                        break;
                }

            }
            while (selection != maxSelection);
            Exit();
        }
        private void Exit()
        {
            Console.Clear();
            Console.WriteLine("You leave the Vending Machine..\n");
            Console.Write("Your Change is: ");
            Console.WriteLine(_vendingMachineLogic.RetrieveChange() + " kr");
            Console.WriteLine("\nYou bought:");
            foreach (var item in _myProducts)
            {
                Console.WriteLine(item.Examine().Name);
            }

            Console.WriteLine("\nThank you come again!");
            Console.ReadKey();
        }
        private void Header()
        {
            Console.Clear();
            Console.WriteLine("Big Vending Machine");
            Console.WriteLine("Credit: " + _vendingMachineLogic.GetCredit() + " kr");
            Console.WriteLine();
        }
        private void InsertMoneyMenu()
        {
            int[] okMoney = _vendingMachineLogic.GetAcceptableMoneyDenominators();
            int selection;
            int minSelection = 1;
            int maxSelection = okMoney.Length + 1;
            do
            {
                Header();
                for (int i = 0; i < okMoney.Length; i++)
                {
                    Console.WriteLine($"{i+1}. Insert {okMoney[i]} kr");
                }
                Console.WriteLine($"{maxSelection}. Exit");

                selection = AskUserForSelection(minSelection, maxSelection);
                if(selection != maxSelection)
                    _vendingMachineLogic.InsertMoney(okMoney[selection-1]);
            }
            while (selection != maxSelection);
        }
        private void BuyMenu()
        {
            int selection;
            int minSelection = 1;
            int maxSelection;
            do
            {
                ProductInfo[] products = _vendingMachineLogic.GetAvailableProducts();
                maxSelection = products.Length + 1;

                Header();
                for (int i = 0; i < products.Length; i++)
                {
                    Console.WriteLine("-------------------------------------------------------------------------------------");
                    if(products[i].Price > 0)
                        Console.WriteLine($"{i + 1}. {products[i].Name}, {products[i].Price} kr");
                    else
                        Console.WriteLine($"{i + 1}. {products[i].Name}");
                    Console.WriteLine($"\n   {products[i].Info}\n");
                }
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine($"{maxSelection}. Exit");

                selection = AskUserForSelection(minSelection, maxSelection);
                if (selection != maxSelection)
                {
                    try
                    {
                        IProduct purchase = _vendingMachineLogic.Purchase(selection);
                        _myProducts.Add(purchase);
                        Console.WriteLine($"You bought {purchase.Examine().Name}.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                }
            }
            while (selection != maxSelection);
        }
        private void MyStuffMenu()
        {
            List<IProduct> products = _myProducts;
            int selection;
            int minSelection = 1;
            int maxSelection = products.Count + 1;
            do
            {
                Header();
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {products[i].Examine().Name}");
                }
                Console.WriteLine($"{maxSelection}. Exit");

                selection = AskUserForSelection(minSelection, maxSelection);
                if (selection != maxSelection)
                {
                    Console.WriteLine("\nYou use " + products[selection - 1].Examine().Name +":\n");
                    Console.WriteLine(products[selection - 1].Use());
                    Console.ReadKey();
                }
            }
            while (selection != maxSelection);
        }
    }
}
