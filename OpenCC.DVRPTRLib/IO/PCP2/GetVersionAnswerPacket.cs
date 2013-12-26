using System;
using OpenCC.Common.Diagnostics;

namespace OpenCC.DVRPTRLib.IO.PCP2
{
    internal class GetVersionAnswerPacket : PCP2Packet
    {
        #region members
        private readonly Version _version;
        private readonly string _versionName;
        #endregion

        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.IO.PCP2.GetVersionAnswerPacket"/> class.
        /// </summary>
        /// <param name="version">Version.</param>
        /// <param name="versionName">Version name.</param>
        public GetVersionAnswerPacket(Version version, string versionName)
        {
            Guard.IsNotNull(version, "version");
            _version = version;
            _versionName = versionName ?? string.Empty;
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the firmware version.
        /// </summary>
        /// <value>The firmware version.</value>
        public Version FirmwareVersion
        {
            get
            {
                return _version;
            }
        }

        /// <summary>
        /// Gets the name of the version.
        /// </summary>
        /// <value>The name of the version.</value>
        public string VersionName
        {
            get
            {
                return _versionName;
            }
        }
        #endregion
    }
}

