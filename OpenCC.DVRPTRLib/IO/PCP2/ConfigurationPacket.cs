
namespace OpenCC.DVRPTRLib.IO.PCP2
{
    internal class ConfigurationPacket : PCP2Packet
    {
        #region ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.PCP2.SetConfigPacket"/> class.
        /// </summary>
        /// <param name='txLevel'>
        /// Tx level.
        /// </param>
        /// <param name='txReverse'>
        /// Tx reverse.
        /// </param>
        /// <param name='rxReverse'>
        /// Rx reverse.
        /// </param>
        /// <param name='txDelay'>
        /// Tx delay.
        /// </param>
        public ConfigurationPacket(byte txLevel, bool txReverse, bool rxReverse, byte txDelay)
        {
        }
        #endregion

        #region properties
         /// <summary>
        /// Gets or sets the tx level.
        /// </summary>
        /// <value>
        /// The tx level.
        /// </value>
        public byte TxLevel {get;set;}

        /// <summary>
        /// Gets or sets a value indicating whether RX is reversed or not
        /// </summary>
        /// <value>
        /// <c>true</c> if rx reverse; otherwise, <c>false</c>.
        /// </value>
        public bool RxReverse {get;set;}


        /// <summary>
        /// Gets or sets a value indicating whether RX is reversed or not
        /// </summary>
        /// <value>
        /// <c>true</c> if tx reverse; otherwise, <c>false</c>.
        /// </value>
        public bool TxReverse{get; set;}


        /// <summary>
        /// Gets or sets the tx delay in ms
        /// </summary>
        /// <value>
        /// The tx delay.
        /// </value>
        public byte TxDelay{get; set;}
        #endregion
    }
}

