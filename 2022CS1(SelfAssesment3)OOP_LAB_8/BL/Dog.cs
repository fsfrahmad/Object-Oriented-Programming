using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment3_OOP_LAB_8.BL
{
    public class Dog: Mammal
    {
        public Dog(string name) : base(name)
        {
        }
        public override string toString()
        {
            Console.WriteLine("Dog[" + base.toString() + "]");
            return "Dog[" + base.toString() + "]";
        }
        public override void greet()
        {
            Console.WriteLine("Woof");
        }
    }
}
