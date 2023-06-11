using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_RailwayManagementSystem__OOP.BL;
using _2022CS1_RailwayManagementSystem__OOP.DL;

namespace _2022CS1_RailwayManagementSystem__OOP.UI
{
    public class ComplainsUI
    {
        public static void DisplayRecommendations()
        {
            List<string> Complains = ComplainsCRUD.GetComplains();
            int loopCount = 0;
            for (int index = 0; index < Complains.Count; index++)
            {
                Console.WriteLine("Complain No " + (index + 1) + " : " + Complains[index]);
                loopCount++;
            }
            if (loopCount == 0)
            {
                Console.WriteLine("No complain Yet! ...");
            }
        }
        public static void AddComplain()
        {
            string complain;
            MenuUI.ClearScreen();
            MenuUI.PrintHeader();
            Console.WriteLine("*********************************************");
            Console.WriteLine("Enter Complain: ");
            complain = Console.ReadLine();
            ComplainsCRUD.StoreNewComplain("", complain); // !!!!!!!
            ComplainsCRUD.AddComplainToList(complain);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("For Further Help                                                   ");
            Console.WriteLine("Contact us:                                                        ");
            Console.WriteLine("+92 0300 123456789 Or +92 0310 123456789                           ");
            Console.WriteLine();
            Console.WriteLine("ThankYou                                                           ");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue:...");
            Console.ReadKey();
        }
        public static void RemoveComplain()
        {
            if (ComplainsCRUD.GetComplains().Count != 0)
            {
                int ComplainIndex;
                MenuUI.ClearScreen();
                MenuUI.PrintHeader();
                Console.WriteLine("*********************************************");
                Console.WriteLine("Enter Complain No. ");
                ComplainIndex = int.Parse(Console.ReadLine());
                ComplainIndex = ComplainIndex - 1;
                ComplainsCRUD.RemoveComplainsFromList(ComplainIndex);
                ComplainsCRUD.StoreComplains("");
                Console.WriteLine();
                Console.WriteLine("Complain Removed Successfully!...");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue:...");
                Console.ReadKey();
            }
        }
    }
}
