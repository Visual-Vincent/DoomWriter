using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;

using SixLaborsImage = SixLabors.ImageSharp.Image;

namespace DoomWriter
{
    /// <summary>
    /// Represents an in-memory image.
    /// </summary>
    public class Image : IImage, IDisposable
    {
        internal SixLaborsImage BaseImage { get; }

        public int Width => BaseImage.Width;
        public int Height => BaseImage.Height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="image">The underlying image that this image wraps.</param>
        public Image(SixLaborsImage image)
        {
            BaseImage = image ?? throw new ArgumentNullException(nameof(image));
        }

        /// <summary>
        /// Saves the image to the specified stream.
        /// </summary>
        /// <param name="stream">The stream to save the image to.</param>
        /// <param name="format">The type of format to save the image as.</param>
        public void Save(Stream stream, ImageFormat format = ImageFormat.Default)
        {
            if(stream == null)
                throw new ArgumentNullException(nameof(stream));

            switch(format)
            {
                case ImageFormat.BMP:
                    BaseImage.SaveAsBmp(stream);
                    break;

                case ImageFormat.Default:
                case ImageFormat.PNG:
                    BaseImage.SaveAsPng(stream);
                    break;

                case ImageFormat.JPEG:
                    BaseImage.SaveAsJpeg(stream, new JpegEncoder() { Quality = 100 });
                    break;

                case ImageFormat.GIF:
                    BaseImage.SaveAsGif(stream);
                    break;

                case ImageFormat.TIFF:
                    BaseImage.SaveAsTiff(stream);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(format), "Invalid image format");
            }
        }

        /// <summary>
        /// Saves the image to a file.
        /// </summary>
        /// <param name="file">The path to the image file to create.</param>
        /// <param name="format">The type of format to save the image as. If <see cref="ImageFormat.Default"/> is specified, the format will be chosen depending on the file extension.</param>
        public void Save(string file, ImageFormat format = ImageFormat.Default)
        {
            if(file == null)
                throw new ArgumentNullException(nameof(file));

            if(format == ImageFormat.Default)
            {
                string extension = Path.GetExtension(file).ToLower();

                switch(extension)
                {
                    case ".bmp":
                        format = ImageFormat.BMP;
                        break;

                    case ".png":
                        format = ImageFormat.PNG;
                        break;

                    case ".jpg":
                    case ".jpeg":
                        format = ImageFormat.JPEG;
                        break;

                    case ".gif":
                        format = ImageFormat.GIF;
                        break;

                    case ".tiff":
                        format = ImageFormat.TIFF;
                        break;
                }
            }

            using(var fileStream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                Save(fileStream, format);
            }
        }

        #region IDisposable Support
        private bool disposedValue;

        private void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if(disposing)
                {
                    // Dispose managed resources
                    BaseImage?.Dispose();
                }

                // Free unmanaged resources

                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Image()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    /// <summary>
    /// Specifies a type of image format.
    /// </summary>
    public enum ImageFormat : int
    {
        /// <summary>
        /// The default image format.
        /// </summary>
        Default = 0,

        /// <summary>
        /// BMP image format.
        /// </summary>
        BMP,

        /// <summary>
        /// PNG image format.
        /// </summary>
        PNG,

        /// <summary>
        /// JPEG image format.
        /// </summary>
        JPEG,

        /// <summary>
        /// GIF image format.
        /// </summary>
        GIF,

        /// <summary>
        /// TIFF image format.
        /// </summary>
        TIFF
    }
}
