using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DoomWriter
{
    /// <summary>
    /// Represents a luminance-based color translation.
    /// </summary>
    public sealed class ColorTranslation
    {
        /// <summary>
        /// Returns a new, empty (untranslated) color translation.
        /// </summary>
        public static ColorTranslation Untranslated => new ColorTranslation();

        private readonly List<TranslationRange> ranges;
        private readonly ReadOnlyCollection<TranslationRange> readOnlyRanges;

        /// <summary>
        /// Gets whether or not this is an empty (untranslated) color translation.
        /// </summary>
        public bool IsUntranslated => ranges.Count == 0;

        /// <summary>
        /// Gets the collection of color ranges in this translation.
        /// </summary>
        public ReadOnlyCollection<TranslationRange> Ranges => readOnlyRanges;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorTranslation"/> class.
        /// </summary>
        public ColorTranslation()
        {
            ranges = new List<TranslationRange>();
            readOnlyRanges = new ReadOnlyCollection<TranslationRange>(ranges);
        }

        /// <summary>
        /// Adds a color range to the translation.
        /// </summary>
        /// <param name="range">The color range to add.</param>
        public void Add(TranslationRange range)
        {
            if(range == null)
                throw new ArgumentNullException(nameof(range));

            foreach(TranslationRange existingRange in ranges)
            {
                if(range.Overlaps(existingRange))
                    throw new ArgumentException($"The color range {range} overlaps the existing range {existingRange}", nameof(range));
            }

            ranges.Add(range);
        }

        /// <summary>
        /// Finds the color range that contains the specified luminance value.
        /// </summary>
        /// <param name="luminance">The luminance value whose color range to locate.</param>
        public TranslationRange FindRange(int luminance)
        {
            if(luminance < 0 || luminance > 256)
                throw new ArgumentException("Luminance must be between 0 and 256", nameof(luminance));

            foreach(TranslationRange range in ranges)
            {
                if(range.Contains((ushort)luminance))
                    return range;
            }

            return null;
        }

        /// <summary>
        /// Removes the specified color range from the translation, if it exists.
        /// </summary>
        /// <param name="range"></param>
        public bool Remove(TranslationRange range)
        {
            return ranges.Remove(range);
        }

        /// <summary>
        /// Removes the color range at the specified index of the translation.
        /// </summary>
        /// <param name="index">The zero-based index of the translation to remove.</param>
        public void RemoveAt(int index)
        {
            ranges.RemoveAt(index);
        }
    }
}
