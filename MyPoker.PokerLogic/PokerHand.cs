
namespace MyPoker.PokerLogic
{
    public class PokerHand
    {
        public PokerHand(PokerHandRanking ranking, IEnumerable<PlayingCard> cards)
        {
            Ranking = ranking;
            Cards = cards;
        }

        public PokerHandRanking Ranking { get; set; }
        public IEnumerable<PlayingCard> Cards { get; set; }
    }

    public enum PokerHandRanking
    {
        RoyalFlush,
        StraightFlush,
        FullHouse,
        Flush,
        Straight,
        ThreeOfAKind,
        TwoPair,
        Pair,
        HighCard
    }
}
