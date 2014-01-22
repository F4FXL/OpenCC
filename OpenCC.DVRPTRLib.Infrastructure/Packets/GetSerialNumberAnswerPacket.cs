using System;

namespace OpenCC.DVRPTRLib.Infrastructure.Packets
{
    /// <summary>
    /// Get serial number answer packet.
    /// </summary>
    public class GetSerialNumberAnswerPacket : Packet
    {
        #region members
        private readonly uint _serial;
        #endregion
        #region ctor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="OpenCC.DVRPTRLib.Infrastructure.Packets.GetSerialNumberAnswerPacket"/> class.
        /// </summary>
        /// <param name="serialNumber">Serial number.</param>
        public GetSerialNumberAnswerPacket(uint serialNumber)
        {
            _serial = serialNumber;
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the serial number.
        /// </summary>
        /// <value>The serial number.</value>
        public uint SerialNumber
        {
            get
            {
                return _serial;
            }
        }
        #endregion
    }
}

