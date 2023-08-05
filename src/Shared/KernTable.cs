using System;
using System.Collections;
using System.Collections.Generic;

namespace DoomWriter
{
    /// <summary>
    /// Represents a table of kerning pairs.
    /// </summary>
    public class KernTable : IEnumerable<KerningPair>
    {
        private readonly Dictionary<int, int> table = new Dictionary<int, int>();

        /// <summary>
        /// Gets or sets the kerning value for the specified kerning pair.
        /// </summary>
        /// <param name="key">The unique key of the kerning pair.</param>
        /// <returns>The kerning value for the character pair associated with the specified key. If the key does not exist, a get operation returns zero, and a set operation creates a new kerning pair.</returns>
        /// <remarks>A negative value means the characters should be moved closer together. A positive value means the characters should be moved further apart.</remarks>
        public int this[int key]
        {
            get {
                if(table.TryGetValue(key, out int kerning))
                    return kerning;

                return 0;
            }
            set {
                table[key] = value;
            }
        }

        /// <summary>
        /// Gets or sets the kerning value for the specified pair of characters.
        /// </summary>
        /// <param name="left">The first character in the pair.</param>
        /// <param name="right">The second character in the pair.</param>
        /// <returns>The kerning value for the specified pair of characters. If the specified kerning pair does not exist, a get operation returns zero, and a set operation creates a new kerning pair.</returns>
        /// <remarks>A negative value means the characters should be moved closer together. A positive value means the characters should be moved further apart.</remarks>
        public int this[char left, char right]
        {
            get {
                int key = KerningPair.GetTableKey(left, right);
                return this[key];
            }
            set {
                int key = KerningPair.GetTableKey(left, right);
                this[key] = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KernTable"/> class.
        /// </summary>
        public KernTable()
        {
        }

        /// <summary>
        /// Adds a kerning pair to the table.
        /// </summary>
        /// <param name="pair">The kerning pair to add.</param>
        public void Add(KerningPair pair)
        {
            int key = pair.Key;
            table.Add(key, pair.Kerning);
        }

        /// <summary>
        /// Adds a kerning pair to the table.
        /// </summary>
        /// <param name="left">The first character in the pair.</param>
        /// <param name="right">The second character in the pair.</param>
        /// <param name="kerning">The kerning value for the pair.</param>
        public void Add(char left, char right, int kerning)
        {
            int key = KerningPair.GetTableKey(left, right);
            table.Add(key, kerning);
        }

        /// <summary>
        /// Removes all kerning pairs from the table.
        /// </summary>
        public void Clear()
        {
            table.Clear();
        }

        /// <summary>
        /// Determines whether the table contains the specified character pair.
        /// </summary>
        /// <param name="left">The first character in the pair.</param>
        /// <param name="right">The second character in the pair.</param>
        public bool ContainsPair(char left, char right)
        {
            int key = KerningPair.GetTableKey(left, right);
            return table.ContainsKey(key);
        }

        /// <summary>
        /// Removes the specified kerning pair from the table.
        /// </summary>
        /// <param name="left">The first character in the pair.</param>
        /// <param name="right">The second character in the pair.</param>
        public bool Remove(char left, char right)
        {
            int key = KerningPair.GetTableKey(left, right);
            return table.Remove(key);
        }

        /// <summary>
        /// Gets the kerning value, if any, for the specified pair of characters.
        /// </summary>
        /// <param name="left">The first character in the pair.</param>
        /// <param name="right">The second character in the pair.</param>
        /// <param name="kerning">When this method returns, contains the kerning value for the specified character pair, if the pair is found; otherwise 0.</param>
        public bool TryGetKerning(char left, char right, out int kerning)
        {
            int key = KerningPair.GetTableKey(left, right);
            return table.TryGetValue(key, out kerning);
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc/>
        public IEnumerator<KerningPair> GetEnumerator()
        {
            foreach(var kvp in table)
            {
                yield return new KerningPair(kvp.Key, kvp.Value);
            }
        }
    }
}
