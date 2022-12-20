using System;
using System.Runtime.CompilerServices;

namespace DoomWriter
{
    internal static class ThrowHelper
    {
        /// <summary>
        /// Checks for a condition; if the condition is false, the specified exception is thrown.
        /// </summary>
        /// <param name="condition">The conditional expression to evaluate.</param>
        /// <param name="exception">The exception that will be thrown if the conditional expression evaluates to false.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Assert(bool condition, Exception exception)
        {
            if(!condition)
                throw exception;
        }
    }
}
