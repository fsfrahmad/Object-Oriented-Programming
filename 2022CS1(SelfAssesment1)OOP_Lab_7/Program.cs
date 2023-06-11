using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_07
{
    class Program
    {
        static void Main(string[] args)
        {
            SelfAssesment1();
            Console.ReadKey();
        }
        public static void SelfAssesment1()
        {
            int option = FireFighterMenuUI.Menu();
            if(option == 1)
            {
                FireFighterMenuUI.AddFireTruck();
            }
            else if(option == 2)
            {
                FireFighterMenuUI.AddFireFighter();
            }
            else if(option == 3)
            {
                FireFighterMenuUI.AddFireChief();
            }
            else
            {
                Console.WriteLine("Enter Valid Option: ");
            }
        }
    }
}
