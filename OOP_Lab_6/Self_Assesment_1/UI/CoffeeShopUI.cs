using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Self_Assesment_1.BL;
using Self_Assesment_1.DL;

namespace Self_Assesment_1.UI
{
    public class CoffeeShopUI
    {
        public static bool AddOrder(CoffeeShop MyShop)
        {
            Console.WriteLine("Enter Order Name: ");
            string order = Console.ReadLine();
            if(MenuItemCRUD.Exists(order))
            {
                MyShop.Orders.Add(order);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void FullFillOrder(CoffeeShop MyShop)
        {
            foreach(string Order in MyShop.Orders)
            {
                Console.WriteLine(Order + " has been delivered!!....");
                Thread.Sleep(2000);
                MyShop.Orders.Remove(Order);
            }
        }
        public static float dueAmount(CoffeeShop MyShop)
        {
            float DueAmount = 0;
            if (MenuItemCRUD.MenuItemsList != null)
            {
                for (int x = 0; x < MyShop.Orders.Count; x++)
                {
                    for (int i = 0; i < MenuItemCRUD.MenuItemsList.Count; i++)
                    {
                        if (MenuItemCRUD.MenuItemsList[i].name == MyShop.Orders[x])
                        {
                            DueAmount = DueAmount + MenuItemCRUD.MenuItemsList[i].price;
                        }
                    }
                }

            }
            return DueAmount;
        }
        public static CoffeeShop AddCoffeeShop()
        {
            Console.WriteLine("Enter Shop Name: ");
            string name = Console.ReadLine();
            List<MenuItem> Menu = MenuItemCRUD.MenuItemsList;
            CoffeeShop MyShop = new CoffeeShop(name, Menu);
            return MyShop;
        }
    }
}
