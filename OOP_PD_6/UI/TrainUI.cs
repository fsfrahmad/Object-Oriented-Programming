using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_PD_6.BL;
using OOP_PD_6.DL;
using OOP_PD_6.UI;

namespace OOP_PD_6.UI
{
    class TrainUI
    {
        public static void AddTrain()
        {
            Menu.ClearScreen();
            Menu.PrintHeader();
            string TrainNo;
            Console.WriteLine("*********************************************");
            Console.WriteLine("Enter Train number:                          ");
            TrainNo = Console.ReadLine();
            TrainInfo newTrain = new TrainInfo(TrainNo);
            TrainInfo FoundTrain = TrainInfoCRUD.TrainExists(newTrain);
            if (FoundTrain != null)
            {
                Console.WriteLine("Train Already Exist!!!");
                Console.WriteLine("Enter any key to continue:...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Enter Train Path:                            ");
                FoundTrain.path = Console.ReadLine();
                Console.WriteLine("Enter Train Fare:                            ");
                FoundTrain.fair = Console.ReadLine();
                Console.WriteLine("Enter Train Timing(eg, 6:00 a.m.):           ");
                FoundTrain.timing = Console.ReadLine();
                TrainInfoCRUD.StoreTrainInList(FoundTrain);
                TrainInfoCRUD.StoreTrainInFile(FoundTrain);
                Console.WriteLine("Train Added Successfully");
                Console.WriteLine("Press any key to continue:...");
                Console.ReadKey();
            }
        }
    }
}
