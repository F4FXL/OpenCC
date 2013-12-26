using System;

namespace OpenCC.DVRPTRLib.IO.PCP2.Deserializers
{
    /// <summary>
    /// Rx sync packet deserializer.
    /// </summary>
    internal class RxSyncPacketDeserializer : PCP2PacketDeserializer<RxSyncPacket>
    {
        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.RxSyncPacketDeserializer"/> class.
        /// </summary>
        public RxSyncPacketDeserializer()
            : base(PacketType.RPTR_RXSYNC)
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
        protected override RxSyncPacket CreatePacketCore(byte[] packetBuffer)
        {
            RxSyncPacket packet = null;
            byte streamId;

            if (TryGetStreamId(packetBuffer, out streamId))
                packet = new RxSyncPacket(streamId);

            return packet;
        }
        #endregion
    }
}

