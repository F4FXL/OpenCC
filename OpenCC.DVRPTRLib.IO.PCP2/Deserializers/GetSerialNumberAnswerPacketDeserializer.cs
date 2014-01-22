using System;
using OpenCC.DVRPTRLib.Infrastructure.Packets;

namespace OpenCC.DVRPTRLib.IO.PCP2.Deserializers
{
    internal class GetSerialNumberAnswerPacketDeserializer : PCP2PacketDeserializer<GetSerialNumberAnswerPacket>
    {
        #region ctors
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="OpenCC.DVRPTRLib.IO.PCP2.Deserializers.GetSerialNumberAnswerPacketDeserializer"/> class.
        /// </summary>
        public GetSerialNumberAnswerPacketDeserializer()
            : base(PacketType.Answer_RPTRGET_SERIAL)
        {
        }
        #endregion

        #region overrides
        /// <summary>
        /// When implemented, creates the packet.
        /// </summary>
        /// <returns>The packet core.</returns>
        /// <param name="packetBuffer">Packet buffer</param>
        protected override GetSerialNumberAnswerPacket CreatePacketCore(byte[] packetBuffer)
        {
            uint serial = BitConverter.ToUInt32(packetBuffer, 3);
            GetSerialNumberAnswerPacket packet = new GetSerialNumberAnswerPacket(serial);
            return packet;
        }
        #endregion
    }
}

