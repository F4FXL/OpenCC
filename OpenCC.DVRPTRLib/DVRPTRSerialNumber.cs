using System;

namespace OpenCC.DVRPTRLib
{
    /// <summary>
    /// DVRPTR serial number.
    /// </summary>
    public sealed class DVRPTRSerialNumber
    {
        #region members
        private readonly int _serialNumber;
        #endregion

        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/> class.
        /// </summary>
        /// <param name="serialNumber">Serial number.</param>
        public DVRPTRSerialNumber(int serialNumber)
        {
            _serialNumber = serialNumber;
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year
        {
            get
            {
                int year = _serialNumber & 0x000000FF;
                return year;
            }
        }

        /// <summary>
        /// Gets the month.
        /// </summary>
        /// <value>The month.</value>
        public int Month
        {
            get
            {
                int month = _serialNumber >> 8;
                month = month & 0x000000FF;
                return month;
            }
        }

        /// <summary>
        /// Gets the number.
        /// </summary>
        /// <value>The number.</value>
        public int Number
        {
            get
            {
                int number = _serialNumber >> 16;
                number = number & 0x0000FFFF;
                return number;
            }
        }
        #endregion

        #region overrides
        /// <summary>
        /// Serves as a hash function for a <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return _serialNumber;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
        /// <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            bool equals = false;
            if(obj is DVRPTRSerialNumber)
            {
                DVRPTRSerialNumber other = (DVRPTRSerialNumber)obj;
                equals = other._serialNumber == _serialNumber;
            }

            return equals;
        }
        #endregion
    }
}

