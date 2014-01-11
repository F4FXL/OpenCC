using System;
using System.IO;
using System.Threading;
using OpenCC.Common;
using OpenCC.Common.Diagnostics;
using OpenCC.DVRPTRLib.Infrastructure.Packets;
using OpenCC.DVRPTRLib.Infrastructure;

namespace OpenCC.DVRPTRLib.IO
{
    /// <summary>
    /// DVRPTR io abstract imlpementation, stream based.
    /// </summary>
    public abstract class DVRPTRio : IDVRPTRio
    {
        #region members
        private readonly BinaryReader _modemStreamReader;//streamReader to read/write to DVRPTR board
        private Thread _readModemThread;
        private readonly SynchronizedQueue<byte[]> _readModemQueue;

        private readonly SynchronizedQueue<byte[]> _writeModemQueue;
        private readonly BinaryWriter _modemStreamWriter;
        private Thread _writeModemThread;

        private Thread _packetDispatchThread;
        private bool _run;
        private bool _disposed;
        private readonly bool _streamOwner;
        private EventHandler<PacketReceivedEventArgs> _packetReceived;
        private readonly SynchronizationContext _syncContext;
        #endregion

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.IO.DVRPTRio"/> class.
        /// </summary>
        /// <param name="stream">Stream.</param>
        /// <param name="streamOwner">If set to <c>true</c> this instance is the stream owner. The stream will disposed when this instance is disposed</param>
        protected DVRPTRio(Stream stream, bool streamOwner)
            : this(stream, streamOwner, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DVRPTRio"/> class.
        /// </summary>
        /// <param name="stream">Stream.</param>
        /// <param name="streamOwner">If set to <c>true</c> this instance is the stream owner. The stream will disposed when this instance is disposed</param>
        /// <param name="syncContext">When specified the PacketReceived event is fired on this context. Otherwise it is fired on a worker thread</para>
        protected DVRPTRio(Stream stream, bool streamOwner, SynchronizationContext syncContext)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (!stream.CanWrite)
                throw new ArgumentException("stream is not writable");
            if (!stream.CanRead)
                throw new ArgumentException("stream is not readable");

            _run = false;
            _disposed = false;

            _modemStreamReader = new BinaryReader(stream);
            _readModemThread = null;
            _readModemQueue = new SynchronizedQueue<byte[]>();

            _modemStreamWriter = new BinaryWriter(stream);
            _writeModemThread = null;
            _writeModemQueue = new SynchronizedQueue<byte[]>();

            _streamOwner = streamOwner;
            _syncContext = syncContext;
        }
        #endregion

        #region finalizer
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="OpenCC.DVRPTRLib.DVRPTR"/> is reclaimed by garbage collection.
        /// </summary>
        ~DVRPTRio()
        {
            Dispose(false);
        }
        #endregion

        #region methods
        /// <summary>
        /// This is the thread procedure that will consume the write queue
        /// </summary>
        private void WriteModemThread()
        {
            while (_run)//TODO use better technique than dumb boolean
            {
                byte[] packetBytes = _writeModemQueue.Dequeue();
                if(packetBytes != null && packetBytes.Length >= 4)
                {
                    _modemStreamWriter.Write(packetBytes);
                    _modemStreamWriter.Flush();
                }
            }
        }

        /// <summary>
        /// Wait for packets to arrive in _readModemQueue
        /// Packets are then parsed and appropriate event is fired
        /// </summary>
        private void PacketDispatchThread()
        {
            while(_run)//TODO use better technique than dumb boolean
            {
                byte[] packetBytes = _readModemQueue.Dequeue();
                if (packetBytes != null && packetBytes.Length >= 4)//packets should at least always have a length of 4
                {                                      //StartID, 2 bytes length, and command byte
                    Packet packet = DeserializePacket(packetBytes);
                    if(packet != null)
                        RaisePacketReceived(packet);
                }
            }
        }

        
        /// <summary>
        /// Reads the modem and fills the RX queue with the read packets
        /// </summary>
        private void ReadModemThread()
        {
            while(_run)//TODO use better technique than dumb boolean
            {
                byte[] packetBytes = ReadPacketBytes();
                if(packetBytes != null && packetBytes.Length >= 4)//packets should at least always have a length of 4
                {                                      //StartID, 2 bytes length, and command byte
                    _readModemQueue.Enqueue(packetBytes);
                }
            }
        }

        /// <summary>
        /// Checks if the object is disposed, if it is disposed an exception is thrown
        /// </summary>
        private void CheckDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(this.GetType().Name);
        }

