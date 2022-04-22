using MyPoker.PokerLogic.HandCalculation.Determining;
using MyPoker.PokerLogic.HandCalculation.HandRetrieving;

namespace MyPoker.PokerLogic.HandCalculation
{
    public class PokerHandCalculator : IPokerHandCalculator
    {
        private readonly PokerHandRankingDeterminatorFactory _pokerHandDeterminatorFactory;
        private readonly PokerHandRetrieverFactory _pokerHandRetrieverFactory;

        public PokerHandCalculator()
        {
            _pokerHandDeterminatorFactory = new PokerHandRankingDeterminatorFactory();
            _pokerHandRetrieverFactory = new PokerHandRetrieverFactory();
        }

        public PokerHand CalculateHand(IEnumerable<PlayingCard> playingCards) => playingCards switch
        {
            var cards when IsHandRanking(PokerHandRanking.RoyalFlush, cards)    => GetHand(PokerHandRanking.RoyalFlush, cards),
            var cards when IsHandRanking(PokerHandRanking.StraightFlush, cards) => GetHand(PokerHandRanking.StraightFlush, cards),
            var cards when IsHandRanking(PokerHandRanking.FullHouse, cards)     => GetHand(PokerHandRanking.FullHouse, cards),
            var cards when IsHandRanking(PokerHandRanking.Flush, cards)         => GetHand(PokerHandRanking.Flush, cards),
            var cards when IsHandRanking(PokerHandRanking.Straight, cards)      => GetHand(PokerHandRanking.Straight, cards),
            var cards when IsHandRanking(PokerHandRanking.ThreeOfAKind, cards)  => GetHand(PokerHandRanking.ThreeOfAKind, cards),
            var cards when IsHandRanking(PokerHandRanking.TwoPair, cards)       => GetHand(PokerHandRanking.TwoPair, cards),
            var cards when IsHandRanking(PokerHandRanking.Pair, cards)          => GetHand(PokerHandRanking.Pair, cards),
            _                                                                   => GetHand(PokerHandRanking.HighCard, playingCards)
        };

        private bool IsHandRanking(PokerHandRanking ranking, IEnumerable<PlayingCard> playingCards) =>
            _pokerHandDeterminatorFactory.GetHandRankingDeterminatorFactory(ranking).IsPokerHandRanking(playingCards);

        private PokerHand GetHand(PokerHandRanking ranking, IEnumerable<PlayingCard> playingCards) =>
            _pokerHandRetrieverFactory.CreatePokerHandRetriever(ranking).GetHand(playingCards);
    }
}
