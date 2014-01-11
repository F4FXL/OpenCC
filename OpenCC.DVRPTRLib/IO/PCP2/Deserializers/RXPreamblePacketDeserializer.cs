using OpenCC.DVRPTRLib.Infrastructure.Packets;

namespace OpenCC.DVRPTRLib.IO.PCP2.Deserializers
{
    /// <summary>
    /// RX preamble packet deserializer.
    /// </summary>
    internal class RXPreamblePacketDeserializer : PCP2PacketDeserializer<RXPreamblePacket>
    {
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.RXPreamblePacketDeserializer"/> class.
        /// </summary>
        public RXPreamblePacketDeserializer()
            : base(PacketType.RPTR_RXPREAMBLE)
        {
        }
        #endregion

        #region overrides
        /// <summary>
        ///  When implemented, creates the packet. 
        /// </summary>
        /// <returns>
        /// The packet core.
        /// </returns>
        /// <param name='packetBuffer'>
        /// Packet buffer. start id, length and type are lready trimmed
        /// </param>
        protected override RXPreamblePacket CreatePacketCore(byte[] packetBuffer)
        {
            RXPreamblePacket packet = null;
            byte streamId;

            if(TryGetStreamId(packetBuffer, out streamId))
                packet = new RXPreamblePacket(streamId);

            return packet;
        }
        #endregion
    }
}

