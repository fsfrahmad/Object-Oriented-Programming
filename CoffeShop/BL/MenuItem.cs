using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.BL
{
    public class MenuItem
    {

        public string name;
        public string type;
        public float price;

        public MenuItem()
        {
            name = "";
            type = "";
            price = 0F;
        }
        public MenuItem(string name, string type, float price)
        {
            this.name = name;
            this.type = type;
            this.price = price;
        }
    }
}
