using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.UI
{
    public class MenuUI
    {
        public static int Menu()
        {
            int option;
            Console.WriteLine("1. Add a new Item.");
            Console.WriteLine("2. View the Cheapest Item in the Menu.");
            Console.WriteLine("3. View the Drinks Menu.");
            Console.WriteLine("4. View the Food Menu.");
            Console.WriteLine("5. Add Order.");
            Console.WriteLine("6. Fullfill Order.");
            Console.WriteLine("7. View the Orders List");
            Console.WriteLine("8. Total Payable Amount");
            Console.WriteLine("9. Exit.");

            Console.WriteLine();
            Console.WriteLine("Enter Any Key to continue>>>>");
            option = int.Parse(Console.ReadLine());
            return option;
        }

    }
}
