using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DoomWriter
{
    public static class BinaryExtensions
    {
        /// <summary>
        /// Reads the exact amount of bytes from the <see cref="BinaryReader"/>, or throws an exception if end of stream is reached before all bytes have been read.
        /// </summary>
        /// <param name="reader">The binary reader.</param>
        /// <param name="count">The amount of bytes to read.</param>
        /// <param name="exception">Optional. A custom exception to throw if end of stream is reached before all bytes have been read.</param>
        public static byte[] ReadExact(this BinaryReader reader, int count, Exception exception = null)
        {
            byte[] data = reader.ReadBytes(count);

            if(data.Length < count)
                throw exception ?? new IOException("End of stream was reached before all data could be read");

            return data;
        }

        /// <summary>
        /// Reads an array of bytes from the <see cref="BinaryReader"/>, based on the size that the data is prefixed with.
        /// </summary>
        /// <param name="reader">The binary reader.</param>
        /// <param name="exception">Optional. A custom exception to throw if end of stream is reached before all bytes have been read.</param>
        public static byte[] ReadLengthPrefixed(this BinaryReader reader, Exception exception = null)
        {
            int size = reader.ReadInt32();
            return reader.ReadExact(size, exception);
        }

        /// <summary>
        /// Writes the specified data onto the <see cref="BinaryWriter"/>, prefixing it with the size, in bytes, of the data.
        /// </summary>
        /// <param name="writer">The binary writer.</param>
        /// <param name="data">The data to write.</param>
        public static void WriteLengthPrefixed(this BinaryWriter writer, byte[] data)
        {
            writer.Write(data.Length);
            writer.Write(data);
        }
    }
}
