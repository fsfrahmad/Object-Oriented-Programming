using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_LAB_05.BL;
using OOP_LAB_05.UI;

namespace OOP_LAB_05.DL
{
    public class SubjectCRUD
    {
        static List<Subject> SubjectsList = new List<Subject>();
        public static bool SujectExists(String Code)
        {
            foreach(Subject s in SubjectsList)
            {
                if (Code == s.Code)
                {
                    return true;
                }
            }
            return false;
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
        
    }
}
