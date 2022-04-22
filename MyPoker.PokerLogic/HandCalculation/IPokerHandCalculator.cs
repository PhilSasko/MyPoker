using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("MyPoker.PokerLogic.Tests")]

namespace MyPoker.PokerLogic.HandCalculation
{
    public interface IPokerHandCalculator
    {
        PokerHand CalculateHand(IEnumerable<PlayingCard> playingCards);
    }
}
