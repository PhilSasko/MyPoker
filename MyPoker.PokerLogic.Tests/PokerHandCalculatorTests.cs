using MyPoker.PokerLogic.HandCalculation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPoker.PokerLogic.Tests
{
    /*
     * Hand Rankings (https://www.cardplayer.com/rules-of-poker/hand-rankings):
     *   1. Royal flush
     *   A, K, Q, J, 10, all the same suit.
     *   A K Q J T
     *
     *   2. Straight flush
     *   Five cards in a sequence, all in the same suit.
     *   8 7 6 5 4
     *   3. Four of a kind
     *   All four cards of the same rank.
     *   J J J J 7
     *
     *   4. Full house
     *   Three of a kind with a pair.
     *   T T T 9 9
     *
     *   5. Flush
     *   Any five cards of the same suit, but not in a sequence.
     *   4 J 8 2 9
     *
     *   6. Straight
     *   Five cards in a sequence, but not of the same suit.
     *   9 8 7 6 5
     *
     *   7. Three of a kind
     *   Three cards of the same rank.
     *   7 7 7 K 3
     *
     *   8. Two pair
     *   Two different pairs.
     *   4 4 3 3 Q
     *
     *   9. Pair
     *   Two cards of the same rank.
     *   A A 8 4 7
     *
     *   10. High Card
     *   When you haven't made any of the hands above, the highest card plays.
     *   In the example below, the jack plays as the highest card.
     *   3 J 8 4 2
     */

    [TestFixture]
    internal class PokerHandCalculatorTests
    {
        [Test]
        public void CalculateHand_WhenHighCardOnlyHand_ReturnsHighCardRanking()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(11, Suit.Spades),
                new PlayingCard(9, Suit.Spades),
                new PlayingCard(2, Suit.Hearts),
                new PlayingCard(4, Suit.Hearts),
                new PlayingCard(6, Suit.Hearts),
                new PlayingCard(8, Suit.Diamonds),
                new PlayingCard(10, Suit.Clubs)
            };
            PokerHandCalculator pokerHandCalculator = new();

            PokerHandRanking ranking = pokerHandCalculator.CalculateHand(cards).Ranking;

            Assert.That(ranking, Is.EqualTo(PokerHandRanking.HighCard));
        }

        [Test]
        public void CalculateHand_WhenHighCardOnlyHand_ReturnsOneHighestValueCard()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(9, Suit.Spades),
                new PlayingCard(11, Suit.Spades),
                new PlayingCard(2, Suit.Hearts),
                new PlayingCard(4, Suit.Hearts),
                new PlayingCard(6, Suit.Hearts),
                new PlayingCard(10, Suit.Clubs),
                new PlayingCard(8, Suit.Diamonds)
            };
            PokerHandCalculator pokerHandCalculator = new();

            PokerHand hand = pokerHandCalculator.CalculateHand(cards);
            PlayingCard resultingFirstCard = hand.Cards.FirstOrDefault() ?? throw new ArgumentNullException("no cards found");

            Assert.That(hand.Cards.Count, Is.EqualTo(1));
            Assert.That(resultingFirstCard.Value, Is.EqualTo(11));
            Assert.That(resultingFirstCard.Suit, Is.EqualTo(Suit.Spades));
        }

        [Test]
        public void CalculateHand_WhenOnePair_ReturnsPair()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(11, Suit.Spades),
                new PlayingCard(9, Suit.Spades),
                new PlayingCard(3, Suit.Hearts),
                new PlayingCard(2, Suit.Diamonds),
                new PlayingCard(8, Suit.Diamonds),
                new PlayingCard(2, Suit.Hearts),
                new PlayingCard(10, Suit.Clubs)
            };
            PokerHandCalculator pokerHandRankingCalculator = new();

            PokerHand hand = pokerHandRankingCalculator.CalculateHand(cards);

            Assert.That(hand.Ranking, Is.EqualTo(PokerHandRanking.Pair));
        }

        [Test]
        public void CalculateHand_WhenOnePair_ReturnsTwoCardsWithMatchingValue()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(11, Suit.Spades),
                new PlayingCard(9, Suit.Spades),
                new PlayingCard(3, Suit.Hearts),
                new PlayingCard(2, Suit.Diamonds),
                new PlayingCard(8, Suit.Diamonds),
                new PlayingCard(2, Suit.Hearts),
                new PlayingCard(10, Suit.Clubs)
            };
            PokerHandCalculator pokerHandRankingCalculator = new();

            PokerHand hand = pokerHandRankingCalculator.CalculateHand(cards);

            Assert.That(hand.Cards.Count, Is.EqualTo(2));
            Assert.That(hand.Cards.Count(c => c.Value == 2), Is.EqualTo(2));
            Assert.That(hand.Cards.Count(c => c.Suit == Suit.Diamonds), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Suit == Suit.Hearts), Is.EqualTo(1));
        }

        [Test]
        public void CalculateHand_WhenTwoPair_ReturnsTwoPair()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(11, Suit.Spades),
                new PlayingCard(9, Suit.Spades),
                new PlayingCard(3, Suit.Hearts),
                new PlayingCard(2, Suit.Diamonds),
                new PlayingCard(10, Suit.Diamonds),
                new PlayingCard(2, Suit.Hearts),
                new PlayingCard(10, Suit.Clubs)
            };
            PokerHandCalculator pokerHandRankingCalculator = new();

            PokerHand hand = pokerHandRankingCalculator.CalculateHand(cards);

            Assert.That(hand.Ranking, Is.EqualTo(PokerHandRanking.TwoPair));
        }

        [Test]
        public void CalculateHand_WhenTwoPair_ReturnsTwoCardsWithMatchingValue()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(11, Suit.Spades),
                new PlayingCard(9, Suit.Spades),
                new PlayingCard(3, Suit.Hearts),
                new PlayingCard(2, Suit.Diamonds),
                new PlayingCard(10, Suit.Diamonds),
                new PlayingCard(2, Suit.Hearts),
                new PlayingCard(10, Suit.Clubs)
            };
            PokerHandCalculator pokerHandRankingCalculator = new();

            PokerHand hand = pokerHandRankingCalculator.CalculateHand(cards);

            Assert.That(hand.Cards.Count, Is.EqualTo(4));
            Assert.That(hand.Cards.Count(c => c.Value == 2 && c.Suit == Suit.Diamonds), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 2 && c.Suit == Suit.Hearts), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 10 && c.Suit == Suit.Diamonds), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 10 && c.Suit == Suit.Clubs), Is.EqualTo(1));
        }

        [Test]
        public void CalculateHand_WhenThreeOfAKind_ReturnsThreeOfAKind()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(11, Suit.Spades),
                new PlayingCard(9, Suit.Spades),
                new PlayingCard(2, Suit.Hearts),
                new PlayingCard(4, Suit.Hearts),
                new PlayingCard(6, Suit.Hearts),
                new PlayingCard(2, Suit.Diamonds),
                new PlayingCard(2, Suit.Clubs)
            };
            PokerHandCalculator pokerHandRankingCalculator = new();

            PokerHand hand = pokerHandRankingCalculator.CalculateHand(cards);

            Assert.That(hand.Ranking, Is.EqualTo(PokerHandRanking.ThreeOfAKind));
        }

        [Test]
        public void CalculateHand_WhenThreeOfAKind_ReturnsThreeCardsWithMatchingValue()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(11, Suit.Spades),
                new PlayingCard(9, Suit.Spades),
                new PlayingCard(2, Suit.Hearts),
                new PlayingCard(4, Suit.Hearts),
                new PlayingCard(6, Suit.Hearts),
                new PlayingCard(2, Suit.Diamonds),
                new PlayingCard(2, Suit.Clubs)
            };
            PokerHandCalculator pokerHandRankingCalculator = new();

            PokerHand hand = pokerHandRankingCalculator.CalculateHand(cards);

            Assert.That(hand.Cards.Count, Is.EqualTo(3));
            Assert.That(hand.Cards.Count(c => c.Value == 2 && c.Suit == Suit.Hearts), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 2 && c.Suit == Suit.Diamonds), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 2 && c.Suit == Suit.Clubs), Is.EqualTo(1));
        }

        [Test]
        public void CalculateHand_WhenStraightHand_ReturnsStraightRanking()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(4, Suit.Spades),
                new PlayingCard(7, Suit.Spades),
                new PlayingCard(5, Suit.Hearts),
                new PlayingCard(4, Suit.Hearts),
                new PlayingCard(6, Suit.Hearts),
                new PlayingCard(8, Suit.Diamonds),
                new PlayingCard(11, Suit.Clubs)
            };
            PokerHandCalculator pokerHandCalculator = new();

            PokerHandRanking ranking = pokerHandCalculator.CalculateHand(cards).Ranking;

            Assert.That(ranking, Is.EqualTo(PokerHandRanking.Straight));
        }

        [Test]
        public void CalculateHand_WhenStraight_ReturnsFiveCardsWithDistinctConsecutiveValues()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(4, Suit.Spades),
                new PlayingCard(7, Suit.Spades),
                new PlayingCard(5, Suit.Hearts),
                new PlayingCard(4, Suit.Hearts),
                new PlayingCard(6, Suit.Hearts),
                new PlayingCard(8, Suit.Diamonds),
                new PlayingCard(11, Suit.Clubs)
            };
            PokerHandCalculator pokerHandRankingCalculator = new();

            PokerHand hand = pokerHandRankingCalculator.CalculateHand(cards);

            Assert.That(hand.Cards.Count, Is.EqualTo(5));
            Assert.That(hand.Cards.Count(c => c.Value == 4), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 5), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 6), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 7), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 8), Is.EqualTo(1));
        }

        [Test]
        public void CalculateHand_WhenSevenStraightValues_ReturnsCardsWithDistinctConsecutiveValuesWhichIncludeTheHighestValues()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(4, Suit.Spades),
                new PlayingCard(7, Suit.Spades),
                new PlayingCard(5, Suit.Hearts),
                new PlayingCard(6, Suit.Hearts),
                new PlayingCard(8, Suit.Diamonds),
                new PlayingCard(10, Suit.Hearts),
                new PlayingCard(9, Suit.Clubs)
            };
            PokerHandCalculator pokerHandRankingCalculator = new();

            PokerHand hand = pokerHandRankingCalculator.CalculateHand(cards);

            Assert.That(hand.Cards.Count, Is.EqualTo(5));
            Assert.That(hand.Cards.Count(c => c.Value == 6), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 7), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 8), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 9), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 10), Is.EqualTo(1));
        }

        [Test]
        public void CalculateHand_WhenFlushHand_ReturnsFlushRanking()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(4, Suit.Spades),
                new PlayingCard(5, Suit.Hearts),
                new PlayingCard(7, Suit.Diamonds),
                new PlayingCard(4, Suit.Hearts),
                new PlayingCard(6, Suit.Hearts),
                new PlayingCard(8, Suit.Hearts),
                new PlayingCard(11, Suit.Hearts)
            };
            PokerHandCalculator pokerHandCalculator = new();

            PokerHandRanking ranking = pokerHandCalculator.CalculateHand(cards).Ranking;

            Assert.That(ranking, Is.EqualTo(PokerHandRanking.Flush));
        }

        [Test]
        public void CalculateHand_WhenFlush_ReturnsFiveCardsWithTheSameSuit()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(4, Suit.Spades),
                new PlayingCard(5, Suit.Hearts),
                new PlayingCard(7, Suit.Diamonds),
                new PlayingCard(4, Suit.Hearts),
                new PlayingCard(6, Suit.Hearts),
                new PlayingCard(8, Suit.Hearts),
                new PlayingCard(11, Suit.Hearts)
            };
            PokerHandCalculator pokerHandRankingCalculator = new();

            PokerHand hand = pokerHandRankingCalculator.CalculateHand(cards);

            Assert.That(hand.Cards.Count, Is.EqualTo(5));
            Assert.That(hand.Cards.Count(c => c.Suit == Suit.Hearts && c.Value == 5), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Suit == Suit.Hearts && c.Value == 4), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Suit == Suit.Hearts && c.Value == 6), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Suit == Suit.Hearts && c.Value == 8), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Suit == Suit.Hearts && c.Value == 11), Is.EqualTo(1));
        }

        [Test]
        public void CalculateHand_WhenFullHouseHand_ReturnsFullHouseRanking()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(4, Suit.Spades),
                new PlayingCard(5, Suit.Hearts),
                new PlayingCard(7, Suit.Diamonds),
                new PlayingCard(4, Suit.Hearts),
                new PlayingCard(4, Suit.Clubs),
                new PlayingCard(5, Suit.Diamonds),
                new PlayingCard(11, Suit.Hearts)
            };
            PokerHandCalculator pokerHandCalculator = new();

            PokerHandRanking ranking = pokerHandCalculator.CalculateHand(cards).Ranking;

            Assert.That(ranking, Is.EqualTo(PokerHandRanking.FullHouse));
        }

        [Test]
        public void CalculateHand_WhenFullHouse_ReturnsThreeAndAtLeastTwoSuitMatchingCards()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(4, Suit.Spades),
                new PlayingCard(5, Suit.Hearts),
                new PlayingCard(7, Suit.Diamonds),
                new PlayingCard(4, Suit.Hearts),
                new PlayingCard(4, Suit.Clubs),
                new PlayingCard(5, Suit.Diamonds),
                new PlayingCard(11, Suit.Hearts)
            };
            PokerHandCalculator pokerHandRankingCalculator = new();

            PokerHand hand = pokerHandRankingCalculator.CalculateHand(cards);

            Assert.That(hand.Cards.Count, Is.EqualTo(5));
            
            Assert.That(hand.Cards.Count(c => c.Suit == Suit.Spades && c.Value == 4), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Suit == Suit.Hearts && c.Value == 4), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Suit == Suit.Clubs && c.Value == 4), Is.EqualTo(1));
            
            Assert.That(hand.Cards.Count(c => c.Suit == Suit.Hearts && c.Value == 5), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Suit == Suit.Diamonds && c.Value == 5), Is.EqualTo(1));
        }

        [Test]
        public void CalculateHand_WhenStraightFlushHand_ReturnsStraightFlushRanking()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(4, Suit.Spades),
                new PlayingCard(7, Suit.Hearts),
                new PlayingCard(5, Suit.Hearts),
                new PlayingCard(4, Suit.Hearts),
                new PlayingCard(6, Suit.Hearts),
                new PlayingCard(8, Suit.Hearts),
                new PlayingCard(11, Suit.Clubs)
            };
            PokerHandCalculator pokerHandCalculator = new();

            PokerHandRanking ranking = pokerHandCalculator.CalculateHand(cards).Ranking;

            Assert.That(ranking, Is.EqualTo(PokerHandRanking.StraightFlush));
        }

        [Test]
        public void CalculateHand_WhenStraightFlush_ReturnsFiveCardsWithDistinctConsecutiveValuesOfTheSameSuit()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(4, Suit.Spades),
                new PlayingCard(7, Suit.Hearts),
                new PlayingCard(5, Suit.Hearts),
                new PlayingCard(4, Suit.Hearts),
                new PlayingCard(6, Suit.Hearts),
                new PlayingCard(8, Suit.Hearts),
                new PlayingCard(11, Suit.Clubs)
            };
            PokerHandCalculator pokerHandRankingCalculator = new();

            PokerHand hand = pokerHandRankingCalculator.CalculateHand(cards);

            Assert.That(hand.Cards.Count, Is.EqualTo(5));
            Assert.That(hand.Cards.Count(c => c.Value == 4 && c.Suit == Suit.Hearts), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 5 && c.Suit == Suit.Hearts), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 6 && c.Suit == Suit.Hearts), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 7 && c.Suit == Suit.Hearts), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 8 && c.Suit == Suit.Hearts), Is.EqualTo(1));
        }

        [Test]
        public void CalculateHand_WhenRoyalFlushHand_ReturnsRoyalFlushRanking()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(13, Suit.Spades),
                new PlayingCard(12, Suit.Hearts),
                new PlayingCard(10, Suit.Hearts),
                new PlayingCard(13, Suit.Hearts),
                new PlayingCard(14, Suit.Hearts),
                new PlayingCard(11, Suit.Hearts),
                new PlayingCard(8, Suit.Hearts)
            };
            PokerHandCalculator pokerHandCalculator = new();

            PokerHandRanking ranking = pokerHandCalculator.CalculateHand(cards).Ranking;

            Assert.That(ranking, Is.EqualTo(PokerHandRanking.RoyalFlush));
        }

        [Test]
        public void CalculateHand_WhenRoyalFlush_ReturnsFiveCardsWithDistinctConsecutiveValuesOfTheSameSuitFromTenToFourteen()
        {
            List<PlayingCard> cards = new()
            {
                new PlayingCard(13, Suit.Spades),
                new PlayingCard(12, Suit.Hearts),
                new PlayingCard(10, Suit.Hearts),
                new PlayingCard(13, Suit.Hearts),
                new PlayingCard(14, Suit.Hearts),
                new PlayingCard(11, Suit.Hearts),
                new PlayingCard(8, Suit.Hearts)
            };
            PokerHandCalculator pokerHandRankingCalculator = new();

            PokerHand hand = pokerHandRankingCalculator.CalculateHand(cards);

            Assert.That(hand.Cards.Count, Is.EqualTo(5));
            Assert.That(hand.Cards.Count(c => c.Value == 14 && c.Suit == Suit.Hearts), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 13 && c.Suit == Suit.Hearts), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 12 && c.Suit == Suit.Hearts), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 11 && c.Suit == Suit.Hearts), Is.EqualTo(1));
            Assert.That(hand.Cards.Count(c => c.Value == 10 && c.Suit == Suit.Hearts), Is.EqualTo(1));
        }
    }
}
