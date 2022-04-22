using System.Collections;

namespace MyPoker.PokerLogic
{
    public class DeckOfCards : ICollection<PlayingCard>
    {
        private readonly List<PlayingCard> _cards;

        public DeckOfCards()
        {
            _cards = new List<PlayingCard>();
            InitCards();
        }

        private void InitCards()
        {
            const int NumberOfSuits = 4;
            const int LowestValue = 2;
            const int HighestValue = 14;

            for(int suit = 0; suit < NumberOfSuits; suit++) 
            {
                for(int value = LowestValue; value <= HighestValue; value++)
                {
                    Suit suitToAdd = suit switch
                    {
                        0 => Suit.Hearts,
                        1 => Suit.Diamonds,
                        2 => Suit.Clubs,
                        3 => Suit.Spades,
                        _ => throw new ArgumentException("Something wend wrong initiating the deck of cards")
                    };

                    _cards.Add(new PlayingCard(value, suitToAdd));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new();
            for (int i = 0; i < _cards.Count; i++)
            {
                int randomIndex = random.Next(0, _cards.Count - 1);
                PlayingCard tmpCard = _cards[i];
                _cards[i] = _cards[randomIndex];
                _cards[randomIndex] = tmpCard;
            }
        }

        public PlayingCard this[int index] => _cards[index];
        #region overridden methods
        // overridden methods
        public int Count => _cards.Count;

        public bool IsReadOnly => true;

        public void Add(PlayingCard item)
        {
            _cards.Add(item);
        }

        public void Clear()
        {
            _cards.Clear();
        }

        public bool Contains(PlayingCard item)
        {
            return _cards.Contains(item);
        }

        public void CopyTo(PlayingCard[] array, int arrayIndex)
        {
            _cards?.CopyTo(array, arrayIndex);
        }

        public IEnumerator<PlayingCard> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        public bool Remove(PlayingCard item)
        {
            return _cards.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
