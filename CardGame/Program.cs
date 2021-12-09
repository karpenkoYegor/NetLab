using System;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer player1 = new Player("Yegor");
            IPlayer player2 = new Player("Yarik");

            IDesk desk = new Desk(player1, player2);
            desk.CountOfCards = 40;
            desk.GenerateCards();
            desk.ShuffleCard();
            desk.DealCards();

            while (player1.GetCountCards() > 0 && player2.GetCountCards() > 0)
            {
                var cardFirstPlayer = player1.GetCard();
                var cardSecondPlayer = player2.GetCard();
                desk.CheckCards(cardFirstPlayer, cardSecondPlayer);
            }
        }
    }
}
