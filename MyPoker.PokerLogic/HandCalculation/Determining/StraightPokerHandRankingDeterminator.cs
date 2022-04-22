namespace MyPoker.PokerLogic.HandCalculation.Determining
{
    internal partial class StraightPokerHandRankingDeterminator : IPokerHandRankingDeterminator
    {
        public bool IsPokerHandRanking(IEnumerable<PlayingCard> playingCards)
        {
            if(playingCards.Count() < 2)
            {
                return false;
            }

            List<PlayingCard> sortedPlayingCards = playingCards.OrderBy(c => c.Value).ToList();
            int numberOfStraightCards = 1;
            PlayingCard previousCard = sortedPlayingCards[0];
            
            for (int index = 1; index < sortedPlayingCards.Count; index++)
            {
                PlayingCard currentCard = sortedPlayingCards[index];
                if(currentCard.Value == previousCard.Value + 1)
                {
                    numberOfStraightCards++;
                }
                else if(currentCard.Value != previousCard.Value)
                {
                    numberOfStraightCards = 1;
                }

                if(numberOfStraightCards >= 5)
                {
                    return true;
                }

                previousCard = currentCard;
            }

            return false;
        }
    }
}
