using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.BL
{
    public class CoffeeShop
    {
        public string name;
        public List<MenuItem> Menu;
        public List<MenuItem> Orders;

        public CoffeeShop()
        {
            name = "";
            Menu = new List<MenuItem>();
            Orders = new List<MenuItem>();
        }
        public CoffeeShop(string name)
        {
            this.name = name;
            Menu = new List<MenuItem>();
            Orders = new List<MenuItem>();
        }
        public CoffeeShop(string name, List<MenuItem> Menu)
        {
            this.name = name;
            this.Menu = Menu;
        }
        public CoffeeShop(string name, List<MenuItem> Menu, List<MenuItem> Orders)
        {
            this.name = name;
            this.Menu = Menu;
            this.Orders = Orders;
        }
        public MenuItem ItemExists(string name)
        {
            if (Menu != null)
            {
                foreach (MenuItem Item in Menu)
                {
                    if (Item.name == name)
                    {
                        return Item;
                    }
                }
                return null;
            }
            return null;
        }
        public float CalculateAmmount()
        {
            float TotalAmmount = 0;
            if(Orders != null)
            {
                foreach (MenuItem Item in Orders)
                {
                    TotalAmmount = TotalAmmount + Item.price;
                    
                }
                return TotalAmmount;
            }
            return TotalAmmount;
        }
        
    }
}
