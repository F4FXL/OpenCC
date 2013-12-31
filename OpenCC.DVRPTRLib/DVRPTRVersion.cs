using System;
using OpenCC.Common;
using OpenCC.Common.Diagnostics;

namespace OpenCC.DVRPTRLib
{
    /// <summary>
    /// DVRPTR version number
    /// </summary>
    public sealed class DVRPTRVersion : IComparable<DVRPTRVersion>, IEquatable<DVRPTRVersion>, IComparable
    {
        #region members
        private readonly byte _mainVersion;
        private readonly byte _subVersion;
        private readonly byte _subSubVersion;
        private readonly char _bugFixLevel;
        private readonly string _deviceIdentification;
        #endregion

        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTRVersion"/> class.
        /// </summary>
        /// <param name="mainVersion">Main version.</param>
        /// <param name="subVersion">Sub version.</param>
        /// <param name="subSubVersion">Sub sub version.</param>
        /// <param name="bugFixLevel">Bug fix level.</param>
        /// <param name = "deviceIdentification"></param>
        public DVRPTRVersion(byte mainVersion, byte subVersion, byte subSubVersion, char bugFixLevel, string deviceIdentification)
        {
            Guard.IsInRange(mainVersion, 0, 9, "mainVersion");
            Guard.IsInRange(subVersion, 0, 9, "subVersion");
            Guard.IsInRange(subSubVersion, 0, 9, "subSubVersion");

            if(bugFixLevel != '\0')
                Guard.IsInRange(bugFixLevel, 'a', 'p', "bugFixLevel");

            _mainVersion = mainVersion;
            _subVersion = subVersion;
            _subSubVersion = subSubVersion;
            _bugFixLevel = bugFixLevel;
            _deviceIdentification = deviceIdentification ?? string.Empty;
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the main version.
        /// </summary>
        /// <value>The main version.</value>
        public byte MainVersion
        {
            get
            {
                return _mainVersion;
            }
        }

        /// <summary>
        /// Gets the sub version.
        /// </summary>
        /// <value>The sub version.</value>
        public byte SubVersion
        {
            get
            {
                return _subVersion;
            }
        }

        /// <summary>
        /// Gets the sub sub version.
        /// </summary>
        /// <value>The sub sub version.</value>
        public byte SubSubVersion
        {
            get
            {
                return _subSubVersion;
            }
        }

        /// <summary>
        /// Gets the bugfix level.
        /// </summary>
        /// <value>The bugfix level.</value>
        public char BugfixLevel
        {
            get
            {
                return _bugFixLevel;
            }
        }
        #endregion

        #region methods
        private static int Compare(DVRPTRVersion a, DVRPTRVersion b)
        {
            return ComparableHelper.Compare(a, b);
        }
        #endregion
        
        #region operators
        public static bool operator <(DVRPTRVersion a, DVRPTRVersion b)
        {
            int result = Compare(a, b);
            return result < 0;
        }

        public static bool operator >(DVRPTRVersion a, DVRPTRVersion b)
        {
            int result = Compare(a, b);
            return result > 0;
        }

        public static bool operator <=(DVRPTRVersion a, DVRPTRVersion b)
        {
            int result = Compare(a, b);
            return result <= 0;
        }

        public static bool operator >=(DVRPTRVersion a, DVRPTRVersion b)
        {
            int result = Compare(a, b);
            return result >= 0;
        }

        public static bool operator ==(DVRPTRVersion a, DVRPTRVersion b)
        {
            int result = Compare(a, b);
            return result == 0;
        }

        public static bool operator !=(DVRPTRVersion a, DVRPTRVersion b)
        {
            int result = Compare(a, b);
            return result != 0;
        }
        #endregion

        #region IComparable implementation
        /// <para>Returns the sort order of the current instance compared to the specified object.</para>
        /// <summary>
        /// Compares to.
        /// </summary>
        /// <returns>The to.</returns>
        /// <param name="other">Other.</param>
        public int CompareTo(DVRPTRVersion other)
        {
            int result = 1;
            if((object)other != null)//cast to object thus overloaded != operator do not get called (avoid stack overflow)
            {
                result = this._mainVersion.CompareTo(other._mainVersion);

                if (result == 0)
                    result = this._subVersion.CompareTo(other._subVersion);

                if (result == 0)
                    result = this._subSubVersion.CompareTo(other._subSubVersion);

                if (result == 0)
                    result = this._bugFixLevel.CompareTo(other._bugFixLevel);
            }

            return result;
        }
        #endregion


        #region IEquatable implementation

        /// <summary>
        /// Determines whether the specified <see cref="OpenCC.DVRPTRLib.DVRPTRVersion"/> is equal to the current <see cref="OpenCC.DVRPTRLib.DVRPTRVersion"/>.
        /// </summary>
        /// <param name="other">The <see cref="OpenCC.DVRPTRLib.DVRPTRVersion"/> to compare with the current <see cref="OpenCC.DVRPTRLib.DVRPTRVersion"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="OpenCC.DVRPTRLib.DVRPTRVersion"/> is equal to the current
        /// <see cref="OpenCC.DVRPTRLib.DVRPTRVersion"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(DVRPTRVersion other)
        {
            int result = CompareTo(other);
            return result == 0;
        }

        #endregion

        #region IComparable implementation

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <returns>The to.</returns>
        /// <param name="obj">Object.</param>
        int IComparable.CompareTo(object obj)
        {
            return this.CompareTo(obj as DVRPTRVersion);
        }

        #endregion

        #region overrides
        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="OpenCC.DVRPTRLib.DVRPTRVersion"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="OpenCC.DVRPTRLib.DVRPTRVersion"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
        /// <see cref="OpenCC.DVRPTRLib.DVRPTRVersion"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            int result = CompareTo(obj as DVRPTRVersion);
            return result == 0;
        }

        /// <summary>
        /// Serves as a hash function for a <see cref="OpenCC.DVRPTRLib.DVRPTRVersion"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a
        /// hash table.</returns>
        public override int GetHashCode()
        {
            return _mainVersion.GetHashCode() ^ 
                   _subVersion.GetHashCode() ^ 
                   _subSubVersion.GetHashCode() ^
                   _bugFixLevel.GetHashCode() ^
                   _deviceIdentification.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="OpenCC.DVRPTRLib.DVRPTRVersion"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="OpenCC.DVRPTRLib.DVRPTRVersion"/>.</returns>
        public override string ToString()
        {
            string s = string.Format("{0}.{1}{2}{3} {4}",
                                     _mainVersion,
                                     _subVersion,
                                     _subSubVersion,
                                     _bugFixLevel != '\0' ? _bugFixLevel.ToString() : "",
                                     _deviceIdentification);
            return s;
        }
        #endregion
    }
}

