using System;

namespace OpenCC.DVRPTRLib.Packets
{
    /// <summary>
    /// RX lost packet.
    /// </summary>
    internal class RXLostPacket : StreamIdPacket
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

