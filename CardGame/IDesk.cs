using System;
using System.Collections.Generic;

namespace CardGame
{
    public interface IDesk
    {
        public int CountOfCards {
            get => CountOfCards;
            set => CountOfCards = (value == 40) ? value : throw new Exception("Invalid cards value");
        }
        public List<ICard> Cards { get; set; }
        public List<ICard> GgarbageCards { get; set; }
        public void ShuffleCard();
        public void CheckCards(ICard cardPlayer1, ICard cardPlayer2);
        public void GenerateCards();
        public void DealCards();
        public List<ICard> GetCards();
    }
}