using OpenCC.DVRPTRLib.Infrastructure.Packets;

namespace OpenCC.DVRPTRLib.IO.PCP2.Deserializers
{
    /// <summary>
    /// RX lost packet deserializer.
    /// </summary>
    internal class RXLostPacketDeserializer : PCP2PacketDeserializer<RXLostPacket>
    {
        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="RXLostPacketDeserializer"/> class.
        /// </summary>
        public RXLostPacketDeserializer()
            : base(PacketType.RPTR_RXLOST)
        {
        }
        #endregion

        #region overrides
        protected override RXLostPacket CreatePacketCore(byte[] packetBuffer)
        {
            RXLostPacket packet = null;
            byte streamId;

            if (TryGetStreamId(packetBuffer, out streamId))
                packet = new RXLostPacket(streamId);

            return packet;
        }
        #endregion
    }
}

