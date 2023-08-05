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
        /// Gets the unique key of the kerning pair that is used to look it up in a <see cref="KernTable"/>.
        /// </summary>
        public int Key { get; }

        /// <summary>
        /// Gets the kerning value of the pair.
        /// </summary>
        public int Kerning { get; }

        /// <summary>
        /// Gets the first character in the pair.
        /// </summary>
        public char Left => (char)(Key & 0xFFFF);

        /// <summary>
        /// Gets the second character in the pair.
        /// </summary>
        public char Right => (char)((Key >> 16) & 0xFFFF);

        /// <summary>
        /// Initializes a new instance of the <see cref="KerningPair"/> struct.
        /// </summary>
        /// <param name="key">The kern table key of the character pair.</param>
        /// <param name="kerning">The kerning value of the pair.</param>
        public KerningPair(int key, int kerning)
        {
            Key = key;
            Kerning = kerning;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KerningPair"/> struct.
        /// </summary>
        /// <param name="left">The first character in the pair.</param>
        /// <param name="right">The second character in the pair.</param>
        /// <param name="kerning">The kerning value of the pair.</param>
        public KerningPair(char left, char right, int kerning)
            : this(GetTableKey(left, right), kerning)
        {
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
        /// Determines whether the specified kerning pair is equal to the current kerning pair. This does not take into account the kerning value, only the key.
        /// </summary>
        /// <param name="pair">The kerning pair to compare against.</param>
        public bool Equals(KerningPair pair)
        {
            return pair.Key == Key;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{{{Left}, {Right}, {Kerning}}}";
        }
    }
}
