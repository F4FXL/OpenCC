using System;

namespace OpenCC.DVRPTRLib.IO.PCP2.Deserializers
{
    /// <summary>
    /// IPC p2 packet deserializer.
    /// </summary>
    internal interface IPCP2PacketDeserializer
    {
        
        /// <summary>
        /// Creates the packet.
        /// </summary>
        /// <returns>The packet.</returns>
        /// <param name="packetBuffer">Packet buffer.</param>
        PCP2Packet CreatePacket(byte[] packetBuffer);

        /// <summary>
        /// Gets the type of the packet.
        /// </summary>
        /// <value>
        /// The type of the packet.
        /// </value>
        PacketType PacketType{get;}
    }
}

