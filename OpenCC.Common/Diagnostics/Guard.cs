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

        /// <summary>
        /// Determines if the specified value is in range lowerRangeLimit higherRangeLimit paramName.
        /// </summary>
        /// <returns><c>true</c> if is in range the specified value lowerRangeLimit higherRangeLimit paramName; otherwise, <c>false</c>.</returns>
        /// <param name="value">Value.</param>
        /// <param name="lowerRangeLimit">Lower range limit.</param>
        /// <param name="higherRangeLimit">Higher range limit.</param>
        /// <param name="paramName">Parameter name.</param>
        /// <typeparam name="TComparable">The 1st type parameter.</typeparam>
        public static void IsInRange<TComparable>(TComparable value, TComparable lowerRangeLimit, TComparable higherRangeLimit, string paramName)
            where TComparable : IComparable
        {
            if(ComparableHelper.Compare(value,lowerRangeLimit) < 0 ||
               ComparableHelper.Compare(value, higherRangeLimit) > 0)
            {
                string message = string.Format("{0} must be between {1} and {2}. {0} was {3}", paramName, lowerRangeLimit, higherRangeLimit, value);
                throw new ArgumentOutOfRangeException(message, (Exception)null);
            }
        }
    }
}

