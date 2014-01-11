using System;
using OpenCC.Common.Diagnostics;
using OpenCC.DVRPTRLib.Infrastructure.Packets;


namespace OpenCC.DVRPTRLib.IO.PCP2.Deserializers
{
    internal abstract class PCP2PacketDeserializer<TPacket> : IPCP2PacketDeserializer
        where TPacket : Packet
    {
        #region members
        private readonly PacketType _packetType;
        #endregion

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.PCP2PacketCreator"/> class.
        /// </summary>
        protected PCP2PacketDeserializer(PacketType packetType)
        {
            _packetType = packetType;
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the type of the packet this factory creates
        /// </summary>
        /// <value>The type of the packet.</value>
        public PacketType PacketType
        {
            get
            {
                return _packetType;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the packet.
        /// </summary>
        /// <returns>The packet.</returns>
        /// <param name="packetBuffer">Packet buffer.</param>
        public Packet CreatePacket(byte[] packetBuffer)
        {
            Guard.IsNotNull(packetBuffer, "packetBuffer");

            if(packetBuffer.Length < 4)
                throw new PCP2Exception("Invalid packet length");

            if(packetBuffer[3] != (byte)this._packetType)
                throw new PCP2Exception(string.Format("Packet does not contain data for {0}", _packetType));


            TPacket packet = this.CreatePacketCore(packetBuffer);
            return packet;
        }

        /// <summary>
        /// Tries the get stream identifier, stream Id should be at position 0 in packetBuffer
        /// </summary>
        /// <returns>
        /// The get stream identifier.
        /// </returns>
        /// <param name='packetBuffer'>
        /// If set to <c>true</c> packet buffer.
        /// </param>
        /// <param name='streamId'>
        /// 
        /// </param>
        protected bool TryGetStreamId(byte[] packetBuffer, out byte streamId)
        {
            bool ok = false;
            streamId = 0;


            try
            {
                if (packetBuffer != null && packetBuffer.Length > 4)
                {
                    streamId = packetBuffer [4];
                    ok = true;
                }
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Failed to get Stream Id");
            }

            return ok;
        }
        #endregion


        #region abstract methods
        /// <summary>
        /// When implemented, creates the packet.
        /// </summary>
        /// <returns>The packet core.</returns>
        /// <param name="packetBuffer">Packet buffer</param>
        protected abstract TPacket CreatePacketCore(byte[] packetBuffer);
        #endregion
    }
}

