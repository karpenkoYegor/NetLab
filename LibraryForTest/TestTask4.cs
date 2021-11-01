using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForTest
{
    public class TestTask4
    {
        public int IpsBetween(string ip_1, string ip_2)
        {
            string[] array_1 = ip_1.Split('.');
            string[] array_2 = ip_2.Split('.');

            int ip_numbers = 0;

            for (int i = 0; i < array_1.Length; i++)
            {
                int j = array_1.Length - 1 - i;
                ip_numbers += (Convert.ToInt32(array_2[i]) - Convert.ToInt32(array_1[i])) * (int)Math.Pow(256, j);
            }
            return ip_numbers;
        }
    }
}
