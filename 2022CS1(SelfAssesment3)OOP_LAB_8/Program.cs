using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_SelfAssesment3_OOP_LAB_8.BL;
using _2022CS1_SelfAssesment3_OOP_LAB_8.DL;
using _2022CS1_SelfAssesment3_OOP_LAB_8.UI;


namespace _2022CS1_SelfAssesment3_OOP_LAB_8
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalUI.AddAnimal();
            AnimalUI.AddMammal();
            AnimalUI.AddCat();
            AnimalUI.AddCat();
            AnimalUI.AddDog();
            AnimalUI.AddDog();
            AnimalUI.PrintListAttributs();
            Console.ReadKey();
        }
    }
}
