using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LibraryForTest.Tests
{
    class UnitTask1
    {
        [Test]
        public void TestTask5_SumOfMultiplesOf3Or5_ReturnInt()
        {
            var expected = 23;
            var number = 10;
            var testTask1 = new TestTask1();

            var sum = testTask1.SumOfMultiplesOf3Or5(number);

            Assert.That(sum, Is.EqualTo(expected));
        }
    }
}
