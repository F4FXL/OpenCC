using System;

namespace OpenCC.DVRPTRLib.IO.PCP2
{
    /// <summary>
    /// RX lost packet.
    /// </summary>
    internal class RXLostPacket : StreamIdPCP2Packet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RXLostPacket"/> class.
        /// </summary>
        public RXLostPacket(byte streamId)
            : base(streamId)
        {
        }
    }
}

