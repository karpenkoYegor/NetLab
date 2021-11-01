using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LibraryForTest.Tests
{
    class UnitTest5
    {
        [Test]
        public void TestTask5_SpiralMatrix_ReturnTwoDimArray()
        {
            var expected = new int[,] {{ 1, 2, 3 },{ 8, 9, 4 },{ 7, 6, 5 } };
            var N = 3;
            var testTask5 = new TestTask5();

            var spiralArray = testTask5.spiralMatrix(N);

            Assert.That(spiralArray, Is.EqualTo(expected));
        }
    }
}
