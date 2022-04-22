namespace MyPoker.PokerLogic.HandCalculation.HandRetrieving
{
    internal class FullHousePokerHandRetriever : IPokerHandRetriever
    {
        public PokerHand GetHand(IEnumerable<PlayingCard> playingCards)
        {
            var valueCounts = playingCards.GroupBy(c => c.Value, (v, c) => new { Value = v, NumberOfValueOccurrences = c.Count() });
            if (valueCounts.Any(vc => vc.NumberOfValueOccurrences >= 3))
            {
                int firstValieWithAtLeasThreeOfAKind = valueCounts.FirstOrDefault(vc => vc.NumberOfValueOccurrences >= 3)?.Value
                    ?? throw new ArgumentException("Something went wrong when resolving a Full House ranking");

                if (valueCounts.Any(vc => vc.Value != firstValieWithAtLeasThreeOfAKind && vc.NumberOfValueOccurrences >= 2))
                {
                    int secondValieWithAtLeasTwoOfAKind = valueCounts
                        .FirstOrDefault(vc => vc.Value != firstValieWithAtLeasThreeOfAKind && vc.NumberOfValueOccurrences >= 2)?
                        .Value ?? throw new ArgumentException("Something went wrong when resolving a Full House ranking");

                    IEnumerable<PlayingCard> fullHousePlayingCards = playingCards.Where(c =>
                        c.Value == firstValieWithAtLeasThreeOfAKind
                        || c.Value == secondValieWithAtLeasTwoOfAKind);

                    return new PokerHand(PokerHandRanking.FullHouse, fullHousePlayingCards);
                }
            }

            throw new ArgumentException("Unable to retrieve hand for Full House ranking");
        }
    }
}
