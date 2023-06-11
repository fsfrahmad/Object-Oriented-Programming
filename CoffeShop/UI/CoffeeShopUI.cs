using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CoffeShop.BL;
using CoffeShop.UI;



namespace CoffeShop.UI
{
    public class CoffeeShopUI
    {
        public static MenuItem AddMenuItem()
        {
            Console.WriteLine("Enter Item Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter item type: ");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Item Price: ");
            float price = float.Parse(Console.ReadLine());
            MenuItem NewMenuItem = new MenuItem(name, type, price);
            return NewMenuItem;
        }
        public static bool AddOrder(CoffeeShop MyShop)
        {
            Console.WriteLine("Enter Order Name: ");
            string order = Console.ReadLine();
            MenuItem Order = MyShop.ItemExists(order);
            if (Order != null)
            {
                MyShop.Orders.Add(Order);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void DisplayOrdersList(CoffeeShop MyShop)
        {
            if (MyShop.Orders != null)
            {
                Console.WriteLine("Name\tType\tPrice");
                foreach (MenuItem M in MyShop.Orders)
                {
                    Console.WriteLine(M.name + "\t" + M.type + "\t" + M.price);
                }
            }
            else
            {
                Console.WriteLine("No Item Exists!!!");
            }
        }
        public static void DisplayDrinks(CoffeeShop MyShop)
        {
            if (MyShop.Menu != null)
            {
                Console.WriteLine("Name\tType\tPrice");
                foreach (MenuItem M in MyShop.Menu)
                {
                    if (M.type == "Drinks" || M.type == "Drink" || M.type == "drink")
                        Console.WriteLine(M.name + "\t" + M.type + "\t" + M.price);
                }
            }
            else
            {
                Console.WriteLine("No Item Exists!!!");
            }
        }
        public static void DisplayFoods(CoffeeShop MyShop)
        {
            if (MyShop.Menu != null)
            {
                Console.WriteLine("Name\tType\tPrice");
                foreach (MenuItem M in MyShop.Menu)
                {
                    if (M.type == "Food" || M.type == "food")
                        Console.WriteLine(M.name + "\t" + M.type + "\t" + M.price);
                }
            }
            else
            {
                Console.WriteLine("No Item Exists!!!");
            }
        }
        public static void DisplayCheapestItem(CoffeeShop MyShop)
        {
            if (MyShop.Menu != null)
            {
                List<MenuItem> SortedMenuList = MyShop.Menu.OrderBy(o => o.price).ToList();
                Console.WriteLine("Cheapest Item: " + SortedMenuList[0].name + "   Price: " + SortedMenuList[0].price);
            }
            else
            {
                Console.WriteLine("No Item Exists!!!");
            }
        }
        public static void FullFillOrder(CoffeeShop MyShop)
        {
            for(int i = 0; i < MyShop.Orders.Count; i++)
            {
                Console.WriteLine(MyShop.Orders[i].name + " has been delivered!!....");
                Thread.Sleep(1000);
                MyShop.Orders.RemoveAt(1);
            }
            Console.WriteLine("All Items Delivered");
        }
    }
}
