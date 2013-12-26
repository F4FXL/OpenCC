using System;
using System.IO;
using System.Threading;
using OpenCC.DVRPTRLib.IO.PCP2;

namespace OpenCC.DVRPTRLib
{
    /// <summary>
    /// DVRPTR class, handling high level functionalities
    /// </summary>
    public partial class DVRPTR : IDisposable
    {
        #region members
        private readonly DVRPTRio _dvrptrIO;
        private TimeSpan _dvrptrTimeout;
        #endregion

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTR"/> class.
        /// </summary>
        /// <param name="stream">Stream.</param>
        /// <param name="streamOwner">If set to <c>true</c> stream owner.</param>
        public DVRPTR(Stream stream, bool streamOwner)
            : this(stream, streamOwner, null)
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.DVRPTR"/> class.
        /// </summary>
        /// <param name="stream">Stream.</param>
        /// <param name="streamOwner">If set to <c>true</c> stream owner.</param>
        /// <param name="syncContext">Sync context to fire events on it</param>
        public DVRPTR(Stream stream, bool streamOwner, SynchronizationContext syncContext)
        {
            //No need to null check args here, DVRPTRio ctor is doing this for us :)
            _dvrptrIO = new DVRPTRio(stream, streamOwner, syncContext);
            _dvrptrTimeout = TimeSpan.FromMilliseconds(500);
        }
        
        #endregion



        #region Methods

        public void GetVersion()
        {
            using(SynchronousBroker<GetVersionAnswerPacket> sync = new SynchronousBroker<GetVersionAnswerPacket>(this._dvrptrIO))
            {
                GetVersionPacket getVerPacket = new GetVersionPacket();
                _dvrptrIO.Write(getVerPacket);
                sync.WaitHandle.WaitOne(_dvrptrTimeout);

            }
        }

        /// <summary>
        /// Open this instance.
        /// </summary>
        public void Open()
        {
            _dvrptrIO.Open();
        }

        /// <summary>
        /// Close this instance.
        /// </summary>
        public void Close()
        {
            this.Dispose();
        }
        #endregion

        #region properties
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

