using System;
using System.Collections.Generic;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку");
            string inputString = Console.ReadLine();
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (char c in inputString)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c] += 1;
                }
                else
                {
                    dict.Add(c, 1);
                }
                Console.Write(dict[c]);
            }
        }
    }
}
