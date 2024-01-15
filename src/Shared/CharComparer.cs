using System;
using System.Collections.Generic;

namespace DoomWriter
{
    /// <summary>
    /// An <see cref="IComparer{T}"/> comparing chars, favouring letters and digits before other characters.
    /// </summary>
    public sealed class CharComparer : IComparer<char>
    {
        /// <summary>
        /// A singleton instance of <see cref="CharComparer"/>.
        /// </summary>
        public static readonly CharComparer Default = new CharComparer();

        /// <summary>
        /// Initializes a new instance of the <see cref="CharComparer"/> class.
        /// </summary>
        public CharComparer()
        {
        }

        /// <inheritdoc/>
        public int Compare(char x, char y)
        {
            bool xIsLetter = char.IsLetter(x);
            bool yIsLetter = char.IsLetter(y);

            bool xIsDigit = !xIsLetter && char.IsDigit(x);
            bool yIsDigit = !yIsLetter && char.IsDigit(y);

            bool xIsLetterOrDigit = xIsLetter || xIsDigit;
            bool yIsLetterOrDigit = yIsLetter || yIsDigit;

            if(xIsLetterOrDigit && !yIsLetterOrDigit)
                return -1;

            if(!xIsLetterOrDigit && yIsLetterOrDigit)
                return 1;

            if(xIsLetter && yIsDigit)
                return -1;

            if(xIsDigit && yIsLetter)
                return 1;

            return x.CompareTo(y);
        }
    }
}
