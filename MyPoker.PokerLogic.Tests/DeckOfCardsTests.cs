using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyPoker.PokerLogic.Tests
{
    [TestFixture]
    internal class DeckOfCardsTests
    {
        [TestCaseSource(nameof(FullDeckOfCards))]
        public void DeckOfCards_OnCreation_CreatesOneOfEachCard(Suit expectedSuit, int expectedValue)
        {
            DeckOfCards deckOfCards = new DeckOfCards();

            IEnumerable<PlayingCard> matchingPlayingCards = deckOfCards
                .Where(card => card.Value == expectedValue && card.Suit == expectedSuit);

            Assert.That(matchingPlayingCards.Count, Is.EqualTo(1));
        }

        [TestCase(1)]
        [TestCase(15)]
        public void DeckOfCards_OnCreation_DoesntCreateValue(int excludedValue)
        {
            DeckOfCards deckOfCards = new DeckOfCards();

            IEnumerable<PlayingCard> matchingPlayingCardsHearts = deckOfCards
                .Where(card => card.Value == excludedValue && card.Suit == Suit.Hearts);
            IEnumerable<PlayingCard> matchingPlayingCardsDiamonds = deckOfCards
                .Where(card => card.Value == excludedValue && card.Suit == Suit.Diamonds);
            IEnumerable<PlayingCard> matchingPlayingCardsClubs = deckOfCards
                .Where(card => card.Value == excludedValue && card.Suit == Suit.Clubs);
            IEnumerable<PlayingCard> matchingPlayingCardsSpades = deckOfCards
                .Where(card => card.Value == excludedValue && card.Suit == Suit.Spades);


            Assert.That(matchingPlayingCardsHearts.Count, Is.EqualTo(0));
            Assert.That(matchingPlayingCardsDiamonds.Count, Is.EqualTo(0));
            Assert.That(matchingPlayingCardsClubs.Count, Is.EqualTo(0));
            Assert.That(matchingPlayingCardsSpades.Count, Is.EqualTo(0));
        }

        [TestCaseSource(nameof(FullDeckOfCards))]
        public void DeckOfCards_AfterShuffle_ShouldContainOneOfEachCard(Suit expectedSuit, int expectedValue)
        {
            DeckOfCards deckOfCards = new DeckOfCards();
            deckOfCards.Shuffle();

            IEnumerable<PlayingCard> matchingPlayingCards = deckOfCards
                .Where(card => card.Value == expectedValue && card.Suit == expectedSuit);

            Assert.That(matchingPlayingCards.Count, Is.EqualTo(1));
        }

        [Test]
        // Note that there is a chance this test will fail if the randomization causes fewer than 5 cards to displace
        public void DeckOfCards_AterShuffling_AtLeast5CardsHaveBeenShuffledToNewIndices()
        {
            DeckOfCards unshuffledDeckOfCards = new DeckOfCards();
            
            DeckOfCards deckOfCards = new DeckOfCards();
            deckOfCards.Shuffle();

            int nuberOfNonMathingCards = 0;
            for (int i = 0; i < deckOfCards.Count; i++)
            {
                if (deckOfCards[i].Suit != unshuffledDeckOfCards[i].Suit
                    && deckOfCards[i].Value != unshuffledDeckOfCards[i].Value)
                {
                    nuberOfNonMathingCards++;
                }
            }

            Assert.That(nuberOfNonMathingCards, Is.AtLeast(5));
        }

        [Test]
        public void DeckOfCards_AterShufflingTwice_AtLeast5CardsHaveBeenShuffledToNewIndicesFromFirstToSecondShuffle()
        {
            DeckOfCards deckOfCards = new DeckOfCards();
            deckOfCards.Shuffle();

            List<PlayingCard> playingCardsAfterOneShuffle = new List<PlayingCard>();

            for (int i = 0; i < deckOfCards.Count; i++)
            {
                playingCardsAfterOneShuffle.Add(deckOfCards[i]);
            }

            deckOfCards.Shuffle();

            int nuberOfNonMathingCards = 0;
            for (int i = 0; i < deckOfCards.Count; i++)
            {
                if (deckOfCards[i].Suit != playingCardsAfterOneShuffle[i].Suit
                    && deckOfCards[i].Value != playingCardsAfterOneShuffle[i].Value)
                {
                    nuberOfNonMathingCards++;
                }
            }

            Assert.That(nuberOfNonMathingCards, Is.AtLeast(5));
        }

        private static readonly object[] FullDeckOfCards = 
        {
            new object[] { Suit.Hearts, 2 },
            new object[] { Suit.Hearts, 3 },
            new object[] { Suit.Hearts, 4 },
            new object[] { Suit.Hearts, 5 },
            new object[] { Suit.Hearts, 6 },
            new object[] { Suit.Hearts, 7 },
            new object[] { Suit.Hearts, 8 },
            new object[] { Suit.Hearts, 9 },
            new object[] { Suit.Hearts, 10 },
            new object[] { Suit.Hearts, 11 },
            new object[] { Suit.Hearts, 12 },
            new object[] { Suit.Hearts, 13 },
            new object[] { Suit.Hearts, 14 },

            new object[] { Suit.Diamonds, 2 },
            new object[] { Suit.Diamonds, 3 },
            new object[] { Suit.Diamonds, 4 },
            new object[] { Suit.Diamonds, 5 },
            new object[] { Suit.Diamonds, 6 },
            new object[] { Suit.Diamonds, 7 },
            new object[] { Suit.Diamonds, 8 },
            new object[] { Suit.Diamonds, 9 },
            new object[] { Suit.Diamonds, 10 },
            new object[] { Suit.Diamonds, 11 },
            new object[] { Suit.Diamonds, 12 },
            new object[] { Suit.Diamonds, 13 },
            new object[] { Suit.Diamonds, 14 },

            new object[] { Suit.Clubs, 2 },
            new object[] { Suit.Clubs, 3 },
            new object[] { Suit.Clubs, 4 },
            new object[] { Suit.Clubs, 5 },
            new object[] { Suit.Clubs, 6 },
            new object[] { Suit.Clubs, 7 },
            new object[] { Suit.Clubs, 8 },
            new object[] { Suit.Clubs, 9 },
            new object[] { Suit.Clubs, 10 },
            new object[] { Suit.Clubs, 11 },
            new object[] { Suit.Clubs, 12 },
            new object[] { Suit.Clubs, 13 },
            new object[] { Suit.Clubs, 14 },

            new object[] { Suit.Spades, 2 },
            new object[] { Suit.Spades, 3 },
            new object[] { Suit.Spades, 4 },
            new object[] { Suit.Spades, 5 },
            new object[] { Suit.Spades, 6 },
            new object[] { Suit.Spades, 7 },
            new object[] { Suit.Spades, 8 },
            new object[] { Suit.Spades, 9 },
            new object[] { Suit.Spades, 10 },
            new object[] { Suit.Spades, 11 },
            new object[] { Suit.Spades, 12 },
            new object[] { Suit.Spades, 13 },
            new object[] { Suit.Spades, 14 }
        };
    }
}
