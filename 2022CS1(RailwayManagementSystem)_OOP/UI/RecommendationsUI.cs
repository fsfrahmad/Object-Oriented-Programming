using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_RailwayManagementSystem__OOP.BL;
using _2022CS1_RailwayManagementSystem__OOP.DL;

namespace _2022CS1_RailwayManagementSystem__OOP.UI
{
    public class RecommendationsUI
    {
        public static void DisplayRecommendations()
        {
            List<string> Recommendations = RecommendationsCRUD.GetRecommendations();
            int loopCount = 0;
            for (int index = 0; index < Recommendations.Count; index++)
            {
                Console.WriteLine("Recommendation No " + (index + 1) + " : " + Recommendations[index]);
                loopCount++;
            }
            if (loopCount == 0)
            {
                Console.WriteLine("No recommendations Yet! ...");
            }
        }
        public static void AddRecommendation()
        {
            string recomendation;
            MenuUI.ClearScreen();
            MenuUI.PrintHeader();
            Console.WriteLine("*********************************************");
            Console.WriteLine("Enter Recommendation: ");
            recomendation = Console.ReadLine();
            RecommendationsCRUD.StoreNewRecommendations("",recomendation); // !!!!!!!
            RecommendationsCRUD.AddRecommendationTOList(recomendation);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("For Further Help                                                   ");
            Console.WriteLine("Contact us:                                                        ");
            Console.WriteLine("+92 0300 123456789 Or +92 0310 123456789                           ");
            Console.WriteLine();
            Console.WriteLine("ThankYou                                                           ");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue:...");
            Console.ReadKey();
        }
        public static void RemoveRecommendation()
        {
            if (RecommendationsCRUD.GetRecommendations().Count != 0)
            {
                int RecommendationIndex;
                MenuUI.ClearScreen();
                MenuUI.PrintHeader();
                Console.WriteLine("*********************************************");
                Console.WriteLine("Enter Recommendation No. ");
                RecommendationIndex = int.Parse(Console.ReadLine());
                RecommendationIndex = RecommendationIndex - 1;
                RecommendationsCRUD.RemoveRecommendationFromList(RecommendationIndex);
                RecommendationsCRUD.StoreRecommendations("E:\\OOPs\\Lab01\\OOP PD 1\\Recommendations.txt");
                Console.WriteLine();
                Console.WriteLine("Recommendation Removed Successfully!...");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue:...");
                Console.ReadKey();
            }
        }
    }
}
