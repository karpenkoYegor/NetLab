using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForTest
{
    public class TestTask3
    {
        public T[] UniqueInOrder<T>(T[] arr)
        {
            List<T> set = new List<T>();
            foreach (T item in arr)
            {
                set.Add(item);
            }
            set = set.Distinct().ToList();

            return set.ToArray();
        }
    }
}
