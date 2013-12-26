using System;
using System.IO;

namespace OpenCC.Common.IO
{
    /// <summary>
    /// Stream reader extensions.
    /// </summary>
    public static class StreamReaderExtensions
    {
        /// <summary>
        /// Tries the read int16.
        /// </summary>
        /// <returns><c>true</c>, if read int16 was tryed, <c>false</c> otherwise.</returns>
        /// <param name="streamReader">Stream reader.</param>
        /// <param name="value">Value.</param>
        public static bool TryReadInt16(this BinaryReader streamReader, out Int16 value)
        {
            Int16 localValue = 0;
            Action action = delegate
            {
                localValue = streamReader.ReadInt16();
            };
            bool success = DoAction(action);
            value = localValue;
            return success;
        }

        /// <summary>
        /// Tries the read.
        /// </summary>
        /// <returns><c>true</c>, if read was tryed, <c>false</c> otherwise.</returns>
        /// <param name="reader">Reader.</param>
        /// <param name="buffer">Buffer.</param>
        /// <param name="index">Index.</param>
        /// <param name="count">Count.</param>
        public static bool TryRead(this BinaryReader reader, byte[] buffer, int index, int count)
        {
            int readCount;
            return reader.TryRead(buffer, index, count, out readCount);
        }

        /// <summary>
        /// Tries the read.
        /// </summary>
        /// <returns><c>true</c>, if read was tryed, <c>false</c> otherwise.</returns>
        /// <param name="reader">Reader.</param>
        /// <param name="buffer">Buffer.</param>
        /// <param name="index">Index.</param>
        /// <param name="count">Count.</param>
        /// <param name = "readCount"></param>
        public static bool TryRead(this BinaryReader reader, byte[] buffer, int index, int count, out int readCount)
        {
            int localReadCount = 0;
            readCount = 0;
            Action action = delegate()
            {
                localReadCount = reader.Read(buffer, index, count);
            };
            bool success = DoAction(action);

            if(success)
                readCount = localReadCount;

            return success;
        }

        private static bool DoAction(Action action)
        {
            bool success = false;

            try
            {
                action();
                success = true;
            }
            catch(IOException){}
            catch(ObjectDisposedException){}

            return success;
        }
    }
}

