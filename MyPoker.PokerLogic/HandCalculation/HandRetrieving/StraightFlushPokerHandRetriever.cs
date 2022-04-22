using MyPoker.PokerLogic.HandCalculation.Determining;

namespace MyPoker.PokerLogic.HandCalculation.HandRetrieving
{
    internal class StraightFlushPokerHandRetriever : IPokerHandRetriever
    {
        // Note that this method can currently not be used to handle a situation with multiple straight flushes
        public PokerHand GetHand(IEnumerable<PlayingCard> playingCards)
        {
            Suit[] allSuits = { Suit.Hearts, Suit.Diamonds, Suit.Clubs, Suit.Spades };
            StraightPokerHandRankingDeterminator straightPokerHandRankingDeterminator = new();
            foreach (Suit suit in allSuits)
            {
                IEnumerable<PlayingCard> suitPlayingCards = playingCards.Where(c => c.Suit == suit);
                if (straightPokerHandRankingDeterminator.IsPokerHandRanking(suitPlayingCards))
                {
                    StraightPokerHandRetriever straightPokerHandRetriever = new();
                    IEnumerable<PlayingCard> straightFlushCards = straightPokerHandRetriever.GetHand(suitPlayingCards).Cards;
                    return new PokerHand(PokerHandRanking.StraightFlush, straightFlushCards);
                }
            }
            throw new ArgumentException("Unable to resolve Straight Flush cards");
        }
    }
}
