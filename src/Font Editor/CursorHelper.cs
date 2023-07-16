using System;
using System.IO;
using System.Windows.Forms;

namespace FontEditor
{
    /// <summary>
    /// A helper class for managing cursors.
    /// </summary>
    public static class CursorHelper
    {
        /// <summary>
        /// Loads a cursor from a byte array.
        /// </summary>
        /// <param name="array">The cursor data to load.</param>
        public static Cursor FromByteArray(byte[] array)
        {
            using(var memoryStream = new MemoryStream(array))
            {
                return new Cursor(memoryStream);
            }
        }
    }
}
