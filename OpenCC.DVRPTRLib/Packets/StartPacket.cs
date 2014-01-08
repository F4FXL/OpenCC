using OpenCC.DVRPTRLib.Packets;

namespace OpenCC.DVRPTRLib.Packets
{
    /// <summary>
    /// Start packet.
    /// </summary>
    internal class StartPacket : StreamIdPacket
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

