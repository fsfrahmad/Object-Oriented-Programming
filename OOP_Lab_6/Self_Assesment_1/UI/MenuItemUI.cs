using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Self_Assesment_1.BL;
using Self_Assesment_1.DL;

namespace Self_Assesment_1.UI
{
    public class MenuItemUI
    {
        public static void DisplayMenuItem()
        {
            if (MenuItemCRUD.MenuItemsList != null)
            {
                Console.WriteLine("Name\tType\tPrice");
                foreach (MenuItem M in MenuItemCRUD.MenuItemsList)
                {
                    Console.WriteLine(M.name + "\t" + M.type + "\t" + M.price);
                }
            }
            else
            {
                Console.WriteLine("No Item Exists!!!");
            }
        }
        public static void DisplayDrinks()
        {
            if (MenuItemCRUD.MenuItemsList != null)
            {
                Console.WriteLine("Name\tType\tPrice");
                foreach (MenuItem M in MenuItemCRUD.MenuItemsList)
                {
                    if (M.type == "Drink" || M.type == "drink")
                        Console.WriteLine(M.name + "\t" + M.type + "\t" + M.price);
                }
            }
            else
            {
                Console.WriteLine("No Item Exists!!!");
            }
        }
        public static void DisplayFoods()
        {
            if (MenuItemCRUD.MenuItemsList != null)
            {
                Console.WriteLine("Name\tType\tPrice");
                foreach (MenuItem M in MenuItemCRUD.MenuItemsList)
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
        public static void DisplayCheapestItem()
        {
            if (MenuItemCRUD.MenuItemsList != null)
            {
                List<MenuItem> SortedMenuList = MenuItemCRUD.MenuItemsList.OrderBy(o => o.price).ToList();
                Console.WriteLine("Cheapest Item: " + SortedMenuList[0].name + "   Price: " + SortedMenuList[0].price);
            }
            else
            {
                Console.WriteLine("No Item Exists!!!");
            }
        }
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
    }
}
