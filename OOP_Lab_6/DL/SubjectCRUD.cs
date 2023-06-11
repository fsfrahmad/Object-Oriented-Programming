using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_LAB_05.BL;
using OOP_LAB_05.UI;
using System.IO;

namespace OOP_LAB_05.DL
{
    public class SubjectCRUD
    {
        static List<Subject> SubjectsList = new List<Subject>();
        public static Subject SubjectExists(String Code)
        {
            foreach(Subject s in SubjectsList)
            {
                if (Code == s.Code)
                {
                    return s;
                }
            }
            return null;
        }    
        public static void ViewSubjects(Student S)
        {
            if(S.RegisteredDegreeProgram != null)
            {
                Console.WriteLine("Subject_Code\tCredit_Hours\tSubject_Type");
                foreach (Subject s in S.RegisteredDegreeProgram.DegreeSubjects)
                {
                    Console.WriteLine(s.Code + "\t\t" + s.CreditHour + "\t\t" + s.SubjectType);
                }
            } 
        }
        public static void AddToList(Subject NewSubject)
        {
            SubjectsList.Add(NewSubject);
        }
        public static bool readFromFile(string path)
        {
            StreamReader NewFile = new StreamReader(path);
            string record;
            if(File.Exists(path))
            {
                while((record = NewFile.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string code = splittedRecord[0];
                    string type = splittedRecord[1];
                    int creditHour = int.Parse(splittedRecord[2]);
                    int fee = int.Parse(splittedRecord[3]);
                    Subject s = new Subject(code, creditHour,type, fee);
                    AddToList(s);
                }
                NewFile.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void StoreIntoFile(string path,Subject s)
        {
            StreamWriter NewFile = new StreamWriter(path, true);
            NewFile.WriteLine(s.Code + "," + s.SubjectType + "," + s.CreditHour + "," + s.SubjectFee);
            NewFile.Flush();
            NewFile.Close();
        }
    }
}
