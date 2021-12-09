using System;

namespace CardGame
{
    public class Card : ICard
    {
        private int _value;
        public int Value { get => _value; set => _value = (value > 0 && value <= 10) ? value : throw new Exception("Invalid card value"); }

        public Card(int value)
        {
            Value = value;
        }
    }
}