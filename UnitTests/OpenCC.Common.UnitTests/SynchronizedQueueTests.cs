using System;
using NUnit.Framework;
using System.Threading;

namespace OpenCC.Common.UnitTests
{
    [TestFixture()]
    public class SynchronizedQueueTests
    {
        [Test()]
        public void TestQueueDequeue()
        {
            // ReSharper disable once ConvertToConstant.Local
            int numberOfObjectsToEnqueue = 100;
            SynchronizedQueue<object> queue = new SynchronizedQueue<object>();

            //This will produce data into the queue
            ThreadStart producerProc = () =>
            {
                Thread.Sleep(300);
                for(int i = 0;i < numberOfObjectsToEnqueue;i++)
                {
                    queue.Enqueue(new Object());
                    Thread.Sleep(100);
                }
            };

            Thread producer = new Thread(producerProc);
            producer.Start();

            //this one (the main thread) will consume the data inside the main thread of the unittest
            object item;
            int itemcount = 0;
            do
            {
                item = queue.Dequeue(1000);
                itemcount++;
                Console.WriteLine("Dequeued {0} items", itemcount);
            }
            while(item != null);

            Assert.AreEqual(numberOfObjectsToEnqueue + 1, itemcount, "Dequeued count mismatch");
            Assert.IsNull(item,"Last dequeued item should be null");
            Assert.AreEqual(0, queue.Count, "Queue should be empty");
        }
    }
}

