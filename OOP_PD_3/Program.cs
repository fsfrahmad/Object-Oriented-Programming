using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace OOP_PD_2_BusinessApplication
{
    class Program
    {
        public static int announcementsNo = 0;
        public static int loan = 0;
        public static int startSeat = 1;        // it is start seat of a Train.
        public static int availableSeats = 100; // It indicates total no of seats of a Train.
        public static int recommendationsNo = 0;    // This Array contains current index of Recommendations.
        public static int complainsNo = 0;          // This shows current index of Complain.
        public class MyUser
        {
            public MyUser()
            {
                name = "";
                password = "";
                role = "";
            }
            public MyUser(string name)
            {
                this.name = name;
            }
            public MyUser(string name, string password)
            {
                this.name = name;
                this.password = password;
            }
            public MyUser(string name, string password, string role)
            {
                this.name = name;
                this.password = password;
                this.role = role;
            }

            public string name;
            public string password;
            public string role;
        }
        public class TrainInfo
        {
            public string no;
            public string path;
            public string fair;
            public string timing;
        }
        static void Main(string[] args)
        {
            RailwayManagentSystem();
            Console.ReadKey();
        }
        public static void RailwayManagentSystem()
        {
            List<MyUser> Users = new List<MyUser>();
            List<TrainInfo> Trains = new List<TrainInfo>();
            List<string> Recommendations = new List<string>();
            List<string> Announcements = new List<string>();
            List<string> Complains = new List<string>();
            ClearScreen();
            Welcome();
            LoadData(Users);
            LoadTrains(Trains);
            LoadRecommendations(Recommendations);
            LoadComplains(Complains);
            LoadAnnouncements(Announcements);
            for (int i = 0; i < Users.Count; i++)
            {
                Console.WriteLine(Users[i].name + "\t" + Users[i].password + "\t" + Users[i].role);
            }
            Console.ReadKey();
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
                    string role = CheckRole(name, password, Users);

                    if (role == "admin" || role == "Admin")
                    {
                        while (true)
                        {
                            ClearScreen();
                            PrintHeader();
                            Console.WriteLine("Hello Admin");

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
                                bool isAvailable = CheckTrain(TrainNo, Trains);
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
                                    TrainInfo item = new TrainInfo
                                    {
                                        no = TrainNo,
                                        path = TrainPath,
                                        fair = TrainFare,
                                        timing = TrainTiming
                                    };
                                    Trains.Add(item);
                                    StoreNewTrain(TrainNo, TrainPath, TrainFare, TrainTiming);
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
                                DisplayTrains(Trains);
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.ReadKey();
                            }
                            else if (adminMenu == 3)
                            {
                                while (true)
                                {
                                    string TrainNo;
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
                                        bool isAvailable = CheckTrain(TrainNo, Trains);
                                        Console.WriteLine();
                                        if (isAvailable == true)
                                        {
                                            int TrainIndex = SearchTrain(TrainNo, Trains);
                                            Console.WriteLine("Previous Path is:  " + Trains[TrainIndex].path);
                                            Console.WriteLine("Enter New Path: ");
                                            Trains[TrainIndex].path = Console.ReadLine();
                                            StoreTrains(Trains);
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
                                        bool isAvailable = CheckTrain(TrainNo, Trains);
                                        Console.WriteLine();
                                        if (isAvailable == true)
                                        {
                                            int TrainIndex = SearchTrain(TrainNo, Trains);
                                            Console.WriteLine("Previous Fare is:  " + Trains[TrainIndex].fair);
                                            Console.WriteLine("Enter New Fare: ");
                                            Trains[TrainIndex].fair = Console.ReadLine();
                                            StoreTrains(Trains);
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
                                        bool isAvailable = CheckTrain(TrainNo, Trains);
                                        Console.WriteLine();
                                        if (isAvailable == true)
                                        {
                                            int TrainIndex = SearchTrain(TrainNo, Trains);
                                            Console.WriteLine("Previous Timing is:  " + Trains[TrainIndex].timing);
                                            Console.WriteLine("Enter New Timing: ");
                                            Trains[TrainIndex].timing = Console.ReadLine();
                                            StoreTrains(Trains);
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
                                Console.WriteLine("UserName" + "\t" + "UserPassword" + "\t\t" + "UserRole");
                                for (index = 0; index < Users.Count; index++)
                                {
                                    if (Users[index].role == "Passenger")
                                    {
                                        Console.WriteLine(Users[index].name + "\t\t" + Users[index].password + "\t\t\t" + Users[index].role);
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
                                DisplayRecommendations(Recommendations);
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.ReadKey();
                            }
                            else if (adminMenu == 6)
                            {
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Your Announcements are:                      ");
                                Console.WriteLine();
                                DisplayAnnouncements(Announcements);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.ReadKey();
                            }
                            else if (adminMenu == 7)
                            {
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                DisplayComplains(Complains);
                                Console.WriteLine();
                                Console.WriteLine("Press any key to continue:...");
                                Console.ReadKey();
                            }
                            else if (adminMenu == 8)
                            {
                                ClearScreen();
                                PrintHeader();
                                string item;
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Announcement No " + announcementsNo + 1 + " : ");
                                item = Console.ReadLine();
                                Console.WriteLine();
                                AddNewAnnouncements(item);
                                Announcements.Add(item);
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
                                    int announcementIndex;
                                    ClearScreen();
                                    PrintHeader();
                                    Console.WriteLine("*********************************************");
                                    Console.WriteLine("Enter announcements No. ");
                                    announcementIndex = int.Parse(Console.ReadLine());
                                    announcementIndex = announcementIndex - 1;
                                    Announcements.RemoveAt(announcementIndex);
                                    StoreAnnouncements(Announcements);
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
                                    Announcements[announcemnetIndex] = Console.ReadLine();
                                    StoreAnnouncements(Announcements);
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
                                bool isAvailable = CheckTrain(TrainNo, Trains);
                                Console.WriteLine();
                                if (isAvailable == true)
                                {
                                    int TrainIndex = SearchTrain(TrainNo, Trains);
                                    Trains.RemoveAt(TrainIndex);
                                    StoreTrains(Trains);
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
                                MyUser newUser = takeInputWithRole("Admin");
                                bool isFound = CheckAccount(name, password, Users);
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
                                    MyUser item = new MyUser
                                    {
                                        name = name,
                                        password = password,
                                        role = role
                                    };
                                    Users.Add(item);
                                    storeDataInFile(newUser);
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
                                int availableTrains = DisplaysTrainAccordingToPath(TrainPath, Trains);
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
                                    bool isAvailable = CheckTrain(TrainNo, Trains);
                                    Console.WriteLine();
                                    if (isAvailable == true)
                                    {
                                        string confirmation;
                                        int TrainIndex = SearchTrain(TrainNo, Trains);
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
                                                Console.WriteLine(Trains[TrainIndex].no + "\t" + Trains[TrainIndex].path + "\t\t" + Trains[TrainIndex].fair + "\t" + Trains[TrainIndex].timing + "\t" + startSeat);
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
                                DisplayTrains(Trains);
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
                                int TrainIndex = SearchTrain(TrainNo, Trains);
                                Console.WriteLine("Searched Trains are: ");
                                Console.WriteLine();
                                Console.WriteLine("TrainNo" + "\t" + "Train Path" + "\t\t" + "Train Fare" + "\t" + "Train Timing");
                                Console.WriteLine(Trains[TrainIndex].no + "\t" + Trains[TrainIndex].path + "\t\t" + Trains[TrainIndex].fair + "\t" + Trains[TrainIndex].timing);

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
                                    DisplayAnnouncements(Announcements);
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
                                string recomendation;
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Enter Recommendation: ");
                                recomendation = Console.ReadLine();
                                StoreRecommendations(recomendation);
                                Recommendations.Add(recomendation);
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
                                string complain;
                                ClearScreen();
                                PrintHeader();
                                Console.WriteLine("*********************************************");
                                Console.WriteLine("Enter Complain: ");
                                complain = Console.ReadLine();
                                StoreComplains(complain);
                                Complains.Add(complain);
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
                    bool isFound = CheckAccount(name, password, Users);
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
                        MyUser NewUser = takeInputWithRole(role);
                        Users.Add(NewUser);
                        storeDataInFile(NewUser);
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
        public static MyUser takeInputWithoutRole()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                MyUser user = new MyUser(name, password);
                return user;
            }
            return null;
        }
        public static MyUser takeInputWithRole(string role1)
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Role: ");
            string role = role1;
            if (name != null && password != null && role != null)
            {
                MyUser user = new MyUser(name, password, role);
                return user;
            }
            return null;
        }
        public static void storeDataInList(List<MyUser> users, MyUser user)
        {
            users.Add(user);
        }
        public static void LoadData(List<MyUser> Users)
        {
            string record;
            StreamReader file = new StreamReader("E:\\OOPs\\Lab01\\OOP PD 1\\records.txt");
            while ((record = file.ReadLine()) != null)
            {
                MyUser item = new MyUser
                {
                    name = Getfield(record, 1),
                    password = Getfield(record, 2),
                    role = Getfield(record, 3)
                };
                Users.Add(item);
            }
            file.Close();
        }
        public static void storeDataInFile(MyUser user)
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\records.txt", true);
            file.WriteLine(user.name + "," + user.password + "," + user.role);
            file.Flush();
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
        public static bool CheckAccount(string name, string password, List<MyUser> Users)
        {
            int foundIndex = -1;
            for (int index = 0; index < Users.Count; index++)
            {
                if (name == Users[index].name && password == Users[index].password)
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
        public static string CheckRole(string name, string password, List<MyUser> Users)
        {
            int foundIndex = -1;
            for (int index = 0; index < Users.Count; index++)
            {
                if (name == Users[index].name && password == Users[index].password)
                {
                    foundIndex = index;
                    break;
                }
            }
            if (foundIndex != -1)
            {
                return Users[foundIndex].role;
            }
            else
            {
                return "Undefined";
            }
        }
        public static void LoadTrains(List<TrainInfo> Trains)
        {
            string line;
            StreamReader file = new StreamReader("E:\\OOPs\\Lab01\\OOP PD 1\\Trains.txt");
            while ((line = file.ReadLine()) != null)
            {
                TrainInfo item = new TrainInfo
                {
                    no = Getfield(line, 1),
                    path = Getfield(line, 2),
                    fair = Getfield(line, 3),
                    timing = Getfield(line, 4)
                };
                Trains.Add(item);
            }
            file.Close();
        }
        public static void StoreTrains(List<TrainInfo> Trains)
        {
            int count = 1;
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\Trains.txt");
            for (int index = 0; index < Trains.Count; index++)
            {
                if (Trains[index].no != " " && Trains[index].no != "")
                {
                    if (count != 1)
                    {
                        file.WriteLine();
                    }
                    file.Write(Trains[index].no + "," + Trains[index].path + "," + Trains[index].fair + "," + Trains[index].timing);
                    file.Flush();
                    count++;
                }
            }
            file.Close();
        }
        public static bool CheckTrain(string TrainNo, List<TrainInfo> Trains)
        {
            int isFound = -1;
            for (int index = 0; index < Trains.Count; index++)
            {
                if (TrainNo == Trains[index].no)
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
        public static void DisplayTrains(List<TrainInfo> Trains)
        {
            Console.WriteLine("TrainNo" + "\t" + "Train Path" + "\t\t" + "Train Fare" + "\t" + "Train Timing");
            for (int index = 0; index < Trains.Count; index++)
            {
                if (Trains[index].no != " ")
                {
                    Console.WriteLine(Trains[index].no + "\t" + Trains[index].path + "\t\t" + Trains[index].fair + "\t" + Trains[index].timing);
                }
            }
        }
        public static void StoreNewTrain(string TrainNo, string TrainPath, string TrainFare, string TrainTiming)
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\Trains.txt", true);
            file.WriteLine();
            file.WriteLine(TrainNo + "," + TrainPath + "," + TrainFare + "," + TrainTiming);
            file.Close();
        }
        public static int SearchTrain(string TrainNo, List<TrainInfo> Trains)
        {
            for (int index = 0; index < Trains.Count; index++)
            {
                if (TrainNo == Trains[index].no)
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
        public static void LoadComplains(List<string> Complains)
        {
            string item;
            StreamReader file = new StreamReader("E:\\OOPs\\Lab01\\OOP PD 1\\Complains.txt");
            while ((item = file.ReadLine()) != null)
            {
                Complains.Add(item);
            }
            file.Close();
        }
        public static void LoadRecommendations(List<string> Recommendations)
        {
            string item;
            StreamReader file = new StreamReader("E:\\OOPs\\Lab01\\OOP PD 1\\Recommendations.txt");
            while ((item = file.ReadLine()) != null)
            {
                Recommendations.Add(item);
            }
            file.Close();
        }
        public static void StoreComplains(string Complain)
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\Complains.txt", true); // append!!
            file.WriteLine();
            file.Write(Complain);
            file.Flush();
            file.Close();
        }
        public static void StoreRecommendations(string Recommendation)
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\Recommendations.txt", true); // append!!
            file.WriteLine();
            file.Write(Recommendation);
            file.Flush();
            file.Close();
        }
        public static void DisplayRecommendations(List<string> Recommendations)
        {
            int loopCount = 0;
            for (int index = 0; index < Recommendations.Count; index++)
            {
                Console.WriteLine("Recommendation No " + (index + 1) + " : " + Recommendations[index]);
                loopCount++;
                recommendationsNo++;
            }
            if (loopCount == 0)
            {
                Console.WriteLine("No recommendations Yet! ...");
            }
        }
        public static void DisplayComplains(List<string> Complains)
        {
            int loopCount = 0;
            for (int index = 0; index < Complains.Count; index++)
            {
                Console.WriteLine("Complain No " + (index + 1) + " : " + Complains[index]);
                loopCount++;
                complainsNo++;
            }
            if (loopCount == 0)
            {
                Console.WriteLine("No complains Yet! ...");
            }
        }
        public static void DisplayAnnouncements(List<string> Announcements)
        {
            for (int index = 0; index < Announcements.Count; index++)
            {
                if (Announcements[index] != " ")
                {
                    Console.WriteLine("Announcements No." + (index + 1) + " : " + Announcements[index]);
                }
            }
        }
        public static void LoadAnnouncements(List<string> Announcements)
        {
            string item;
            StreamReader file = new StreamReader("E:\\OOPs\\Lab01\\OOP PD 1\\Announcements.txt");
            while ((item = file.ReadLine()) != null)
            {
                Announcements.Add(item);
                announcementsNo++;
            }
            file.Close();
        }
        public static void StoreAnnouncements(List<string> Announcements)
        {
            int count = 0;
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\Announcements.txt");
            for (int index = 0; index < Announcements.Count; index++)
            {
                if (Announcements[index] != " " && Announcements[index] != "")
                {
                    if (count != 0)
                    {
                        file.WriteLine();
                    }
                    file.Write(Announcements[index]);
                    count++;
                }
            }
            file.Flush();
            file.Close();
        }
        public static void AddNewAnnouncements(string Announcement)
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\Announcements.txt", true);
            file.WriteLine();
            file.Write(Announcement);
            file.Flush();
            file.Close();
        }
        public static int DisplaysTrainAccordingToPath(string TrainPath, List<TrainInfo> Trains)
        {
            int count = 0;
            Console.WriteLine("All available Trains for given Route are:");
            Console.WriteLine();
            Console.WriteLine("TrainNo" + "\t" + "Train Path" + "\t\t" + "Train Fare" + "\t" + "Train Timing");
            for (int index = 0; index < Trains.Count; index++)
            {
                if (TrainPath == Trains[index].path)
                {
                    Console.WriteLine(Trains[index].no + "\t" + Trains[index].path + "\t\t" + Trains[index].fair + "\t" + Trains[index].timing);
                    count++;
                }
            }
            return count;
        }
        

    }
}

