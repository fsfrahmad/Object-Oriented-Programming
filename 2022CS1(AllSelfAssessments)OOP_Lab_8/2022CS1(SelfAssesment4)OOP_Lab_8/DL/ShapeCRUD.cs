using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_SelfAssesment4_OOP_Lab_8.BL;

namespace _2022CS1_SelfAssesment4_OOP_Lab_8.DL
{
    public class ShapeCRUD
    {
        private static List<Shape> Shapes = new List<Shape>();
        public static void AddtoList(Shape S)
        {
            Shapes.Add(S);
        }
        public static List<Shape> GetList()
        {
            return Shapes;
        }
    }
}
