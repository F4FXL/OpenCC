using System;
using NUnit.Framework;

namespace OpenCC.DVRPTRLib.UnitTests
{
    [TestFixture()]
    public class TestDVRPTRSerialNumber
    {
        [Test()]
        public void TestCase()
        {
            DVRPTRSerialNumber serialNumber = new DVRPTRSerialNumber ((123 << 16) | (12 << 8) | 13);
            Assert.AreEqual(13, serialNumber.Year);
            Assert.AreEqual(12, serialNumber.Month);
            Assert.AreEqual(123, serialNumber.Number);
        }
    }
}

