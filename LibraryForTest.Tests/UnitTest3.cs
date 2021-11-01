using NUnit.Framework;

namespace LibraryForTest.Tests
{
    public class UnitTest3
    {
        [Test]
        public void TestTask3_UniqueInOrder_ReturnsIntArray()
        {
            var expected = new int[] { 1 };
            var testArray = new int[] { 1, 1, 1, 1, 1, 1, 1, 1 };
            var testTask3 = new TestTask3();

            int[] uniqeArray = testTask3.UniqueInOrder(testArray);

            Assert.That(uniqeArray, Is.EqualTo(expected));
        }
    }
}
