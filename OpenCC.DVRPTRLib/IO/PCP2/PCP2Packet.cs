using System;

namespace OpenCC.DVRPTRLib.IO.PCP2
{
    /// <summary>
    /// Represents a PCP packet
    /// This class is meant as a data container
    /// Inherited classes should not contain any logic
    /// De/Serialization is done either using PCP2PAcketCreator or PCP2PAcketSerializer
    /// </summary>
    public abstract class PCP2Packet
    {
        #region consts
        /// <summary>
        /// The STAR_ID of a PCPPacket
        /// </summary>
        public const byte START_ID = 0xD0;
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2Packet"/> class.
        /// </summary>
        protected PCP2Packet()
        {
        }
        #endregion
    }
}

