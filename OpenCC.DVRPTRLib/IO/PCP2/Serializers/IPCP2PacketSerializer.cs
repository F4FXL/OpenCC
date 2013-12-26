using System;

namespace OpenCC.DVRPTRLib.IO.PCP2.Serializers
{
    /// <summary>
    /// IPC p2 packet serializer.
    /// </summary>
    internal interface IPCP2PacketSerializer
    {
        /// <summary>
        /// Serializes the packet.
        /// </summary>
        /// <returns>
        /// The packet.
        /// </returns>
        /// <param name='packet'>
        /// Packet.
        /// </param>
        byte[] SerializePacket(PCP2Packet packet);

        /// <summary>
        /// Gets the type of the packet.
        /// </summary>
        /// <value>
        /// The type of the packet.
        /// </value>
        Type DeserializedPacketType  {get;}
    }
}

