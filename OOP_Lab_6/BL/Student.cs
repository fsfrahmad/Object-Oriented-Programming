using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_LAB_05.UI;
using OOP_LAB_05.DL;

namespace OOP_LAB_05.BL
{
    public class Student
    {
        public string name;
        public int age;
        public int FSCMarks;
        public int EcatMarks;
        public double merit;
        public List<DegreeProgram> Prefrences;
        public List<Subject> RegisteredSubjects;
        public DegreeProgram RegisteredDegreeProgram;

        public Student()
        {
            name = "";
            age = 0;
            FSCMarks = 0;
            EcatMarks = 0;
            Prefrences = new List<DegreeProgram>();
            RegisteredSubjects = new List<Subject>();
            RegisteredDegreeProgram = new DegreeProgram();
        }
        public Student(string name, int age, int FSCMarks, int EcatMarks, List<DegreeProgram> Prefrences)
        {
            this.name = name;
            this.age = age;
            this.FSCMarks = FSCMarks;
            this.EcatMarks = EcatMarks;
            this.Prefrences = Prefrences;
        }
        public void CalculateMerit()
        {
            this.merit = (((FSCMarks / 1100) * .45F) + ((EcatMarks / 400) * .55)) * 100;
        }
        public bool RegisterStudentSubject(Subject NewSubject)
        {
            int StudentCreditHour = GetStudentTotalCreditHours();
            if ((RegisteredDegreeProgram != null && RegisteredDegreeProgram.SujectExists(NewSubject)) && StudentCreditHour + NewSubject.CreditHour <= 9)
            {
                RegisteredSubjects.Add(NewSubject);
                return true;
            }
            return false;
        }
        public int GetStudentTotalCreditHours()
        {
            int StudentTotalCreditHours = 0;
            for (int i = 0; i < RegisteredSubjects.Count; i++)
            {
                StudentTotalCreditHours = StudentTotalCreditHours + RegisteredSubjects[i].CreditHour;
            }
            return StudentTotalCreditHours;
        }
        public int CalculateFee()
        {
            int TotalFee = 0;
            if (RegisteredDegreeProgram != null)
            {
                foreach (Subject s in RegisteredSubjects)
                {
                    TotalFee = TotalFee + s.SubjectFee;
                }
            }
            return TotalFee;
        }
        public bool Contains(Subject Sub)
        {
            foreach (Subject s in RegisteredSubjects)
            {
                if (Sub.Code == s.Code)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ContainsDegree(DegreeProgram Degree)
        {
            foreach(DegreeProgram d in Prefrences)
            {
                if(d.title == Degree.title)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
