using VideoPoker.Core;

Deck deck = Deck.CreateDeck();
deck.Flip(CardFacing.Up);
deck.Shuffle();
Console.WriteLine(deck);