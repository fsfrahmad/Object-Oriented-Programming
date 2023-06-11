using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment1_OOP_Lab_8.BL
{
    public class Cylinder : Circle
    {
        private double height;
        public Cylinder()
        {
            height = 0;
        }
        public Cylinder(double radius): base(radius)
        {
            height = 0;
        }
        public Cylinder(double radius, double height): base(radius)
        {
            this.height = height;
        }
        public Cylinder(double radius, double height, string colour): base(radius, colour)
        {
            this.height = height;
        }
        public void SetHeight(double height)
        {
            this.height = height;
        }
        public double GetHeight()
        {
            return height;
        }
        public override double GetArea()
        {
            return height * base.GetArea();
        }
        public override string toString()
        {
            return "Cylinder[Radius: " + radius + ", Colour: " + colour + ", Height: " + height + "]";
        }
    }
}
