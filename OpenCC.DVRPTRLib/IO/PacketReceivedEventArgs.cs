using System;
using OpenCC.DVRPTRLib.IO.PCP2;

namespace OpenCC.DVRPTRLib
{
    /// <summary>
    /// Packet received event arguments.
    /// </summary>
    public class PacketReceivedEventArgs : EventArgs
    {
        #region members
        private readonly PCP2Packet _packet;
        #endregion

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PacketReceivedEventArgs"/> class.
        /// </summary>
        /// <param name='packet'>
        /// Packet.
        /// </param>
        public PacketReceivedEventArgs(PCP2Packet packet)
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
        public PCP2Packet Packet
        {
            get
            {
                return _packet;
            }
        }
        #endregion
    }
}

