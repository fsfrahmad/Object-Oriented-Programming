using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment4_OOP_Lab_8.BL
{
    public class Shape
    {
        public Shape()
        {
        }
        public virtual string GetType()
        {
            return "Shape";
        }
        public virtual double GetArea()
        {
            return 0;
        }
    }
}
