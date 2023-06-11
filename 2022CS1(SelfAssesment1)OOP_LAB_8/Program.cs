using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_SelfAssesment1_OOP_Lab_8.BL;
using _2022CS1_SelfAssesment1_OOP_Lab_8.DL;
using _2022CS1_SelfAssesment1_OOP_Lab_8.UI;



namespace _2022CS1_SelfAssesment1_OOP_Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Cylinder C1 = new Cylinder();
            CircleCRUD.AddtoList(C1);
            CircleUI.TakeDataForCylinder();
            CircleUI.TakeDataForCylinder();
            CircleUI.DisplayAreas();
            Console.ReadKey();
        }
    }
}
