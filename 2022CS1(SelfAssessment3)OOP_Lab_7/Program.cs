using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2022CS1_SelfAssessment2_OOP_Lab_7.BL;

namespace _2022CS1_SelfAssessment2_OOP_Lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            do
            {
                Console.WriteLine("Enter 1 to Play Game. ");
                Console.WriteLine("Enter 2 to Exit Game. ");
                option = int.Parse(Console.ReadLine());
                Console.Clear();
                if(option == 1)
                {
                    bool GameRunning = true;
                    int score = 0;
                    Deck Object = new Deck();
                    Object.ShuffleCards();
                    Card Card1 = Object.DealCard();
                    while(GameRunning)
                    {
                        int RemainingCard = Object.CardLeft();
                        Card Card2 = Object.DealCard();
                        Console.WriteLine("*************************************************");
                        Console.WriteLine("Your Card " + Card1.toString());
                        Console.WriteLine("**Remaining Cards**" + RemainingCard);
                        Console.WriteLine("Enter 1 if the next card is Lower.");
                        Console.WriteLine("Enter 2 if the next card is Higher.");
                        int Card_Check = int.Parse(Console.ReadLine());
                        if(Card_Check == 1)
                        {
                            if(Card1.GetValue() >= Card2.GetValue())
                            {
                                score++;
                                Card1 = Card2;
                            }
                            else
                            {
                                GameRunning = false;
                                Console.WriteLine("SORRY! YOU LOSE PRESS ANY KEY TO CONTINUE!!!");
                                Console.WriteLine("The Card was " + Card2.toString());
                                Console.WriteLine("Your Score is " + score);
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        else if(Card_Check == 2)
                        {
                            if(Card1.GetValue() <= Card2.GetValue())
                            {
                                score++;
                                Card1 = Card2;
                            }
                            else
                            {
                                GameRunning = false;
                                Console.WriteLine("SORRY! YOU LOSE PRESS ANY KEY TO CONTINUE!!!");
                                Console.WriteLine("The Card was " + Card2.toString());
                                Console.WriteLine("Your Score is " + score);
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        if(Object.CardLeft() == 0 && Card2 == null)
                        {
                            GameRunning = false;
                            Console.WriteLine("congrats you have scored MAximum");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    }
                }
            } while (option != 2);
        }
    }
}
