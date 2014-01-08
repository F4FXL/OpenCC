using OpenCC.DVRPTRLib.Packets;

namespace OpenCC.DVRPTRLib.IO.PCP2.Serializers
{
    /// <summary>
    /// Get version packet serializer.
    /// </summary>
    internal class GetVersionPacketSerializer : PCP2PacketSerializer<GetVersionPacket>
    {
        /// <summary>
        /// Serializes the packet core.
        /// </summary>
        /// <returns>The packet core.</returns>
        /// <param name="packet">Packet.</param>
        protected override byte[] SerializePacketCore(GetVersionPacket packet)
        {
            return new byte[]
                {
                    Constants.START_ID,
                    0x01, //hardcoded 1 length
                    0x00,
                    (byte)PacketType.RPTR_GET_VERSION,
                    0x00,//dummy bytes place holders for CRC
                    0x00
                };
        }
    }
}

