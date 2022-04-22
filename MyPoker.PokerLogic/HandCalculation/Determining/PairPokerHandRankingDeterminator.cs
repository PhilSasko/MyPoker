namespace MyPoker.PokerLogic.HandCalculation.Determining
{
    internal class PairPokerHandRankingDeterminator : IPokerHandRankingDeterminator
    {
        public bool IsPokerHandRanking(IEnumerable<PlayingCard> playingCards) =>
            playingCards.GroupBy(c => c.Value).Count() < playingCards.Count();
    }
}
