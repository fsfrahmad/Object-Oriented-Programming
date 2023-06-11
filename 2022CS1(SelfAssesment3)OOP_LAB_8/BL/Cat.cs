using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment3_OOP_LAB_8.BL
{
    public class Cat: Mammal
    {
        public Cat(string name) : base(name)
        {
        }
        public override string toString()
        {
            Console.WriteLine("Cat[" + base.toString() + "]");
            return "Cat[" + base.toString() + "]";
        }
        public override void greet()
        {
            Console.WriteLine("Meow");
        }
    }
}
