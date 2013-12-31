using System;
using NUnit.Framework;

namespace OpenCC.DVRPTRLib.UnitTests
{
    [TestFixture()]
    public class TestDVRPTRVersion
    {
        [Test()]
        public void TestCompareTo()
        {
            DVRPTRVersion a = new DVRPTRVersion(1,6,9,'a', "Test");
            DVRPTRVersion b = new DVRPTRVersion(1,6,9,'a', "Test");
            Assert.AreEqual(0, a.CompareTo(b), "a should equal b");

            a = new DVRPTRVersion(1,6,9,'a', "Test");
            b = new DVRPTRVersion(1,6,9,'\0', "Test");
            Assert.AreEqual(1, a.CompareTo(b), "a should be greater than b");

            a = new DVRPTRVersion(1,6,9,'a', "Test");
            b = new DVRPTRVersion(1,6,9,'b', "Test");
            Assert.AreEqual(-1, a.CompareTo(b), "a should be smaller than b");

            a = new DVRPTRVersion(1,6,9,'a', "Test");
            b = null;
            Assert.AreEqual(1, a.CompareTo(b), "a should be smaller than null");
        }

        [Test]
        public void TestEquals()
        {
            DVRPTRVersion a = new DVRPTRVersion(1,6,9,'a', "Test");
            DVRPTRVersion b = new DVRPTRVersion(1,6,9,'a', "Test");
            Assert.IsTrue(a.Equals(b), "a should equal b");

            a = new DVRPTRVersion(1,6,9,'a', "Test");
            b = new DVRPTRVersion(1,6,8,'z', "Test");
            Assert.IsFalse(a.Equals(b), "a should NOT equal b");

            a = new DVRPTRVersion(1,6,9,'a', "Test");
            b = null;
            Assert.IsFalse(a.Equals(b), "a should NOT equal null");
        }

        [Test]
        public void TestGetHashCode()
        {
            DVRPTRVersion a = new DVRPTRVersion(1,6,9,'a', "Test");
            DVRPTRVersion b = new DVRPTRVersion(1,6,9,'a', "Test");
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode(), "a should equal b");

            a = new DVRPTRVersion(1,6,9,'a', "Test");
            b = new DVRPTRVersion(1,6,8,'z', "Test");
            Assert.AreNotEqual(a.GetHashCode(), b.GetHashCode(), "a should NOT equal b");
        }

        [Test]
        public void TestToString()
        {
            DVRPTRVersion a = new DVRPTRVersion(1,6,9,'a', "Test");
            Assert.AreEqual("1.69a Test", a.ToString());

            DVRPTRVersion b = new DVRPTRVersion(1,6,9,'\0', "Test");
            Assert.AreEqual("1.69 Test", b.ToString());
        }

        [Test]
        public void TestOperators()
        {
            DVRPTRVersion a = new DVRPTRVersion(1,6,9,'a', "Test");
            DVRPTRVersion b = new DVRPTRVersion(1,6,9,'a', "Test");
            Assert.IsTrue(a == b, "a should equal b");
            Assert.IsTrue(a <= b, "a should equal b");
            Assert.IsTrue(a >= b, "a should equal b");
            Assert.IsFalse(a != b, "a should not be different b");

            a = new DVRPTRVersion(1,6,9,'a', "Test");
            b = new DVRPTRVersion(1,6,9,'b', "Test");
            Assert.IsTrue(a < b, "a should be lower than b");
            Assert.IsTrue(a != b, "a should be different b");

            a = new DVRPTRVersion(1,6,9,'c', "Test");
            b = new DVRPTRVersion(1,6,9,'a', "Test");
            Assert.IsTrue(a > b, "a should be greater than b");
            Assert.IsTrue(a != b, "a should be different b");

            a = new DVRPTRVersion(1,6,9,'c', "Test");
            b = null;
            Assert.IsTrue(a > b, "a should be greater than b");
            Assert.IsTrue(a != b, "a should be different b");

            a = null;
            b = new DVRPTRVersion(1,6,9,'a', "Test");
            Assert.IsTrue(a < b, "a should be lower than b");
            Assert.IsTrue(a != b, "a should be different b");

            a = null;
            b = null;
            Assert.IsTrue(a == b, "a should be greater than b");
            Assert.IsFalse(a != b, "a should NOT be different b");
        }
    }
}

