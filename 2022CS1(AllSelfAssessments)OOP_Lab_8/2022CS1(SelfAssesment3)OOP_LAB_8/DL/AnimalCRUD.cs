using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_SelfAssesment3_OOP_LAB_8.BL;

namespace _2022CS1_SelfAssesment3_OOP_LAB_8.DL
{
    public class AnimalCRUD
    {
        private static List<Animal> Animals = new List<Animal>();
        public static void AddAnimalToList(Animal A)
        {
            Animals.Add(A);
        }
        public static List<Animal> GetList()
        {
            return Animals;
        }
    }
}
