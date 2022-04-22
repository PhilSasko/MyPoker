using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPoker.PokerLogic
{
    public class PlayerCards
    {
        public PlayerCards(PlayingCard card1, PlayingCard card2)
        {
            Card1 = card1;
            Card2 = card2;
        }

        public PlayingCard Card1 { get; set; }
        public PlayingCard Card2 { get; set; }
    }

    public class TableCards
    {
        public TableCards(PlayingCard card1, PlayingCard card2, PlayingCard card3, PlayingCard card4, PlayingCard card5)
        {
            Card1 = card1;
            Card2 = card2;
            Card3 = card3;
            Card4 = card4;
            Card5 = card5;
        }

        public PlayingCard Card1 { get; set; }
        public PlayingCard Card2 { get; set; }
        public PlayingCard Card3 { get; set; }
        public PlayingCard Card4 { get; set; }
        public PlayingCard Card5 { get; set; }

    }
}
