using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment2_OOP_LAB_8.BL
{
    public class Staff: Person
    {
        private string school;
        private float pay;

        public Staff(string name, string address, string school, float pay) : base(name, address)
        {
            this.school = school;
            this.pay = pay;
        }
        public string GetSchool()
        {
            return school;
        }
        public float GetPay()
        {
            return pay;
        }
        public void SetSchool(string school)
        {
            this.school = school;
        }
        public void SetPay(float pay)
        {
            this.pay = pay;
        }
        public override string toString()
        {
            return "Staff" + base.toString().Substring(0, base.toString().Length-1) + ", School : " + school + ", Pay : " + pay + " ]";
        }
    }
}
