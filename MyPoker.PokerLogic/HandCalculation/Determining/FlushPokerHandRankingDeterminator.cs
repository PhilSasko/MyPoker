namespace MyPoker.PokerLogic.HandCalculation.Determining
{
    internal class FlushPokerHandRankingDeterminator : IPokerHandRankingDeterminator
    {
        public bool IsPokerHandRanking(IEnumerable<PlayingCard> playingCards) =>
            playingCards
            .GroupBy(
                c => c.Suit,
                (s, c) => new { Suit = s, NumberOfCardsInSuit = c.Count() })
            .Any(sc => sc.NumberOfCardsInSuit >= 5);
    }
}
