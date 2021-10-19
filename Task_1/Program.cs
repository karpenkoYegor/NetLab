using System;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number > 0)
            {
                for (int i = 1; i < number; i++)
                {
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        Console.Write(i + " ");
                    }
                    else if (i % 3 == 0)
                    {
                        Console.Write(i + " ");
                    }
                    else if (i % 5 == 0)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
