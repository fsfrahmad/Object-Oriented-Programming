using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_RailwayManagementSystem__OOP.BL;
using _2022CS1_RailwayManagementSystem__OOP.DL;
using _2022CS1_RailwayManagementSystem__OOP.UI;

namespace _2022CS1_RailwayManagementSystem__OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuUI.ClearScreen();
            MenuUI.Welcome();
            MyUserCRUD.LoadData(""); // Must Add File Path
            TrainInfoCRUD.LoadTrains(""); // Must Add FIle Path
            // Recommendations
            // Complains
            // Announcements
            while (true)
            {
                MenuUI.ClearScreen();
                MenuUI.PrintHeader();
                int option = MenuUI.Login();

                if (option == 1)
                {

                    MyUser newUser = MyUserUI.TakeInputWithoutRole();
                    MyUser FoundUser = MyUserCRUD.UserExists(newUser);
                    if (FoundUser == null)
                    {
                        Console.WriteLine("Account does not exists.");
                        Console.WriteLine("Please Sign Up First.");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                    }
                    else if (FoundUser.GetRole() == "Admin" || FoundUser.GetRole() == "Admin")
                    { 
                    }
                }
            }
        }
    }
}
