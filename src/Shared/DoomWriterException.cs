using System;
using System.Runtime.Serialization;

namespace DoomWriter
{
    /// <summary>
    /// A Doom Writer-specific exception.
    /// </summary>
    public class DoomWriterException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoomWriterException"/> class.
        /// </summary>
        public DoomWriterException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DoomWriterException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DoomWriterException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the System.Exception class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public DoomWriterException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DoomWriterException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
