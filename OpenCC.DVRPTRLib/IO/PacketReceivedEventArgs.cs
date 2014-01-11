using System;
using OpenCC.DVRPTRLib.Infrastructure.Packets;

namespace OpenCC.DVRPTRLib
{
    /// <summary>
    /// Packet received event arguments.
    /// </summary>
    public class PacketReceivedEventArgs : EventArgs
    {
        #region members
        private readonly Packet _packet;
        #endregion

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PacketReceivedEventArgs"/> class.
        /// </summary>
        /// <param name='packet'>
        /// Packet.
        /// </param>
        public PacketReceivedEventArgs(Packet packet)
        {
            _packet = packet;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the packet.
        /// </summary>
        /// <value>
        /// The packet.
        /// </value>
        public Packet Packet
        {
            get
            {
                return _packet;
            }
        }
        #endregion
    }
}

