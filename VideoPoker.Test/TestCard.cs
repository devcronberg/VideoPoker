namespace VideoPoker.Test
{

    using VideoPoker.Core;
    public class TestCard
    {

        [Fact]
        public void TestCardConstructor()
        {
            var card = new Card(Suit.Hearts, Rank.Ace);
            Assert.Equal(Suit.Hearts, card.Suit);
            Assert.Equal(Rank.Ace, card.Rank);
            Assert.Equal(CardFacing.Down, card.CardFacing);
        }


        [Fact]
        public void TestCardFlip()
        {
            var card = new Card(Suit.Hearts, Rank.Ace);
            card.Flip();
            Assert.Equal(CardFacing.Up, card.CardFacing);
        }


        [Fact]
        public void TestCardFlipTwice()
        {
            var card = new Card(Suit.Hearts, Rank.Ace);
            card.Flip();
            card.Flip();
            Assert.Equal(CardFacing.Down, card.CardFacing);
        }


        [Fact]
        public void TestCardCopy()
        {
            var card = new Card(Suit.Hearts, Rank.Ace);
            var cardCopy = card.Copy();
            Assert.NotSame(card, cardCopy);
        }


        [Fact]
        public void TestCardCopyValues()
        {
            var card = new Card(Suit.Hearts, Rank.Ace);
            var cardCopy = card.Copy();
            Assert.Equal(card.Suit, cardCopy.Suit);
            Assert.Equal(card.Rank, cardCopy.Rank);
            Assert.Equal(card.CardFacing, cardCopy.CardFacing);
        }


        [Fact]
        public void TestCardFacingUpToString()
        {
            var card = new Card(Suit.Hearts, Rank.Ace);
            card.Flip(CardFacing.Up);
            Assert.Equal("AC H", card.ToString());

            // test severel cards
            card = new Card(Suit.Hearts, Rank.Two);
            card.Flip(CardFacing.Up);
            Assert.Equal(" 2 H", card.ToString());

            card = new Card(Suit.Clubs, Rank.Three);
            card.Flip(CardFacing.Up);
            Assert.Equal(" 3 C", card.ToString());

            card = new Card(Suit.Diamonds, Rank.Four);
            card.Flip(CardFacing.Up);
            Assert.Equal(" 4 D", card.ToString());

            card = new Card(Suit.Hearts, Rank.Five);
            card.Flip(CardFacing.Up);
            Assert.Equal(" 5 H", card.ToString());

        }


        [Fact]
        public void TestCardFacingDownToString()
        {
            var card = new Card(Suit.Hearts, Rank.Ace);
            card.Flip(CardFacing.Down);
            Assert.Equal("**", card.ToString());
        }

    }
}