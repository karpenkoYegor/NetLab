using System;

namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ips_between("10.0.0.0", "10.0.0.50"));
            Console.WriteLine(ips_between("10.0.0.0", "10.0.1.0"));
            Console.WriteLine(ips_between("20.0.0.10", "20.0.1.0"));
        }
        static int ips_between(string ip_1, string ip_2)
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
