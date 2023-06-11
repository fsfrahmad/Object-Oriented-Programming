using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_SelfAssesment3_OOP_LAB_8.BL;
using _2022CS1_SelfAssesment3_OOP_LAB_8.DL;


namespace _2022CS1_SelfAssesment3_OOP_LAB_8.UI
{
    public class AnimalUI
    {
        public static void AddAnimal()
        {
            Console.WriteLine("Enter Animal Name: ");
            string name = Console.ReadLine();
            Animal NewAnimal = new Animal(name);
            AnimalCRUD.AddAnimalToList(NewAnimal);
        }
        public static void AddMammal()
        {
            Console.WriteLine("Enter Mammal Name: ");
            string name = Console.ReadLine();
            Mammal NewMammal = new Mammal(name);
            AnimalCRUD.AddAnimalToList(NewMammal);
        }
        public static void AddCat()
        {
            Console.WriteLine("Enter Cat Name: ");
            string name = Console.ReadLine();
            Cat NewCat = new Cat(name);
            AnimalCRUD.AddAnimalToList(NewCat);
        }
        public static void AddDog()
        {
            Console.WriteLine("Enter Dog Name: ");
            string name = Console.ReadLine();
            Dog NewDog = new Dog(name);
            AnimalCRUD.AddAnimalToList(NewDog);
        }
        public static void PrintListAttributs()
        {
            List<Animal> AnimalsList = AnimalCRUD.GetList();
            for(int i = 0; i < AnimalsList.Count; i++)
            {
                Console.WriteLine(AnimalsList[i].toString());
                AnimalsList[i].greet();
            }
        }
    }
}
