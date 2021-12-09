using System;
using System.Collections.Generic;

namespace CardGame
{
    public class Player : IPlayer
    {
        private string _name;
        public string Name { get => (_name == "") ? "Unknow" : _name; set => _name = value; }
        public Queue<ICard> Cards { get; set; }
        public List<ICard> Discard { get; set; }

        public Player(string name)
        {
            Name = name;
            Cards = new Queue<ICard>();
            Discard = new List<ICard>();
        }
        public void DrawCards(List<ICard> cards)
        {
            foreach (var card in cards)
            {
                Cards.Enqueue(card);
            }
        }

        public ICard GetCard()
        {
            return Cards.Dequeue();
        }

        public int GetCountCards()
        {
            if (Cards.Count == 0)
            {
                Discard = RandomShuffle.ShuffleCard(Discard);
                FillCards();
            }

            return Cards.Count;
        }

        public void FillCards()
        {
            foreach (var card in Discard)
            {
                Cards.Enqueue(card);
            }
            Discard.Clear();
        }
    }
}