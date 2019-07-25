using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOApplication
{
    class LookUpTableProcessor
    {
        private static readonly object imageLock = new object();

        public LookUpTableProcessor() { }

        public unsafe Bitmap ApplyLookUpTable(Bitmap originalImage, int[] lookUpTable)
        {
            if (originalImage.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new ArgumentException("Only 8bppIndexed pixel format is supported by this method");

            Bitmap finalImage = new Bitmap(
               originalImage.Width,
               originalImage.Height,
               PixelFormat.Format8bppIndexed);

            ColorPalette colorPalette = finalImage.Palette;
            for (int i = 0; i < 256; ++i)
                colorPalette.Entries[i] = Color.FromArgb(i, i, i);
            finalImage.Palette = colorPalette;

            lock (imageLock)
            {
                BitmapData originalImageData = originalImage.LockBits(
                    new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                BitmapData finalImageData = finalImage.LockBits(
                    new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format8bppIndexed);

                int originalImageRemain = originalImageData.Stride - originalImageData.Width;
                int finalImageRemain = finalImageData.Stride - finalImageData.Width;

                byte* originalImagePointer = (byte*)originalImageData.Scan0.ToPointer();
                byte* finalImagePointer = (byte*)finalImageData.Scan0.ToPointer();

                for (int i = 0; i < originalImage.Height; ++i)
                {
                    for (int j = 0; j < originalImage.Width; ++j)
                    {
                        finalImagePointer[0] = (byte)lookUpTable[originalImagePointer[0]];
                        ++originalImagePointer;
                        ++finalImagePointer;
                    }
                    originalImagePointer += originalImageRemain;
                    finalImagePointer += finalImageRemain;
                }
                originalImage.UnlockBits(originalImageData);
                finalImage.UnlockBits(finalImageData);
            }

            return finalImage;
        }
    }
}
