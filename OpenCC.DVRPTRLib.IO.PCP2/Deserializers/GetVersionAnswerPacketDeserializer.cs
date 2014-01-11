using System;
using System.Text;
using OpenCC.DVRPTRLib.Infrastructure.Packets;

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
            byte mainVersion = Convert.ToByte((packetBuffer [5] >> 4) & 0xFF);
            byte subVersion = Convert.ToByte(packetBuffer [5] & 0x0F);
            byte subsubVersion = Convert.ToByte((packetBuffer [4] >> 4) & 0xFF);

            char bugFixLevel = '\0';
            if((packetBuffer [4] & 0x0F) > 0)//if this is zero we do not have any bugfix level. 1 means A, 2 b and so on ...
                bugFixLevel = Convert.ToChar((packetBuffer [4] & 0x0F) + 'a' - 1);

            string deviceIdentification = string.Empty;
            if(packetBuffer.Length - 8 > 6)//make sur we do not overrun
                deviceIdentification = Encoding.ASCII.GetString(packetBuffer,6,packetBuffer.Length - 8);

            GetVersionAnswerPacket packet = new GetVersionAnswerPacket(mainVersion, subVersion, subsubVersion, bugFixLevel, deviceIdentification);
            return packet;
        }
        #endregion
    }
}

