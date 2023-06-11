using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_SelfAssesment2_OOP_LAB_8.BL;

namespace _2022CS1_SelfAssesment2_OOP_LAB_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Student Student1 = TakeStudentData();
            Student Student2 = TakeStudentData();
            Staff Staff1 = TakeStaffData();
            Staff Staff2 = TakeStaffData();
            Console.WriteLine(Student1.toString());
            Console.WriteLine(Student2.toString());
            Console.WriteLine(Staff1.toString());
            Console.WriteLine(Staff2.toString());
            Console.ReadLine();
        }
        public static Student TakeStudentData()
        {
            Console.WriteLine("Enter Student Data: ");
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Program: ");
            string program = Console.ReadLine();
            Console.WriteLine("Enter Fee");
            float fee = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Year");
            int year = int.Parse(Console.ReadLine());
            Student NewStudent = new Student(name, address, program, fee, year);
            return NewStudent;
        }
        public static Staff TakeStaffData()
        {
            Console.WriteLine("Enter Staff Data: ");
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter School: ");
            string school = Console.ReadLine();
            Console.WriteLine("Enter Pay");
            float pay = int.Parse(Console.ReadLine());
            Staff NewStaff = new Staff(name, address, school, pay);
            return NewStaff;
        }
    }
}
