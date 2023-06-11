using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_LAB_05.UI;
using OOP_LAB_05.DL;

namespace OOP_LAB_05.BL
{
    public class Subject
    {
        public string Code;
        public int CreditHour;
        public string SubjectType;
        public int SubjectFee;
        public Subject()
        {
            Code = "";
            CreditHour = 0;
            SubjectType = "";
            SubjectFee = 0;
        }
        public Subject(string Code, int CreditHour, string SubjectType, int SubjectFee)
        {
            this.Code = Code;
            this.CreditHour = CreditHour;
            this.SubjectType = SubjectType;
            this.SubjectFee = SubjectFee;
        }
    }
}
