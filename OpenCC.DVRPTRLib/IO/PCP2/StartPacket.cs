using System;

namespace OpenCC.DVRPTRLib.IO.PCP2.Deserializers
{
    /// <summary>
    /// Start packet.
    /// </summary>
    internal class StartPacket : StreamIdPCP2Packet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.StartPacket"/> class.
        /// </summary>
        /// <param name='streamId'>
        /// Stream identifier.
        /// </param>
        public StartPacket(byte streamId)
            : base(streamId)
        {
        }
    }
}

