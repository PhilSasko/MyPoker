namespace MyPoker.PokerLogic
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public class PlayingCard
    {
        public PlayingCard(int value, Suit suit)
        {
            Value = value;
            Suit = suit;
        }

        public int Value { get; set; }
        public Suit Suit { get; set; }
    }
}
