using System;
using OpenCC.DVRPTRLib.IO.PCP2;

namespace OpenCC.DVRPTRLib
{
    /// <summary>
    /// A simple data container for DVRPTR configuration
    /// </summary>
    public class Configuration
    {
        public Configuration()
        {
            //some default values
            TxLevel = 128;
            RxReverse = false;
            TxReverse = false;
            TxDelay = 100;
        }
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

        /// <param name='configuration'>
        /// Configuration.
        /// </param>
        internal ConfigurationPacket ToConfigurationPacket()
        {
            return new ConfigurationPacket(this.TxLevel,
                                       this.TxReverse,
                                       this.RxReverse,
                                       this.TxDelay);
        }
    }
}

