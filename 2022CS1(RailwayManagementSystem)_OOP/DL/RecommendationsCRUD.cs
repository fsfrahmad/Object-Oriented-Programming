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
    public class RecommendationsCRUD
    {
        private static List<string> Recommendations = new List<string>();
        public static void AddRecommendationTOList(string recommendation)
        {
            Recommendations.Add(recommendation);
        }
        public static void LoadRecommendations(string path)
        {
            string item;
            StreamReader file = new StreamReader("E:\\OOPs\\Lab01\\OOP PD 1\\Recommendations.txt");
            while ((item = file.ReadLine()) != null)
            {
                Recommendations.Add(item);
            }
            file.Close();
        }
        public static List<string> GetRecommendations()
        {
            return Recommendations;
        }
        public static void RemoveRecommendationFromList(int RecommendationIndex)
        {   
            Recommendations.RemoveAt(RecommendationIndex);
        }
        public static void StoreRecommendations(string path)
        {
            int count = 0;
            StreamWriter file = new StreamWriter(path);
            for (int index = 0; index < Recommendations.Count; index++)
            {
                if (Recommendations[index] != " " && Recommendations[index] != "")
                {
                    if (count != 0)
                    {
                        file.WriteLine();
                    }
                    file.Write(Recommendations[index]);
                    count++;
                }
            }
            file.Flush();
            file.Close();
        }
        public static void StoreNewRecommendations(string path, string Recommendation)
        {
            StreamWriter file = new StreamWriter(path, true); // append!!
            file.WriteLine();
            file.Write(Recommendation);
            file.Flush();
            file.Close();
        }
    }
}
