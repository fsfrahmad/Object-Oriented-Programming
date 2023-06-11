using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment2_OOP_LAB_8.BL
{
    public class Student : Person
    {
        private string program;
        private float fee;
        private int year;
        public Student(string name, string address, string program, float fee, int year): base(name,address)
        {
            this.program = program;
            this.fee = fee;
            this.year = year;
        }
        public string GetProgram()
        {
            return program;
        }
        public float GetFee()
        {
            return fee;
        }
        public int GetYear()
        {
            return year;
        }
        public void SetProgram(string program)
        {
            this.program = program;
        }
        public void SetFee(float fee)
        {
            this.fee = fee;

        }
        public void SetYear(int year)
        {
            this.year = year;
        }
        public override string toString()
        {
            return "Student" + base.toString().Substring(0, base.toString().Length - 1) + ", Program : " + program + ", Year : " + year  + ", Fee: " + fee + " ]";
        }
    }
}
