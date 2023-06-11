using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Self_Assesment_1.BL;
using System.IO;

namespace Self_Assesment_1.DL
{
    class MenuItemCRUD
    {
        public static List<MenuItem> MenuItemsList = new List<MenuItem>();
        public static bool ItemExists(string name)
        {
            if(MenuItemsList != null)
            {
                foreach(MenuItem Item in MenuItemsList)
                {
                    if(Item.name == name)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        public static void AddDataToList(MenuItem NewMenuItem)
        {
            MenuItemsList.Add(NewMenuItem);
        }
        public static bool ReadDataFromFile(string path)
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
                    AddDataToList(NewMenuItem);
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
        public static bool Exists(string order)
        {
            if (MenuItemsList != null)
            {
                foreach (MenuItem M in MenuItemsList)
                {
                    if (M.name == order)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
