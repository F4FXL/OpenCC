using System;
using OpenCC.DVRPTRLib.Infrastructure.Packets;
using OpenCC.DVRPTRLib.Infrastructure;


namespace OpenCC.DVRPTRLib.IO
{
    /// <summary>
    /// IDVRPTRio.
    /// </summary>
    public interface IDVRPTRio : IDisposable
    {
        #region methods
        /// <summary>
        /// Open this instance.
        /// </summary>
        void Open();

        /// <summary>
        /// Close this instance.
        /// </summary>
        void Close();

        /// <summary>
        /// Write the specified packet.
        /// </summary>
        /// <param name="packet">Packet.</param>
        void Write(Packet packet);
        #endregion

        #region events
        /// <summary>
        /// Occurs when a packet is received
        /// </summary>
        event EventHandler<PacketReceivedEventArgs> PacketReceived;
        #endregion

        #region properties
        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value><c>true</c> if this instance is disposed; otherwise, <c>false</c>.</value>
        bool IsDisposed{ get;}

        /// <summary>
        /// Gets a value indicating whether this instance is open.
        /// </summary>
        /// <value><c>true</c> if this instance is open; otherwise, <c>false</c>.</value>
        bool IsOpen { get;}
        #endregion
    }
}

