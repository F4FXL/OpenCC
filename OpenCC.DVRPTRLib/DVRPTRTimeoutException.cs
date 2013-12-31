using System;

namespace OpenCC.DVRPTRLib
{
    public class DVRPTRTimeoutException : DVRPTRException
    {
        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTRTimeoutException"/> class.
        /// </summary>
        public DVRPTRTimeoutException()
            : this("Communication with DVRPTR timedout")
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTRException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public DVRPTRTimeoutException(string message)
            : this(message, null)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTRException"/> class.
        /// </summary>
        public DVRPTRTimeoutException(string message, Exception inner)
            : base(message, inner)
        {
        }
        #endregion
    }
}

