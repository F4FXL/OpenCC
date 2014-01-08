using System;

namespace OpenCC.DVRPTRLib.Packets
{
    /// <summary>
    /// EOT packet.
    /// </summary>
    internal class EOTPacket : StreamIdPacket
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.EOTPacket"/> class.
        /// </summary>
        /// <param name='streamId'>
        /// Stream identifier.
        /// </param>
        public EOTPacket(byte streamId)
            : base(streamId)
        {
        }
    }
}

