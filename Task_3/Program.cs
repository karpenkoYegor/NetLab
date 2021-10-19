using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UniqueInOrder(new char[]{ 'a', 's', 'd', 'a', 's', 'd'});
        }

        static void UniqueInOrder<T>(T[] arr)
        {
            List<T> set = new List<T>();
            foreach (T item in arr)
            {
                set.Add(item);
            }
            set = set.Distinct().ToList();
            foreach (var item in set)
            {
                Console.Write(item);
            }
        } 
    }
}
