using System;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.PixelFormats;

namespace DoomWriter
{
    /// <summary>
    /// Represents a luminance-to-color translation range.
    /// </summary>
    public sealed class TranslationRange
    {
        /// <summary>
        /// Gets the color at the start of the range.
        /// </summary>
        public Rgba32 ColorStart { get; }

        /// <summary>
        /// Gets the color at the end of the range.
        /// </summary>
        public Rgba32 ColorEnd { get; }

        /// <summary>
        /// Gets the luminance at the start of the range.
        /// </summary>
        public ushort LuminanceStart { get; }

        /// <summary>
        /// Gets the luminance at the end of the range.
        /// </summary>
        public ushort LuminanceEnd { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationRange"/> class.
        /// </summary>
        /// <param name="luminanceStart">The luminance at the start of the range.</param>
        /// <param name="luminanceEnd">The luminance at the end of the range.</param>
        /// <param name="colorStart">The color at the start of the range.</param>
        /// <param name="colorEnd">The color at the end of the range.</param>
        public TranslationRange(ushort luminanceStart, ushort luminanceEnd, Rgba32 colorStart, Rgba32 colorEnd)
        {
            if(luminanceStart > 256)
                throw new ArgumentOutOfRangeException(nameof(luminanceStart), "The start luminance of the color range must be between 0 and 256");
            
            if(luminanceEnd > 256)
                throw new ArgumentOutOfRangeException(nameof(luminanceStart), "The end luminance of the color range must be between 0 and 256");

            if(luminanceStart >= luminanceEnd)
                throw new ArgumentOutOfRangeException(nameof(luminanceStart), "The start luminance of the color range must be less than the end luminance");

            LuminanceStart = luminanceStart;
            LuminanceEnd = luminanceEnd;
            ColorStart = colorStart;
            ColorEnd = colorEnd;
        }

        public static bool operator !=(TranslationRange a, TranslationRange b) => !(a == b);
        public static bool operator ==(TranslationRange a, TranslationRange b)
        {
            if(a is null)
                return b is null;

            return a.Equals(b);
        }

        /// <summary>
        /// Returns a deep copy of the <see cref="TranslationRange"/>.
        /// </summary>
        public TranslationRange Clone()
        {
            return new TranslationRange(LuminanceStart, LuminanceEnd, ColorStart, ColorEnd);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if(obj is null)
                return false;

            if(!(obj is TranslationRange))
                return false;

            return Equals((TranslationRange)obj);
        }

        /// <summary>
        /// Determines whether the specified color range is equal to the current range.
        /// </summary>
        /// <param name="range">The color range to compare with the current range.</param>
        public bool Equals(TranslationRange range)
        {
            if(range is null)
                return false;

            return range.LuminanceStart == LuminanceStart
                && range.LuminanceEnd == LuminanceEnd
                && range.ColorStart == ColorStart
                && range.ColorEnd == ColorEnd;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(LuminanceStart, LuminanceEnd, ColorStart, ColorEnd);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{{{LuminanceStart}:{LuminanceEnd}, {ColorStart.ToHexString()}:{ColorEnd.ToHexString()}}}";
        }

        /// <summary>
        /// Returns whether the color range contains the specified luminance value.
        /// </summary>
        /// <param name="luminance">The luminance value to check.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(ushort luminance)
        {
            return luminance >= LuminanceStart && luminance <= LuminanceEnd;
        }

        /// <summary>
        /// Returns whether the specified luminance range overlaps the current range.
        /// </summary>
        /// <param name="range">The range to compare against.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Overlaps(TranslationRange range)
        {
            if(range == null)
                throw new ArgumentNullException(nameof(range));

            return LuminanceStart <= range.LuminanceEnd && LuminanceEnd >= range.LuminanceStart;
        }
    }
}
