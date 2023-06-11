using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_SelfAssesment4_OOP_Lab_8.BL;
using _2022CS1_SelfAssesment4_OOP_Lab_8.DL;

namespace _2022CS1_SelfAssesment4_OOP_Lab_8.UI
{
    public class ShapeUI
    {
        public static void AddRectangle()
        {
            Console.WriteLine("Rectangle: ");
            Console.WriteLine("Enter Length: ");
            float length = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Width: ");
            float width = float.Parse(Console.ReadLine());
            Rectangle NewRectangle = new Rectangle(length, width);
            ShapeCRUD.AddtoList(NewRectangle);
        }
        public static void AddCircle()
        {
            Console.WriteLine("Circle:");
            Console.WriteLine("Enter Radius: ");
            float radius = float.Parse(Console.ReadLine());
            Circle NewCircle = new Circle(radius);
            ShapeCRUD.AddtoList(NewCircle);
        }
        public static void AddSquare()
        {
            Console.WriteLine("Square: ");
            Console.WriteLine("Enter Length: ");
            float length = float.Parse(Console.ReadLine());
            Square NewSquare = new Square(length);
            ShapeCRUD.AddtoList(NewSquare);
        }
        public static void DisplayAllShapes()
        {
            List<Shape> Shapes = ShapeCRUD.GetList();
            for(int i = 0; i < Shapes.Count; i++)
            {
                Console.WriteLine((i + 1) + ". The Shape is " + Shapes[i].GetType() + " and has Area " + Shapes[i].GetArea());
            }
        }
    }
}
