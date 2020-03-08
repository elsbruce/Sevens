using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    public class Card
    {
        private int value;
        private int suit;

        public Card(int value, int suit)
        {
            this.value = value;
            this.suit = suit;

        }

        public Card(int value, String suit)
        {
            this.value = value;
            this.suit = suitStringToInt(suit);
        }

        public int getValue()
        {
            return this.value;
        }

        public int getSuit()
        {
            return this.suit;
        }

        public Boolean equalsSevenOfDiamonds() //compares card to seven of diamonds, returns true if card is 7 of diamonds
        {
            if ((this.suit == 0) && (this.value == 7))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string suitIntToString() //returns a letter to represent each suit, duplicated in game class
        {
            if (this.suit == 0)
            {
                return "D";
            }
            else if (this.suit == 1)
            {
                return "H";
            }
            else if (this.suit == 2)
            {
                return "C";
            }
            else
            {
                return "S";
            }
        }

        public int suitStringToInt(String s)
        {
            if (s == "D")
            {
                return 0;
            } else if (s == "H")
            {
                return 1;
            }
            else if (s == "C")
            {
                return 2;
            } else
            {
                return 3;
            }
            
        }
    }
}
