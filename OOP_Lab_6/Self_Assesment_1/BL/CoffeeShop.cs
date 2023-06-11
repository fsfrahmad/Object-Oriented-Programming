using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Self_Assesment_1.BL;
using Self_Assesment_1.DL;
using Self_Assesment_1.UI;


namespace Self_Assesment_1.BL
{
    public class CoffeeShop
    {
        public string name;
        public List<MenuItem> Menu = new List<MenuItem>();
        public List<string> Orders;

        public CoffeeShop()
        {
            name = "";
            Menu = new List<MenuItem>();
            Orders = new List<string>();
        }
        public CoffeeShop(string name, List<MenuItem> Menu)
        {
            this.name = name;
            this.Menu = Menu;
        }
        public CoffeeShop(string name, List<MenuItem> Menu, List<string> Orders)
        {
            this.name = name;
            this.Menu = Menu;
            this.Orders = Orders;
        }

    }
}
