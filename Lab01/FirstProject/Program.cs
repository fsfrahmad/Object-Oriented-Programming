using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Project3();
        }
        public static void task1()
        {
            Console.Write("Hello World");
            Console.Write("Hello World");
            Console.ReadKey();
        }
        public static void task2()
        {
            Console.WriteLine("Hello World");
            Console.Write("Hello World");
            Console.ReadKey();
        }
        public static void task3()
        {
            int number = 7;
            Console.Write("Number is ");
            Console.Write(number);
            Console.ReadKey();
        }
        public static void task4()
        {
            string line = "I am string";
            Console.WriteLine("String is: ");
            Console.Write(line);
            Console.ReadKey();
        }
        public static void task5()
        {
            char variable = 'A';
            Console.WriteLine("Character is: ");
            Console.Write(variable);
            Console.ReadKey();
        }
        public static void task6()
        {
            float variable = 2.3F;
            Console.WriteLine("Decimal is: ");
            Console.Write(variable);
            Console.ReadKey();
        }
        public static void task7()
        {
            string str;
            Console.Write("Enter string: ");
            str = Console.ReadLine();
            Console.Write("You have inputted: ");
            Console.Write(str);
            Console.ReadKey();
        }
        public static void task8()
        {
            int number;
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            Console.Write("You have inputted: ");
            Console.Write(number);
            Console.ReadKey();
        }
        public static void task9()
        {
            float number;
            Console.Write("Enter decimal: ");
            number = float.Parse(Console.ReadLine());
            Console.Write("You have inputted: ");
            Console.Write(number);
            Console.ReadKey();
        }
        public static void task10()
        {
            char variable;
            Console.Write("Enter character: ");
            variable = char.Parse(Console.ReadLine());
            Console.Write("You have inputted: ");
            Console.Write(variable);
            Console.ReadKey();
        }
        public static void task11()
        {
            float length, area;
            Console.Write("Enter length: ");
            length = float.Parse(Console.ReadLine());
            area = length * length;
            Console.Write("Area is: ");
            Console.Write(area);
            Console.ReadKey();
        }
        public static void task12()
        {
            int marks;
            Console.Write("Enter Marks: ");
            marks = int.Parse(Console.ReadLine());
            if(marks > 50)
            {
                Console.Write("You are Pass");
            }
            else
            {
                Console.Write("You are Fail");
            }
            Console.ReadKey();
        }
        public static void task13()
        {
            int count;
            for(count = 1; count <= 5; count++)
            {
                Console.WriteLine("Saad Ahmad");
            }
            Console.ReadKey();
        }
        public static void task14()
        {
            int num;
            int sum = 0;
            Console.Write("Enter number: ");
            num = int.Parse(Console.ReadLine());
            while(num != -1)
            {
                sum = sum + num;
                Console.Write("Enter number: ");
                num = int.Parse(Console.ReadLine());
            }
            Console.Write("The total sum is " + sum);
            Console.Read();
        }
        public static void task15()
        {
            int num;
            int sum = 0;
            do
            {
                Console.Write("Enter number: ");
                num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }
            while (num != -1);
            sum++;
            Console.Write("The total sum is " + sum);
            Console.Read();
        }
        public static void task16()
        {
            int[] arr = new int[3];
            int large = 0;
            Console.WriteLine("Enter three numbers: ");
            for(int idx = 0; idx < 3; idx++)
            {
                arr[idx] = int.Parse(Console.ReadLine());
            }
            for (int idx = 0; idx < 3; idx++)
            {
                if (arr[idx] > large)
                    large = arr[idx];
            }
            Console.Write("Largest number is: " + large);
            Console.ReadKey();
        }
        public static void task17()
        {
            int num1, num2;
            Console.WriteLine("Enter two numbers: ");
            num1 = int.Parse(Console.ReadLine());
            num2 = int.Parse(Console.ReadLine());
            Console.Write("Sum is " + add(num1, num2));
            Console.ReadKey();
        }
        static int add(int num1, int num2)
        {
            return num1 + num2;
        }
        public static void task18()
        {
            string path = "E:\\OOPs\\Lab01\\FirstProject\\Data.txt";
            if(File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while((record = fileVariable.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File does not exist!!!");
            }
            Console.ReadKey();
        }
        public static void task19()
        {
            string path = "E:\\OOPs\\Lab01\\FirstProject\\Data.txt";
            StreamWriter fileVariable = new StreamWriter(path, true);
            fileVariable.WriteLine("hello");
            fileVariable.Flush();
            fileVariable.Close();
        }
        public static void Project1()
        {
            while (true)
            {
                Console.Clear();
                string path = "E:\\OOPs\\Lab01\\FirstProject\\records.txt";
                string[] names = new string[5];
                string[] passwords = new string[5];
                readData(path, names, passwords);
                int option = Menu();
                if (option == 1)
                {
                    Console.WriteLine("Sign In");
                    string n;
                    string p;
                    Console.Write("Enter your name : ");
                    n = Console.ReadLine();
                    Console.Write("Enter your password : ");
                    p = Console.ReadLine();
                    signIn(n, p, names, passwords);
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
                    SignUp(path, n, p, names, passwords);
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
        public static int Menu()
        {
            int option;
            Console.WriteLine("1.Sign In");
            Console.WriteLine("2.Sign Up");
            Console.WriteLine("3.Exit");
            Console.Write("Enter option: ");
            option = int.Parse((Console.ReadLine()));
            return option;
        }
        public static string getField(string record, int field)
        {
            int comma = 1;
            string item = "";
            for(int x = 0; x < record.Length; x++)
            {
                if(record[x] == ',')
                {
                    comma++;
                }
                else if(comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        public static void readData(string path,string[] names, string[] passwords)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    names[x] = getField(record, 1);
                    passwords[x] = getField(record, 2);
                    x++;
                    if(x >= 5)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File does not exist!!!");
            }
        }
        public static void signIn(string n, string p, string[] names, string[] passwords)
        {
            bool flag = false;
            for(int x = 0; x < 5; x++)
            {
                if(n == names[x] && p == passwords[x])
                {
                    Console.WriteLine("Valid User!");
                    flag = true;
                }
            }
            if(flag == false)
            {
                Console.WriteLine("Invalid User!");
            }
        }
        public static int SignUp(string path, string n, string p, string[] names, string[] passwords)
        {
            for (int x = 0; x < 5; x++)
            {
                if (n == names[x] && p == passwords[x])
                {
                    Console.WriteLine("Account Already exists!!!");
                    Console.WriteLine("Press Any key to continue.....");
                    return 0;
                }
            }
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine();
            file.Write(n + "," + p);
            file.Flush();
            file.Close();
            return 0;
        }
        public static void Project2()
        {
            int PresentAge;
            int money = 0;
            int toys = 0;
            int gift = 10;
            float UnitToyPrice;
            float TotalPrice;
            float WashingMachinePrice;
            Console.Write("Enter the age of Lilly: ");
            PresentAge = int.Parse(Console.ReadLine());
            Console.Write("Enter the Price of one Toy: ");
            UnitToyPrice = float.Parse(Console.ReadLine());
            Console.Write("Enter the Price of Washing Machine: ");
            WashingMachinePrice = float.Parse(Console.ReadLine());
            for (int startYear = 1; startYear <= PresentAge; startYear++)
            {
                if(startYear % 2 == 0)
                {
                    money = money + gift;
                    money--;
                    gift = gift + 10;
                }
                else
                {
                    toys++;
                }
            }
            TotalPrice = money + (toys * UnitToyPrice);
            if (TotalPrice < WashingMachinePrice)
            {
                Console.WriteLine("No! Insuffficient Money! {0}! Required" , (WashingMachinePrice - TotalPrice));
            }
            else
            {
                Console.WriteLine("Yes! Remaining Balance: {0}!  ", (TotalPrice - WashingMachinePrice));
            }
            Console.ReadKey();
        }
        public static void Project3()
        {
            int MinOrders;
            int MinOrderPrice;
            string path = "E:\\OOPs\\Lab01\\FirstProject\\Customers.txt";
            Console.Write("Enter Minimum number of orders: ");
            MinOrders = int.Parse(Console.ReadLine());
            Console.Write("Enter Minimum Price of order: ");
            MinOrderPrice = int.Parse(Console.ReadLine());
            CheckStatus(path, MinOrders, MinOrderPrice);
            Console.ReadKey();
        }
        public static void CheckStatus(string path, int MinOrders, int MinOrderprice)
        {
            string record;
            StreamReader fileVariable = new StreamReader(path);
            while((record = fileVariable.ReadLine()) != null)
            {
                string Name = ExtractCustomerData(record,1);
                int TotalOrders = int.Parse(ExtractCustomerData(record, 2)); 
                string TotalPrices = ExtractCustomerData(record, 3);
                if (TotalOrders >= MinOrders)
                {
                    if(CheckPrices(MinOrderprice, MinOrders, TotalOrders, TotalPrices))
                    {
                        Console.WriteLine("Name = " + Name);
                    }
                }            
            }
            fileVariable.Close();
        }
        public static bool CheckPrices(int minOrderPrice, int minOrders, int TotalOrders, string totalPrices)
        {
            int count = 0;
            bool flag = false;
            for(int i = 1; i < TotalOrders; i++)
            {
                int order = int.Parse(getField(totalPrices, i));
                if(order >= minOrderPrice)
                {
                    count++;
                    if(count >= minOrders)
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }
        public static string ExtractCustomerData(string record, int field)
        {
            int Space = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ' ')
                {
                    Space++;
                }
                else if (Space == field)
                {
                    if(record[x] != '[' && record[x] != ']')
                    item = item + record[x];
                }
            }
            return item;
        }
    }
}
