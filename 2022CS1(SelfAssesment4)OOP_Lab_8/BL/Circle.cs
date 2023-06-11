using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment4_OOP_Lab_8.BL
{
    public class Circle : Shape
    {
        private float radius;
        public Circle(float radius)
        {
            this.radius = radius;
        }
        public override string GetType()
        {
            return "Circle";
        }
        public override double GetArea()
        {
            return Math.PI * Math.Pow(radius,2);
        }
    }
}
