using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_LAB_05.BL;
using OOP_LAB_05.UI;
using OOP_LAB_05.DL;
using OOP_LAB_05;
using System.IO;

namespace OOP_LAB_05.DL
{
    public class StudentCRUD
    {
        public static List<Student> StudentsList = new List<Student>();
        public static Student StudentPresent(string name)
        {
            foreach(Student s in StudentsList)
            {
                if (name == s.name && s.RegisteredDegreeProgram != null)
                    return s;
            }
            return null;
        }
        public static void AddStudentToList(Student NewStudent)
        {
            StudentsList.Add(NewStudent);
        }
        public static void CalculateFeeForAllStudent()
        {
            foreach (Student s in StudentsList)
            {
                if(s.RegisteredDegreeProgram != null)
                {
                    Console.WriteLine(s.name + " has " + s.CalculateFee() + " Fees ");
                }
            }
        }
        public static List<Student> SortStudentByMerit()
        {
            List<Student> SortedStudentList = new List<Student>();
            foreach(Student s in StudentsList)
            {
                s.CalculateMerit();
            }
            SortedStudentList = StudentsList.OrderByDescending(o => o.merit).ToList();
            return SortedStudentList;
        }
        public static void PrintStudents()
        {
            foreach(Student s in StudentsList)
            {
                if (s.RegisteredDegreeProgram != null)
                {
                    Console.WriteLine(s.name + " got Admission in " + s.RegisteredDegreeProgram);
                }
                else
                {
                    Console.WriteLine(s.name + " did not got Admission. ");
                }
            }
        }
        public static void viewStudentInDegree(string DegreeName)
        {
            Console.WriteLine("Name\tAge\tFSC_Marks\tEcat_Marks");
            foreach(Student s in StudentsList)
            {
                if(s.RegisteredDegreeProgram != null)
                {
                    if(DegreeName == s.RegisteredDegreeProgram.title)
                    {
                        Console.WriteLine(s.name + "\t" + s.age + "\t" + s.FSCMarks + "\t" + s.EcatMarks);
                    }
                }
            }
        }
        public static void viewAllRegisteredStudents()
        {
            Console.WriteLine("Name\tAge\tFSC_Marks\tEcat_Marks\tRegistered_Degree");
            foreach (Student s in StudentsList)
            {
                if (s.RegisteredDegreeProgram != null)
                {
                    Console.WriteLine(s.name + "\t" + s.age + "\t" + s.FSCMarks + "\t" + s.EcatMarks+ "\t" + s.RegisteredDegreeProgram.title);
                }
            }
        }
        public static void StoreIntoFile(string path, Student s)
        {
            StreamWriter NewFile = new StreamWriter(path, true);
            string DegreeNames = "";
            for (int x = 0; x < s.Prefrences.Count - 1; x++)
            {
                DegreeNames = DegreeNames + s.Prefrences[x].title + ";";
            }
            DegreeNames = DegreeNames + s.Prefrences[s.Prefrences.Count - 1].title;
            NewFile.WriteLine(s.name + "," + s.age + "," + s.FSCMarks + "," + s.EcatMarks + "," + DegreeNames);
            NewFile.Flush();
            NewFile.Close();
        }
        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path); string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    int age = int.Parse(splittedRecord[1]);
                    int FSCMarks = int.Parse(splittedRecord[2]);
                    int EcatMarks = int.Parse(splittedRecord[3]);

                    string[] splittedRecordForPrefrences = splittedRecord[4].Split(';');
                    List<DegreeProgram> Prefrences = new List<DegreeProgram>();
                    for (int x = 0; x < splittedRecordForPrefrences.Length; x++)
                    {
                        DegreeProgram NewDegreeProgram = new DegreeProgram(splittedRecordForPrefrences[x], "");
                        Prefrences.Add(NewDegreeProgram);
                    }
                }
                f.Close();
                return true;
            }
            else
            {
                f.Close();
                return false;
            }
        }
    }
}
