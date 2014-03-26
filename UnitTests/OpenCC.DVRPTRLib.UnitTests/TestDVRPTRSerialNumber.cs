using System;
using NUnit.Framework;

namespace OpenCC.DVRPTRLib.UnitTests
{
    [TestFixture()]
    public class TestDVRPTRSerialNumber
    {
        [Test()]
        public void TestParse()
        {
            DVRPTRSerialNumber serialNumber = new DVRPTRSerialNumber ((123 << 16) | (12 << 8) | 13);
            Assert.AreEqual(13, serialNumber.Year);
            Assert.AreEqual(12, serialNumber.Week);
            Assert.AreEqual(123, serialNumber.Number);
        }

        [Test]
        public void TestEquals()
        {
            DVRPTRSerialNumber serialNumber = new DVRPTRSerialNumber ((123 << 16) | (12 << 8) | 13);
            DVRPTRSerialNumber serialNumber2 = new DVRPTRSerialNumber ((123 << 16) | (12 << 8) | 13);

            Assert.AreEqual(serialNumber.GetHashCode(), serialNumber2.GetHashCode());
            Assert.AreEqual(serialNumber, serialNumber2);

            serialNumber2 = new DVRPTRSerialNumber ((123 << 16) | (12 << 8) | 12);

            Assert.AreNotEqual(serialNumber.GetHashCode(), serialNumber2.GetHashCode());
            Assert.AreNotEqual(serialNumber, serialNumber2);
        }
    }
}

