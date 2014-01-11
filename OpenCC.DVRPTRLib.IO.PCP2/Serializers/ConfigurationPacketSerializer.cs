using System;
using System.Collections.Generic;
using OpenCC.DVRPTRLib.IO.PCP2;
using System.Linq;
using System.IO;
using OpenCC.DVRPTRLib.Infrastructure.Packets;


namespace OpenCC.DVRPTRLib.IO.PCP2.Serializers
{
    /// <summary>
    /// Set configuration packet serializer.
    /// </summary>
    internal class ConfigurationPacketSerializer : PCP2PacketSerializer<ConfigurationPacket>
    {
        #region overrides
        /// <summary>
        /// Serializes the packet core.
        /// </summary>
        /// <returns>
        /// The packet core.
        /// </returns>
        /// <param name='packet'>
        /// Packet.
        /// </param>
        protected override byte[] SerializePacketCore(ConfigurationPacket packet)
        {
            using(MemoryStream stream = new MemoryStream())
            using(BinaryWriter writer = new BinaryWriter(stream))
            {
                byte[] payload = GetPayloadBytes(packet).ToArray();
                writer.Write(Constants.START_ID);
                writer.Write((Int16)payload.Length);
                writer.Write(payload);

                writer.Flush();

                byte[] serializedBytes = stream.ToArray();
                return serializedBytes;
            }
        }
        #endregion

        #region methods
        private IEnumerable<byte> GetPayloadBytes(ConfigurationPacket packet)
        {
            yield return (byte)OpenCC.DVRPTRLib.IO.PCP2.PacketType.RPTR_SET_CONFIG;

            byte rxtxrev = packet.RxReverse ? (byte)1 : (byte)0;
            rxtxrev |= packet.TxReverse ? (byte)2 : (byte)0;
            yield return rxtxrev;

            yield return packet.TxLevel;
            yield return packet.TxDelay;//Tx Delay low byte
            yield return 0;//TxDelay high byte
        }
        #endregion
    }
}

