using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_SelfAssesment3_OOP_LAB_8.BL;

namespace _2022CS1_SelfAssesment3_OOP_LAB_8.BL
{
    public class Mammal : Animal
    {
        public Mammal(string name): base(name)
        {
        }
        public override string toString()
        {
            return "Mammal[" + base.toString() + "]";
        }
        public override void greet()
        {
            Console.WriteLine("Mammals can greet!");
        }
    }
}
