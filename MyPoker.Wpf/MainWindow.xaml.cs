using MyPoker.PokerLogic;
using MyPoker.PokerLogic.HandCalculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyPoker.Wpf
{
    public enum GameState
    {
        Start,
        FourthCardDealt,
        FifthCardDealt
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DeckOfCards _playingCards;
        private PlayerCards? _playerCards;
        private TableCards? _tableCards;
        private GameState _gameState;

        private CardControl _tableCardControl1;
        private CardControl _tableCardControl2;
        private CardControl _tableCardControl3;
        private CardControl _tableCardControl4;
        private CardControl _tableCardControl5;

        private CardControl _playerCardControl1;
        private CardControl _playerCardControl2;

        private IList<PlayingCard> _cardsPlayed = new List<PlayingCard>();

        public MainWindow()
        {
            _playingCards = new DeckOfCards();

            InitializeComponent();

            _playerCardControl1 = new(playerValueFirst, playerSuitFirst, playerRectFirst);
            _playerCardControl2 = new(playerValueSecond, playerSuitSecond, playerRectSecond);

            _tableCardControl1 = new(tableValueFirst, tableSuitFirst, tableRectFirst);
            _tableCardControl2 = new(tableValueSecond, tableSuitSecond, tableRectSecond);
            _tableCardControl3 = new(tableValueThird, tableSuitThird, tableRectThird);
            _tableCardControl4 = new(tableValueFourth, tableSuitFourth, tableRectFourth);
            _tableCardControl5 = new(tableValueFifth, tableSuitFifth, tableRectFifth);

            PlayGame();
        }

        private void PlayGame()
        {
            StartNewRound();
            _gameState = GameState.Start;
        }

        private void CalculateAndDisplayRanking()
        {
            PokerHandCalculator pokerHandCalculator = new();
            PokerHand hand = pokerHandCalculator.CalculateHand(_cardsPlayed);
            rankingLabel.Content = hand.Ranking;
        }

        private void StartNewRound()
        {
            _playingCards.Shuffle();
            DealPlayerCards();
            SetTableCards();
            ResetCardsPlayed();
            CalculateAndDisplayRanking();
            _gameState = GameState.Start;
        }

        private void ResetCardsPlayed()
        {
            _cardsPlayed = new List<PlayingCard>
            {
                _playerCards.Card1,
                _playerCards.Card2,

                _tableCards.Card1,
                _tableCards.Card2,
                _tableCards.Card3,
            };
        }

        private void ClearTableCards()
        {
            _tableCardControl4.ClearControlCard();
            _tableCardControl5.ClearControlCard();
        }

        private void DealFourthTableCard()
        {
            PlayingCard fourthCard = _tableCards?.Card4 ?? throw new ArgumentNullException(nameof(fourthCard));
            _tableCardControl4.AssignCard(fourthCard);
            _cardsPlayed.Add(fourthCard);
            _gameState = GameState.FourthCardDealt;
        }

        private void DealFifthTableCard()
        {
            PlayingCard fifthCard = _tableCards?.Card5 ?? throw new ArgumentNullException(nameof(fifthCard));
            _tableCardControl5.AssignCard(fifthCard);
            _cardsPlayed.Add(fifthCard);
            _gameState = GameState.FifthCardDealt;
        }

        private void DealPlayerCards()
        {
            _playerCards = new PlayerCards(
                card1: _playingCards[0], 
                card2: _playingCards[1]);
            _playerCardControl1.AssignCard(_playerCards.Card1);
            _playerCardControl2.AssignCard(_playerCards.Card2);
        }

        private void SetTableCards()
        {
            _tableCards = new TableCards(
                card1: _playingCards[2],
                card2: _playingCards[3],
                card3: _playingCards[4],
                card4: _playingCards[5],
                card5: _playingCards[6]);
            _tableCardControl1.AssignCard(_tableCards.Card1);
            _tableCardControl2.AssignCard(_tableCards.Card2);
            _tableCardControl3.AssignCard(_tableCards.Card3);
        }

        private void GameNextActionButton_Click(object sender, RoutedEventArgs e)
        {
            switch (_gameState)
            {
                case GameState.Start:
                    DealFourthTableCard();
                    break;
                case GameState.FourthCardDealt:
                    DealFifthTableCard();
                    break;
                case GameState.FifthCardDealt:
                    ClearTableCards();
                    StartNewRound();
                    break;
            }
            CalculateAndDisplayRanking();
        }
    }

    internal class CardControl
    {
        public CardControl(Label valueLabel, Label suitLabel, Rectangle outline)
        {
            ValueLabel = valueLabel;
            SuitLabel = suitLabel;
            Outline = outline;
        }

        public Label ValueLabel { get; private set; }
        public Label SuitLabel { get; private set; }
        public Rectangle Outline { get; private set; }

        public void AssignCard(PlayingCard playingCard)
        {
            SetControlContent(playingCard);
            SetControlColor(playingCard.Suit);
        }

        public void ClearControlCard()
        {
            SetControlContent(null);
            SetControlColor(null);
        }

        private void SetControlContent(PlayingCard? playingCard)
        {
            ValueLabel.Content = playingCard?.Value switch
            {
                11 => "Jack",
                12 => "Queen",
                13 => "King",
                14 => "Ace",
                null => "?",
                _ => playingCard.Value
            };
            SuitLabel.Content = playingCard?.Suit.ToString() ?? "?";
        }

        private void SetControlColor(Suit? suit)
        {
            Brush cardColor = suit is Suit.Hearts or Suit.Diamonds
                            ? Brushes.Red
                            : Brushes.Black;

            ValueLabel.Foreground = cardColor;
            SuitLabel.Foreground = cardColor;
            Outline.Stroke = cardColor;
        }
    }
}
