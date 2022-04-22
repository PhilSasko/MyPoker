namespace MyPoker.PokerLogic.HandCalculation.Determining
{
    internal class StraightFlushPokerHandRankingDeterminator : IPokerHandRankingDeterminator
    {
        public bool IsPokerHandRanking(IEnumerable<PlayingCard> playingCards)
        {
            Suit[] allSuits = { Suit.Hearts, Suit.Diamonds, Suit.Clubs, Suit.Spades };
            StraightPokerHandRankingDeterminator straightPokerHandRankingDeterminator = new();
            foreach (Suit suit in allSuits)
            {
                if(straightPokerHandRankingDeterminator.IsPokerHandRanking(playingCards.Where(c => c.Suit == suit)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
