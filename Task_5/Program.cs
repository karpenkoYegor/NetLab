using System;

namespace Task_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[N, N];
            int x = 0;
            int y = 0;
            int sx = 1;
            int sy = 0;
            int steps = N-1;
            int currentStep = steps;
            int count = 0;
            

            for (int i = 1; i <= N*N; i++)
            {

                currentStep--;
                array[y, x] = i;
                x += sx;
                y += sy;

                if (currentStep == 0)
                {
                    int a = sx;
                    sx = -sy;
                    sy = a;
                    count++;
                    if(count == 3)
                    {
                        count = 1;
                        steps--;
                    }
                    currentStep = steps;
                }

                Console.WriteLine(i);
            }

            for (int a = 0; a < N; a++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{array[a, j],3}");
                }
                Console.WriteLine();
            }

        }
    }
}
