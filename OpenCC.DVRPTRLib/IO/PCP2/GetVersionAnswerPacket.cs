using System;
using OpenCC.Common.Diagnostics;

namespace OpenCC.DVRPTRLib.IO.PCP2
{
    internal class GetVersionAnswerPacket : PCP2Packet
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
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.IO.PCP2.GetVersionAnswerPacket"/> class.
        /// </summary>
        /// <param name="mainVersion">Main version.</param>
        /// <param name="subVersion">Sub version.</param>
        /// <param name="subSubVersion">Sub sub version.</param>
        /// <param name="bugFixLevel">Bug fix level.</param>
        /// <param name="deviceIdentification">Device identification.</param>
        public GetVersionAnswerPacket(byte mainVersion, byte subVersion, byte subSubVersion, char bugFixLevel, string deviceIdentification)
        {
            _mainVersion = mainVersion;
            _subVersion = subVersion;
            _subSubVersion = subSubVersion;
            _bugFixLevel = bugFixLevel;
            _deviceIdentification = deviceIdentification ?? string.Empty;
        }
        #endregion

        #region Methods
        /// <summary>
        /// </summary>
        /// <returns>The version.</returns>
        public DVRPTRVersion ToVersion()
        {
            DVRPTRVersion version = new DVRPTRVersion(_mainVersion, _subVersion, _subSubVersion, _bugFixLevel, _deviceIdentification);
            return version;
        }
        #endregion
    }
}

