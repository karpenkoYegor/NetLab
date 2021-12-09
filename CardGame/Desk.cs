using System;
using System.Collections.Generic;

namespace CardGame
{
    public class Desk : IDesk
    {
        private int _countOfCards;
        public int CountOfCards 
        { 
            get => _countOfCards; 
            set => _countOfCards = (value == 40) ? value : throw new Exception("Invalid cards value");
        }
        public List<ICard> Cards { get => _cards; set => _cards = value; }
        public List<ICard> GgarbageCards { get => _garbageCards; set => _garbageCards = value; }

        private List<ICard> _garbageCards = new List<ICard>();
        private List<ICard> _cards;
        private IPlayer _player1;
        private IPlayer _player2;

        public Desk(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public void CheckCards(ICard cardPlayer1, ICard cardPlayer2)
        {
            GgarbageCards.Add(cardPlayer1);
            GgarbageCards.Add(cardPlayer2);
            Console.WriteLine($"{_player1.Name} card value {cardPlayer1.Value} ({_player1.Cards.Count + _player1.Discard.Count}) cards");
            Console.WriteLine($"{_player2.Name} card value {cardPlayer2.Value} ({_player2.Cards.Count + _player2.Discard.Count}) cards");
            if (GgarbageCards[GgarbageCards.Count - 2].Value > GgarbageCards[GgarbageCards.Count - 1].Value)
            {
                ShowWinnerRound(_player1);
            }
            else
            {
                if (GgarbageCards[GgarbageCards.Count - 2].Value < GgarbageCards[GgarbageCards.Count - 1].Value)
                {
                    ShowWinnerRound(_player2);
                }
                else
                {
                    if (CheckDraw(_player1))
                    {
                        ShowPlayer(_player1);
                    }
                    if (CheckDraw(_player2))
                    {
                        ShowPlayer(_player2);
                    }
                    Console.WriteLine("Draw");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            ShowWinnerGame(_player1);
            ShowWinnerGame(_player2);
        }

        public void ShowWinnerRound(IPlayer player)
        {
            player.Discard.AddRange(GgarbageCards);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Won {player.Name} {player.Cards.Count + player.Discard.Count}");
            GgarbageCards.Clear();
        }

        public void ShowWinnerGame(IPlayer player)
        {
            if (player.Cards.Count + player.Discard.Count == CountOfCards)
            {
                ShowPlayer(player);
            }
        }

        public void ShowPlayer(IPlayer player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{player.Name} won this game");
        }

        public void GenerateCards()
        {
            Cards = new List<ICard>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Cards.Add(new Card(i));
                }
            }
        }
        public void DealCards()
        {
            int halfCount = CountOfCards / 2;
            List<ICard> cardsForPlayer1 = new List<ICard>();
            List<ICard> cardsForPlayer2 = new List<ICard>();
            for (int i = 0; i < halfCount; i++)
            {
                cardsForPlayer1.Add(Cards[i]);
            }
            for (int i = halfCount; i < Cards.Count; i++)
            {
                cardsForPlayer2.Add(Cards[i]);
            }
            _player1.DrawCards(cardsForPlayer1);
            _player2.DrawCards(cardsForPlayer2);
        }

        public void ShuffleCard()
        {
            Cards = RandomShuffle.ShuffleCard(Cards);
        }

        public bool CheckDraw(IPlayer player)
        {
            return player.Cards.Count + player.Discard.Count == CountOfCards - 2;
        }

        public List<ICard> GetCards()
        {
            return Cards;
        }
    }
}