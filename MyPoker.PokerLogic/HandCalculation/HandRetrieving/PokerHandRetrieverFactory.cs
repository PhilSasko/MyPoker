namespace MyPoker.PokerLogic.HandCalculation.HandRetrieving
{
    internal class PokerHandRetrieverFactory
    {
        public IPokerHandRetriever CreatePokerHandRetriever(PokerHandRanking ranking) => ranking switch
        {
            PokerHandRanking.RoyalFlush => new RoyalFlushPokerHandRetriever(),
            PokerHandRanking.StraightFlush => new StraightFlushPokerHandRetriever(),
            PokerHandRanking.FullHouse => new FullHousePokerHandRetriever(),
            PokerHandRanking.Flush => new FlushPokerHandRetriever(),
            PokerHandRanking.Straight => new StraightPokerHandRetriever(),
            PokerHandRanking.ThreeOfAKind => new ThreeOfAKindPokerHandRetriever(),
            PokerHandRanking.TwoPair => new TwoPairPokerHandRetriever(),
            PokerHandRanking.Pair => new PairPokerHandRetriever(),
            _ => new HightCardPokerHandRetriever()
        };
    }
}
