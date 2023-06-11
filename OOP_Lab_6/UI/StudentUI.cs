using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_LAB_05;
using OOP_LAB_05.BL;
using OOP_LAB_05.DL;
using OOP_LAB_05.UI;

namespace OOP_LAB_05.UI
{
    public class StudentUI
    {
        public static Student TakeInputFromStudent()
        {
            Console.WriteLine("Enter your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Fsc Marks: ");
            int FSCMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Ecat Marks: ");
            int EcatMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Program: ");
            DegreeProgramCRUD.ViewAllDegreeProgram();
            Console.WriteLine("How many prefrences to enter: ");
            int NoOFPrefrences = int.Parse(Console.ReadLine());
            List<DegreeProgram> ProgramsList = new List<DegreeProgram>();
            for(int i = 0; i < NoOFPrefrences; i++)
            {
                Console.WriteLine("Enter Degree Name: ");
                string DegreeName = Console.ReadLine();
                bool flag = false;
                foreach(DegreeProgram d in DegreeProgramCRUD.DegreeProgramsList)
                {
                    if (DegreeName == d.title && !ProgramsList.Contains(d)) 
                    {
                        ProgramsList.Add(d);
                        flag = true;
                    }
                }
                if(flag == false)
                {
                    Console.WriteLine("Enter Valid Degree Program Name!!!");
                    i--;
                }
            }
            Student NewStudent = new Student(name, age, FSCMarks, EcatMarks, ProgramsList);
            return NewStudent;
         }
        public static void RegisterSubjects(Student NewStudent)
        {
            Console.WriteLine("Enter how many subject you want to register: ");
            int count = int.Parse(Console.ReadLine());
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter subject Code: ");
                string code = Console.ReadLine();
                bool flag = false;
                foreach(Subject Sub in NewStudent.RegisteredDegreeProgram.DegreeSubjects)
                {
                    if(code == Sub.Code && !(NewStudent.RegisteredSubjects.Contains(Sub)))
                    {
                        NewStudent.RegisterStudentSubject(Sub);
                        flag = true;
                        break;
                    }
                }
                if(flag == false)
                {
                    Console.WriteLine("Enter Valid Subject!!!");
                    i--;
                }
            }
        }
        public static void GiveAdmission(List<Student> SortedStudentList)
        {
            foreach(Student s in SortedStudentList)
            {
                foreach(DegreeProgram d in s.Prefrences)
                {
                    if(d.seats > 0 && s.RegisteredDegreeProgram == null)
                    {
                        s.RegisteredDegreeProgram = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }
        
    }
}
