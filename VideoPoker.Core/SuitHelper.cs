using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Core
{
    public static class SuitHelper
    {
        public static Suit GetSuit(int suit)
        {
            return (Suit)suit;
        }

        public static string GetSuitString(Suit suit)
        {
            switch (suit)
            {
                case Suit.Hearts:
                    return "H";
                case Suit.Diamonds:
                    return "D";
                case Suit.Clubs:
                    return "C";
                case Suit.Spades:
                    return "S";
            }
            throw new Exception("Invalid suit");
        }
    }
}
