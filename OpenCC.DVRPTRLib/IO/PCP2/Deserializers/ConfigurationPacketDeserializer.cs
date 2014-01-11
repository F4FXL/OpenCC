using OpenCC.DVRPTRLib.Infrastructure.Packets;

namespace OpenCC.DVRPTRLib.IO.PCP2.Deserializers
{
    /// <summary>
    /// Configuration packet deserializer.
    /// </summary>
    internal class ConfigurationPacketDeserializer : PCP2PacketDeserializer<ConfigurationPacket>
    {
        #region ctors
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ConfigurationPacketDeserializer"/> class.
        /// </summary>
        public ConfigurationPacketDeserializer()
            : base(PacketType.Answer_RPTRGET_CONFIG)
        {
        }
        #endregion

        #region overrides
        protected override ConfigurationPacket CreatePacketCore(byte[] packetBuffer)
        {
            //TODO
            return null;
        }
        #endregion
    }
}

