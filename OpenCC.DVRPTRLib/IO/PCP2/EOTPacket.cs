using System;

namespace OpenCC.DVRPTRLib.IO.PCP2
{
    /// <summary>
    /// EOT packet.
    /// </summary>
    internal class EOTPacket : StreamIdPCP2Packet
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

