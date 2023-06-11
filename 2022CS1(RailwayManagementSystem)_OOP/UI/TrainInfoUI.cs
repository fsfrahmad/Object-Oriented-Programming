using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using _2022CS1_RailwayManagementSystem__OOP.BL;
using _2022CS1_RailwayManagementSystem__OOP.DL;

namespace _2022CS1_RailwayManagementSystem__OOP.UI
{
    public class TrainInfoUI
    {
        public static void DisplayTrains()
        {
            List<TrainInfo> Trains = TrainInfoCRUD.GetList();
            Console.WriteLine("TrainNo" + "\t" + "Train Path" + "\t\t" + "Train Fare" + "\t" + "Train Timing");
            for (int index = 0; index < Trains.Count; index++)
            {
                if (Trains[index].GetNo() != " ")
                {
                    Console.WriteLine(Trains[index].GetNo() + "\t" + Trains[index].GetPath() + "\t\t" + Trains[index].GetFare() + "\t" + Trains[index].GetTiming());
                }
            }
        }
        public static int FindTrainFromList(string TrainNo)
        {
            List<TrainInfo> Trains = TrainInfoCRUD.GetList();
            for (int i = 0; i < Trains.Count; i++)
            {
                if (TrainNo == Trains[i].GetNo())
                {
                    return i;
                }
            }
            return -1;
        }
        public static bool CheckTrain(string TrainNo)
        {
            List<TrainInfo> Trains = TrainInfoCRUD.GetList();
            int isFound = -1;
            for (int index = 0; index < Trains.Count; index++)
            {
                if (TrainNo == Trains[index].GetNo())
                {
                    isFound = index;
                }
            }
            if (isFound != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int DisplaysTrainAccordingToPath(string TrainPath)
        {
            List<TrainInfo> Trains = TrainInfoCRUD.GetList();
            int count = 0;
            Console.WriteLine("All available Trains for given Route are:");
            Console.WriteLine();
            Console.WriteLine("TrainNo" + "\t" + "Train Path" + "\t\t" + "Train Fare" + "\t" + "Train Timing");
            for (int index = 0; index < Trains.Count; index++)
            {
                if (TrainPath == Trains[index].GetPath())
                {
                    Console.WriteLine(Trains[index].GetNo() + "\t" + Trains[index].GetPath() + "\t\t" + Trains[index].GetFare() + "\t" + Trains[index].GetTiming());
                    count++;
                }
            }
            return count;
        }
    }
}
