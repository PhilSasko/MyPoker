using MyPoker.PokerLogic.HandCalculation.HandRetrieving;

namespace MyPoker.PokerLogic.HandCalculation.Determining
{
    internal partial class RoyalFlushPokerHandRankingDeterminator : IPokerHandRankingDeterminator
    {
        public bool IsPokerHandRanking(IEnumerable<PlayingCard> playingCards)
        {
            const int AceCardValue = 14;
            StraightFlushPokerHandRankingDeterminator straightFlushPokerHandRankingDeterminator = new();
            if (straightFlushPokerHandRankingDeterminator.IsPokerHandRanking(playingCards))
            {
                StraightFlushPokerHandRetriever straightFlushPokerHandRetriever = new();
                IEnumerable<PlayingCard> straightFlushCards = straightFlushPokerHandRetriever.GetHand(playingCards).Cards;
                
                int highestCardValue = straightFlushCards.OrderByDescending(c => c.Value).FirstOrDefault()?.Value 
                    ?? throw new ArgumentException("Issue when determining Straight ranking");
                return highestCardValue == AceCardValue;
            }
            return false;
        }
    }
}
