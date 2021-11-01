using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForTest
{
    public class TestTask5
    {
        public int[,] spiralMatrix(int N)
        {
            if (N > 0)
            {
                int[,] array = new int[N, N];
                int x = 0;
                int y = 0;
                int sx = 1;
                int sy = 0;
                int steps = N - 1;
                int currentStep = steps;
                int count = 0;

                for (int i = 1; i <= N * N; i++)
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
                        if (count == 3)
                        {
                            count = 1;
                            steps--;
                        }
                        currentStep = steps;
                    }
                }
                return array;
            }
            else
            {
                return new int[0, 0];
            }
        }
    }
}
