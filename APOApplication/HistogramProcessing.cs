using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOApplication
{
    public unsafe class HistogramProcessing
    {
        private static readonly object imageLocker = new object();

        public HistogramProcessing() { }

        public unsafe int[] GetHistogram(Bitmap originalImage)
        {
            int[] histogram = new int[256];

            lock (imageLocker)
            {
                BitmapData bitmapData = originalImage.LockBits(
                    new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                int remain = bitmapData.Stride - bitmapData.Width;
                byte* pointer = (byte*)bitmapData.Scan0.ToPointer();

                for (int i = 0; i < bitmapData.Height; ++i)
                {
                    for (int j = 0; j < bitmapData.Width; ++j)
                    {
                        ++histogram[pointer[0]];
                        ++pointer;
                    }
                    pointer += remain;
                }

                originalImage.UnlockBits(bitmapData);
            }

            return histogram;
        }

        private int GetHistogramMinimum(int[] histogram)
        {
            for (int i = 0; i < histogram.Length; ++i)
            {
                if (histogram[i] != 0) return i;
            }
            return histogram.Length - 1;
        }

        private int GetHistogramMaximum(int[] histogram)
        {
            for (int i = histogram.Length - 1; i > 0; --i)
            {
                if (histogram[i] != 0) return i;
            }
            return 0;
        }

        public unsafe Bitmap StretchHistogram(Bitmap originalImage)
        {
            if (originalImage.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Histogram stretching is not supported for this pixel format");

            Bitmap finalImage = new Bitmap(
               originalImage.Width,
               originalImage.Height,
               PixelFormat.Format8bppIndexed);

            ColorPalette colorPalette = finalImage.Palette;
            for (int i = 0; i < 256; ++i)
                colorPalette.Entries[i] = Color.FromArgb(i, i, i);
            finalImage.Palette = colorPalette;

            lock (imageLocker)
            {
                int[] originalImageHistogram = GetHistogram(originalImage);
                double originalImageHistogramMinimum = (double)GetHistogramMinimum(originalImageHistogram);
                double originalImageHistogramMaximum = (double)GetHistogramMaximum(originalImageHistogram);

                BitmapData originalImageData = originalImage.LockBits(
                    new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                BitmapData finalImageData = finalImage.LockBits(
                    new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format8bppIndexed);

                //getting number of bits which are used for pad the bitmap 
                int originalImageRemain = originalImageData.Stride - originalImageData.Width;
                int finalImageRemain = finalImageData.Stride - finalImageData.Width;

                //getting the pointers
                byte* originalImagePointer = (byte*)originalImageData.Scan0.ToPointer();
                byte* finalImagePointer = (byte*)finalImageData.Scan0.ToPointer();

                for (int i = 0; i < originalImage.Height; ++i)
                {
                    for (int j = 0; j < originalImage.Width; ++j)
                    {
                        finalImagePointer[0] = (byte)(
                            ((originalImagePointer[0] - originalImageHistogramMinimum) /
                             (originalImageHistogramMaximum - originalImageHistogramMinimum)) * 255);

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

        //simple and comprehensible method
        public unsafe Bitmap EqualizeHistogram(Bitmap originalImage)
        {
            if (originalImage.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Histogram stretching is not supported for this pixel format");

            Bitmap finalImage = new Bitmap(
               originalImage.Width,
               originalImage.Height,
               PixelFormat.Format8bppIndexed);

            ColorPalette colorPalette = finalImage.Palette;
            for (int i = 0; i < 256; ++i)
                colorPalette.Entries[i] = Color.FromArgb(i, i, i);
            finalImage.Palette = colorPalette;

            lock (imageLocker)
            {
                int[] originalImageHistogram = GetHistogram(originalImage);
                double originalBitmapSize = originalImage.Width * originalImage.Height;

                double[] pixelIntensityCumulativeProbability = new double[256];
                pixelIntensityCumulativeProbability[0] = originalImageHistogram[0] / originalBitmapSize;

                for (int i = 1; i < originalImageHistogram.Length; ++i)
                {
                    pixelIntensityCumulativeProbability[i] = (originalImageHistogram[i] / originalBitmapSize)
                        + pixelIntensityCumulativeProbability[i - 1];
                }

                int[] lookUpTable = new int[256];

                for (int i = 0; i < lookUpTable.Length; i++)
                {
                    lookUpTable[i] = (int)Math.Round(pixelIntensityCumulativeProbability[i] * 255);
                }
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

        //really incomrehensible methods
        public unsafe Bitmap EqualizeHistogramHeurestic(Bitmap originalImage)
        {
            if (originalImage.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Histogram stretching is not supported for this pixel format");

            Bitmap finalImage = new Bitmap(
               originalImage.Width,
               originalImage.Height,
               PixelFormat.Format8bppIndexed);

            ColorPalette colorPalette = finalImage.Palette;
            for (int i = 0; i < 256; ++i)
                colorPalette.Entries[i] = Color.FromArgb(i, i, i);
            finalImage.Palette = colorPalette;

            lock (imageLocker)
            {
                byte[] left = new byte[256];
                byte[] right = new byte[256];
                byte[] newLevels = new byte[256];
                int[] histogram = GetHistogram(originalImage);
                double histogramAverage = histogram.Average();
                byte R = 0;
                double histogramIntegral = 0;

                for (int i = 0; i < 256; ++i)
                {
                    left[i] = R;
                    histogramIntegral += histogram[i];
                    while (histogramIntegral > histogramAverage)
                    {
                        histogramIntegral -= histogramAverage;
                        R++;
                    }
                    right[i] = R;
                    newLevels[i] = (byte)((left[i] + right[i]) / 2);
                }

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
                        if (left[originalImagePointer[0]] == right[originalImagePointer[0]])
                        {
                            finalImagePointer[0] = left[originalImagePointer[0]];
                        }
                        else
                        {
                            finalImagePointer[0] = newLevels[originalImagePointer[0]];
                        }
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

        public unsafe Bitmap EqualizeHistogramRandom(Bitmap originalImage)
        {
            if (originalImage.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Histogram stretching is not supported for this pixel format");

            Bitmap finalImage = new Bitmap(
               originalImage.Width,
               originalImage.Height,
               PixelFormat.Format8bppIndexed);

            ColorPalette colorPalette = finalImage.Palette;
            for (int i = 0; i < 256; ++i)
                colorPalette.Entries[i] = Color.FromArgb(i, i, i);
            finalImage.Palette = colorPalette;

            lock (imageLocker)
            {
                Random random = new Random();
                byte[] left = new byte[256];
                byte[] right = new byte[256];
                byte[] newLevels = new byte[256];
                int[] histogram = GetHistogram(originalImage);
                double histogramAverage = histogram.Average();
                byte R = 0;
                double histogramIntegral = 0;

                for (int i = 0; i < 256; ++i)
                {
                    left[i] = R;
                    histogramIntegral += histogram[i];
                    while (histogramIntegral > histogramAverage)
                    {
                        histogramIntegral -= histogramAverage;
                        R++;
                    }
                    right[i] = R;
                    newLevels[i] = (byte)(right[i] - left[i]);
                }

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
                        if (left[originalImagePointer[0]] == right[originalImagePointer[0]])
                        {
                            finalImagePointer[0] = left[originalImagePointer[0]];
                        }
                        else
                        {
                            finalImagePointer[0] = (byte)(
                                random.Next(0, newLevels[originalImagePointer[0]] + 1) +
                                left[originalImagePointer[0]]);
                        }
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

        public unsafe Bitmap EqualizeHistogramAverage(Bitmap originalImage)
        {
            if (originalImage.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Histogram stretching is not supported for this pixel format");

            Bitmap finalImage = new Bitmap(
               originalImage.Width,
               originalImage.Height,
               PixelFormat.Format8bppIndexed);

            ColorPalette colorPalette = finalImage.Palette;
            for (int i = 0; i < 256; ++i)
                colorPalette.Entries[i] = Color.FromArgb(i, i, i);
            finalImage.Palette = colorPalette;

            lock (imageLocker)
            {
                byte[] left = new byte[256];
                byte[] right = new byte[256];
                byte[] newLevels = new byte[256];
                int[] histogram = GetHistogram(originalImage);
                double histogramAverage = histogram.Average();
                byte R = 0;
                double histogramIntegral = 0;

                for (int i = 0; i < 256; ++i)
                {
                    left[i] = R;
                    histogramIntegral += histogram[i];
                    while (histogramIntegral > histogramAverage)
                    {
                        histogramIntegral -= histogramAverage;
                        R++;
                    }
                    right[i] = R;
                }

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
                int maskWidth = 3;
                int maskHeight = 3;
                int depth = 1;

                int helpingPointerOffset = originalImageData.Stride - 3;
                int helpingPointerStartOffset = originalImageData.Stride + 1;

                byte* helpingPointer;

                int xStartOffset, yStartOffset;
                int xFinishOffset, yFinishOffset;

                int workspaceWidth = originalImage.Width;
                int workspaceHeight = originalImage.Height;

                int helper;
                int sum;
                int avg;

                for (int i = 0; i < workspaceHeight; ++i)
                {
                    for (int j = 0; j < workspaceWidth; ++j)
                    {
                        sum = 0;

                        helper = j - 1;
                        xStartOffset = helper < 0 ? helper : 0;

                        helper = i - 1;
                        yStartOffset = helper < 0 ? helper : 0;

                        helper = j + 1;
                        xFinishOffset = helper >= workspaceWidth ? helper - workspaceWidth + 1 : 0;

                        helper = i + 1;
                        yFinishOffset = helper >= workspaceHeight ? helper - workspaceHeight + 1 : 0;

                        helpingPointer = originalImagePointer;
                        helpingPointer -= helpingPointerStartOffset;
                        helpingPointer += originalImageData.Stride * -yStartOffset + -xStartOffset;
                        int m = 0;

                        for (int k = -yStartOffset; k < maskHeight - yFinishOffset; ++k)
                        {
                            for (int l = -xStartOffset; l < maskWidth - xFinishOffset; ++l)
                            {
                                sum += helpingPointer[0];
                                helpingPointer += depth;

                                m++;
                            }
                            helpingPointer += helpingPointerOffset;
                            helpingPointer += -xStartOffset + xFinishOffset;
                        }

                        avg = sum / m;

                        if (avg > right[originalImagePointer[0]])
                            finalImagePointer[0] = right[originalImagePointer[0]];
                        else if (avg < left[originalImagePointer[0]])
                            finalImagePointer[0] = left[originalImagePointer[0]];
                        else
                            finalImagePointer[0] = (byte)avg;

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
