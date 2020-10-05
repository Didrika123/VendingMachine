using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine
{
    class VendingMachine
    {
        IVendingMachineLogic _vendingMachineLogic = new VendingMachineLogic();

        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                MainMenu();
            }
        }
        public int AskUserForSelection(int min, int max)
        {
            return int.Parse(Console.ReadLine());
        }

        private void MainMenu()
        {
            int selection;
            int minSelection = 1;
            int maxSelection = 4;
            do
            {
                Console.WriteLine("1. Insert Money");
                Console.WriteLine("2. Buy Stuff");
                Console.WriteLine("3. My Stuff");
                Console.WriteLine("3. Exit");
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
            Console.WriteLine("Your Change is");
            Console.WriteLine(_vendingMachineLogic.GetChange());
            Console.WriteLine("Your items buyed:");
            Console.WriteLine("Soda");

            Console.WriteLine("Thank you come again!");
            Console.ReadKey();
        }
        private void InsertMoneyMenu()
        {
            int[] okMoney = _vendingMachineLogic.GetAcceptableMoneyDenominators();
            int selection;
            int minSelection = 1;
            int maxSelection = okMoney.Length;
            do
            {
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
            List<IProduct> products = _vendingMachineLogic.GetAvailableProducts();
            int selection;
            int minSelection = 1;
            int maxSelection = products.Count;
            do
            {
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {products[i].Examine().Name}, \t{products[i].Examine().Price} kr");
                }
                Console.WriteLine($"{maxSelection}. Exit");

                selection = AskUserForSelection(minSelection, maxSelection);
                if (selection != maxSelection)
                    _vendingMachineLogic.Purchase(products[selection - 1]);
            }
            while (selection != maxSelection);
        }
        private void MyStuffMenu()
        {
            List<IProduct> products = _vendingMachineLogic.GetPurchasedProducts();
            int selection;
            int minSelection = 1;
            int maxSelection = products.Count;
            do
            {
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {products[i].Examine().Name}");
                    Console.WriteLine($"  - {products[i].Examine().Info}");
                }
                Console.WriteLine($"{maxSelection}. Exit");

                selection = AskUserForSelection(minSelection, maxSelection);
                if (selection != maxSelection)
                    Console.WriteLine(products[selection - 1].Use());
            }
            while (selection != maxSelection);
        }
    }
}
