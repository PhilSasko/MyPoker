namespace MyPoker.PokerLogic.HandCalculation.Determining
{
    internal class PokerHandRankingDeterminatorFactory
    {
        public IPokerHandRankingDeterminator GetHandRankingDeterminatorFactory(PokerHandRanking ranking) => ranking switch
        {
            PokerHandRanking.RoyalFlush => new RoyalFlushPokerHandRankingDeterminator(),
            PokerHandRanking.StraightFlush => new StraightFlushPokerHandRankingDeterminator(),
            PokerHandRanking.FullHouse => new FullHousePokerHandRankingDeterminator(),
            PokerHandRanking.Flush => new FlushPokerHandRankingDeterminator(),
            PokerHandRanking.Straight => new StraightPokerHandRankingDeterminator(),
            PokerHandRanking.ThreeOfAKind => new ThreeOfAKindPokerHandRankingDeterminator(),
            PokerHandRanking.TwoPair => new TwoPairPokerHandRankingDeterminator(),
            PokerHandRanking.Pair => new PairPokerHandRankingDeterminator(),
            _ => throw new ArgumentException($"{ranking} is not a valid ranking when retrieving a determinator")
        };
    }
}
