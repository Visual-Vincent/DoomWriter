using System;
using System.Runtime.CompilerServices;

namespace DoomWriter
{
    /// <summary>
    /// Represents a kerning pair.
    /// </summary>
    public readonly struct KerningPair
    {
        /// <summary>
        /// Gets the first character in the pair.
        /// </summary>
        public char Left { get; }

        /// <summary>
        /// Gets the second character in the pair.
        /// </summary>
        public char Right { get; }

        /// <summary>
        /// Gets the kerning value of the pair.
        /// </summary>
        public int Kerning { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KerningPair"/> struct.
        /// </summary>
        /// <param name="key">The kern table key to extract a character pair from.</param>
        /// <param name="kerning">The kerning value of the pair.</param>
        public KerningPair(int key, int kerning)
            : this((char)(key & 0xFFFF), (char)((key >> 16) & 0xFFFF), kerning)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KerningPair"/> struct.
        /// </summary>
        /// <param name="left">The first character in the pair.</param>
        /// <param name="right">The second character in the pair.</param>
        /// <param name="kerning">The kerning value of the pair.</param>
        public KerningPair(char left, char right, int kerning)
        {
            Left = left;
            Right = right;
            Kerning = kerning;
        }

        /// <summary>
        /// Constructs a unique key of the specified character pair that is used to look it up in a <see cref="KernTable"/>.
        /// </summary>
        /// <param name="left">The first character in the pair.</param>
        /// <param name="right">The second character in the pair.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetTableKey(char left, char right)
        {
            return left | (right << 16);
        }

        /// <summary>
        /// Returns the unique key of the kerning pair that is used to look it up in a <see cref="KernTable"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetTableKey()
        {
            return GetTableKey(Left, Right);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if(obj is null)
                return false;

            if(!(obj is KerningPair))
                return false;

            return Equals((KerningPair)obj);
        }

        /// <summary>
        /// Determines whether the specified kerning pair is equal to the current kerning pair.
        /// </summary>
        /// <param name="pair">The kerning pair to compare against.</param>
        public bool Equals(KerningPair pair)
        {
            return (
                pair.Left == Left &&
                pair.Right == Right &&
                pair.Kerning == Kerning
            );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return GetTableKey().GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{{{Left}, {Right}, {Kerning}}}";
        }
    }
}
