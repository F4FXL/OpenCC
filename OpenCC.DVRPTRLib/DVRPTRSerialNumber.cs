using System;
using OpenCC.Common;

namespace OpenCC.DVRPTRLib
{
    /// <summary>
    /// DVRPTR serial number.
    /// </summary>
    public sealed class DVRPTRSerialNumber : IEquatable<DVRPTRSerialNumber>
    {
        #region members
        private readonly uint _serialNumber;
        #endregion

        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/> class.
        /// </summary>
        /// <param name="serialNumber">Serial number.</param>
        public DVRPTRSerialNumber(uint serialNumber)
        {
            _serialNumber = serialNumber;
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>The year.</value>
        public uint Year
        {
            get
            {
                uint year = (_serialNumber >> 28) & 0xF;
                year = year.BCDtoDecimal();
                return year;
            }
        }

        /// <summary>
        /// Gets the month.
        /// </summary>
        /// <value>The month.</value>
        public uint Week
        {
            get
            {
                uint week = (_serialNumber >> 24) & 0xF;
                week = week.BCDtoDecimal();
                return week;
            }
        }

        /// <summary>
        /// Gets the number.
        /// </summary>
        /// <value>The number.</value>
        public uint Number
        {
            get
            {
                uint number = _serialNumber >> 16;
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
            return _serialNumber.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
        /// <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as DVRPTRSerialNumber);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/>.</returns>
        public override string ToString()
        {
            //return string.Format("[DVRPTRSerialNumber: Year={0}, Week={1}, Number={2}]", Year, Week, Number);
            return _serialNumber.BCDtoDecimal().ToString();
        }
        #endregion

        #region IEquatable implementation
        /// <summary>
        /// Determines whether the specified <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/> is equal to the current <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/>.
        /// </summary>
        /// <param name="other">The <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/> to compare with the current <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/> is equal to the current
        /// <see cref="OpenCC.DVRPTRLib.DVRPTRSerialNumber"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(DVRPTRSerialNumber other)
        {
            bool equals = false;
            if(other != null)
            {
                equals = other._serialNumber == _serialNumber;
            }

            return equals;
        }

        #endregion
    }
}

