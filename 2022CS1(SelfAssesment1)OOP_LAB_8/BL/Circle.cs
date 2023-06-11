using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment1_OOP_Lab_8.BL
{
    public class Circle
    {
        protected double radius;
        protected string colour;
        
        public Circle()
        {
            radius = 0;
            colour = "";
        }
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public Circle(double radius, string colour)
        {
            this.radius = radius;
            this.colour = colour;
        }
        public void SetRadius(double radius)
        {
            this.radius = radius;
        }
        public double GetRadius()
        {
            return radius;
        }
        public void SetColour(string colour)
        {
            this.colour = colour;
        }
        public string GetColour()
        {
            return colour;
        }
        public virtual double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }
        public virtual string toString()
        {
            return "Circle[Radius: " + radius + ", Colour: " + colour + "]"; 
        }
    }
}
