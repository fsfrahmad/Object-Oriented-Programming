using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022CS1_SelfAssessment2_OOP_Lab_7
{
    class Card
    {
        private int value;
        private int suit;
        
        public Card(int value, int suit)
        {
            this.value = value;
            this.suit = suit;
        }
        public int GetValue()
        {
            return value;
        }
        public int GetSuit()
        {
            return suit;
        }
        public string GetValueAsString()
        {
            if (value == 1)
            {
                return "Ace";
            }
            else if (value == 11)
            {
                return "Jake";
            }
            else if (value == 12)
            {
                return "Quenn";
            }
            else if (value == 13)
            {
                return "King";
            }
            else
            {
                return value.ToString();
            }
        }
        public string GetSuitAsString()
        {
            if (suit == 1)
            {
                return "Clubs";
            }
            else if (suit == 2)
            {
                return "Diamonds";
            }
            else if (suit == 3)
            {
                return "Spades";
            }
            else 
            {
                return "Hearts";
            }
        }
        public string toString()
        {
            return GetValueAsString() + " OF " + GetSuitAsString();
        }
    }
}
