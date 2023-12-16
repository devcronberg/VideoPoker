namespace VideoPoker.Test
{

    using VideoPoker.Core;
    public class TestCard
    {

        [Fact]
        public void TestCardConstructor()
        {
            var card = new Card(CardSuit.Hearts, CardValue.Ace);
            Assert.Equal(CardSuit.Hearts, card.Suit);
            Assert.Equal(CardValue.Ace, card.Rank);
            Assert.Equal(CardFacing.Down, card.CardFacing);
        }


        [Fact]
        public void TestCardFlip()
        {
            var card = new Card(CardSuit.Hearts, CardValue.Ace);
            card.Flip();
            Assert.Equal(CardFacing.Up, card.CardFacing);
        }


        [Fact]
        public void TestCardFlipTwice()
        {
            var card = new Card(CardSuit.Hearts, CardValue.Ace);
            card.Flip();
            card.Flip();
            Assert.Equal(CardFacing.Down, card.CardFacing);
        }


        [Fact]
        public void TestCardCopy()
        {
            var card = new Card(CardSuit.Hearts, CardValue.Ace);
            var cardCopy = card.Copy();
            Assert.NotSame(card, cardCopy);
        }


        [Fact]
        public void TestCardCopyValues()
        {
            var card = new Card(CardSuit.Hearts, CardValue.Ace);
            var cardCopy = card.Copy();
            Assert.Equal(card.Suit, cardCopy.Suit);
            Assert.Equal(card.Rank, cardCopy.Rank);
            Assert.Equal(card.CardFacing, cardCopy.CardFacing);
        }

    }
}