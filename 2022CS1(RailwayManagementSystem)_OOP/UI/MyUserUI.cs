using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using _2022CS1_RailwayManagementSystem__OOP.BL;
using _2022CS1_RailwayManagementSystem__OOP.DL;
using _2022CS1_RailwayManagementSystem__OOP.UI;


namespace _2022CS1_RailwayManagementSystem__OOP.UI
{
    public class MyUserUI
    {
        public static MyUser TakeInputWithoutRole()
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine();
            Console.WriteLine("User Login: ");
            Console.WriteLine();
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            MyUser user = new MyUser(name, password);
            return user;
        }
    }
}
