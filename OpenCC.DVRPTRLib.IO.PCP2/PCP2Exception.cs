using System;

namespace OpenCC.DVRPTRLib.IO.PCP2
{
    /// <summary>
    /// PC p2 exception.
    /// </summary>
    [Serializable]
    public class PCP2Exception : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.PCP2Exception"/> class.
        /// </summary>
        public PCP2Exception()
            : this(string.Empty)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.PCP2Exception"/> class.*/
        /// </summary>
        /// <param name="message">Message.</param>
        public PCP2Exception(string message)
            : this(message, null)
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.PCP2Exception"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public PCP2Exception(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}

