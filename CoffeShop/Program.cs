using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeShop.BL;
using CoffeShop.DL;
using CoffeShop.UI;

namespace CoffeShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Coffee Shop Name: ");
            string name = Console.ReadLine();
            CoffeeShop NewCoffeeShop = new CoffeeShop(name);
            if (CoffeeShopCRUD.ReadDataFromFile("E:\\OOPs\\CoffeShop\\MenuItems.txt", NewCoffeeShop.Menu))
            {
                Console.WriteLine("Data has been Read SuccessFully From File");
            }
            int option;
            do
            {
                option = MenuUI.Menu();
                if (option == 1)
                {
                    MenuItem NewMenuItem = CoffeeShopUI.AddMenuItem();
                    NewCoffeeShop.Menu.Add(NewMenuItem);
                    Console.WriteLine("Item Added Successfully");
                }
                else if(option == 2)
                {
                    CoffeeShopUI.DisplayCheapestItem(NewCoffeeShop);
                }
                else if(option == 3)
                {
                    CoffeeShopUI.DisplayDrinks(NewCoffeeShop);
                }
                else if(option == 4)
                {
                    CoffeeShopUI.DisplayFoods(NewCoffeeShop);
                }
                else if(option == 5)
                {
                    bool Check = CoffeeShopUI.AddOrder(NewCoffeeShop);
                    if (Check == true)
                    {
                        Console.WriteLine("Item Added Successfully!!");
                    }
                    else
                    {
                        Console.WriteLine("Item is currently unavailable>>>>>");
                    }
                }
                else if(option == 6)
                {
                    CoffeeShopUI.FullFillOrder(NewCoffeeShop);
                }
                else if(option == 7)
                {
                    CoffeeShopUI.DisplayOrdersList(NewCoffeeShop);
                }
                else if(option == 8)
                {
                    Console.WriteLine("Final Bill is " + NewCoffeeShop.CalculateAmmount());
                }
                Console.Write("Press Any Key to Continue>>>>");
                Console.ReadKey();
                Console.Clear();
            } while (option != 9);
        }
    }
}
