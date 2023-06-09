using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

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

        private int frozenHashCode;

        /// <summary>
        /// Gets whether or not the object is frozen, preventing further modifications from being made.
        /// </summary>
        public bool IsFrozen { get; private set; }

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ThrowIfFrozen()
        {
            if(IsFrozen)
                throw new InvalidOperationException("Object is frozen: No modifications can be made");
        }

        /// <summary>
        /// Adds a color range to the translation.
        /// </summary>
        /// <param name="range">The color range to add.</param>
        public void Add(TranslationRange range)
        {
            ThrowIfFrozen();

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
        /// Returns a deep copy of the <see cref="ColorTranslation"/>. The new <see cref="ColorTranslation"/> will not be frozen.
        /// </summary>
        public ColorTranslation Clone()
        {
            var clone = new ColorTranslation();

            foreach(TranslationRange range in ranges)
            {
                clone.ranges.Add(range.Clone());
            }

            return clone;
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
        /// Freezes the <see cref="ColorTranslation"/>, preventing further modifications.
        /// </summary>
        public void Freeze()
        {
            if(IsFrozen)
                throw new InvalidOperationException("Object is already frozen");

            frozenHashCode = GetHashCode();
            IsFrozen = true;
        }

        /// <summary>
        /// Removes the specified color range from the translation, if it exists.
        /// </summary>
        /// <param name="range"></param>
        public bool Remove(TranslationRange range)
        {
            ThrowIfFrozen();

            return ranges.Remove(range);
        }

        /// <summary>
        /// Removes the color range at the specified index of the translation.
        /// </summary>
        /// <param name="index">The zero-based index of the translation to remove.</param>
        public void RemoveAt(int index)
        {
            ThrowIfFrozen();

            ranges.RemoveAt(index);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if(obj is null)
                return false;

            if(!(obj is ColorTranslation))
                return false;

            return Equals((ColorTranslation)obj);
        }

        /// <summary>
        /// Determines whether the specified color translation is equal to the current translation.
        /// </summary>
        /// <param name="translation">The color translation to compare with the current translation.</param>
        public bool Equals(ColorTranslation translation)
        {
            if(translation is null)
                return false;

            if(translation.IsUntranslated == IsUntranslated)
                return true;

            if(translation.ranges.Count != ranges.Count)
                return false;

            for(int i = 0; i < translation.ranges.Count; i++)
            {
                if(translation.ranges[i] != ranges[i])
                    return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            if(IsFrozen)
                return frozenHashCode;

            unchecked
            {
                int hash = 19;

                foreach(TranslationRange range in ranges)
                {
                    hash = hash * 31 + range.GetHashCode();
                }

                return hash;
            }
        }
    }
}