namespace MyPoker.PokerLogic.HandCalculation.HandRetrieving
{
    internal class FlushPokerHandRetriever : IPokerHandRetriever
    {
        public PokerHand GetHand(IEnumerable<PlayingCard> playingCards)
        {
            Suit flushSuit = playingCards
                .GroupBy(
                    c => c.Suit,
                    (s, c) => new { Suit = s, NumberOfCardsInSuit = c.Count() })
                .FirstOrDefault(sc => sc.NumberOfCardsInSuit >= 5)?
                .Suit ?? throw new ArgumentException("Unable to find suit satisfying a flush");

            return new PokerHand(PokerHandRanking.Flush, playingCards.Where(c => c.Suit == flushSuit));
        }
    }
}
