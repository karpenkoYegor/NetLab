using System.Collections.Generic;

namespace CardGame
{
    public interface IPlayer
    {
        public string Name { get; set; }
        public Queue<ICard> Cards { get; set; }
        public List<ICard> Discard { get; set; }
        public ICard GetCard();
        public void DrawCards(List<ICard> cards);
        public int GetCountCards();
    }
}