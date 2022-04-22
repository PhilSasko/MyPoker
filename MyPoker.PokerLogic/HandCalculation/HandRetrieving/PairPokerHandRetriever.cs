namespace MyPoker.PokerLogic.HandCalculation.HandRetrieving
{
    internal class PairPokerHandRetriever : IPokerHandRetriever
    {
        public PokerHand GetHand(IEnumerable<PlayingCard> playingCards)
        {
            IEnumerable<int> cardValues = playingCards.Select(c => c.Value);
            IEnumerable<PlayingCard> pairPlayingCards = Enumerable.Empty<PlayingCard>();
            foreach (PlayingCard card in playingCards)
            {
                if (cardValues.Count(value => value == card.Value) > 1)
                {
                    pairPlayingCards = playingCards.Where(c => c.Value == card.Value);
                    return new PokerHand(PokerHandRanking.Pair, pairPlayingCards);
                }
            }

            throw new ArgumentException("Failed to retrieve Pair hand");
        }
    }
}
