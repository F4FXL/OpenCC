
namespace OpenCC.DVRPTRLib.Infrastructure.Packets
{
    public abstract class StreamIdPacket : Packet
    {
        #region members
        private readonly int _streamId;
        #endregion

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.Packets.StreamIdPacket"/> class.
        /// </summary>
        /// <param name="streamId">Stream identifier.</param>
        protected StreamIdPacket(int streamId)
        {
            _streamId = streamId;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the stream identifier.
        /// </summary>
        /// <value>The stream identifier.</value>
        public int StreamId
        {
            get
            {
                return _streamId;
            }
        }
        #endregion
    }
}

