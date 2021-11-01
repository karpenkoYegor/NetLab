using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForTest
{
    public class TestTask2
    {
        public string NumericOfString(string inputString)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            var result = "";
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
                result += dict[c];
            }

            return result;
        }
    }
}
