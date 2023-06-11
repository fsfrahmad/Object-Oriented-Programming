using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_LAB_05.UI;
using OOP_LAB_05.DL;

namespace OOP_LAB_05.BL
{
    public class DegreeProgram
    {
        public string title;
        public string duration;
        public int seats;
        public int NoOfSubjects;
        public List<Subject> DegreeSubjects = new List<Subject>();
        public DegreeProgram()
        {
            title = "";
            duration = "";
            NoOfSubjects = 0;
        }
        public DegreeProgram(string title, string duration, int seats)
        {
            this.title = title;
            this.duration = duration;
            this.seats = seats;
        }
        public DegreeProgram(string title, string duration, int seats,int NoOfSubjects, List<Subject> DegreeSubjects)
        {
            this.title = title;
            this.duration = duration;
            this.seats = seats;
            this.NoOfSubjects = NoOfSubjects;
            this.DegreeSubjects = DegreeSubjects;
        }
        public DegreeProgram(string title, string duration)
        {
            this.title = title;
            this.duration = duration; 
        }
        public bool SujectExists(Subject NewSubject)
        {
            foreach (Subject s in DegreeSubjects)
            {
                if (NewSubject.Code == s.Code)
                {
                    return true;
                }
            }
            return false;
        }
        public bool AddSubjectToList(Subject NewSubject)
        {
            int TotalCreditHours = CalculateCreditHours();
            if (TotalCreditHours + NewSubject.CreditHour <= 20)
            {
                DegreeSubjects.Add(NewSubject);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int CalculateCreditHours()
        {
            int TotalCreditHours = 0;
            for (int i = 0; i < DegreeSubjects.Count; i++)
            {
                TotalCreditHours = TotalCreditHours + DegreeSubjects[i].CreditHour;
            }
            return TotalCreditHours;
        }
    }
}
