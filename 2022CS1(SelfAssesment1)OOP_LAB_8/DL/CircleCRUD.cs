using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_SelfAssesment1_OOP_Lab_8.BL;
using _2022CS1_SelfAssesment1_OOP_Lab_8.UI;

namespace _2022CS1_SelfAssesment1_OOP_Lab_8.DL
{
    public class CircleCRUD
    {
        private static List<Circle> CircleList = new List<Circle>();
        public static void AddtoList(Cylinder C)
        {
            CircleList.Add(C);
        }
        public static void AddtoList(Circle C)
        {
            CircleList.Add(C);
        }
        public static List<Circle> GetList()
        {
            return CircleList;
        }
    }
}
