using System;

namespace OpenCC.Common.Diagnostics
{
    /// <summary>
    /// Guard.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// If the specified value is null an exception is thrown
        /// </summary>
        /// <returns><c>true</c> if is not null the specified value paramName; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        /// <param name="paramName">Parameter name.</param>
        public static void IsNotNull(object value, string paramName)
        {
            if(value == null)
            {
                ArgumentNullException itInTheAir = new ArgumentNullException(paramName);
                throw itInTheAir;
            }
        }
    }
}

