using System;
using OpenCC.Common.Diagnostics;
using OpenCC.DVRPTRLib.Infrastructure.Packets;
using OpenCC.DVRPTRLib.IO;

namespace OpenCC.DVRPTRLib
{
    /// <summary>
    /// DVRPTR class, handling high level functionalities
    /// </summary>
    public partial class DVRPTR : IDisposable
    {
        #region members
        private readonly IDVRPTRio _dvrptrIO;
        private TimeSpan _dvrptrTimeout;
        private static readonly DVRPTRVersion _minSupportedVersion;
        #endregion

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTR"/> class.
        /// </summary>
        public DVRPTR(IDVRPTRio dvrptrio)
        {
            Guard.IsNotNull(dvrptrio, "dvrptrio");
            _dvrptrIO = dvrptrio;
            _dvrptrTimeout = TimeSpan.FromMilliseconds(500);
        }

        /// <summary>
        /// Initializes the <see cref="OpenCC.DVRPTRLib.DVRPTR"/> class.
        /// </summary>
        static DVRPTR()
        {
            _minSupportedVersion = new DVRPTRVersion(1,6,9,'b', "DV-RPTR R.2012-08-08");//1.69b DV-RPTR R.2012-08-08
        }
        #endregion



        #region Methods
        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <returns>The version.</returns>
        public DVRPTRVersion GetVersion()
        {
            DVRPTRVersion version = null;

            GetVersionAnswerPacket versionAnswerPacket = SendCommandAndWaitForAnswer<GetVersionAnswerPacket>(new GetVersionPacket());
            version = DVRPTRVersion.FromPacket(versionAnswerPacket);

            return version;
        }

        /// <summary>
        /// Gets the serial number.
        /// </summary>
        /// <returns>The serial number.</returns>
        public DVRPTRSerialNumber GetSerialNumber()
        {
            GetSerialNumberAnswerPacket serialNumberPkt = SendCommandAndWaitForAnswer<GetSerialNumberAnswerPacket>(new GetSerialNumberPacket());
            DVRPTRSerialNumber serialNumber = new DVRPTRSerialNumber(serialNumberPkt.SerialNumber);

            return serialNumber;
        }

        private TAnswerPacket SendCommandAndWaitForAnswer<TAnswerPacket>(Packet commandPacket)
            where TAnswerPacket : Packet
        {
            Guard.IsNotNull(commandPacket, "commandPacket");

            if(!this.IsOpen)
                throw new InvalidOperationException("This DVRPTR is not open");

            using(SynchronousBroker<TAnswerPacket> sync = new SynchronousBroker<TAnswerPacket>(this._dvrptrIO))
            {
                _dvrptrIO.Write(commandPacket);
                bool timedOut = !sync.WaitHandle.WaitOne(_dvrptrTimeout);

                if (timedOut)
                    throw new DVRPTRTimeoutException();

                return sync.Packet;
            }
        }

        /// <summary>
        /// Open this instance.
        /// </summary>
        /// <exception cref="DVRPTRException">Failed to communicate with board</exception>
        /// <exception cref="DVRPTRVersionException">Unsuported FW version</exception>
        public void Open()
        {
            _dvrptrIO.Open();
            if(IsOpen)
            {
                DVRPTRVersion boardVersion = this.GetVersion();

                if (boardVersion < _minSupportedVersion)
                    throw new DVRPTRVersionException(_minSupportedVersion, boardVersion);


            }
        }

        /// <summary>
        /// Close this instance.
        /// </summary>
        public void Close()
        {
            this.Dispose();
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <returns>The configuration.</returns>
        public Configuration GetConfiguration()
        {
            Configuration configuration = null;

            ConfigurationPacket configurationPacket = SendCommandAndWaitForAnswer<ConfigurationPacket>(new GetConfigurationPacket());

            return configuration;
        }
        #endregion

        #region properties


        /// <summary>
        /// Gets a value indicating whether this instance is open.
        /// </summary>
        /// <value><c>true</c> if this instance is open; otherwise, <c>false</c>.</value>
        public bool IsOpen
        {
            get
            {
                return _dvrptrIO.IsOpen;
            }
        }
        /// <summary>
        /// Gets or sets the time out for communicating with the DVRPTR board.
        /// Default is 500ms
        /// </summary>
        /// <value>The time out.</value>
        public TimeSpan TimeOut
        {
            get
            {
                return _dvrptrTimeout;
            }
            set
            {
                _dvrptrTimeout = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value><c>true</c> if this instance is disposed; otherwise, <c>false</c>.</value>
        public bool IsDisposed
        {
            get
            {
                return _dvrptrIO.IsDisposed;
            }
        }
        #endregion

        #region finalizer
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="OpenCC.DVRPTRLib.DVRPTR"/> is reclaimed by garbage collection.
        /// </summary>
        ~ DVRPTR()
        {
            Dispose(false);
        }
        #endregion


        #region IDisposable implementation

        /// <summary>
        /// </summary>
        /// <param name="disposing">If set to <c>true</c> disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                _dvrptrIO.Dispose();
            }
        }

        /// <summary>
        /// Releases all resource used by the <see cref="OpenCC.DVRPTRLib.DVRPTR"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="OpenCC.DVRPTRLib.DVRPTR"/>. The
        /// <see cref="Dispose"/> method leaves the <see cref="OpenCC.DVRPTRLib.DVRPTR"/> in an unusable state. After
        /// calling <see cref="Dispose"/>, you must release all references to the <see cref="OpenCC.DVRPTRLib.DVRPTR"/>
        /// so the garbage collector can reclaim the memory that the <see cref="OpenCC.DVRPTRLib.DVRPTR"/> was occupying.</remarks>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}

