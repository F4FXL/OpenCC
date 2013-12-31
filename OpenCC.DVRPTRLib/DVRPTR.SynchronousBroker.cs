using System;
using System.Threading;
using OpenCC.Common.Diagnostics;
using OpenCC.DVRPTRLib.IO.PCP2;

namespace OpenCC.DVRPTRLib
{
    public partial class DVRPTR
    {
        ///<summary>Handles synchronous calls</summary>
        private sealed class SynchronousBroker<TAwaitedPacket> : IDisposable
            where TAwaitedPacket : PCP2Packet
        {
            #region members
            private DVRPTRio _dvrptrio;
            private readonly ManualResetEvent _resetEvent;
            private TAwaitedPacket _packet;
            #endregion

            #region ctor
            /// <summary>
            /// Initializes a new instance of the OpenCC.DVRPTRLib.DVRPTR+SynchronousBrokerclass.
            /// </summary>
            /// <param name="dvrptrio">Dvrptrio.</param>
            public SynchronousBroker(DVRPTRio dvrptrio)
            {
                Guard.IsNotNull(dvrptrio, "dvrptrio");

                _dvrptrio = dvrptrio;
                _dvrptrio.PacketReceived += HandlePacketReceived;
                _resetEvent = new ManualResetEvent(false);
            }

            void HandlePacketReceived (object sender, PacketReceivedEventArgs e)
            {
                if (e.Packet is TAwaitedPacket)//is this what we are waiting for ?
                {
                    _dvrptrio.PacketReceived -= HandlePacketReceived;//unsubscribe
                    _packet = (TAwaitedPacket)e.Packet;
                    _resetEvent.Set();
                }
            }
            #endregion

            #region properties

            /// <summary>
            /// Gets the packet.
            /// </summary>
            /// <value>The packet.</value>
            public TAwaitedPacket Packet
            {
                get
                {
                    return _packet;
                }
            }

            /// <summary>
            /// Gets the wait handle.
            /// </summary>
            /// <value>The wait handle.</value>
            public WaitHandle WaitHandle
            {
                get
                {
                    return _resetEvent;
                }
            }
            #endregion

            #region IDisposable implementation

            /// 
            public void Dispose()
            {
                _dvrptrio.PacketReceived -= HandlePacketReceived;
                _dvrptrio = null;
                _resetEvent.Dispose();
            }

            #endregion
        }
    }
}

