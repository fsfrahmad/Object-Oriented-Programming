using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment4_OOP_Lab_8.BL
{
    public class Square : Shape
    {
        private float length;
        public Square(float length)
        {
            this.length = length;
        }
        public override string GetType()
        {
            return "Square";
        }
        public override double GetArea()
        {
            return length * length;
        }
    }
}
