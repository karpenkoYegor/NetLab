using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForTest
{
    public class TestTask1
    {
        public int SumOfMultiplesOf3Or5(int number)
        {
            int sum = 0;
            if (number > 0)
            {
                for (int i = 1; i < number; i++)
                {
                    if (i % 3 == 0 || i % 5 == 0)
                    {
                        sum += i;
                    }
                }
            }
            else
            {
                sum = 0;
            }

            return sum;
        }
    }
}
