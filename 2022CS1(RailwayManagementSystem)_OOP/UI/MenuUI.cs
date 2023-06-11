using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2022CS1_RailwayManagementSystem__OOP.UI
{
    public class MenuUI
    {
        public static void ClearScreen()
        {
            Console.Clear();
        }
        public static void Welcome()
        {
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("         ####       #      ####### #       #     #      #     #     #          ");
            Console.WriteLine("         #   #     # #        #    #       #     #     # #     #   #           ");
            Console.WriteLine("         #  #     #   #       #    #       #     #    #   #     # #            ");
            Console.WriteLine("         ##      #######      #    #       #  #  #   #######     #             ");
            Console.WriteLine("         # #    #       #     #    #       # # # #  #       #    #             ");
            Console.WriteLine("         #  ## #         # ####### ####### #     # #         #   #             ");
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("*******************************************************************************");
            Thread.Sleep(2000);

        }
        public static void PrintHeader()
        {
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("*             Pakistan Railways Managemet & Ticketing System                  *");
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine("*******************************************************************************");
            Console.WriteLine();
            Console.WriteLine();
        }
        public static int Login()
        {
            int option;
            Console.WriteLine("*********************************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1.Sign In.");
            Console.WriteLine("2.Sign-up(For new passenger only).");
            Console.WriteLine("3.Exit.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter any option to continue:...");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        public static int PrintAdminInterfaces()
        {
            int option;
            Console.WriteLine("*********************************************");
            Console.WriteLine("1. Add New Train.                            ");
            Console.WriteLine("2. Check Exsisting Train.                    ");
            Console.WriteLine("3. Update Train.                             ");
            Console.WriteLine("4. See Passengers.                           ");
            Console.WriteLine("5. See Recommendation and Feedbacks.         ");
            Console.WriteLine("6. See Announcements.                        ");
            Console.WriteLine("7. See Complains.                            ");
            Console.WriteLine("8. Make Announcements.                       ");
            Console.WriteLine("9. Remove Announcements.                     ");
            Console.WriteLine("10. Update Announcements.                    ");
            Console.WriteLine("11. Delete Train.                            ");
            Console.WriteLine("12. Add Admin.                               ");
            Console.WriteLine("13. Log Out.                                 ");
            Console.WriteLine();
            Console.WriteLine("Enter any option to continue:...");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        public static int PrintUserInterfaces()
        {
            int option;
            Console.WriteLine("*********************************************");
            Console.WriteLine("1. Book a Train.                             ");
            Console.WriteLine("2. View Train Shedule.                       ");
            Console.WriteLine("3. Search Train.                             ");
            Console.WriteLine("4. See Announcements.                        ");
            Console.WriteLine("5. Cancel A Booking.                         ");
            Console.WriteLine("6. Get Loan.                                 ");
            Console.WriteLine("7. Return Loan.                              ");
            Console.WriteLine("8. Get Help.                                 ");
            Console.WriteLine("9. Send Recommendations and Feedback.        ");
            Console.WriteLine("10. Add Complains.                           ");
            Console.WriteLine("11. Logout.                                  ");
            Console.WriteLine();
            Console.WriteLine("Enter any option to continue:...");
            option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
