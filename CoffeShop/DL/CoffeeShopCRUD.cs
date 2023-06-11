using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CoffeShop.BL;

namespace CoffeShop.DL
{
    public class CoffeeShopCRUD
    {
        public static bool ReadDataFromFile(string path, List<MenuItem> Menu)
        {
            StreamReader NewFile = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = NewFile.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    string type = splittedRecord[1];
                    float price = float.Parse(splittedRecord[2]);
                    MenuItem NewMenuItem = new MenuItem(name, type, price);
                    Menu.Add(NewMenuItem);
                }
                NewFile.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void StoreDataIntoFile(string path, MenuItem NewMenuItem)
        {
            StreamWriter NewFile = new StreamWriter(path, true);
            NewFile.WriteLine(NewMenuItem.name + "," + NewMenuItem.type + "," + NewMenuItem.price);
            NewFile.Flush();
            NewFile.Close();
        }
    }
}
