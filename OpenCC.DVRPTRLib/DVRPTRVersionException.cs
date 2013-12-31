using System;

namespace OpenCC.DVRPTRLib
{
    /// <summary>
    /// DVRPTR version exception.
    /// </summary>
    public class DVRPTRVersionException : DVRPTRException
    {
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTRVersionException"/> class.
        /// </summary>
        /// <param name="expected">Expected.</param>
        /// <param name="actual">Actual.</param>
        public DVRPTRVersionException(DVRPTRVersion expected, DVRPTRVersion actual)
            : this(string.Format("This version of the library supports version {0} of the firmware. Board has version {1}", expected, actual))
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTRVersionException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public DVRPTRVersionException(string message)
            : this(message, null)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTRVersionException"/> class.
        /// </summary>
        /// <param name="inner">Inner.</param>
        /// <param name="message">Message.</param>
        public DVRPTRVersionException(string message, Exception inner)
            : base(message, inner)
        {
        }
        #endregion
    }
}

