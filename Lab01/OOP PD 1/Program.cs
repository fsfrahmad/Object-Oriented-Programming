using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace OOP_PD_1
{
    class Program
    {
        public static string[] userName = new string[1000];     // This Arrays stores Names of All Users
        public static string[] userPassword = new string[1000]; // This Array stores passwords of All Users
        public static string[] userRole = new string[1000];     // This Array contains roles of All Users
        public static int count = 0;
         
        public static string[] TrainNoArray = new string[1000];
        public static string[] TrainPathArray = new string[1000];
        public static string[] TrainFairArray = new string[1000];
        public static string[] TrainTimingArray = new string[1000];
        public static int TrainCount = 0;
         
        public static string[] recommendations = new string[1000]; // This Array contains Recommendations of users.
        public static string[] complains = new string[1000];       // This array contains complains of All Passengers.
        public static int recommendationsNo = 0;    // This Array contains current index of Recommendations.
        public static int complainsNo = 0;          // This shows current index of Complain.
         
        public static string[] announcements = new string[1000]; // This Array contains all announcements added by Admin of the System.
        public static int announcementsNo = 0;    // This shows the current index of Announcements Arrays.
         
        public static int startSeat = 1;        // it is start seat of a Train.
        public static int availableSeats = 100; // It indicates total no of seats of a Train.
        public static int loan = 0;
        static void Main(string[] args)
        {
            RailwayManagementSystem();
        }
        public static void RailwayManagementSystem()
        {
            ClearScreen();
            Welcome();
            LoadData();
            LoadTrains();
            LoadRecommendations();
            LoadComplains();
            LoadAnnouncements();
            while (true)
            {
                ClearScreen();
                PrintHeader();
                int option = Login();
                if (option == 1)
                {
                    ClearScreen();
                    PrintHeader();
                    Console.WriteLine("*********************************************");
                    Console.WriteLine();
                    Console.WriteLine("User Login: ");
                    Console.WriteLine();
                    string name;
                    string password;

                    Console.WriteLine("Enter user name: ");
                    name = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter Password: ");
                    password = Console.ReadLine();
                    string role = CheckRole(name, password);

                    if (role == "admin" || role == "Admin")
                    {
                        while(true)
                        {
                            ClearScreen();
                            PrintHeader();
                            Console.WriteLine("Hello Admin" );

                            int adminMenu = PrintAdminInterfaces();
                            if (adminMenu == 1)
                            {
                                ClearScreen();
                                PrintHeader();
                                string TrainNo;
                                string TrainPath;
                                string TrainFare;
                                string TrainTiming;
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Enter Train number:                          ");
                                TrainNo = Console.ReadLine();
                                bool isAvailable = CheckTrain(TrainNo);
                                Console.WriteLine();
                                if (isAvailable == true)
                                {
                                    Console.WriteLine("Train Already Exist!!!");
                                    Console.WriteLine("Enter any key to continue:...");
                                    Console.ReadKey();
                                }
                                else if (isAvailable == false)
                                {
                                    Console.WriteLine("Enter Train Path:                            ");
                                    TrainPath = Console.ReadLine();
                                    Console.WriteLine("Enter Train Fare:                            ");
                                    TrainFare = Console.ReadLine();
                                    Console.WriteLine("Enter Train Timing(eg, 6:00 a.m.):           ");
                                    TrainTiming = Console.ReadLine();
                                    Console.WriteLine();
                                    TrainNoArray[TrainCount] = TrainNo;
                                    TrainPathArray[TrainCount] = TrainPath;
                                    TrainFairArray[TrainCount] = TrainFare;
                                    TrainTimingArray[TrainCount] = TrainTiming;
                                    StoreNewTrain();
                                    TrainCount++;
                                    Console.WriteLine("Train Added Successfully");
                                    Console.WriteLine("Press any key to continue:...");
                                    Console.ReadKey();
                                }
                            }
                            else if (adminMenu == 2)
                            {
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine();
                                Console.WriteLine("All available Trains are: ");
                                Console.WriteLine();
                                DisplayTrains();
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.ReadKey();
                            }
                            else if (adminMenu == 3)
                            {
                                while (true)
                                {
                                    string TrainNo;
                                    string TrainPath;
                                    string TrainTiming;
                                    string TrainFare;
                                    ClearScreen();
                                    PrintHeader();
                                    int UpdateOption = UpdateTrainInfo();
                                    if (UpdateOption == 1)
                                    {
                                        ClearScreen();
                                        PrintHeader();
                                        Console.WriteLine("*********************************************");
                                        Console.WriteLine("Enter Train number:                          ");
                                        TrainNo = Console.ReadLine();
                                        Console.WriteLine();
                                        bool isAvailable = CheckTrain(TrainNo);
                                        Console.WriteLine();
                                        if (isAvailable == true)
                                        {
                                            int TrainIndex = SearchTrain(TrainNo);
                                            Console.WriteLine("Previous Path is:  " + TrainPathArray[TrainIndex]);
                                            Console.WriteLine("Enter New Path: ");
                                            TrainPath = Console.ReadLine();
                                            TrainPathArray[TrainIndex] = TrainPath;
                                            StoreTrains();
                                            Console.WriteLine();
                                            Console.WriteLine("Train Path Updated Successfully!");
                                            Console.WriteLine();
                                            Console.WriteLine("Press any key to continue:...");
                                            Console.ReadKey();
                                        }
                                        else if (isAvailable == false)
                                        {
                                            Console.WriteLine("Train does not exists!!!");
                                            Console.WriteLine();
                                            Console.WriteLine("Press any key to continue:...");
                                            Console.ReadKey();
                                        }
                                    }
                                    else if (UpdateOption == 2)
                                    {
                                        ClearScreen();
                                        PrintHeader();
                                        Console.WriteLine("*********************************************");
                                        Console.WriteLine("Enter Train number:                          ");
                                        TrainNo = Console.ReadLine();
                                        Console.WriteLine();
                                        bool isAvailable = CheckTrain(TrainNo);
                                        Console.WriteLine();
                                        if (isAvailable == true)
                                        {
                                            int TrainIndex = SearchTrain(TrainNo);
                                            Console.WriteLine("Previous Fare is:  " + TrainFairArray[TrainIndex]);
                                            Console.WriteLine("Enter New Fare: ");
                                            TrainFare = Console.ReadLine();
                                            TrainFairArray[TrainIndex] = TrainFare;
                                            StoreTrains();
                                            Console.WriteLine();
                                            Console.WriteLine("Train Fare Updated Successfully!");
                                            Console.WriteLine();
                                            Console.WriteLine("Press any key to continue:...");
                                            Console.ReadKey();
                                        }
                                        else if (isAvailable == false)
                                        {
                                            Console.WriteLine("Train does not exists!!!");
                                            Console.WriteLine();
                                            Console.WriteLine("Press any key to continue:...");
                                            Console.ReadKey();
                                        }
                                    }
                                    else if (UpdateOption == 3)
                                    {
                                        ClearScreen();
                                        PrintHeader();
                                        Console.WriteLine("*********************************************");
                                        Console.WriteLine("Enter Train number:                          ");
                                        TrainNo = Console.ReadLine();
                                        Console.WriteLine();
                                        bool isAvailable = CheckTrain(TrainNo);
                                        Console.WriteLine();
                                        if (isAvailable == true)
                                        {
                                            int TrainIndex = SearchTrain(TrainNo);
                                            Console.WriteLine("Previous Timing is:  " + TrainTimingArray[TrainIndex]);
                                            Console.WriteLine("Enter New Timing: ");
                                            TrainTiming = Console.ReadLine();
                                            TrainTimingArray[TrainIndex] = TrainTiming;
                                            StoreTrains();
                                            Console.WriteLine();
                                            Console.WriteLine("Train Time Updated Successfully!");
                                            Console.WriteLine();
                                            Console.WriteLine("Press any key to continue:...");
                                            Console.ReadKey();
                                        }
                                        else if (isAvailable == false)
                                        {
                                            Console.WriteLine("Train does not exists!!!");
                                            Console.WriteLine();
                                            Console.WriteLine("Press any key to continue:...");
                                            Console.ReadKey();
                                        }
                                    }
                                    else if (UpdateOption == 4)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter valid Option!!!");
                                        Console.WriteLine();
                                        Console.WriteLine("Press any key to continue:...");
                                        Console.ReadKey();
                                    }
                                }
                            }
                            else if (adminMenu == 4)
                            {
                                int index;
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine();
                                Console.WriteLine("Following Users are using the Application: ");
                                Console.WriteLine();
                                Console.WriteLine("UserName" + "\t" + "UserPassword" + "\t" + "UserRole");
                                for (index = 0; index < count; index++)
                                {
                                    if (userRole[index] == "Passenger")
                                    {
                                        Console.WriteLine(userName[index] + "\t" + userPassword[index] + "\t" + userRole[index]);
                                    }
                                }
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.ReadKey();
                            }
                            else if (adminMenu == 5)
                            {
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                DisplayRecommendations();
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.ReadKey();
                            }
                            else if (adminMenu == 6)
                            {
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************" );
                                Console.WriteLine("Your Announcements are:                      " );
                                Console.WriteLine();
                                DisplayAnnouncements();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:..." );
                                Console.ReadKey();
                            }
                            else if (adminMenu == 7)
                            {
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************" );
                                DisplayComplains();
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:..." );
                                Console.ReadKey();
                            }
                            else if (adminMenu == 8)
                            {
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Announcement No " + announcementsNo + 1 + " : ");
                                announcements[announcementsNo] = Console.ReadLine();
                                Console.WriteLine();
                                AddNewAnnouncements();
                                Console.WriteLine("Announcements Added Successfully!...");
                                announcementsNo++;
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.ReadKey();
                            }
                            else if (adminMenu == 9)
                            {
                                if (announcementsNo != 0)
                                {
                                    int announcemnetIndex;
                                    ClearScreen();
                                    PrintHeader();
                                    Console.WriteLine("*********************************************");
                                    Console.WriteLine("Enter announcements No. ");
                                    announcemnetIndex = int.Parse(Console.ReadLine());
                                    announcemnetIndex = announcemnetIndex - 1;
                                    announcements[announcemnetIndex] = " ";
                                    StoreAnnouncements();
                                    Console.WriteLine();
                                    Console.WriteLine("Announcements Removed Successfully!...");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue:...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    ClearScreen();
                                    PrintHeader();
                                    Console.WriteLine("No Announcements Yet!!!...");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue:...");
                                    Console.ReadKey();
                                }
                            }
                            else if (adminMenu == 10)
                            {
                                if (announcementsNo != 0)
                                {
                                    int announcemnetIndex;
                                    ClearScreen();
                                    PrintHeader();
                                    Console.WriteLine("*********************************************");
                                    Console.WriteLine("Enter announcements No. ");
                                    announcemnetIndex = int.Parse(Console.ReadLine());
                                    announcemnetIndex = announcemnetIndex - 1;
                                    Console.WriteLine("Enter Announcement : ");
                                    announcements[announcemnetIndex] = Console.ReadLine();
                                    StoreAnnouncements();
                                    Console.WriteLine();
                                    Console.WriteLine("Announcements Updated Successfully!...");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue:...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    ClearScreen();
                                    PrintHeader();
                                    Console.WriteLine("No Announcements Yet!!!...");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue:...");
                                    Console.ReadKey();
                                }
                            }
                            else if (adminMenu == 11)
                            {
                                string TrainNo;
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Enter Train number:                  ");
                                TrainNo = Console.ReadLine();
                                Console.WriteLine();
                                bool isAvailable = CheckTrain(TrainNo);
                                Console.WriteLine();
                                if (isAvailable == true)
                                {
                                    int TrainIndex = SearchTrain(TrainNo);
                                    TrainNoArray[TrainIndex] = " ";
                                    TrainPathArray[TrainIndex] = " ";
                                    TrainFairArray[TrainIndex] = " ";
                                    TrainTimingArray[TrainIndex] = " ";
                                    StoreTrains();
                                    Console.WriteLine("Train Removed Succesfully.                   ");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue:...");
                                    Console.ReadKey();
                                }
                                else if (isAvailable == false)
                                {
                                    Console.WriteLine("Train does not exists!!!");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue:...");
                                    Console.ReadKey();
                                }
                            }
                            else if (adminMenu == 12)
                            {
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine();
                                Console.WriteLine("ADD ADMIN:");
                                Console.WriteLine();
                                Console.WriteLine("Enter Admin Name:                            ");
                                name = Console.ReadLine();
                                Console.WriteLine("Enter Password:                              ");
                                password = Console.ReadLine();
                                role = "Admin";
                                bool isFound = CheckAccount(name, password);
                                if (isFound == true)
                                {
                                    Console.WriteLine("UserName already exists.");
                                    Console.WriteLine("Please Try Again.");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    userName[count] = name;
                                    userPassword[count] = password;
                                    userRole[count] = role;
                                    StoreData();
                                    count++;
                                    Console.WriteLine("Account created successfully!");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                            }
                            else if (adminMenu == 13)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Enter Valid Option!!!");
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.WriteLine();
                            }
                        }
                    }
                    else if (role == "passenger" || role == "Passenger")
                    {
                        while (true)
                        {
                            ClearScreen();
                            PrintHeader();
                            Console.WriteLine("Hello Passenger!!!");
                            int userMenu = PrintUserInterfaces();
                            if (userMenu == 1)
                            {
                                string TrainPath;
                                string TrainNo;

                                int seat;
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Enter Train route(Enter complete path e.g. lahore-to-faisalabad): ");
                                TrainPath = Console.ReadLine();
                                int availableTrains = DisplaysTrainAccordingToPath(TrainPath);
                                if (availableTrains == 0)
                                {
                                    Console.WriteLine("No Train Exists for given path.");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    Console.WriteLine("Enter Train Number: ");
                                    TrainNo = Console.ReadLine();
                                    bool isAvailable = CheckTrain(TrainNo);
                                    Console.WriteLine();
                                    if (isAvailable == true)
                                    {
                                        string confirmation;
                                        int TrainIndex = SearchTrain(TrainNo);
                                        Console.WriteLine("All available seats are: " + availableSeats);
                                        Console.WriteLine("Enter Number of Seats: ");
                                        seat = int.Parse(Console.ReadLine());
                                        availableSeats = availableSeats - seat;
                                        Console.WriteLine("Confirmation(confirm): ");
                                        confirmation = Console.ReadLine();
                                        if (confirmation == "confirm" || confirmation == "confirm")
                                        {
                                            Console.WriteLine("Your E-Ticket is: ");

                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine("TrainNo" + "\t" + "Train Path" + "\t\t" + "Train Fare" + "\t" + "Train Timing" + "\t" + "Seat no");
                                            for (int start = 1; start <= seat; start++)
                                            {
                                                Console.WriteLine(TrainNoArray[TrainIndex] + "\t" + TrainPathArray[TrainIndex] + "\t\t" + TrainFairArray[TrainIndex] + "\t" + TrainTimingArray[TrainIndex] + "\t" + startSeat);
                                                startSeat++;
                                            }
                                            Console.WriteLine();
                                            Console.WriteLine("Enter any key to continue:...");
                                            Console.ReadKey();
                                        }
                                    }
                                    else if (isAvailable == false)
                                    {
                                        Console.WriteLine("Train Does not Exists!!!");
                                        Console.WriteLine();
                                        Console.WriteLine("Enter any key to continue:...");
                                        Console.ReadKey();
                                    }
                                }
                            }
                            else if (userMenu == 2)
                            {
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine();
                                Console.WriteLine("All available Trains are: ");
                                Console.WriteLine();
                                DisplayTrains();
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.ReadKey();
                            }
                            else if (userMenu == 3)
                            {
                                string TrainNo;
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine();
                                Console.WriteLine("Enter Train Number: ");
                                TrainNo = Console.ReadLine();
                                int TrainIndex = SearchTrain(TrainNo);
                                Console.WriteLine("Searched Trains are: ");
                                Console.WriteLine();
                                Console.WriteLine("TrainNo" + "\t" + "Train Path" + "\t\t" + "Train Fare" + "\t" + "Train Timing");
                                Console.WriteLine(TrainNoArray[TrainIndex] + "\t" + TrainPathArray[TrainIndex] + "\t\t" + TrainFairArray[TrainIndex] + "\t" + TrainTimingArray[TrainIndex]);

                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.ReadKey();
                            }
                            else if (userMenu == 4)
                            {
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine();
                                if (announcementsNo != 0)
                                {
                                    DisplayAnnouncements();
                                }
                                else
                                {
                                    Console.WriteLine("No Announcements Yet!!!...");
                                }
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
                            else if (userMenu == 5)
                            {
                                int seat;
                                string TrainNo;
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Enter Train no: ");
                                TrainNo = Console.ReadLine();
                                Console.WriteLine("Enter the number of Seats: ");
                                seat = int.Parse(Console.ReadLine());
                                startSeat = startSeat - seat;
                                availableSeats = availableSeats + seat;
                                Console.WriteLine();
                                Console.WriteLine("Ticket canceled Successfully.");
                                Console.WriteLine();
                                Console.WriteLine("ThankYou                                                           ");
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.ReadKey();
                            }
                            else if (userMenu == 6)
                            {
                                string checkPassword;
                                int amount;
                                string confirm;
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Enter Loan amount(From 1000 to 10000): Rs. ");
                                amount = int.Parse(Console.ReadLine());
                                if (amount >= 1000 && amount <= 10000)
                                {
                                    Console.WriteLine("Enter password: ");
                                    checkPassword = Console.ReadLine();
                                    if (password == checkPassword)
                                    {
                                        Console.WriteLine("The interest Rate is 0%.                        ");
                                        Console.WriteLine("Return within 30 days.                          ");
                                        Console.WriteLine("Confirmation(confirm: ");
                                        confirm = Console.ReadLine();

                                        if (confirm == "confirm")
                                        {
                                            loan = amount;
                                            Console.WriteLine("Money Transfered to your Account Succesfully.   ");
                                            Console.WriteLine("*********************************************   ");
                                            Console.WriteLine();
                                            Console.WriteLine("Press any key to continue:...");
                                            Console.ReadKey();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wrong Password!!!.");
                                        Console.WriteLine();
                                        Console.WriteLine("Press any key to continue:...");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Enter Valid Amount>> !!!!");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue:...");
                                    Console.ReadKey();
                                }
                            }
                            else if (userMenu == 7)
                            {
                                int amount;
                                string confirmation;
                                string checkPassword;
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Loan to be returned: " + loan);
                                if (loan != 0)
                                {
                                    Console.WriteLine("Enter amount: Rs. ");
                                    amount = int.Parse(Console.ReadLine());
                                    if (amount <= loan)
                                    {
                                        Console.WriteLine("Enter Password: ");
                                        checkPassword = Console.ReadLine();
                                        if (checkPassword == password)
                                        {
                                            Console.WriteLine("Confirmation(confirm): ");
                                            confirmation = Console.ReadLine();
                                            if (confirmation == "confirm")
                                            {
                                                loan = loan - amount;
                                                Console.WriteLine("Remianing loan is Rs. " + loan);
                                                Console.WriteLine("Money Recieved Succesfully. Thankyou.           ");
                                                Console.WriteLine("*********************************************   ");
                                                Console.WriteLine();
                                                Console.WriteLine("Press any key to continue:...");
                                                Console.ReadKey();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Password is Incorrect!!! ");
                                            Console.WriteLine();
                                            Console.WriteLine("Press any key to continue:...");
                                            Console.ReadKey();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Amount cannot be greater than loan. ");
                                        Console.WriteLine();
                                        Console.WriteLine("Press any key to continue:...");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You have not taken any loan. ");
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to continue:...");
                                    Console.ReadKey();
                                }
                            }
                            else if (userMenu == 8)
                            {
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Pakistan Railway Management system is a business application       ");
                                Console.WriteLine("to help passengers book tickets, search trains, see shedules of    ");
                                Console.WriteLine("trains, and cancel a booking. If you are have any recommendations  ");
                                Console.WriteLine("and complains you an also tell us.                                 ");
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
                            else if (userMenu == 9)
                            {
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Enter Recommendation: ");
                                recommendations[recommendationsNo] = Console.ReadLine();
                                StoreRecommendations();
                                recommendationsNo++;
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
                            else if (userMenu == 10)
                            {
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Enter Complain: ");
                                complains[complainsNo] = Console.ReadLine();
                                StoreComplains();
                                complainsNo++;
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("For Further Help                                                   ");
                                Console.WriteLine("Contact us:                                                        ");
                                Console.WriteLine("+92 0300 123456789 Or +92 0310 123456789                           ");
                                Console.WriteLine();
                                Console.WriteLine("ThankYou                                                           ");
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.ReadLine();
                            }
                            else if (userMenu == 11)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Enter Valid Option!!!");
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.ReadLine();
                            }
                        }
                    }
                    else if (role == "Undefined")
                    {
                        Console.WriteLine("Account does not exists.");
                        Console.WriteLine("Please Sign Up First.");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                    }
                }
                else if (option == 2)
                {
                    ClearScreen();
                    PrintHeader();
                    Console.WriteLine("*********************************************");
                    Console.WriteLine();
                    Console.WriteLine("User Login: ");
                    Console.WriteLine();
                    string name;
                    string password;
                    string role = "Passenger";

                    Console.WriteLine("Enter user name: ");
                    name = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Enter Password: ");
                    password = Console.ReadLine();
                    bool isFound = CheckAccount(name, password);
                    if (isFound == true)
                    {
                        Console.WriteLine("Account already exists.");
                        Console.WriteLine("Please Sign In.");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        userName[count] = name;
                        userPassword[count] = password;
                        userRole[count] = role;
                        StoreData();
                        count++;
                        Console.WriteLine("Account created successfully!");
                        Console.WriteLine("Sign In Please.");
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }


                }
                else if (option == 3)
                {
                    ClearScreen();
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Valid Option!!!!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            Console.ReadKey();
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
        public static void ClearScreen()
        {
            Console.Clear();
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
        public static bool CheckAccount(string name, string password)
        {
            int foundIndex = -1;
            for (int index = 0; index < count; index++)
            {
                if (name == userName[index] && password == userPassword[index])
                {
                    foundIndex = index;
                    break;
                }
            }
            if (foundIndex != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string CheckRole(string name, string password)
        {
            int foundIndex = -1;
            for (int index = 0; index < count; index++)
            {
                if (name == userName[index] && password == userPassword[index])
                {
                    foundIndex = index;
                    break;
                }
            }
            if (foundIndex != -1)
            {
                return userRole[foundIndex];
            }
            else
            {
                return "Undefined";
            }
        }
        public static void LoadData()
        {
            string record;
            StreamReader file = new StreamReader("E:\\OOPs\\Lab01\\OOP PD 1\\records.txt");            
            while((record = file.ReadLine()) != null)
            {
                userName[count] = Getfield(record, 1);
                userPassword[count] = Getfield(record, 2);
                userRole[count] = Getfield(record, 3);
                count++;
            }
            file.Close();
        }
        public static void StoreData()
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\records.txt");
            file.WriteLine();
            file.WriteLine(userName[count] + "," + userPassword[count] + "," + userRole[count]);
            file.Close();
        }
        public static string Getfield(string record, int field)
        {
            string item = "";
            int commacount = 1;
            int size = record.Length;
            for (int idx = 0; idx < size; idx++)
            {
                if (record[idx] == ',')
                {
                    commacount++;
                }
                else if (commacount == field)
                {
                    item = item + record[idx];
                }
            }
            return item;
        }
        public static void LoadTrains()
        {
            string line;
            StreamReader file = new StreamReader("E:\\OOPs\\Lab01\\OOP PD 1\\Trains.txt");
            while((line = file.ReadLine()) != null)
            {
                TrainNoArray[TrainCount] = Getfield(line, 1);
                TrainPathArray[TrainCount] = Getfield(line, 2);
                TrainFairArray[TrainCount] = Getfield(line, 3);
                TrainTimingArray[TrainCount] = Getfield(line, 4);
                TrainCount++;
            }
            file.Close();
        }
        public static void StoreTrains()
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\Trains.txt");
            for (int index = 0; index < TrainCount; index++)
            {
                if (TrainNoArray[index] != " " && TrainNoArray[index] != "")
                {
                    file.WriteLine();
                    file.Write(TrainNoArray[index] + "," + TrainPathArray[index] + "," + TrainFairArray[index] + "," + TrainTimingArray[index]);
                }
            }
            file.Close();
        }
        public static void StoreNewTrain()
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\Trains.txt", true);
            file.WriteLine();
            file.WriteLine(TrainNoArray[TrainCount] + "," + TrainPathArray[TrainCount] + "," + TrainFairArray[TrainCount] + "," + TrainTimingArray[TrainCount]);
            file.Close();
        }
        public static bool CheckTrain(string TrainNo)
        {
            int isFound = -1;
            for (int index = 0; index < TrainCount; index++)
            {
                if (TrainNo == TrainNoArray[index])
                {
                    isFound = index;
                }
            }
            if (isFound != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void DisplayTrains()
        {
            Console.WriteLine("TrainNo" + "\t" + "Train Path" + "\t\t" + "Train Fare" + "\t" + "Train Timing");
            for (int index = 0; index < TrainCount; index++)
            {
                if (TrainNoArray[index] != " ")
                {
                    Console.WriteLine(TrainNoArray[index] + "\t" + TrainPathArray[index] + "\t\t" + TrainFairArray[index] + "\t" + TrainTimingArray[index]);
                }
            }
        }
        public static int SearchTrain(string TrainNo)
        {
            for (int index = 0; index < TrainCount; index++)
            {
                if (TrainNo == TrainNoArray[index])
                {
                    return index;
                }
            }
            return -1;
        }
        public static int UpdateTrainInfo()
        {
            int option;
            Console.WriteLine("*********************************************");
            Console.WriteLine("1. Update Train Route.                       ");
            Console.WriteLine("2. Update Train Fare.                        ");
            Console.WriteLine("3. Update Train Timing.                      ");
            Console.WriteLine("4. Exit.                                     ");
            Console.WriteLine();
            Console.WriteLine("Enter any option to continue:...");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        public static void LoadComplains()
        {
            StreamReader file = new StreamReader("E:\\OOPs\\Lab01\\OOP PD 1\\Complains.txt");
            while ((complains[complainsNo] = file.ReadLine()) != null)
            {
                complainsNo++;
            }
            file.Close();
        }
        public static void LoadRecommendations()
        {
            StreamReader file = new StreamReader("E:\\OOPs\\Lab01\\OOP PD 1\\Recommendations.txt");
            while ((recommendations[recommendationsNo] = file.ReadLine()) != null)
            {
                recommendationsNo++;
            }
            file.Close();
        }
        public static void StoreComplains()
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\Complains.txt", true); // append!!
            file.WriteLine();
            file.Write(complains[complainsNo]);
            file.Close();
        }
        public static void StoreRecommendations()
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\Recommendations.txt", true); // append!!
            file.WriteLine();
            file.Write(recommendations[recommendationsNo]);
            file.Close();
        }
        public static void DisplayRecommendations()
        {
            int loopCount = 0;
            for (int index = 0; index < recommendationsNo; index++)
            {
                Console.WriteLine("Recommendation No " + (index + 1) + " : " + recommendations[index]);
                loopCount++;
            }
            if (loopCount == 0)
            {
                Console.WriteLine("No recommendations Yet! ...");
            }
        }
        public static void DisplayComplains()
        {
            int loopCount = 0;
            for (int index = 0; index < complainsNo; index++)
            {
                Console.WriteLine("Complain No " + (index + 1) + " : " + complains[index]);
                loopCount++;
            }
            if (loopCount == 0)
            {
                Console.WriteLine("No complains Yet! ...");
            }
        }
        public static void DisplayAnnouncements()
        {
            for (int index = 0; index < announcementsNo; index++)
            {
                if (announcements[index] != " ")
                {
                    Console.WriteLine("Announcements No." + (index + 1) + " : " + announcements[index]);
                }
            }
        }
        public static void LoadAnnouncements()
        {
            StreamReader file = new StreamReader("E:\\OOPs\\Lab01\\OOP PD 1\\Announcements.txt");
            while( (announcements[announcementsNo] = file.ReadLine()) != null) 
            {
                announcementsNo++;
            }
            file.Close();
        }
        public static void StoreAnnouncements()
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\Announcements.txt");
            for (int index = 0; index < announcementsNo; index++)
            {
                if (announcements[index] != " " && announcements[index] != "")
                {
                    file.WriteLine();
                    file.Write(announcements[index]);
                }
            }
            file.Close();
        }
        public static void AddNewAnnouncements()
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\Announcements.txt", true);
            file.WriteLine();
            file.Write(announcements[announcementsNo]);
            file.Close();
        }
        public static int DisplaysTrainAccordingToPath(string TrainPath)
        {
            int count = 0;
            Console.WriteLine("All available Trains for given Route are:");
            Console.WriteLine();
            Console.WriteLine("TrainNo" + "\t" + "Train Path" + "\t\t" + "Train Fare" + "\t" + "Train Timing");
            for (int index = 0; index < TrainCount; index++)
            {
                if (TrainPath == TrainPathArray[index])
                {
                    Console.WriteLine(TrainNoArray[index] + "\t" + TrainPathArray[index] + "\t\t" + TrainFairArray[index] + "\t" + TrainTimingArray[index]);
                    count++;
                }
            }
            return count;
        }

    }
}
