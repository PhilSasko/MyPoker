namespace MyPoker.PokerLogic.HandCalculation.Determining
{
    internal class TwoPairPokerHandRankingDeterminator : IPokerHandRankingDeterminator
    {
        public bool IsPokerHandRanking(IEnumerable<PlayingCard> playingCards)
        {
            var valueCounts = playingCards.GroupBy(c => c.Value, (v, c) => new { Value = v, NumberOfValueOccurrences = c.Count() });
            int numberOfReocurringValues = valueCounts.Count(vc => vc.NumberOfValueOccurrences > 1);
            return numberOfReocurringValues > 1;
        }
    }
}
