using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using _2022CS1_RailwayManagementSystem__OOP.BL;
using _2022CS1_RailwayManagementSystem__OOP.UI;

namespace _2022CS1_RailwayManagementSystem__OOP.DL
{
    public class ComplainsCRUD
    {
        private static List<string> Complains = new List<string>();
        public static void AddComplainToList(string recommendation)
        {
            Complains.Add(recommendation);
        }
        public static void LoadComplains(string path)
        {
            string item;
            StreamReader file = new StreamReader(path);
            while ((item = file.ReadLine()) != null)
            {
                Complains.Add(item);
            }
            file.Close();
        }
        public static List<string> GetComplains()
        {
            return Complains;
        }
        public static void RemoveComplainsFromList(int RecommendationIndex)
        {
            Complains.RemoveAt(RecommendationIndex);
        }
        public static void StoreComplains(string path)
        {
            int count = 0;
            StreamWriter file = new StreamWriter(path);
            for (int index = 0; index < Complains.Count; index++)
            {
                if (Complains[index] != " " && Complains[index] != "")
                {
                    if (count != 0)
                    {
                        file.WriteLine();
                    }
                    file.Write(Complains[index]);
                    count++;
                }
            }
            file.Flush();
            file.Close();
        }
        public static void StoreNewComplain(string path, string Complain)
        {
            StreamWriter file = new StreamWriter(path, true); // append!!
            file.WriteLine();
            file.Write(Complain);
            file.Flush();
            file.Close();
        }
    }
}
