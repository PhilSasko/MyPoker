namespace MyPoker.PokerLogic.HandCalculation.HandRetrieving
{
    internal class StraightPokerHandRetriever : IPokerHandRetriever
    {
        public PokerHand GetHand(IEnumerable<PlayingCard> playingCards)
        {
            Stack<PlayingCard> straightPlayingCards = new();

            List<PlayingCard> sortedPlayingCards = playingCards.OrderByDescending(c => c.Value).ToList();
            int numberOfStraightCards = 1;

            straightPlayingCards.Push(sortedPlayingCards[0]);

            for (int index = 1; index < sortedPlayingCards.Count; index++)
            {
                PlayingCard currentCard = sortedPlayingCards[index];
                if (currentCard.Value == straightPlayingCards.Peek().Value - 1)
                {
                    straightPlayingCards.Push(currentCard);
                    numberOfStraightCards++;
                }
                else if (currentCard.Value != straightPlayingCards.Peek().Value)
                {
                    straightPlayingCards.Clear();
                    straightPlayingCards.Push(currentCard);
                    numberOfStraightCards = 1;
                }

                if (numberOfStraightCards >= 5)
                {
                    return new PokerHand(PokerHandRanking.Straight, straightPlayingCards);
                }
            }

            throw new ArgumentException("Cannot retrieve cards in Straight hand");
        }
    }
}
