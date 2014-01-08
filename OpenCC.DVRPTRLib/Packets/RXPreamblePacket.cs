using System;

namespace OpenCC.DVRPTRLib.Packets
{
    internal class RXPreamblePacket : StreamIdPacket
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.RXPreamblePacket"/> class.
        /// </summary>
        /// <param name='streamId'>
        /// Strem identifier.
        /// </param>
        public RXPreamblePacket(byte streamId)
            : base(streamId)
        {
        }
    }
}

