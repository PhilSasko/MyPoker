namespace MyPoker.PokerLogic.HandCalculation.HandRetrieving
{
    internal class ThreeOfAKindPokerHandRetriever : IPokerHandRetriever
    {
        public PokerHand GetHand(IEnumerable<PlayingCard> playingCards)
        {
            int valueInThreeOfAKind = playingCards.GroupBy(
                    c => c.Value,
                    (v, c) => new { Value = v, NumberOfValueOccurrences = c.Count() })
                .FirstOrDefault(vn => vn.NumberOfValueOccurrences > 2)?
                .Value ?? throw new ArgumentException("Unable to resolve Three of a Kind");

            IEnumerable<PlayingCard> threeOfAKindPlayingCards = playingCards.Where(c => c.Value == valueInThreeOfAKind);
            return new PokerHand(PokerHandRanking.ThreeOfAKind, threeOfAKindPlayingCards);
        }
    }
}
