namespace MyPoker.PokerLogic.HandCalculation.HandRetrieving
{
    internal interface IPokerHandRetriever
    {
        PokerHand GetHand(IEnumerable<PlayingCard> playingCards);
    }
}
