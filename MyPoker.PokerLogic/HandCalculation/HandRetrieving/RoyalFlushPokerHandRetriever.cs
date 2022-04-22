using MyPoker.PokerLogic.HandCalculation.Determining;

namespace MyPoker.PokerLogic.HandCalculation.HandRetrieving
{
    internal class RoyalFlushPokerHandRetriever : IPokerHandRetriever
    {
        // Note that this method can currently not be used to handle a situation with multiple straight/royal flushes
        public PokerHand GetHand(IEnumerable<PlayingCard> playingCards)
        {
            const int AceCardValue = 14;
            StraightFlushPokerHandRankingDeterminator straightFlushPokerHandRankingDeterminator = new();
            if (straightFlushPokerHandRankingDeterminator.IsPokerHandRanking(playingCards))
            {
                StraightFlushPokerHandRetriever straightFlushPokerHandRetriever = new();
                IEnumerable<PlayingCard> straightFlushCards = straightFlushPokerHandRetriever.GetHand(playingCards).Cards;
                if(straightFlushCards.OrderByDescending(c => c.Value).FirstOrDefault()?.Value == AceCardValue)
                {
                    return new PokerHand(PokerHandRanking.RoyalFlush, straightFlushCards);
                }
            }
            throw new ArgumentException("Unable to retrieve cards for Royal Flush");
        }
    }
}
