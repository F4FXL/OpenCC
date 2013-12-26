using System;

namespace OpenCC.DVRPTRLib.IO.PCP2
{
    internal class StreamIdPCP2Packet : PCP2Packet
    {
        #region Members
        private byte _streamId;
        #endregion

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.StreamIdPCP2Packet"/> class.
        /// </summary>
        public StreamIdPCP2Packet(byte streamId)
        {
            _streamId = streamId;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the stream identifier.
        /// </summary>
        /// <value>
        /// The stream identifier.
        /// </value>
        public byte StreamId
        {
            get
            {
                return _streamId;
            }
        }
        #endregion
    }
}

