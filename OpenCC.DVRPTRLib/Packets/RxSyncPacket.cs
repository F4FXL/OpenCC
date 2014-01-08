using OpenCC.DVRPTRLib.Packets;

namespace OpenCC.DVRPTRLib.Packets
{
    /// <summary>
    /// Rx sync packet.
    /// </summary>
    internal class RxSyncPacket : StreamIdPacket
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

