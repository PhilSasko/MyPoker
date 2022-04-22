namespace MyPoker.PokerLogic.HandCalculation.HandRetrieving
{
    internal class HightCardPokerHandRetriever : IPokerHandRetriever
    {
        public PokerHand GetHand(IEnumerable<PlayingCard> playingCards)
        {
            PlayingCard highCard = playingCards.OrderByDescending(c => c.Value).FirstOrDefault()
                ?? throw new ArgumentException("Issue retrieving highest value card");

            return new PokerHand(PokerHandRanking.HighCard, new List<PlayingCard> { highCard });
        }
    }
}
