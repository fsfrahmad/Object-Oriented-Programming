using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OOP_PD_6.BL;


namespace OOP_PD_6.DL
{
    public class TrainInfoCRUD
    {
        static List<TrainInfo> TrainsList = new List<TrainInfo>();
        public static TrainInfo TrainExists(TrainInfo NewTrain)
        {
            for (int i = 0; i < TrainsList.Count; i++)
            {
                if (NewTrain.no == TrainsList[i].no)
                {
                    return TrainsList[i];
                }
            }
            return null;
        }
        public static void LoadTrains()
        {
            string record;
            StreamReader file = new StreamReader("E:\\OOPs\\Lab01\\OOP PD 1\\Trains.txt");
            while ((record = file.ReadLine()) != null)
            {
                string[] TrainData = record.Split(',');
                string no = TrainData[0];
                string path = TrainData[1];
                string fair = TrainData[2];
                string timing = TrainData[3];
                TrainInfo NewTrain = new TrainInfo(no, path, fair, timing);
                TrainsList.Add(NewTrain);
            }
            file.Close();
        }
        public static void StoreTrainInList(TrainInfo Train)
        {
            TrainsList.Add(Train);
        }
        public static void StoreTrainInFile(TrainInfo Train)
        {
            StreamWriter file = new StreamWriter("E:\\OOPs\\Lab01\\OOP PD 1\\Trains.txt", true);
            file.WriteLine();
            file.WriteLine(Train.no + "," + Train.path + "," + Train.fair + "," + Train.timing);
            file.Close();
        }
        public static void DisplayTrains()
        {
            Console.WriteLine("TrainNo" + "\t" + "Train Path" + "\t\t" + "Train Fare" + "\t" + "Train Timing");
            for (int index = 0; index < TrainsList.Count; index++)
            {
                if (TrainsList[index].no != " ")
                {
                    Console.WriteLine(TrainsList[index].no + "\t" + TrainsList[index].path + "\t\t" + TrainsList[index].fair + "\t" + TrainsList[index].timing);
                }
            }
        }

    }
}
