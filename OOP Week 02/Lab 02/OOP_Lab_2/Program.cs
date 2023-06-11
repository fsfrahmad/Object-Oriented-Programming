using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OOP_Lab_2.BL;

namespace OOP_Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Challenge2();
            Console.Read();
        }
        public static void Task1()
        {
            // Student 1 Data
            students s1 = new students();
            s1.name = "Ali";
            s1.roll_no = 1;
            s1.gpa = 3.25F;
            Console.WriteLine("{0} {1} {2} ", s1.name, s1.roll_no, s1.gpa);

            // Student 2 Data 
            students s2 = new students();
            s2.name = "Bilal";
            s2.roll_no = 2;
            s2.gpa = 3.78F;
            Console.WriteLine("{0} {1} {2} ", s2.name, s2.roll_no, s2.gpa);
        }
        public static void Task2()
        {
            // Student 1 Data
            students s1 = new students();
            Console.Write("Enter Your Name: ");
            s1.name = Console.ReadLine();
            Console.Write("Enter Your Roll Number: ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.Write("Enter Your GPA: ");
            s1.gpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Name: {0} Roll # {1} GPA: {2} ", s1.name, s1.roll_no, s1.gpa);
        }
        public static void Task3()
        {
            students[] s = new students[10];
            char option;
            int count = 0;
            do
            {
                option = Menu();
                if (option == '1')
                {
                    s[count] = AddStudent();
                    count = count + 1;
                }
                else if (option == '2')
                { ViewStudents(s, count);
                }
                else if (option == '3') 
                { topStudent(s, count); 
                }
                else if (option == '4')
                {
                    break;
                } 
                else
                {
                    Console.WriteLine("Invalid Choice");
                    Console.WriteLine("Press any key to continue...........");
                    Console.ReadKey();
                }
            } while (option != '4');
            Console.WriteLine("Press Enter to Exit..");
            Console.Read();
        }
        public static char Menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press 1 for Adding a new student: ");
            Console.WriteLine("Press 2 for view students: ");
            Console.WriteLine("Press 3 for Top Three students: ");
            Console.WriteLine("Press 4 to exit: ");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        public static students AddStudent()
        {
            Console.Clear();
            students s1 = new students();
            Console.Write("Enter Name: ");
            s1.name = Console.ReadLine();
            Console.Write("Enter Roll no.: ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.Write("Enter GPA: ");
            s1.gpa = float.Parse(Console.ReadLine());
            Console.Write("Enter Department: ");
            s1.department = Console.ReadLine();
            Console.Write("Is Hostellide Y||N: ");
            s1.isHostellide = char.Parse(Console.ReadLine());
            return s1;
        }
        public static void ViewStudents(students[] s, int count)
        {
            Console.Clear();
            if(count == 0)
            {
                Console.WriteLine("No Record Yet");
            }
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Name: {0} Roll No.{1} GPA: {2} Department:{3} IsHostellide:{4}", s[i].name, s[i].roll_no, s[i].gpa, s[i].department, s[i].isHostellide);
            }
            Console.WriteLine("Press any key to continue...........");
            Console.ReadKey();
        }
        public static void topStudent(students[] s, int count)
        {
            Console.Clear(); 
            if (count == 0)
            {
                Console.WriteLine("No Record Present");
            }
            else if (count == 1)
            {
                ViewStudents(s, 1);
            }
            else if (count == 2) 
            { 
                for (int x = 0; x < 2; x++)
                { 
                    int index = Largest(s, x, count); 
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp; 
                }
                ViewStudents(s, 2); 
            }
            else
            {
                for (int x = 0; x < 3; x++)
                {
                    int index = Largest(s, x, count); students temp = s[index]; s[index] = s[x]; s[x] = temp;
                }
                ViewStudents(s, 3);
            }
        }
        public static int Largest(students[] s, int start, int end)
        {
            int index = start;
            float large = s[start].gpa;
            for (int x = start; x < end; x++)
            {
                if (large < s[x].gpa)
                {
                    large = s[x].gpa;
                    index = x;
                }
            }
            return index;
        }
        public class credentials
        {
            public string username;
            public string password;
        }
        public static void Challenge2()
        {
            Console.Clear();
            string path = "E:\\OOPs\\Lab01\\FirstProject\\records.txt";
            List<credentials> Users = new List<credentials>();
            ReadData(path, Users);
            while(true)
            {
                Console.Clear();
                int option = Menu1();
                if (option == 1)
                {
                    Console.WriteLine("Sign In");
                    string n;
                    string p;
                    Console.Write("Enter your name : ");
                    n = Console.ReadLine();
                    Console.Write("Enter your password : ");
                    p = Console.ReadLine();
                    SignIn(n, p, Users);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Sign In");
                    string n;
                    string p;
                    Console.Write("Enter your name : ");
                    n = Console.ReadLine();
                    Console.Write("Enter your password : ");
                    p = Console.ReadLine();
                    SignUp(path, n, p, Users);
                }
                else if (option == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Valid option!!!!!");
                    Console.WriteLine("Press Any key to continue.....");
                    Console.ReadKey();
                }
                Console.ReadKey();
            }
        }
        public static int Menu1()
        {
            int option;
            Console.WriteLine("1.Sign In");
            Console.WriteLine("2.Sign Up");
            Console.WriteLine("3.Exit");
            Console.Write("Enter option: ");
            option = int.Parse((Console.ReadLine()));
            return option;
        }
        public static void ReadData(string path, List<credentials> users)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    credentials info = new credentials();
                    info.username = ParseData(record, 1);
                    info.password = ParseData(record, 2);
                    users.Add(info);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        public static string ParseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static void SignIn(string n, string p, List<credentials> users)
        {
            bool flag = false;
            for (int x = 0; x < users.Count; x++)
            {
                if (n == users[x].username && p == users[x].password)
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();
        }
        public static int SignUp(string path, string n, string p, List<credentials> users)
        {
            for (int x = 0; x < 5; x++)
            {
                if (n == users[x].username && p == users[x].password)
                {
                    Console.WriteLine("Account Already exists!!!");
                    Console.WriteLine("Press Any key to continue.....");
                    return 0;
                }
            }
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
            return 0;
        }
    }
}
