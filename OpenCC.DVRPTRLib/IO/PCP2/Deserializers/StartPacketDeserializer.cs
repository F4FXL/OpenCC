using OpenCC.DVRPTRLib.Packets;

namespace OpenCC.DVRPTRLib.IO.PCP2.Deserializers
{
    /// <summary>
    /// Start packet factory.
    /// </summary>
    internal class StartPacketDeserializer : PCP2PacketDeserializer<StartPacket>
    {
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.StartPacketDeserializer"/> class.
        /// </summary>
        public StartPacketDeserializer()
            : base(PacketType.RPTR_START)
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
        protected override StartPacket CreatePacketCore(byte[] packetBuffer)
        {
            StartPacket packet = null;
            byte streamId;

            if (TryGetStreamId(packetBuffer, out streamId))
                packet = new StartPacket(streamId);

            return packet;
        }
        #endregion
    }
}

