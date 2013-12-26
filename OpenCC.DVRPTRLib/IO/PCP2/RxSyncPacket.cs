using System;

namespace OpenCC.DVRPTRLib.IO.PCP2
{
    /// <summary>
    /// Rx sync packet.
    /// </summary>
    internal class RxSyncPacket : StreamIdPCP2Packet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.RxSyncPacket"/> class.
        /// </summary>
        /// <param name='streamId'>
        /// Stream identifier.
        /// </param>
        public RxSyncPacket(byte streamId)
            : base(streamId)
        {
        }
    }
}

