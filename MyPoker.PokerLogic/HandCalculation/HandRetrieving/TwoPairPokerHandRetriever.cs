namespace MyPoker.PokerLogic.HandCalculation.HandRetrieving
{
    internal class TwoPairPokerHandRetriever : IPokerHandRetriever
    {
        public PokerHand GetHand(IEnumerable<PlayingCard> playingCards)
        {
            IEnumerable<int> uniqueReocurringValues = playingCards
                .GroupBy(
                    c => c.Value,
                    (v, c) => new { Value = v, NumberOfValueOccurrences = c.Count() })
                .Where(vn => vn.NumberOfValueOccurrences > 1)
                .Select(vn => vn.Value);

            IEnumerable<PlayingCard> twoPairPlayingCards = playingCards.Where(c => uniqueReocurringValues.Contains(c.Value));

            return new PokerHand(PokerHandRanking.TwoPair, twoPairPlayingCards);
        }
    }
}
