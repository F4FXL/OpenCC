using System;

namespace OpenCC.DVRPTRLib.IO.PCP2.Deserializers
{
    /// <summary>
    /// Get version answer packet deserializer.
    /// </summary>
    internal class GetVersionAnswerPacketDeserializer : PCP2PacketDeserializer<GetVersionAnswerPacket>
    {
        #region ctor
        public GetVersionAnswerPacketDeserializer()
            : base(PacketType.Answer_RPTRGET_VERSION)
        {
        }
        #endregion

        #region overrides
        /// <summary>
        /// When implemented, creates the packet.
        /// </summary>
        /// <returns>The packet core.</returns>
        /// <param name="packetBuffer">Packet buffer</param>
        protected override GetVersionAnswerPacket CreatePacketCore(byte[] packetBuffer)
        {
            return null;
        }
        #endregion
    }
}

