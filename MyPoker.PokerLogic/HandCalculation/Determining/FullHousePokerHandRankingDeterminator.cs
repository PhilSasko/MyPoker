namespace MyPoker.PokerLogic.HandCalculation.Determining
{
    internal class FullHousePokerHandRankingDeterminator : IPokerHandRankingDeterminator
    {
        public bool IsPokerHandRanking(IEnumerable<PlayingCard> playingCards)
        {
            var valueCounts = playingCards.GroupBy(c => c.Value, (v, c) => new { Value = v, NumberOfValueOccurrences = c.Count() });
            if(valueCounts.Any(vc => vc.NumberOfValueOccurrences >= 3))
            {
                int firstValieWithAtLeasThreeOfAKind = valueCounts.FirstOrDefault(vc => vc.NumberOfValueOccurrences >= 3)?.Value 
                    ?? throw new ArgumentException("Something went wrong when resolving a Full House ranking");

                if(valueCounts.Any(vc => vc.Value != firstValieWithAtLeasThreeOfAKind &&  vc.NumberOfValueOccurrences >= 2))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
