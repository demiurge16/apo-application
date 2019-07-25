using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOApplication
{
    public unsafe class MedianFilter
    {
        private static readonly object imageLock = new object();

        public MedianFilter() { }

        public Bitmap ApplyFilter(Bitmap originalImage, int maskWidth, int maskHeight, EdgeProcessingMethod edgeProcessingMethod = EdgeProcessingMethod.UseExistingPixels)
        {
            if (originalImage.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Only 8bppIndexed bitmap are supported");

            switch (edgeProcessingMethod)
            {
                case EdgeProcessingMethod.DuplicateEdges:
                    return ApplyMedianFilterDuplicatingEdges(originalImage, maskWidth, maskHeight, 1);
                case EdgeProcessingMethod.IgnoreEdges:
                    return ApplyMedianFilterIgnoringEdges(originalImage, maskWidth, maskHeight, 1); ;
                case EdgeProcessingMethod.UseExistingPixels:
                    return ApplyMedianFilterUsingExistingNeighbourhood(originalImage, maskWidth, maskHeight, 1); ;
                default:
                    throw new ArgumentException("Unknown edge processing method");
            }
        }

        private unsafe Bitmap ApplyMedianFilterDuplicatingEdges(Bitmap originalImage, int maskWidth, int maskHeight, int depth)
        {
            Bitmap finalImage = new Bitmap(
                originalImage.Width,
                originalImage.Height,
                originalImage.PixelFormat);
            Bitmap unwrappedImage = new Bitmap(
                originalImage.Width + (maskWidth - 1),
                originalImage.Height + (maskHeight - 1),
                originalImage.PixelFormat);

            if (depth == 1)
            {
                ColorPalette finalPalette = finalImage.Palette;
                for (int i = 0; i < 256; ++i)
                {
                    finalPalette.Entries[i] = Color.FromArgb(i, i, i);
                }
                finalImage.Palette = finalPalette;
                unwrappedImage.Palette = finalPalette;
            }

            lock (imageLock)
            {
                BitmapData originalBitmapData = originalImage.LockBits(
                    new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    ImageLockMode.ReadOnly,
                    originalImage.PixelFormat);
                BitmapData unwrappedBitmapData = unwrappedImage.LockBits(
                    new Rectangle(0, 0, unwrappedImage.Width, unwrappedImage.Height),
                    ImageLockMode.ReadOnly,
                    unwrappedImage.PixelFormat);

                byte* originalBitmapPointer = (byte*)originalBitmapData.Scan0.ToPointer();
                byte* unwrappedBitmapPointer = (byte*)unwrappedBitmapData.Scan0.ToPointer();

                byte originalBitmapRemain = (byte)(originalBitmapData.Stride - originalBitmapData.Width);
                byte unwrappedBitmapRemain = (byte)(unwrappedBitmapData.Stride - unwrappedBitmapData.Width);

                unwrappedBitmapPointer += unwrappedBitmapData.Stride * (maskHeight / 2) + depth * (maskWidth / 2);

                int unwrappedPointerOffset = unwrappedBitmapRemain + maskWidth * depth - depth;

                int workspaceWidth = originalBitmapData.Width;
                int workspaceHeight = originalBitmapData.Height;

                //initial copying
                for (int i = 0; i < workspaceHeight; ++i)
                {
                    for (int j = 0; j < workspaceWidth; ++j)
                    {
                        unwrappedBitmapPointer[0] = originalBitmapPointer[0];

                        originalBitmapPointer += depth;
                        unwrappedBitmapPointer += depth;
                    }
                    originalBitmapPointer += originalBitmapRemain;
                    unwrappedBitmapPointer += unwrappedPointerOffset;
                }

                unwrappedBitmapPointer = (byte*)unwrappedBitmapData.Scan0.ToPointer() + (maskWidth / 2) * depth;
                originalBitmapPointer = (byte*)originalBitmapData.Scan0.ToPointer();
                //copy rows
                for (int i = 0; i < maskHeight / 2; ++i)
                {
                    for (int j = 0; j < workspaceWidth; ++j)
                    {
                        unwrappedBitmapPointer[0] = originalBitmapPointer[0];
                        originalBitmapPointer += depth;
                        unwrappedBitmapPointer += depth;
                    }
                    originalBitmapPointer -= originalBitmapData.Width;
                    unwrappedBitmapPointer += unwrappedPointerOffset;
                }

                unwrappedBitmapPointer += unwrappedBitmapData.Stride * originalBitmapData.Height;
                originalBitmapPointer += originalBitmapData.Stride * originalBitmapData.Height;
                originalBitmapPointer -= originalBitmapData.Width;

                for (int i = 0; i < maskHeight / 2; ++i)
                {
                    for (int j = 0; j < workspaceWidth; ++j)
                    {
                        unwrappedBitmapPointer[0] = originalBitmapPointer[0];
                        originalBitmapPointer += depth;
                        unwrappedBitmapPointer += depth;
                    }
                    originalBitmapPointer -= originalBitmapData.Width;
                    unwrappedBitmapPointer += unwrappedPointerOffset;
                }

                workspaceHeight = unwrappedBitmapData.Height;
                unwrappedBitmapPointer = (byte*)unwrappedBitmapData.Scan0.ToPointer();
                originalBitmapPointer = unwrappedBitmapPointer;

                //Copy columns

                for (int i = 0; i < workspaceHeight; ++i)
                {
                    originalBitmapPointer += (maskHeight / 2) * depth;
                    for (int j = 0; j < maskWidth / 2; ++j)
                    {
                        unwrappedBitmapPointer[0] = originalBitmapPointer[0];
                        unwrappedBitmapPointer += depth;
                    }
                    originalBitmapPointer += originalBitmapData.Width * depth - depth;
                    unwrappedBitmapPointer += originalBitmapData.Width * depth;

                    for (int j = 0; j < maskWidth / 2; ++j)
                    {
                        unwrappedBitmapPointer[0] = originalBitmapPointer[0];
                        unwrappedBitmapPointer += depth;
                    }
                    originalBitmapPointer += maskWidth / 2 + unwrappedBitmapRemain + depth;
                    unwrappedBitmapPointer += unwrappedBitmapRemain;
                }

                originalImage.UnlockBits(originalBitmapData);

                BitmapData finalBitmapData = finalImage.LockBits(
                    new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                    ImageLockMode.ReadOnly,
                    finalImage.PixelFormat);

                byte* finalBitmapPointer = (byte*)finalBitmapData.Scan0.ToPointer();
                byte finalBitmapRemain = (byte)(finalBitmapData.Stride - finalBitmapData.Width);

                unwrappedBitmapPointer = (byte*)unwrappedBitmapData.Scan0.ToPointer();
                unwrappedBitmapPointer += unwrappedBitmapData.Stride * (maskHeight / 2) + depth * (maskWidth / 2);

                int helpingPointerOffset = unwrappedBitmapData.Stride - maskWidth * depth;
                int helpingPointerStartOffset = unwrappedBitmapData.Stride * (maskHeight / 2) + depth * (maskWidth / 2);

                workspaceWidth = unwrappedBitmapData.Width - maskWidth + depth;
                workspaceHeight = unwrappedBitmapData.Height - maskHeight + depth;
                //set up helping pointer
                byte* helpingPointer;

                int n;
                //setting up an array to hold values
                byte[] values = new byte[maskHeight * maskWidth];

                for (int i = 0; i < workspaceHeight; ++i)
                {
                    for (int j = 0; j < workspaceWidth; ++j)
                    {
                        helpingPointer = unwrappedBitmapPointer;
                        helpingPointer -= helpingPointerStartOffset;

                        n = 0;
                        for (int k = 0, m = 0; k < maskHeight; ++k)
                        {
                            for (int l = 0; l < maskWidth; ++l)
                            {
                                values[m] = helpingPointer[0];
                                helpingPointer += depth;

                                m++;
                                n++;
                            }
                            helpingPointer += helpingPointerOffset;
                        }
                        Array.Sort(values);
                        finalBitmapPointer[0] = values[n / 2];

                        unwrappedBitmapPointer += depth;
                        finalBitmapPointer += depth;
                    }
                    unwrappedBitmapPointer += unwrappedPointerOffset;
                    finalBitmapPointer += finalBitmapRemain;
                }

                unwrappedImage.UnlockBits(unwrappedBitmapData);
                finalImage.UnlockBits(finalBitmapData);
            }

            return finalImage;
        }

        private unsafe Bitmap ApplyMedianFilterUsingExistingNeighbourhood(Bitmap originalImage, int maskWidth, int maskHeight, int depth)
        {
            Bitmap finalImage = new Bitmap(
                originalImage.Width,
                originalImage.Height,
                originalImage.PixelFormat);

            ColorPalette finalPalette = finalImage.Palette;
            for (int i = 0; i < 256; ++i)
            {
                finalPalette.Entries[i] = Color.FromArgb(i, i, i);
            }
            finalImage.Palette = finalPalette;

            lock (imageLock)
            {
                BitmapData originalBitmapData = originalImage.LockBits(
                    new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    ImageLockMode.ReadOnly,
                    originalImage.PixelFormat);
                BitmapData finalBitmapData = finalImage.LockBits(
                    new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                    ImageLockMode.ReadOnly,
                    finalImage.PixelFormat);

                byte* originalBitmapPointer = (byte*)originalBitmapData.Scan0.ToPointer();
                byte* finalBitmapPointer = (byte*)finalBitmapData.Scan0.ToPointer();
                byte originalBitmapRemain = (byte)(originalBitmapData.Stride - originalBitmapData.Width);
                byte finalBitmapRemain = (byte)(finalBitmapData.Stride - finalBitmapData.Width);

                //pointers next row offsets
                int helpingPointerOffset = originalBitmapData.Stride - maskWidth * depth;

                int helpingPointerStartOffset = originalBitmapData.Stride * (maskHeight / 2) + depth * (maskWidth / 2);

                int workspaceWidth = originalImage.Width;
                int workspaceHeight = originalImage.Height;
                //set up helping pointer
                byte* helpingPointer;

                int xStartOffset, yStartOffset;
                int xFinishOffset, yFinishOffset;

                int helper;

                int n;
                //setting up an array to hold values
                byte[] values = new byte[maskHeight * maskWidth];

                for (int i = 0; i < workspaceHeight; ++i)
                {
                    for (int j = 0; j < workspaceWidth; ++j)
                    {
                        helper = j - maskWidth / 2;
                        xStartOffset = helper < 0 ? helper : 0;

                        helper = i - maskHeight / 2;
                        yStartOffset = helper < 0 ? helper : 0;

                        helper = j + maskWidth / 2;
                        xFinishOffset = helper >= workspaceWidth ? helper - workspaceWidth + 1 : 0;

                        helper = i + maskHeight / 2;
                        yFinishOffset = helper >= workspaceHeight ? helper - workspaceHeight + 1 : 0;

                        helpingPointer = originalBitmapPointer;
                        helpingPointer -= helpingPointerStartOffset;
                        helpingPointer += originalBitmapData.Stride * -yStartOffset + depth * -xStartOffset;

                        n = 0;
                        for (int k = -yStartOffset, m = 0; k < maskHeight - yFinishOffset; ++k)
                        {
                            for (int l = -xStartOffset; l < maskWidth - xFinishOffset; ++l)
                            {
                                values[m] = helpingPointer[0];
                                helpingPointer += depth;

                                m++;
                                n++;
                            }
                            helpingPointer += helpingPointerOffset;
                            helpingPointer += -xStartOffset + xFinishOffset;
                        }
                        Array.Sort(values, 0, n);
                        finalBitmapPointer[0] = values[n / 2];

                        originalBitmapPointer += depth;
                        finalBitmapPointer += depth;
                    }
                    originalBitmapPointer += originalBitmapRemain;
                    finalBitmapPointer += finalBitmapRemain;
                }

                originalImage.UnlockBits(originalBitmapData);
                finalImage.UnlockBits(finalBitmapData);
            }

            return finalImage;
        }

        private unsafe Bitmap ApplyMedianFilterIgnoringEdges(Bitmap originalImage, int maskWidth, int maskHeight, int depth)
        {
            Bitmap finalImage = new Bitmap(
                originalImage.Width,
                originalImage.Height,
                originalImage.PixelFormat);

            if (depth == 1)
            {
                ColorPalette finalPalette = finalImage.Palette;
                for (int i = 0; i < 256; ++i)
                {
                    finalPalette.Entries[i] = Color.FromArgb(i, i, i);
                }
                finalImage.Palette = finalPalette;
            }

            lock (imageLock)
            {
                BitmapData originalBitmapData = originalImage.LockBits(
                    new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    ImageLockMode.ReadOnly,
                    originalImage.PixelFormat);
                BitmapData finalBitmapData = finalImage.LockBits(
                    new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                    ImageLockMode.ReadOnly,
                    finalImage.PixelFormat);

                byte* originalBitmapPointer = (byte*)originalBitmapData.Scan0.ToPointer();
                byte* finalBitmapPointer = (byte*)finalBitmapData.Scan0.ToPointer();

                byte originalBitmapRemain = (byte)(originalBitmapData.Stride - originalBitmapData.Width);
                byte finalBitmapRemain = (byte)(finalBitmapData.Stride - finalBitmapData.Width);

                //set up pointers starting positions
                originalBitmapPointer += originalBitmapData.Stride * (maskHeight / 2) + depth * (maskWidth / 2);
                finalBitmapPointer += finalBitmapData.Stride * (maskHeight / 2) + depth * (maskWidth / 2);

                //pointers next row offsets
                int originalPointerOffset = originalBitmapRemain + maskWidth * depth - depth;
                int finalPointerOffset = finalBitmapRemain + maskWidth * depth - depth;
                int helpingPointerOffset = originalBitmapData.Stride - maskWidth * depth;

                int helpingPointerStartOffset = originalBitmapData.Stride * (maskHeight / 2) + depth * (maskWidth / 2);

                int workspaceWidth = originalImage.Width - maskWidth + depth;
                int workspaceHeigth = originalImage.Height - maskHeight + depth;
                //set up helping pointer
                byte* helpingPointer;

                int n;
                //setting up an array to hold values
                byte[] values = new byte[maskHeight * maskWidth];

                for (int i = 0; i < workspaceHeigth; ++i)
                {
                    for (int j = 0; j < workspaceWidth; ++j)
                    {
                        helpingPointer = originalBitmapPointer;
                        helpingPointer -= helpingPointerStartOffset;

                        n = 0;
                        for (int k = 0, m = 0; k < maskHeight; ++k)
                        {
                            for (int l = 0; l < maskWidth; ++l)
                            {
                                values[m] = helpingPointer[0];
                                helpingPointer += depth;

                                m++;
                                n++;
                            }
                            helpingPointer += helpingPointerOffset;
                        }
                        Array.Sort(values);
                        finalBitmapPointer[0] = values[n / 2];

                        originalBitmapPointer += depth;
                        finalBitmapPointer += depth;
                    }
                    originalBitmapPointer += originalPointerOffset;
                    finalBitmapPointer += finalPointerOffset;
                }

                originalImage.UnlockBits(originalBitmapData);
                finalImage.UnlockBits(finalBitmapData);
            }

            return finalImage;
        }
    }
}
