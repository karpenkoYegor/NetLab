using NUnit.Framework;

namespace LibraryForTest.Tests
{
    public class UnitTest2
    {
        [Test]
        public void TestTask2_NumericOfString_ReturnString()
        {
            var expected = "123456789101112";
            var testString = "aaaaaaaaaaaa";
            var testTask2 = new TestTask2();

            var result = testTask2.NumericOfString(testString);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}