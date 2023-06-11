using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssesment3_OOP_LAB_8.BL
{
    public class Animal
    {
        protected string name;
        public Animal(string name)
        {
            this.name = name;
        }
        public virtual string toString()
        {
            return "Animal[Name: " + name + "]";
        }
        public virtual void greet()
        {
            Console.WriteLine("Animals can greet!");
        }
    }
}
