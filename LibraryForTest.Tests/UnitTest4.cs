using LibraryForTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForTest.Tests
{
    class UnitTest4
    {
        [Test]
        public void TestTask4_IpsBetween_ReturnIntNumber()
        {
            var expetced = 256;
            var testIp1 = "10.0.0.0";
            var testIp2 = "10.0.1.0";
            var testTask4 = new TestTask4();

            int countIps = testTask4.IpsBetween(testIp1, testIp2);

            Assert.That(countIps, Is.EqualTo(expetced));
        }
    }
}
