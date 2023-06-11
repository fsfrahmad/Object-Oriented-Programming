using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_07
{
    public class FireFighter
    {
        protected string name;
        protected FireTruck MyTruck;
        public FireFighter(string name, FireTruck MyTruck)
        {
            this.name = name;
            this.MyTruck = MyTruck;
        }
        public string GetName()
        {
            return name;
        }
    }
}
