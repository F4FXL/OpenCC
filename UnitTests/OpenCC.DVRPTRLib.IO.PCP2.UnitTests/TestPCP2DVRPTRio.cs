using System;
using NUnit.Framework;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;
using OpenCC.DVRPTRLib.IO.PCP2;

namespace OpenCC.DVRPTRLib.UnitTests
{
    [TestFixture()]
    public class TestPCP2DVRPTRio
    {
        [Test()]
        public void TestOpen()
        {
            using (SerialPort serial = new SerialPort("/dev/ttyACM0"))
            {
                serial.Open();
                using (PCP2DVRPTRio dvrptr = new PCP2DVRPTRio(serial.BaseStream, false))
                {
                    dvrptr.PacketReceived += (sender, e) => Debug.WriteLine(e.Packet);
                    dvrptr.Open();

                    while (dvrptr.IsOpen)
                        Thread.Sleep(500);
                }
            }
        }
    }
}

