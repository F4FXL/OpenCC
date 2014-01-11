using System;
using OpenCC.Common.Diagnostics;
using OpenCC.DVRPTRLib.Infrastructure.Packets;


namespace OpenCC.DVRPTRLib.IO.PCP2.Serializers
{
    /// <summary>
    /// PC p2 packet serializer.
    /// </summary>
    internal abstract class PCP2PacketSerializer<TPacket> : IPCP2PacketSerializer
        where TPacket : Packet
    {
        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.Serializers.PCP2PacketSerializer`1"/> class.
        /// </summary>
        protected PCP2PacketSerializer()
        {
        }
        #endregion

        #region methods
        /// <summary>
        /// Serializes the packet.
        /// </summary>
        /// <returns>
        /// The packet.
        /// </returns>
        /// <param name='packet'>
        /// Packet.
        /// </param>
        public byte[] SerializePacket(Packet packet)
        {
            Guard.IsNotNull(packet, "packet");

            byte[] serializedPacket = SerializePacketCore((TPacket) packet);
            return serializedPacket;
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the type of the packet this serializer serlizes
        /// </summary>
        /// <value>
        /// The type of the packet.
        /// </value>
        public Type DeserializedPacketType
        {
            get
            {
                return typeof(TPacket);
            }
        }
        #endregion

        #region abstracts
        protected abstract byte[] SerializePacketCore(TPacket packet);
        #endregion

    }
}

