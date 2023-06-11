using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Lab_03.BL;

namespace OOP_Lab_03
{
    class Program
    {

        static void Main(string[] args)
        {
            Challenge2();
            Console.ReadKey();
        }
        public static void Task1()
        {
            students item = new students();
            Console.WriteLine("Name : " + item.sname);
            Console.WriteLine("Matric Marks : " + item.matricmarks);
            Console.WriteLine("FSC Marks : " + item.fscmarks);
            Console.WriteLine("ECAT Marks : " + item.ecatmarks);
            Console.WriteLine("Aggregate : " + item.aggregate);
        }
        public static void Task2()
        {
            students item = new students();
        }
        public static void Task3()
        {
            students item = new students();
            Console.WriteLine("Name : " + item.sname);
        }
        public static void Task4()
        {
            students item = new students();
            Console.WriteLine("Name : " + item.sname);
            Console.WriteLine("Matric Marks : " + item.matricmarks);
            Console.WriteLine("FSC Marks : " + item.fscmarks);
            Console.WriteLine("ECAT Marks : " + item.ecatmarks);
            Console.WriteLine("Aggregate : " + item.aggregate);
        }
        public static void Task5()
        {
            students item1 = new students();
            Console.WriteLine("Name : " + item1.sname);
            Console.WriteLine("Matric Marks : " + item1.matricmarks);
            Console.WriteLine("FSC Marks : " + item1.fscmarks);
            Console.WriteLine("ECAT Marks : " + item1.ecatmarks);
            Console.WriteLine("Aggregate : " + item1.aggregate);
            students item2 = new students();
            Console.WriteLine("Name : " + item2.sname);
            Console.WriteLine("Matric Marks : " + item2.matricmarks);
            Console.WriteLine("FSC Marks : " + item2.fscmarks);
            Console.WriteLine("ECAT Marks : " + item2.ecatmarks);
            Console.WriteLine("Aggregate : " + item2.aggregate);
        }
        public static void Task6()
        {
            students s1 = new students("Jack");
            Console.WriteLine(s1.sname);
            students s2 = new students("Jill");
            Console.WriteLine(s2.sname);
        }
        public static void Task7()
        {
            students s1 = new students("Saad", 1026F, 1036F, 255F, 90.27F);
            Console.WriteLine("Name : " + s1.sname);
            Console.WriteLine("Matric Marks : " + s1.matricmarks);
            Console.WriteLine("FSC Marks : " + s1.fscmarks);
            Console.WriteLine("ECAT Marks : " + s1.ecatmarks);
            Console.WriteLine("Aggregate : " + s1.aggregate);
        }
        public static void Task8()
        {
            students s1 = new students("Saad", 1026F, 1036F, 255F, 90.27F);
            Console.WriteLine("Name : " + s1.sname);
            Console.WriteLine("Matric Marks : " + s1.matricmarks);
            Console.WriteLine("FSC Marks : " + s1.fscmarks);
            Console.WriteLine("ECAT Marks : " + s1.ecatmarks);
            Console.WriteLine("Aggregate : " + s1.aggregate);
            students s2 = new students("Rauf", 1023F, 1090F, 140F, 83F);
            Console.WriteLine("Name : " + s2.sname);
            Console.WriteLine("Matric Marks : " + s2.matricmarks);
            Console.WriteLine("FSC Marks : " + s2.fscmarks);
            Console.WriteLine("ECAT Marks : " + s2.ecatmarks);
            Console.WriteLine("Aggregate : " + s2.aggregate);
        }
        public static void Task9()
        {
            List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach(int n in Numbers)
            {
                Console.WriteLine(n);
            }
        }
        public static void Task10()
        {
            // Default Constructor
            clockType empty_time = new clockType();
            Console.WriteLine("Empty_time : ");
            empty_time.PrintTime();
            // Parametrized Constructor (one parameter)
            clockType hour_time = new clockType(1);
            Console.WriteLine("Hour_time : ");
            hour_time.PrintTime();
            // Parametrized Constructor (two parameter)
            clockType minute_time = new clockType(8,20);
            Console.WriteLine("Minute_time : ");
            minute_time.PrintTime();
            // Parametrized Constructor (three parameter)
            clockType full_time = new clockType(8,20,30);
            Console.WriteLine("Full_time : ");
            full_time.PrintTime();
            // Increment Seconds
            full_time.incrementSeconds();
            Console.WriteLine("Full_time(incremented second) : ");
            full_time.PrintTime();
            // Increment minutes
            full_time.incrementminutes();
            Console.WriteLine("Full_time(incremented minute) : ");
            full_time.PrintTime();
            // Increment hours
            full_time.incrementHours();
            Console.WriteLine("Full_time(incremented hour) : ");
            full_time.PrintTime();
            // Check if Equal
            bool flag = full_time.IsEqual(9, 11, 11);
            Console.WriteLine("Flag: " + flag);
            // Check if equal with object
            clockType cmp = new clockType(10, 12, 1);
            flag = full_time.IsEqual(cmp);
            Console.WriteLine("Object Flag : " + flag);
        }
        public static void Challenge1()
        {
            clockType full_time = new clockType(3, 24, 23);
            Console.WriteLine("Full_time : ");
            full_time.PrintTime();
            clockType ElapsedTime = new clockType();
            ElapsedTime = full_time.CalculateElapsedTime();
            Console.WriteLine("Elapsed Time: ");
            ElapsedTime.PrintTime();
            Console.WriteLine("Elapsed Time in Seconds: " + ((ElapsedTime.hours * 3600) + (ElapsedTime.minutes * 60) + (ElapsedTime.seconds)));
            clockType RemainingTime = new clockType();
            RemainingTime = full_time.CalculateRemainingTime();
            Console.WriteLine("Remaining Time: ");
            RemainingTime.PrintTime();
            Console.WriteLine("Remaining Time in Seconds: " + ((RemainingTime.hours * 3600) + (RemainingTime.minutes * 60) + (RemainingTime.seconds)));
            clockType FirstTime = new clockType(10,11,3); 
            clockType SecondTime = new clockType(11, 2, 11);
            clockType DifferenceTime = new clockType();
            DifferenceTime = FirstTime.CalculateDifference(SecondTime);
            Console.WriteLine("Difference Time: ");
            DifferenceTime.PrintTime();
        }
        public static void Challenge2()
        {
            List<product> Products = new List<product>();
            while (true)
            {
                int option = Menu();
                if (option == 1)
                {
                    Console.Clear();
                    product item = new product();
                    item.AddProduct();
                    Products.Add(item);
                    Console.WriteLine("Item Added Successfully");
                }
                else if (option == 2)
                {
                    Console.WriteLine("Name" + "\t" + "Category" + "\t" + "Price" + "\t" + "Quantity" + "\t" + "Min Stock");
                    for(int index = 0; index < Products.Count; index++)
                    {
                        Console.WriteLine(Products[index].name + "\t" + Products[index].category + "\t\t" + Products[index].price + "\t\t" + Products[index].quantity + "\t\t" + Products[index].MinQuantity);    
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    float large = 0;
                    int LargestIndex = 0;
                    for (int index = 0; index < Products.Count; index++)
                    {
                        if(Products[index].price > large)
                        {
                            large = Products[index].price;
                            LargestIndex = index;
                        }
                    }
                    Console.WriteLine("Product with highest unit Price: ");
                    Console.WriteLine("Name: " + Products[LargestIndex].name + " Price: " + Products[LargestIndex].price + " Tax: " + Products[LargestIndex].CalculateTax());
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (option == 4)
                {
                    Console.WriteLine("Name" + "\t\t" + "Price" + "\t\t" + "Sales Tax");
                    for (int index = 0; index < Products.Count; index++)
                    {
                        Console.WriteLine(Products[index].name + "\t\t" + Products[index].price + "\t\t" + Products[index].CalculateTax());
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (option == 5)
                {
                    Console.WriteLine("Following Products have to be ordered: ");
                    for (int index = 0; index < Products.Count; index++)
                    {
                        if(Products[index].quantity < Products[index].MinQuantity)
                        {
                            Console.WriteLine("Name: " + Products[index].name + "  Price: " + Products[index].price);
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if(option == 6)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Valid Option");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        public static int Menu()
        {
            int option;
            Console.Clear();
            Console.WriteLine("1.Add New Item");
            Console.WriteLine("2.View All Products");
            Console.WriteLine("3.Find Product with Highest Unit Price");
            Console.WriteLine("4.View Sales tax of All Products");
            Console.WriteLine("5.View Products to be Ordered");
            Console.WriteLine("6.Exit");
            Console.Write("Enter your option: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
