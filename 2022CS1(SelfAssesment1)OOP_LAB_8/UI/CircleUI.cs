using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_SelfAssesment1_OOP_Lab_8.BL;
using _2022CS1_SelfAssesment1_OOP_Lab_8.DL;

namespace _2022CS1_SelfAssesment1_OOP_Lab_8.UI
{
    class CircleUI
    {
        public static void TakeDataForCircle()
        {
            Console.WriteLine("Enter Radius: ");
            double radius = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Colour: ");
            string colour = Console.ReadLine();
            Circle NewCircle = new Circle(radius, colour);
            CircleCRUD.AddtoList(NewCircle);
        }
        public static void TakeDataForCylinder()
        {
            Console.WriteLine("Enter Radius: ");
            double radius = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Colour: ");
            string colour = Console.ReadLine();
            Console.WriteLine("Enter Height: ");
            double height = double.Parse(Console.ReadLine());
            Circle NewCylinder = new Cylinder(radius,height, colour);
            CircleCRUD.AddtoList(NewCylinder);
        }
        public static void DisplayAreas()
        {
            List<Circle> CircleList = CircleCRUD.GetList();
            for(int i = 0; i < CircleList.Count; i++)
            {
                Console.WriteLine(CircleList[i].toString() + CircleList[i].GetArea());
            }
        }
        public static void DisplayMenu()
        {
            Console.WriteLine("1. Add Circle");
            Console.WriteLine("2. Add Cylinder");
            Console.WriteLine("3. Get All Data");
        }
    }
}
