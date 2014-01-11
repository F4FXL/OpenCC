using System;
using OpenCC.Common.Diagnostics;

namespace OpenCC.DVRPTRLib.Infrastructure.Packets
{
    public class GetVersionAnswerPacket : Packet
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

        #region Properties
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
        /// Gets the sub version.
        /// </summary>
        /// <value>The sub version.</value>
        public byte SubsubVersion
        {
            get
            {
                return _subSubVersion;
            }
        }

        /// <summary>
        /// Gets the sub version.
        /// </summary>
        /// <value>The sub version.</value>
        public char BugFixLevel
        {
            get
            {
                return _bugFixLevel;
            }
        }

        /// <summary>
        /// Gets the device identification.
        /// </summary>
        /// <value>The device identification.</value>
        public string DeviceIdentification
        {
            get
            {
                return _deviceIdentification;
            }
        }
        #endregion
    }
}

