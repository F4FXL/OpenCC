using System;
using System.Collections.Generic;
using OpenCC.Common.Diagnostics;
using OpenCC.DVRPTRLib.IO.PCP2.Deserializers;

namespace OpenCC.DVRPTRLib.IO.PCP2
{
    /// <summary>
    /// PC p2 packet factory
    /// </summary>
    internal class PCP2PacketFactory
    {
        #region Members
        public static readonly PCP2PacketFactory Default;
        private Dictionary<PacketType, IPCP2PacketDeserializer> _deserializers;
        #endregion

        #region ctors
        /// <summary>
        /// Initializes the <see cref="OpenCC.DVRPTRLib.PCP2.PCP2PacketFactory"/> class.
        /// </summary>
        static PCP2PacketFactory()
        {
            Default = new PCP2PacketFactory();

            //maybe this should be done somewhere else...
            Default.RegisterDesrializer(new RXPreamblePacketDeserializer());
            Default.RegisterDesrializer(new StartPacketDeserializer());
            Default.RegisterDesrializer(new RXLostPacketDeserializer());
            Default.RegisterDesrializer(new RxSyncPacketDeserializer());
            Default.RegisterDesrializer(new ConfigurationPacketDeserializer());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.PCP2PacketFactory"/> class.
        /// </summary>
        public PCP2PacketFactory()
        {
            _deserializers = new Dictionary<PacketType, IPCP2PacketDeserializer>();
        }
        #endregion

        #region methods
        /// <summary>
        /// Registers the creator.
        /// </summary>
        /// <param name="creator">Creator.</param>
        public void RegisterDesrializer(IPCP2PacketDeserializer creator)
        {
            Guard.IsNotNull(creator, "creator");

            _deserializers.Add(creator.PacketType, creator);
        }

        /// <summary>
        /// Creates the packet.
        /// </summary>
        /// <returns>The packet.</returns>
        /// <param name="packetBuffer">Packet buffer.</param>
        public PCP2Packet CreatePacket(byte[] packetBuffer)
        {
            Guard.IsNotNull(packetBuffer, "packetBuffer");

            if(packetBuffer.Length < 4)
                throw new PCP2Exception("Invalid packet length");

            PacketType packetType = (PacketType)packetBuffer[3];

            IPCP2PacketDeserializer creator;
            PCP2Packet packet = null;
            if(_deserializers.TryGetValue(packetType, out creator))
            {
                packet = creator.CreatePacket(packetBuffer);
            }

            return packet;
        }
        #endregion
    }
}

