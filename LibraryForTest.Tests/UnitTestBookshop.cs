using NUnit.Framework;

namespace LibraryForTest.Tests
{
    public class UnitTestBookshop
    {
        [Test]
        public void BookShop_FinalCost_ReturnDouble()
        {
            var expected = 92.0;
            var countOfBook = new int[] { 0, 5, 3, 4, 1 };
            var bookShop = new BookShop(countOfBook);

            var costOfBook = bookShop.FinalCost();

            Assert.That(costOfBook, Is.EqualTo(expected));
        }
    }
}