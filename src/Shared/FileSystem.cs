using System;
using System.IO;

namespace DoomWriter
{
    /// <summary>
    /// A static helper class for querying information about the current file system.
    /// </summary>
    public static class FileSystem
    {
        /// <summary>
        /// Whether or not the current file system is case-sensitive.
        /// </summary>
        public static readonly bool IsCaseSensitive = ((Func<bool>)(() => {
            var path = AppContext.BaseDirectory;
            return !Directory.Exists(path.ToLower()) || !Directory.Exists(path.ToUpper());
        })).Invoke();
    }
}
