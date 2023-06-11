using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssessment2_OOP_Lab_7.BL
{
    class Deck
    {
        private int count;
        private Card[] deck = new Card[52];
        public Deck()
        {
            count = 0;
            for(int suit = 1; suit <= 4; suit++)
            {
                for(int value= 1; value <= 13; value++)
                {
                    deck[count] = new Card(value, suit);
                    count++;
                }
            }
        }
        public void ShuffleCards()
        {
            System.Random rand = new System.Random();
            Card temp;
            for(int i = 0; i < 52; i++)
            {
                int num = rand.Next(0, 52);
                temp = deck[num];
                deck[num] = deck[i];
                deck[i] = temp;
            }
            count = 52;
        }
        public Card DealCard()
        {
            if(count > 0)
            {
                count--;
                return deck[count];
            }
            else
            {
                return null;
            }
        }
        public int CardLeft()
        {
            return count;
        }
    }
}
