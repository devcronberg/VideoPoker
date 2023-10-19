namespace VideoPoker.Core
{    
    public class PokerHand : Deck
    {
        public override void AddCard(Card card)
        {
            if (_cards.Count == 5)
            {
                throw new Exception("Hand is full");
            }
            _cards.Push(card);
        }

        public bool IsFlush()
        {
            var suit = _cards.Peek().Suit;
            foreach (var card in _cards)
            {
                if (card.Suit != suit)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsStraight()
        {
            var ranks = new List<Rank>();
            foreach (var card in _cards)
            {
                ranks.Add(card.Rank);
            }
            ranks.Sort();
            var rank = ranks[0];
            foreach (var r in ranks)
            {
                if (r != rank)
                {
                    return false;
                }
                rank++;
            }
            return true;
        }

        public bool IsStraightFlush()
        {
            return IsFlush() && IsStraight();
        }

        public bool IsRoyalFlush()
        {
            return IsStraightFlush() && _cards.Peek().Rank == Rank.Ace;
        }

        public bool IsFourOfAKind()
        {
            var ranks = new List<Rank>();
            foreach (var card in _cards)
            {
                ranks.Add(card.Rank);
            }
            ranks.Sort();
            var rank = ranks[0];
            var count = 0;
            foreach (var r in ranks)
            {
                if (r == rank)
                {
                    count++;
                }
                else
                {
                    count = 1;
                    rank = r;
                }
                if (count == 4)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsFullHouse()
        {
            var ranks = new List<Rank>();
            foreach (var card in _cards)
            {
                ranks.Add(card.Rank);
            }
            ranks.Sort();
            var rank = ranks[0];
            var count = 0;
            foreach (var r in ranks)
            {
                if (r == rank)
                {
                    count++;
                }
                else
                {
                    count = 1;
                    rank = r;
                }
                if (count == 3)
                {
                    break;
                }
            }
            if (count != 3)
            {
                return false;
            }
            foreach (var r in ranks)
            {
                if (r != rank)
                {
                    count = 1;
                    rank = r;
                    break;
                }
            }
            if (count != 1)
            {
                return false;
            }
            foreach (var r in ranks)
            {
                if (r == rank)
                {
                    count++;
                }
                else
                {
                    count = 1;
                    rank = r;
                }
                if (count == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsThreeOfAKind()
        {
            var ranks = new List<Rank>();
            foreach (var card in _cards)
            {
                ranks.Add(card.Rank);
            }
            ranks.Sort();
            var rank = ranks[0];
            var count = 0;
            foreach (var r in ranks)
            {
                if (r == rank)
                {
                    count++;
                }
                else
                {
                    count = 1;
                    rank = r;
                }
                if (count == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsTwoPair()
        {
            var ranks = new List<Rank>();
            foreach (var card in _cards)
            {
                ranks.Add(card.Rank);
            }
            ranks.Sort();
            var rank = ranks[0];
            var count = 0;
            foreach (var r in ranks)
            {
                if (r == rank)
                {
                    count++;
                }
                else
                {
                    count = 1;
                    rank = r;
                }
                if (count == 2)
                {
                    break;
                }
            }
            if (count != 2)
            {
                return false;
            }
            foreach (var r in ranks)
            {
                if (r != rank)
                {
                    count = 1;
                    rank = r;
                    break;
                }
            }
            if (count != 1)
            {
                return false;
            }
            foreach (var r in ranks)
            {
                if (r == rank)
                {
                    count++;
                }
                else
                {
                    count = 1;
                    rank = r;
                }
                if (count == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsPair()
        {
            var ranks = new List<Rank>();
            foreach (var card in _cards)
            {
                ranks.Add(card.Rank);
            }
            ranks.Sort();
            var rank = ranks[0];
            var count = 0;
            foreach (var r in ranks)
            {
                if (r == rank)
                {
                    count++;
                }
                else
                {
                    count = 1;
                    rank = r;
                }
                if (count == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsJacksOrBetter()
        {
            var ranks = new List<Rank>();
            foreach (var card in _cards)
            {
                ranks.Add(card.Rank);
            }
            ranks.Sort();
            var rank = ranks[0];
            var count = 0;
            foreach (var r in ranks)
            {
                if (r == rank)
                {
                    count++;
                }
                else
                {
                    count = 1;
                    rank = r;
                }
                if (count == 2 && (rank == Rank.Jack || rank == Rank.Queen || rank == Rank.King || rank == Rank.Ace))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
