using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_LAB_05.BL;
using OOP_LAB_05.UI;
using OOP_LAB_05.DL;

namespace OOP_LAB_05
{
    class Program
    {
        static void Main(string[] args)
        {
            UAMS();
        }
        public static void SelfAssesment1()
        {
            List<string> StudentsList = new List<string>() { "Ali", "Fatima", "Zubair", "Shafiq", "Rafay", "Saad", "Ahmad" };
            StudentsList.Sort();
            foreach(string s in StudentsList)
            {
                Console.WriteLine(s);
            }
            List<float> FloatList = new List<float>() { 3.5F, 6.38F, 67.93F, 1.57F, 3.4F, 4.00F };
            FloatList.Sort();
            foreach (float f in FloatList)
            {
                Console.WriteLine(f);
            }
            Console.ReadKey();
        }
        public static void UAMS()
        {
            int option;
            do
            {
                option = Menu();
                ClearScreen();
                if(option == 1)
                {
                    if(DegreeProgramCRUD.DegreeProgramsList.Count > 0)
                    {
                        Student NewStudent = StudentUI.TakeInputFromStudent();
                        StudentCRUD.AddStudentToList(NewStudent);
                    }
                }
                else if(option == 2)
                {
                    DegreeProgram NewDegreeProgram = DegreeProgramUI.AddDegreeProgram();
                    DegreeProgramCRUD.AddDegreeProgramToList(NewDegreeProgram);
                }
                else if(option == 3)
                {
                    List<Student> SortedStudentList = new List<Student>();
                    SortedStudentList = StudentCRUD.SortStudentByMerit();
                    StudentUI.GiveAdmission(SortedStudentList);
                    StudentCRUD.PrintStudents();
                }
                else if(option == 4)
                {
                    StudentCRUD.viewAllRegisteredStudents();
                }
                else if(option == 5)
                {
                    string DegreeName;
                    Console.Write("Enter Degree Name: ");
                    DegreeName = Console.ReadLine();
                    StudentCRUD.viewStudentInDegree(DegreeName);
                }
                else if(option == 6)
                {
                    Console.Write("Enter Student Name: ");
                    string name = Console.ReadLine();
                    Student NewStudent = StudentCRUD.StudentPresent(name);
                    if(NewStudent != null)
                    {
                        SubjectCRUD.ViewSubjects(NewStudent);
                    }
                }
                else if(option == 7)
                {
                    StudentCRUD.CalculateFeeForAllStudent();
                }
                else
                {
                    Console.WriteLine("Enter Valid Option!!!");
                }
            } while (option != 8);
            Console.ReadKey();
        }
        public static void ClearScreen()
        {
            Console.WriteLine("Press any key to continue!!!");
            Console.ReadKey();
            Console.Clear();
        }
        public static void Header()
        {
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("((                   University Management System                    ))");
            Console.WriteLine("***********************************************************************");
        }
        public static int Menu()
        {
            Header();
            int option;
            Console.WriteLine("1. Add Student.");
            Console.WriteLine("2. Add Degree Program.");
            Console.WriteLine("3. Generate Merit.");
            Console.WriteLine("4. View Registered Students.");
            Console.WriteLine("5. View Studeents of a Specific Program.");
            Console.WriteLine("6. Register Subjects For a Specific Student.");
            Console.WriteLine("7. Calculate Fees for All Registered Students.");
            Console.WriteLine("8. Exit.");
            Console.WriteLine();
            Console.Write("Enter Option to Continue: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
