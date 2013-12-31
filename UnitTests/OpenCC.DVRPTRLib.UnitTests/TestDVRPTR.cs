using System;
using NUnit.Framework;
using System.IO.Ports;
using System.Threading;

namespace OpenCC.DVRPTRLib.UnitTests
{
    [TestFixture()]
    public class TestDVRPTR
    {
        [Test()]
        public void TestGetVersion()
        {
            using (SerialPort serial = new SerialPort("/dev/ttyACM0"))
            {
                serial.Open();
                using(DVRPTR dvrptr = new DVRPTR(serial.BaseStream,false))
                {
                    dvrptr.TimeOut = TimeSpan.FromMilliseconds(-1);//this will give us infinite timeout so we can debug
                    dvrptr.Open();
                    DVRPTRVersion version = dvrptr.GetVersion();

                    Assert.IsNotNull(version, "version should not be null");
                    Console.WriteLine(version);
                }
            }
        }
    }
}

