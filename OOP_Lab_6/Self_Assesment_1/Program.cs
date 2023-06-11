using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Self_Assesment_1.BL;
using Self_Assesment_1.DL;
using Self_Assesment_1.UI;

namespace Self_Assesment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuItemCRUD.ReadDataFromFile("");
            int option = MenuUI.Menu();
        }
    }
}
