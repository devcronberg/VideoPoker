using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPoker.Core
{
    public class Deck
    {
       
        protected Stack<Card> cards = new();

        public Card Peek(int index)
        {
            return cards.ElementAt(index);
        }

        public void Flip()
        {
            foreach (var card in cards)
            {
                card.Flip();
            }
        }

        public void Flip(CardFacing cardFacing)
        {
            foreach (var card in cards)
            {
                card.Flip(cardFacing);
            }
        }

        public void Shuffle()
        {
            var random = new Random();
            var cards = this.cards.ToArray();
            this.cards.Clear();
            foreach (var card in cards.OrderBy(c => random.Next()))
            {
                this.cards.Push(card);
            }
        }

        public virtual void AddCard(Card card)
        {
            cards.Push(card);
        }
        
        public virtual Card DealCard()
        {            
            if (cards.Count == 0)
            {
                throw new Exception("Deck is empty");
            }
            return cards.Pop();
        }

        public virtual Stack<Card> DealCards(int count)
        {
            if (cards.Count < count)
            {
                throw new Exception("Deck is empty");
            }
            var c = new Stack<Card>();
            for (int i = 0; i < count; i++)
            {
                c.Push(cards.Pop());                
            }
            return c;
        }

        public static Deck CreateDeck()
        {
            var deck = new Deck();
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue rank in Enum.GetValues(typeof(CardValue)))
                {
                    deck.AddCard(new Card(suit, rank));
                }
            }
            return deck;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var card in cards)
            {
                sb.AppendLine(card.ToString());
            }
            return sb.ToString();
        }


    }
}
