using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Core
{
    public class Deck
    {
       
        protected Stack<Card> _cards = new();

        
        public void Flip()
        {
            foreach (var card in _cards)
            {
                card.Flip();
            }
        }

        public void Flip(CardFacing cardFacing)
        {
            foreach (var card in _cards)
            {
                card.Flip(cardFacing);
            }
        }

        public void Shuffle()
        {
            var random = new Random();
            var cards = _cards.ToArray();
            _cards.Clear();
            foreach (var card in cards.OrderBy(c => random.Next()))
            {
                _cards.Push(card);
            }
        }

        public virtual void AddCard(Card card)
        {
            _cards.Push(card);
        }
        
        public virtual Card RemoveCard()
        {            
            if (_cards.Count == 0)
            {
                throw new Exception("Deck is empty");
            }
            return _cards.Pop();
        }

        // static method that creates a new deck
        public static Deck CreateDeck()
        {
            var deck = new Deck();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.AddCard(new Card(suit, rank));
                }
            }
            return deck;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var card in _cards)
            {
                sb.AppendLine(card.ToString());
            }
            return sb.ToString();
        }


    }
}
