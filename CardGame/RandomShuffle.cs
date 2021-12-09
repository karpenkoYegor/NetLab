using System;
using System.Collections.Generic;

namespace CardGame
{
    public static class RandomShuffle
    {
        private static Random random = new Random();
        private static int GenerateAnotherNum(int from, int to) => random.Next(from, to);

        public static List<ICard> ShuffleCard(List<ICard> cards)
        {
            if (cards == null)
                throw new ArgumentNullException();

            for (int i = 0; i < cards.Count - 1; i++)
            {
                int GenObj = GenerateAnotherNum(i, cards.Count);

                var h = cards[i];
                cards[i] = cards[GenObj];
                cards[GenObj] = h;
            }

            return cards;
        }
    }
}