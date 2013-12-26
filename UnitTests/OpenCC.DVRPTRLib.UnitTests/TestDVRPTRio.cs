using System;
using NUnit.Framework;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;

namespace OpenCC.DVRPTRLib.UnitTests
{
    [TestFixture()]
    public class TestDVRPTRio
    {
        [Test()]
        public void TestOpen()
        {
            using (SerialPort serial = new SerialPort("/dev/ttyACM0"))
            {
                serial.Open();
                DVRPTRio dvrptr = new DVRPTRio(serial.BaseStream, false);
                dvrptr.PacketReceived += (sender, e) => Debug.WriteLine(e.Packet);
                dvrptr.Open();

                while (dvrptr.IsOpen)
                    Thread.Sleep(500);
            }
        }
    }
}

