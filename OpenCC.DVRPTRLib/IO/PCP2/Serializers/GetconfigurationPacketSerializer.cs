using System;

namespace OpenCC.DVRPTRLib.IO.PCP2.Serializers
{
    /// <summary>
    /// Getconfiguration packet serializer.
    /// </summary>
    internal class GetConfigurationPacketSerializer : PCP2PacketSerializer<GetConfigurationPacket>
    {
        #region overrides
        protected override byte[] SerializePacketCore(GetConfigurationPacket packet)
        {
            return new byte[]
            {
                PCP2Packet.START_ID,
                0x01,//hardcoded length of 1
                0x00,
                (byte)OpenCC.DVRPTRLib.IO.PCP2.PacketType.RPTR_GET_CONFIG,//0x13
                0xc0, 0x04,//Original CC had this, what is the use ???
                0x00,
                0x00
            };
        }
        #endregion
    }
}

