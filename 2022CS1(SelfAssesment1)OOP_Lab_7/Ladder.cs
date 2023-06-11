using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Lab_07
{
    public class Ladder
    {
        private float length;
        private string colour;

        public Ladder(float length , string colour)
        {
            this.length = length;
            this.colour = colour;
        }
        public float GetLength()
        {
            return length;
        }
        public string GetColour()
        {
            return colour;
        }
    }
}