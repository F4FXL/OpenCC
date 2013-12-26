using System;
using System.Collections.Generic;
using OpenCC.DVRPTRLib.IO.PCP2.Serializers;
using OpenCC.Common.Diagnostics;

namespace OpenCC.DVRPTRLib.IO.PCP2
{
    //TODO find a better name for this class
    /// <summary>
    /// PC p2 packet bytes factory.
    /// </summary>
    internal sealed class PCP2PacketBytesFactory
    {
        #region members
        public readonly static PCP2PacketBytesFactory Default;
        private Dictionary<Type, IPCP2PacketSerializer> _serializers;
        #endregion

        #region ctors
        /// <summary>
        /// Initializes the <see cref="OpenCC.DVRPTRLib.PCP2.PCP2PacketBytesFactory"/> class.
        /// </summary>
        static PCP2PacketBytesFactory()
        {
            Default = new PCP2PacketBytesFactory();

            Default.RegisterSerializer(new ConfigurationPacketSerializer());
            Default.RegisterSerializer(new GetConfigurationPacketSerializer());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PCP2PacketBytesFactory"/> class.
        /// </summary>
        public PCP2PacketBytesFactory ()
        {
            _serializers = new Dictionary<Type, IPCP2PacketSerializer>();
        }
        #endregion

        #region methods
        /// <summary>
        /// Registers the serializer.
        /// </summary>
        /// <param name='serializer'>
        /// Serializer.
        /// </param>
        public void RegisterSerializer(IPCP2PacketSerializer serializer)
        {
            Guard.IsNotNull(serializer, "serializer");

            _serializers.Add(serializer.PacketType, serializer);
        }

        /// <summary>
        /// Serializes the packet.
        /// </summary>
        /// <returns>
        /// The packet.
        /// </returns>
        /// <param name='packet'>
        /// Packet.
        /// </param>
        public byte[] SerializePacket(PCP2Packet packet)
        {
            Guard.IsNotNull(packet, "packet");
            byte[] serializedPacketBytes = null;
            IPCP2PacketSerializer serializer;

            if(_serializers.TryGetValue(packet.GetType(), out serializer))
                serializedPacketBytes = serializer.SerializePacket(packet);

            return serializedPacketBytes;
        }
        #endregion
    }
}

