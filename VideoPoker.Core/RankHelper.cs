using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Core
{
    public static class RankHelper
    {
        public static Rank GetRank(int rank)
        {
            return (Rank)rank;
        }   

        public static string GetRankString(Rank rank)
        {
            switch (rank)
            {
                case Rank.Two:
                case Rank.Three:
                case Rank.Four:
                case Rank.Five:
                case Rank.Six:
                case Rank.Seven:
                case Rank.Eight:
                case Rank.Nine:
                case Rank.Ten:
                    return ((int)rank).ToString().PadLeft(2);
                case Rank.Jack:
                    return "JA";
                case Rank.Queen:
                    return "QU";
                case Rank.King:
                    return "KI";
                case Rank.Ace:
                    return "AC";
            }
            throw new Exception("Invalid rank");
        }
    }
}
