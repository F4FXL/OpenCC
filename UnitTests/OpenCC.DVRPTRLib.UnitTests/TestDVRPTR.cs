using System;
using NUnit.Framework;
using System.IO.Ports;
using System.Threading;
using OpenCC.DVRPTRLib.IO.PCP2;

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
                using(DVRPTR dvrptr = new DVRPTR(new PCP2DVRPTRio(serial.BaseStream,false)))
                {
                    dvrptr.TimeOut = TimeSpan.FromMilliseconds(-1);//this will give us infinite timeout so we can debug
                    dvrptr.Open();
                    DVRPTRVersion version = dvrptr.GetVersion();

                    Assert.IsNotNull(version, "version should not be null");
                    Console.WriteLine(version);
                }
            }
        }

        [Test]
        public void TestGetSerial()
        {
            using (SerialPort serial = new SerialPort("/dev/ttyACM0"))
            {
                serial.Open();
                using(DVRPTR dvrptr = new DVRPTR(new PCP2DVRPTRio(serial.BaseStream,false)))
                {
                    dvrptr.TimeOut = TimeSpan.FromMilliseconds(-1);//this will give us infinite timeout so we can debug
                    dvrptr.Open();
                    DVRPTRSerialNumber serialNumber = dvrptr.GetSerialNumber();

                    Assert.IsNotNull(serialNumber, "version should not be null");
                    Console.WriteLine("Year {0} Week {1} Number : {2}", serialNumber.Year, serialNumber.Week, serialNumber.Number);
                    Console.WriteLine(serialNumber.ToString());
                }
            }
        }

        [Test()]
        public void TestGetConfiguration()
        {
            using (SerialPort serial = new SerialPort("/dev/ttyACM0"))
            {
                serial.Open();
                using(DVRPTR dvrptr = new DVRPTR(new PCP2DVRPTRio(serial.BaseStream,false)))
                {
                    dvrptr.TimeOut = TimeSpan.FromMilliseconds(-1);//this will give us infinite timeout so we can debug
                    dvrptr.Open();
                    Configuration config = dvrptr.GetConfiguration();

					Assert.IsNotNull(config, "config should not be null");
					Console.WriteLine(config);
                }
            }
        }
    }
}

