using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment4_OOP_Lab_8.BL
{
    public class Rectangle: Shape
    {
        private float length;
        private float width;
        public Rectangle(float length,float width)
        {
            this.length = length;
            this.width = width;
        }
        public override string GetType()
        {
            return "Rectangle";
        }
        public override double GetArea()
        {
            return length * width;
        }
    }
}
