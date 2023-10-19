using System.Xml.Serialization;

namespace VideoPoker.Core
{
    public class Card
    {
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }
        public CardFacing CardFacing { get; private set; }

        public Card()
        {
            Suit = Suit.Diamonds;
            Rank = Rank.Two;
            CardFacing = CardFacing.Down;
        }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
            CardFacing = CardFacing.Down;
        }

        public void Flip()
        {
            CardFacing = CardFacing == CardFacing.Down ? CardFacing.Up : CardFacing.Down;
        }

        public void Flip(CardFacing cardFacing)
        {
            CardFacing = cardFacing;
        }


        public Card(Suit suit, Rank rank, CardFacing cardFacing)
        {
            Suit = suit;
            Rank = rank;
            CardFacing = cardFacing;
        }

        // change the ToString method to print with actual suits

        public override string ToString()
        {
            if(CardFacing == CardFacing.Down)
            {
                return "**";
            }
            return $"{RankHelper.GetRankString(Rank)} {SuitHelper.GetSuitString(Suit)}";
        }
        
        public Card Copy()
        {
            return new Card(Suit, Rank, CardFacing);
        }
    }

}
