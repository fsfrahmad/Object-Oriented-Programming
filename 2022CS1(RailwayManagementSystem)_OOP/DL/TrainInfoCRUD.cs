using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using _2022CS1_RailwayManagementSystem__OOP.BL;

namespace _2022CS1_RailwayManagementSystem__OOP.DL
{
    public class TrainInfoCRUD
    {
        private static List<TrainInfo> TrainsList = new List<TrainInfo>();

        public static List<TrainInfo> GetList()
        {
            return TrainsList;
        }
        public static void AddTrainToList(TrainInfo NewTrain)
        {
            TrainsList.Add(NewTrain);
        }
        public static void LoadTrains(string Filepath)
        {
            string line;
            StreamReader file = new StreamReader(Filepath);
            while ((line = file.ReadLine()) != null)
            {
                string[] Data = line.Split(',');
                string no = Data[0];
                string path = Data[1];
                string fare = Data[2];
                string timing = Data[3];
                TrainInfo item = new TrainInfo(no, path,fare,timing); 
                TrainsList.Add(item);
            }
            file.Close();
        }
        public static void StoreTrains(string Filepath)
        {
            int count = 1;
            StreamWriter file = new StreamWriter(Filepath);
            for (int index = 0; index < TrainsList.Count; index++)
            {
                if (TrainsList[index].GetNo() != " " && TrainsList[index].GetNo() != "")
                {
                    if (count != 1)
                    {
                        file.WriteLine();
                    }
                    file.Write(TrainsList[index].GetNo() + "," + TrainsList[index].GetPath() + "," + TrainsList[index].GetFare() + "," + TrainsList[index].GetTiming());
                    file.Flush();
                    count++;
                }
            }
            file.Close();
        }
    }
}
