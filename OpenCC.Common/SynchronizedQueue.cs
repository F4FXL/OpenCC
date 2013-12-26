using System;
using System.Collections.Generic;
using System.Threading;

namespace OpenCC.Common
{
    /// <summary>
    /// Synchronized queue class
    /// A simple queue that can be used to implement Producer Consumer pattern
    /// Calls to <see cref="Dequeue"/> block the calling thread until data is put into the queue
    /// </summary>
    public class SynchronizedQueue<TITEM>
    {
        #region Members
        private readonly Queue<TITEM> _queue;//the inner queue
        private readonly ManualResetEvent _enqueudEvent;//This event will be signaled when there is something in the queue
        #endregion

        #region ctors
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCC.DVRPTRLib.SynchronizedQueue`1"/> class.
        /// </summary>
        public SynchronizedQueue()
        {
            this._queue = new Queue<TITEM>();
            this._enqueudEvent = new ManualResetEvent(false);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Enqueue the specified item.
        /// </summary>
        /// <param name='item'>
        /// Item.
        /// </param>
        public void Enqueue(TITEM item)
        {
            lock (_queue)//Use simple ways provided by .Net to avoid multiple accesses to the queue
            {
                this._queue.Enqueue(item);
                this._enqueudEvent.Set();
            }
        }

        /// <summary>
        /// Dequeue an item from the queue. If nothing is inserted into the queue this function will block indefinetely.
        /// </summary>
        public TITEM Dequeue()
        {
            return Dequeue(Timeout.Infinite);
        }

        /// <summary>
        /// Dequeue an item and wait for the specified timeout. If no item is present within the specified timeout, default(TITEM) is returned
        /// </summary>
        /// <param name='timeout'>
        /// Timeout.
        /// </param>
        public TITEM Dequeue(TimeSpan timeout)
        {
            return Dequeue((int)timeout.TotalMilliseconds);
        }

        /// <summary>
        /// Dequeue an item and wait for the specified timeout. If no item is present within the specified timeout, default(TITEM) is returned
        /// </summary>
        /// <param name='timeOutInMilliseconds'>
        /// Time out in milliseconds.
        /// </param>
        public TITEM Dequeue(int timeOutInMilliseconds)
        {
            TITEM item = default(TITEM);

            bool didNotTimedOut = this._enqueudEvent.WaitOne(timeOutInMilliseconds);//wait for the event to signal there is  some stuff in the queue

            lock (_queue)
            {
                if (didNotTimedOut)//if we did not timeout there is most likely something in the queue
                {
                    if(_queue.Count > 0)
                        item = _queue.Dequeue();

                    if (_queue.Count == 0)
                        this._enqueudEvent.Reset();//signal that we are empty
                }
            }

            return item;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count
        {
            get
            {
                return _queue.Count;
            }
        }

        /// <summary>
        /// Clear this instance.
        /// </summary>
        public void Clear()
        {
            lock(_queue)
            {
                _queue.Clear();
                //fake signal that we have something thus threads blocked on Dequeue will be unblocked
                _enqueudEvent.Set();
            }
        }
        #endregion
    }
}

