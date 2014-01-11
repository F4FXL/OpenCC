using System;

namespace OpenCC.DVRPTRLib.Infrastructure.Packets
{
    /// <summary>
    /// RX lost packet.
    /// </summary>
    public class RXLostPacket : StreamIdPacket
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