        /// <summary>
        /// Raises the packet received event
        /// </summary>
        /// <param name='packet'>
        /// Packet.
        /// </param>
        private void RaisePacketReceived(Packet packet)
        {
            PacketReceivedEventArgs e = new PacketReceivedEventArgs(packet);
            OnPacketReceived(e);
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the modem stream reader. Derived class should NOT dispose this !
        /// </summary>
        /// <value>The modem stream reader.</value>
        protected BinaryReader ModemStreamReader
        {
            get
            {
                return _modemStreamReader;
            }
        }

        /// <summary>
        /// Gets the modem stream writer. Derived classes should NOT dispose this !
        /// </summary>
        /// <value>The modem stream write.</value>
        protected BinaryWriter ModemStreamWriter
        {
            get
            {
                return _modemStreamWriter;
            }
        }
        #endregion

        #region abstract methods
        /// <summary>
        /// When implemented, wait for a packet coming from the DV-RPTR
        /// </summary>
        /// <returns>The packet.</returns>
        protected abstract byte[] ReadPacketBytes();

        /// <summary>
        /// When implemented serilizes the specified packet into an array of bytes
        /// </summary>
        /// <returns>The packet bytes.</returns>
        /// <param name="packet">Packet.</param>
        protected abstract byte[] SerializePacket(Packet packet);

        /// <summary>
        /// When implemented Deserializes the packet out of the specified byte array
        /// </summary>
        /// <returns>The packet.</returns>
        /// <param name="bytes">Bytes.</param>
        protected abstract Packet DeserializePacket(byte[]  bytes);
        #endregion

        #region virtual
        /// <summary>
        /// Raises the packet received event.
        /// </summary>
        /// <param name='e'>
        /// E.
        /// </param>
        protected virtual void OnPacketReceived(PacketReceivedEventArgs e)
        {
            if (_packetReceived != null)
            {
                if(_syncContext == null)
                {
                    _packetReceived(this, e);
                }
                else
                {
                    _syncContext.Post(delegate(object state)
                                      {
                        _packetReceived(this, e);
                    }, null);
                }
            }
        }
        #endregion

        #region IDVRPTRio implementation

        /// <summary>
        /// Occurs when a packet is received.
        /// </summary>
        public event EventHandler<PacketReceivedEventArgs> PacketReceived
        {
            add
            {
                _packetReceived += value;
            }
            remove
            {
                _packetReceived -= value;
            }
        }

        /// <summary>
        /// Start this instance of DVRPTR
        /// The Read and Send queue start to be processed.
        /// </summary>
        public void Open()
        {
            CheckDisposed();
            _run = true;

            _readModemThread = new Thread(ReadModemThread);
            _readModemThread.Name = "Read Modem";
            _readModemThread.IsBackground = true;
            _readModemThread.Start();

            _packetDispatchThread = new Thread(PacketDispatchThread);
            _packetDispatchThread.Name = "Packet Dispatch";
            _packetDispatchThread.IsBackground = true;
            _packetDispatchThread.Start();

            _writeModemThread = new Thread(WriteModemThread);
            _writeModemThread.Name = "Write Modem";
            _writeModemThread.IsBackground = true;
            _writeModemThread.Start();
        }

        /// <summary>
        /// Close this instance.
        /// </summary>
        public void Close()
        {
            CheckDisposed();
            this.Dispose();
        }

        /// <summary>
        /// Write the specified packet to the DVRPTR
        /// </summary>
        /// <param name='packet'>
        /// Packet.
        /// </param>
        public void Write(Packet packet)
        {
            Guard.IsNotNull(packet, "packet");

            byte[] packetBytes = SerializePacket(packet);

            _writeModemQueue.Enqueue(packetBytes);
        }
        
        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value><c>true</c> if this instance is disposed; otherwise, <c>false</c>.</value>
        public bool IsDisposed
        {
            get
            {
                return this._disposed;
            }
        }
        /// <summary>
        /// Gets a value indicating whether this instance is open.
        /// </summary>
        /// <value><c>true</c> if this instance is open; otherwise, <c>false</c>.</value>
        public bool IsOpen
        {
            get
            {
                bool isOpen= !_disposed &&
                    _run &&
                        _readModemThread != null &&
                        _readModemThread.IsAlive &&
                        _writeModemThread != null &&
                        _writeModemThread.IsAlive &&
                        _packetDispatchThread != null &&
                        _packetDispatchThread.IsAlive;

                return isOpen;
            }
        }

        #endregion

        #region IDisposable implementation
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

        /// <summary>
        /// </summary>
        /// <param name="disposing">If set to <c>true</c> disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                _disposed = true;
                if(_streamOwner)
                {
                    _modemStreamReader.Close();
                    _modemStreamReader.BaseStream.Close();

                    //should not be necessary as the stream has already been disposed by above calls
                    _modemStreamWriter.Close();
                    _modemStreamWriter.BaseStream.Close();
                }

                _run = false;
                _readModemQueue.Clear();
            }
        }


        #endregion
    }
}

