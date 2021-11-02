using NUnit.Framework;

namespace LibraryForTest.Tests
{
    public class UnitTestBookshop
    {
        [Test]
        public void BookShop_FinalCost_ReturnDouble()
        {
            var expected = 51.6;
            var countOfBook = new int[] { 2, 2, 2, 1, 1 };
            var bookShop = new BookShop(countOfBook);

            var costOfBook = bookShop.FinalCost();

            Assert.That(costOfBook, Is.EqualTo(expected));
        }
    }
}