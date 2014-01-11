using OpenCC.DVRPTRLib.Infrastructure.Packets;

namespace OpenCC.DVRPTRLib.IO.PCP2.Deserializers
{
    /// <summary>
    /// EOT packet deserializer.
    /// </summary>
    internal class EOTPacketDeserializer : PCP2PacketDeserializer<EOTPacket>
    {
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.Deserializers.EOTPacketDeserializer"/> class.
        /// </summary>
        public EOTPacketDeserializer()
            : base(PacketType.RPTR_EOT)
        {
        }
        #endregion

        #region overrides
        protected override EOTPacket CreatePacketCore(byte[] packetBuffer)
        {
            EOTPacket packet = null;
            byte streamId;

            if (TryGetStreamId(packetBuffer, out streamId))
                packet = new EOTPacket(streamId);

            return packet;
        }
        #endregion
    }
}

