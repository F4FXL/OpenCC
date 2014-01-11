using System;
using System.IO;
using OpenCC.DVRPTRLib.IO.PCP2;
using OpenCC.Common.IO;
using System.Linq;
using System.Threading;
using OpenCC.Common;
using OpenCC.Common.Diagnostics;
using System.Diagnostics;
using OpenCC.DVRPTRLib.Infrastructure.Packets;


namespace OpenCC.DVRPTRLib.IO.PCP2
{
    /// <summary>
    /// This class is for reading/writing commands to the DVRPTR board
    /// This a PCP2 implementation
    /// </summary>
	public class PCP2DVRPTRio : DVRPTRio
	{

        #region ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTR"/> class.
        /// </summary>
        /// <param name="stream">Stream.</param>
        /// <param name="streamOwner">If set to <c>true</c> this instance is the stream owner. The stream will disposed when this instance is disposed</param>
        public PCP2DVRPTRio(Stream stream, bool streamOwner)
            : base(stream, streamOwner, null)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.IO.PCP2.PCP2DVRPTRio"/> class.
        /// </summary>
        /// <param name="stream">Stream.</param>
        /// <param name="streamOwner">If set to <c>true</c> this instance is the stream owner. The stream will disposed when this instance is disposed</param>
        /// <param name="syncContext">Sync context.</param>
        public PCP2DVRPTRio(Stream stream, bool streamOwner, SynchronizationContext syncContext)
            : base(stream, streamOwner, syncContext)
        {

        }
        #endregion


        #region Methods
        /// <summary>
        /// When implemented serilizes the specified packet into an array of bytes
        /// </summary>
        /// <returns>The packet bytes.</returns>
        /// <param name="packet">Packet.</param>
        protected override byte[] SerializePacket(Packet packet)
        {
            byte[] bytes = PCP2PacketBytesFactory.Default.SerializePacket(packet);
            return bytes;
        }

        /// <summary>
        /// When implemented Deserializes the packet out of the specified byte array
        /// </summary>
        /// <returns>The packet.</returns>
        /// <param name="bytes">Bytes.</param>
        protected override Packet DeserializePacket(byte[] bytes)
        {
            Packet packet = PCP2PacketFactory.Default.CreatePacket(bytes);
            return packet;
        }

        /// <summary>
        /// Waits for start PcPPacket start ID
        /// </summary>
        protected override byte[] ReadPacketBytes()
        {
            bool readOK;
            using (MemoryStream readBytes = new MemoryStream())
            using (BinaryWriter readBytesWriter = new BinaryWriter(readBytes))
            {
                byte[] buffer = new byte[2048];
                int readCount = 0;

                //loop until we find a start ID
                do
                {
                    readOK = ModemStreamReader.TryRead(buffer, 0, 1);
#if DEBUG
                    if(readOK)
                        Debug.WriteLine("Wait for StarID read : {0}", Convert.ToString(buffer[0], 16));
#endif
                } while (buffer [0] != Constants.START_ID && readOK);

                readBytesWriter.Write(Constants.START_ID);

                //Ok we got the start ID now get the length
                //according to doc it should be "PC ready"
                short packetLength;
                if (ModemStreamReader.TryRead(out packetLength))
                {
                    readBytesWriter.Write(packetLength);//do not forget to write the length to the output !
                    packetLength += 2; //add 2 to read the CRC bytes
                    while (readCount < packetLength && readOK)//loop 'til we have read all the bytes specified in packetLength
                    {                                         //or 'til somthing bad happens
                        int lastReadCount;
                        readOK = ModemStreamReader.TryRead(buffer, 0, buffer.Length, out lastReadCount);

                        readCount += lastReadCount;
                        readBytesWriter.Write(buffer.Take(lastReadCount).ToArray());
                    }
                }

                readBytesWriter.Flush();
                byte[] packetBytes = readOK ? readBytes.ToArray() : null;
                return packetBytes;
            }
        }


        #endregion

	}
}

