namespace LibraryForTest
{
    public class BookShop
    {
        private int[] _purchasedBooks;
        private int _costOfBook = 8;
        public BookShop(int[] purchasedBooks)
        {
            _purchasedBooks = purchasedBooks;
        }

        public double FinalCost()
        {
            int countOfBook;
            double finalCost = 0;
            double discount = 0;
            for (int j = 0; j < _purchasedBooks.Length; j++)
            {
                countOfBook = 0;
                for (int i = 0; i < _purchasedBooks.Length; i++)
                {
                    if (_purchasedBooks[i] > 0)
                    {
                        _purchasedBooks[i]--;
                        countOfBook++;
                    }
                }

                switch (countOfBook)
                {
                    case 1:
                        discount = 1;
                        break;
                    case 2:
                        discount = 0.95;
                        break;
                    case 3:
                        discount = 0.9;
                        break;
                    case 4:
                        discount = 0.8;
                        break;
                    case 5:
                        discount = 0.75;
                        break;
                }
                finalCost += _costOfBook * countOfBook * discount;
            }

            return finalCost;
        }
    }
}