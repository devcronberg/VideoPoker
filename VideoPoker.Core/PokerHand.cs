namespace VideoPoker.Core
{    
    public class PokerHand : Deck
    {
        public PokerHand(Stack<Card> cards)
        {
            this.cards = cards;
        }

        public override void AddCard(Card card)
        {
            if (cards.Count == 5)
            {
                throw new Exception("Hand is full");
            }
            cards.Push(card);
        }

        public void AddCards(Stack<Card> cards)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                AddCard(cards.Pop());
            }
        }


        public bool IsFlush()
        {
            var suit = cards.Peek().Suit;
            foreach (var card in cards)
            {
                if (card.Suit != suit)
                {
                    return false;
                }
            }
            return true;
        }

        public void ConsoleWrite(bool debug = false)
        {


            foreach (Card card in cards)
            {
                card.ConsoleWrite();
                Console.Write(" ");
            }

            if (debug)
            {
                Console.WriteLine();
                Console.WriteLine();                
                Console.WriteLine($"Royal flush     : {IsRoyalFlush}   = {(IsRoyalFlush?Prizes.RoyalFlush.Value:0)}");
                Console.WriteLine($"Straight flush  : {IsStraightFlush}");
                Console.WriteLine($"Four of a kind  : {IsFourOfAKind}");
                Console.WriteLine($"Full house      : {IsFullHouse}");
                Console.WriteLine($"Flush           : {Isflush}");
                Console.WriteLine($"Straight        : {IsStraight}");
                Console.WriteLine($"Three of a kind : {IsThreeOfAKind}");
                Console.WriteLine($"Two pair        : {IsTwoPair}");
                Console.WriteLine($"Jacks or better : {IsJacksOrBetter}");
                Console.WriteLine($"One pair        : {IsOnePair}");

            }
        }


        public bool IsJacksOrBetter
        {
            get
            {
                return cards.GroupBy(card => card.Rank).Any(group => group.Count() >= 2 && group.Key >= CardValue.Jack);
            }
        }

        public bool IsTwoPair
        {
            get
            {
                return cards.GroupBy(card => card.Rank).Count(group => group.Count() == 2) == 2;
            }
        }

        public bool IsThreeOfAKind
        {
            get
            {
                return cards.GroupBy(card => card.Rank).Any(group => group.Count() == 3);
            }
        }

        public bool IsStraight
        {
            get
            {
                var ordered = cards.OrderBy(card => card.Rank).ToList();
                if (ordered[0].Rank == CardValue.Two && ordered[1].Rank == CardValue.Three && ordered[2].Rank == CardValue.Four && ordered[3].Rank == CardValue.Five && ordered[4].Rank == CardValue.Ace)
                {
                    return true;
                }
                for (int i = 0; i < ordered.Count - 1; i++)
                {
                    if (ordered[i].Rank + 1 != ordered[i + 1].Rank)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public bool Isflush
        {
            get
            {
                return cards.All(card => card.Suit == cards.First().Suit);
            }
        }

        public bool IsFullHouse
        {
            get
            {
                return IsThreeOfAKind && IsOnePair;
            }
        }

        public bool IsFourOfAKind
        {
            get
            {
                return cards.GroupBy(card => card.Rank).Any(group => group.Count() == 4);
            }
        }

        public bool IsStraightFlush
        {
            get
            {
                return Isflush && IsStraight;
            }
        }

        public bool IsRoyalFlush
        {
            get
            {
                return Isflush && IsStraight && cards.Any(card => card.Rank == CardValue.Ace);
            }
        }

        public bool IsOnePair
        {
            get
            {
                return cards.GroupBy(card => card.Rank).Any(group => group.Count() == 2);
            }
        }
    }
}
