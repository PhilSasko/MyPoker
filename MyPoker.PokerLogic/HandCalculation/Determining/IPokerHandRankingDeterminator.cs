namespace MyPoker.PokerLogic.HandCalculation.Determining
{
    internal interface IPokerHandRankingDeterminator
    {
        bool IsPokerHandRanking(IEnumerable<PlayingCard> playingCards);
    }
}
