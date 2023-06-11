using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_SelfAssesment4_OOP_Lab_8.BL;
using _2022CS1_SelfAssesment4_OOP_Lab_8.UI;
using _2022CS1_SelfAssesment4_OOP_Lab_8.DL;

namespace _2022CS1_SelfAssesment4_OOP_Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeUI.AddRectangle();
            ShapeUI.AddCircle();
            ShapeUI.AddSquare();
            ShapeUI.AddRectangle();
            ShapeUI.AddCircle();
            ShapeUI.DisplayAllShapes();
            Console.ReadKey();
        }
    }
}
