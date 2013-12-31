using System;

namespace OpenCC.DVRPTRLib
{
    /// <summary>
    /// DVRPTR exception.
    /// </summary>
    [Serializable]
    public class DVRPTRException : Exception
    {
        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTRException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public DVRPTRException(string message)
            : this(message, null)
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTRException"/> class.
        /// </summary>
        public DVRPTRException(string message, Exception inner)
            : base(message, inner)
        {
        }
        #endregion
    }
}

