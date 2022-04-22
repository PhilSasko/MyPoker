namespace MyPoker.PokerLogic.HandCalculation.Determining
{
    internal class ThreeOfAKindPokerHandRankingDeterminator : IPokerHandRankingDeterminator
    {
        public bool IsPokerHandRanking(IEnumerable<PlayingCard> playingCards)
        {
            var valueCounts = playingCards.GroupBy(
                c => c.Value, 
                (v, c) => new { Value = v, NumberOfValueOccurrences = c.Count() });

            return valueCounts.Any(vc => vc.NumberOfValueOccurrences > 2);
        }
    }
}
