using System;
using OpenCC.DVRPTRLib.Infrastructure.Packets;

namespace OpenCC.DVRPTRLib.IO.PCP2.Serializers
{
    /// <summary>
    /// Get serial number packet serializer.
    /// </summary>
    internal class GetSerialNumberPacketSerializer : PCP2PacketSerializer<GetSerialNumberPacket>
    {
        #region ctors
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="OpenCC.DVRPTRLib.IO.PCP2.Serializers.GetSerialNumberPacketSerializer"/> class.
        /// </summary>
        public GetSerialNumberPacketSerializer()
        {
        }
        #endregion

        #region implemented abstract members of PCP2PacketSerializer

        /// <summary>
        /// Serializes the packet core.
        /// </summary>
        /// <returns>The packet core.</returns>
        /// <param name="packet">Packet.</param>
        protected override byte[] SerializePacketCore(GetSerialNumberPacket packet)
        {
            byte[] bytes = new byte[]
            {
                Constants.START_ID,
                0x01,//payload length 1
                0x00,
                (byte)PacketType.RPTR_GET_SERIAL,
                0x00,//place holder for crc
                0x00//place holder for crc
            };

            return bytes;
        }

        #endregion
    }
}

