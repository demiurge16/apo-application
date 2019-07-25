using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOApplication
{
    unsafe class CompassFilter
    {
        private static readonly object imageLock = new object();

        public CompassFilter() { }

        public Bitmap KirschFilter(Bitmap originalImage, ScalingMethod scalingMethod = ScalingMethod.Cutting, EdgeProcessingMethod edgeProcessingMethod = EdgeProcessingMethod.UseExistingPixels)
        {
            if (originalImage.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Only 8bppIndexed bitmap are supported");

            int[,] nResult;
            int[,] neResult;
            int[,] eResult;
            int[,] seResult;
            int[,] sResult;
            int[,] swResult;
            int[,] wResult;
            int[,] nwResult;

            switch (edgeProcessingMethod)
            {
                case EdgeProcessingMethod.DuplicateEdges:
                    nResult = ApplyMaskDuplicatingEdges(originalImage, Mask.KirschN);
                    neResult = ApplyMaskDuplicatingEdges(originalImage, Mask.KirschNE);
                    eResult = ApplyMaskDuplicatingEdges(originalImage, Mask.KirschE);
                    seResult = ApplyMaskDuplicatingEdges(originalImage, Mask.KirschSE);
                    sResult = ApplyMaskDuplicatingEdges(originalImage, Mask.KirschS);
                    swResult = ApplyMaskDuplicatingEdges(originalImage, Mask.KirschSW);
                    wResult = ApplyMaskDuplicatingEdges(originalImage, Mask.KirschW);
                    nwResult = ApplyMaskDuplicatingEdges(originalImage, Mask.KirschNW);
                    break;
                case EdgeProcessingMethod.IgnoreEdges:
                    nResult = ApplyMaskIgnoringEdges(originalImage, Mask.KirschN);
                    neResult = ApplyMaskIgnoringEdges(originalImage, Mask.KirschNE);
                    eResult = ApplyMaskIgnoringEdges(originalImage, Mask.KirschE);
                    seResult = ApplyMaskIgnoringEdges(originalImage, Mask.KirschSE);
                    sResult = ApplyMaskIgnoringEdges(originalImage, Mask.KirschS);
                    swResult = ApplyMaskIgnoringEdges(originalImage, Mask.KirschSW);
                    wResult = ApplyMaskIgnoringEdges(originalImage, Mask.KirschW);
                    nwResult = ApplyMaskIgnoringEdges(originalImage, Mask.KirschNW);
                    break;
                case EdgeProcessingMethod.UseExistingPixels:
                    nResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.KirschN);
                    neResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.KirschNE);
                    eResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.KirschE);
                    seResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.KirschSE);
                    sResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.KirschS);
                    swResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.KirschSW);
                    wResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.KirschW);
                    nwResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.KirschNW);
                    break;
                default:
                    throw new ArgumentException("Unknown edge processing method");
            }
            int width = nResult.GetLength(1);
            int height = nResult.GetLength(0);
            int[,] result = new int[height, width];
            int[] buf = new int[8];

            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    buf[0] = nResult[i, j];
                    buf[1] = neResult[i, j];
                    buf[2] = eResult[i, j];
                    buf[3] = seResult[i, j];
                    buf[4] = eResult[i, j];
                    buf[5] = swResult[i, j];
                    buf[6] = wResult[i, j];
                    buf[7] = nwResult[i, j];

                    result[i, j] = buf.Max();
                }
            }

            byte[,] rescaled;
            switch (scalingMethod)
            {
                case ScalingMethod.RangeRescale:
                    rescaled = RescaleStretch(result);
                    break;
                case ScalingMethod.Cutting:
                    rescaled = RescaleCut(result);
                    break;
                case ScalingMethod.Trivalent:
                    rescaled = RescaleTrivalent(result);
                    break;
                default:
                    throw new ArgumentException("Unknown rescaling method");
            }

            Bitmap finalImage = new Bitmap(width, height, originalImage.PixelFormat);

            ColorPalette finalPalette = finalImage.Palette;
            for (int i = 0; i < 256; ++i)
            {
                finalPalette.Entries[i] = Color.FromArgb(i, i, i);
            }
            finalImage.Palette = finalPalette;

            BitmapData finalBitmapData = finalImage.LockBits(
                new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                ImageLockMode.ReadOnly,
                finalImage.PixelFormat);

            byte* finalBitmapPointer = (byte*)finalBitmapData.Scan0.ToPointer();
            byte finalBitmapRemain = (byte)(finalBitmapData.Stride - finalBitmapData.Width);

            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    finalBitmapPointer[0] = rescaled[i, j];
                    ++finalBitmapPointer;
                }
                finalBitmapPointer += finalBitmapRemain;
            }
            finalImage.UnlockBits(finalBitmapData);

            return finalImage;
        }

        public Bitmap PrewittFilter(Bitmap originalImage, ScalingMethod scalingMethod = ScalingMethod.Cutting, EdgeProcessingMethod edgeProcessingMethod = EdgeProcessingMethod.UseExistingPixels)
        {
            if (originalImage.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Only 8bppIndexed bitmap are supported");

            int[,] nResult;
            int[,] neResult;
            int[,] eResult;
            int[,] seResult;
            int[,] sResult;
            int[,] swResult;
            int[,] wResult;
            int[,] nwResult;

            switch (edgeProcessingMethod)
            {
                case EdgeProcessingMethod.DuplicateEdges:
                    nResult = ApplyMaskDuplicatingEdges(originalImage, Mask.PrewittN);
                    neResult = ApplyMaskDuplicatingEdges(originalImage, Mask.PrewittNE);
                    eResult = ApplyMaskDuplicatingEdges(originalImage, Mask.PrewittE);
                    seResult = ApplyMaskDuplicatingEdges(originalImage, Mask.PrewittSE);
                    sResult = ApplyMaskDuplicatingEdges(originalImage, Mask.PrewittS);
                    swResult = ApplyMaskDuplicatingEdges(originalImage, Mask.PrewittSW);
                    wResult = ApplyMaskDuplicatingEdges(originalImage, Mask.PrewittW);
                    nwResult = ApplyMaskDuplicatingEdges(originalImage, Mask.PrewittNW);
                    break;
                case EdgeProcessingMethod.IgnoreEdges:
                    nResult = ApplyMaskIgnoringEdges(originalImage, Mask.PrewittN);
                    neResult = ApplyMaskIgnoringEdges(originalImage, Mask.PrewittNE);
                    eResult = ApplyMaskIgnoringEdges(originalImage, Mask.PrewittE);
                    seResult = ApplyMaskIgnoringEdges(originalImage, Mask.PrewittSE);
                    sResult = ApplyMaskIgnoringEdges(originalImage, Mask.PrewittS);
                    swResult = ApplyMaskIgnoringEdges(originalImage, Mask.PrewittSW);
                    wResult = ApplyMaskIgnoringEdges(originalImage, Mask.PrewittW);
                    nwResult = ApplyMaskIgnoringEdges(originalImage, Mask.PrewittNW);
                    break;
                case EdgeProcessingMethod.UseExistingPixels:
                    nResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.PrewittN);
                    neResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.PrewittNE);
                    eResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.PrewittE);
                    seResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.PrewittSE);
                    sResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.PrewittS);
                    swResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.PrewittSW);
                    wResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.PrewittW);
                    nwResult = ApplyMaskUsingExistingNeighbourhood(originalImage, Mask.PrewittNW);
                    break;
                default:
                    throw new ArgumentException("Unknown edge processing method");
            }
            int width = nResult.GetLength(1);
            int height = nResult.GetLength(0);
            int[,] result = new int[height, width];
            int[] buf = new int[8];

            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    buf[0] = nResult[i, j];
                    buf[1] = neResult[i, j];
                    buf[2] = eResult[i, j];
                    buf[3] = seResult[i, j];
                    buf[4] = eResult[i, j];
                    buf[5] = swResult[i, j];
                    buf[6] = wResult[i, j];
                    buf[7] = nwResult[i, j];

                    result[i, j] = buf.Max();
                }
            }

            byte[,] rescaled;
            switch (scalingMethod)
            {
                case ScalingMethod.RangeRescale:
                    rescaled = RescaleStretch(result);
                    break;
                case ScalingMethod.Cutting:
                    rescaled = RescaleCut(result);
                    break;
                case ScalingMethod.Trivalent:
                    rescaled = RescaleTrivalent(result);
                    break;
                default:
                    throw new ArgumentException("Unknown rescaling method");
            }

            Bitmap finalImage = new Bitmap(width, height, originalImage.PixelFormat);

            ColorPalette finalPalette = finalImage.Palette;
            for (int i = 0; i < 256; ++i)
            {
                finalPalette.Entries[i] = Color.FromArgb(i, i, i);
            }
            finalImage.Palette = finalPalette;

            BitmapData finalBitmapData = finalImage.LockBits(
                new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                ImageLockMode.ReadOnly,
                finalImage.PixelFormat);

            byte* finalBitmapPointer = (byte*)finalBitmapData.Scan0.ToPointer();
            byte finalBitmapRemain = (byte)(finalBitmapData.Stride - finalBitmapData.Width);

            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    finalBitmapPointer[0] = rescaled[i, j];
                    ++finalBitmapPointer;
                }
                finalBitmapPointer += finalBitmapRemain;
            }
            finalImage.UnlockBits(finalBitmapData);

            return finalImage;
        }

        private unsafe int[,] ApplyMaskIgnoringEdges(Bitmap originalImage, int[,] mask)
        {
            int depth = 1;
            int maskHeight = mask.GetLength(0);
            int maskWidth = mask.GetLength(1);
            int[,] result;

            lock (imageLock)
            {
                BitmapData originalBitmapData = originalImage.LockBits(
                    new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    ImageLockMode.ReadOnly,
                    originalImage.PixelFormat);

                byte* originalBitmapPointer = (byte*)originalBitmapData.Scan0.ToPointer();

                byte originalBitmapRemain = (byte)(originalBitmapData.Stride - originalBitmapData.Width);

                //set up pointers starting positions
                originalBitmapPointer += originalBitmapData.Stride * (maskHeight / 2) + depth * (maskWidth / 2);

                //pointers next row offsets
                int originalPointerOffset = originalBitmapRemain + maskWidth * depth - depth;
                int helpingPointerOffset = originalBitmapData.Stride - maskWidth * depth;

                int helpingPointerStartOffset = originalBitmapData.Stride * (maskHeight / 2) + depth * (maskWidth / 2);

                int workspaceWidth = originalImage.Width - maskWidth + depth;
                int workspaceHeigth = originalImage.Height - maskHeight + depth;
                //set up helping pointer
                byte* helpingPointer;

                result = new int[workspaceHeigth, workspaceWidth];

                int usedSum;
                int pixelSum;
                for (int i = 0; i < workspaceHeigth; ++i)
                {
                    for (int j = 0; j < workspaceWidth; ++j)
                    {
                        helpingPointer = originalBitmapPointer;
                        helpingPointer -= helpingPointerStartOffset;

                        usedSum = 0;
                        pixelSum = 0;
                        for (int k = 0; k < maskHeight; ++k)
                        {
                            for (int l = 0; l < maskWidth; ++l)
                            {
                                pixelSum += mask[k, l] * helpingPointer[0];
                                usedSum += mask[k, l];

                                helpingPointer += depth;
                            }
                            helpingPointer += helpingPointerOffset;
                        }
                        result[i, j] = pixelSum / (usedSum == 0 ? 1 : usedSum);

                        originalBitmapPointer += depth;
                    }
                    originalBitmapPointer += originalPointerOffset;
                }
                originalImage.UnlockBits(originalBitmapData);
            }
            return result;
        }

        private unsafe int[,] ApplyMaskUsingExistingNeighbourhood(Bitmap originalImage, int[,] mask)
        {
            int depth = 1;
            int maskHeight = mask.GetLength(0);
            int maskWidth = mask.GetLength(1);
            int[,] result;

            lock (imageLock)
            {
                BitmapData originalBitmapData = originalImage.LockBits(
                    new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    ImageLockMode.ReadOnly,
                    originalImage.PixelFormat);

                byte* originalBitmapPointer = (byte*)originalBitmapData.Scan0.ToPointer();
                byte originalBitmapRemain = (byte)(originalBitmapData.Stride - originalBitmapData.Width);

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

                result = new int[workspaceHeight, workspaceWidth];

                int usedSum;
                int pixelSum;

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

                        usedSum = 0;
                        pixelSum = 0;

                        for (int k = -yStartOffset; k < maskHeight - yFinishOffset; ++k)
                        {
                            for (int l = -xStartOffset; l < maskWidth - xFinishOffset; ++l)
                            {
                                pixelSum += mask[k, l] * helpingPointer[0];
                                usedSum += mask[k, l];
                                helpingPointer += depth;
                            }
                            helpingPointer += helpingPointerOffset;
                            helpingPointer += -xStartOffset + xFinishOffset;
                        }
                        result[i, j] = pixelSum / (usedSum == 0 ? 1 : usedSum);

                        originalBitmapPointer += depth;
                    }
                    originalBitmapPointer += originalBitmapRemain;
                }
                originalImage.UnlockBits(originalBitmapData);
            }
            return result;
        }

        private unsafe int[,] ApplyMaskDuplicatingEdges(Bitmap originalImage, int[,] mask)
        {
            int depth = 1;
            int maskHeight = mask.GetLength(0);
            int maskWidth = mask.GetLength(1);

            Bitmap unwrappedImage = new Bitmap(
                originalImage.Width + (maskWidth - 1),
                originalImage.Height + (maskHeight - 1),
                originalImage.PixelFormat);

            int[,] result;

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

                unwrappedBitmapPointer = (byte*)unwrappedBitmapData.Scan0.ToPointer();
                unwrappedBitmapPointer += unwrappedBitmapData.Stride * (maskHeight / 2) + depth * (maskWidth / 2);

                int helpingPointerOffset = unwrappedBitmapData.Stride - maskWidth * depth;
                int helpingPointerStartOffset = unwrappedBitmapData.Stride * (maskHeight / 2) + depth * (maskWidth / 2);

                workspaceWidth = unwrappedBitmapData.Width - maskWidth + depth;
                workspaceHeight = unwrappedBitmapData.Height - maskHeight + depth;
                //set up helping pointer
                byte* helpingPointer;

                result = new int[workspaceHeight, workspaceWidth];

                int usedSum;
                int pixelSum;

                for (int i = 0; i < workspaceHeight; ++i)
                {
                    for (int j = 0; j < workspaceWidth; ++j)
                    {
                        helpingPointer = unwrappedBitmapPointer;
                        helpingPointer -= helpingPointerStartOffset;

                        usedSum = 0;
                        pixelSum = 0;

                        for (int k = 0; k < maskHeight; ++k)
                        {
                            for (int l = 0; l < maskWidth; ++l)
                            {
                                pixelSum += mask[k, l] * helpingPointer[0];
                                usedSum += mask[k, l];

                                helpingPointer += depth;
                            }
                            helpingPointer += helpingPointerOffset;
                        }

                        result[i, j] = pixelSum / (usedSum == 0 ? 1 : usedSum);

                        unwrappedBitmapPointer += depth;
                    }
                    unwrappedBitmapPointer += unwrappedPointerOffset;
                }
                unwrappedImage.UnlockBits(unwrappedBitmapData);
            }
            return result;
        }

        private byte[,] RescaleStretch(int[,] pixelValues)
        {
            byte[,] result = new byte[pixelValues.GetLength(0), pixelValues.GetLength(1)];

            int min = 0;
            int max = 0;

            for (int i = 0; i < pixelValues.GetLength(0); ++i)
            {
                for (int j = 0; j < pixelValues.GetLength(1); ++j)
                {
                    if (pixelValues[i, j] < min) min = pixelValues[i, j];
                    if (pixelValues[i, j] > max) max = pixelValues[i, j];
                }
            }

            for (int i = 0; i < pixelValues.GetLength(0); ++i)
            {
                for (int j = 0; j < pixelValues.GetLength(1); ++j)
                {
                    result[i, j] = (byte)(((pixelValues[i, j] - min) / ((float)max - min)) * 255f);
                }
            }

            return result;
        }

        //corel pp uses this
        private byte[,] RescaleCut(int[,] pixelValues)
        {
            byte[,] result = new byte[pixelValues.GetLength(0), pixelValues.GetLength(1)];

            for (int i = 0; i < pixelValues.GetLength(0); ++i)
            {
                for (int j = 0; j < pixelValues.GetLength(1); ++j)
                {
                    if (pixelValues[i, j] < 0)
                        result[i, j] = 0;
                    else if (pixelValues[i, j] > 255)
                        result[i, j] = 255;
                    else
                        result[i, j] = (byte)pixelValues[i, j];
                }
            }

            return result;
        }

        private byte[,] RescaleTrivalent(int[,] pixelValues)
        {
            byte[,] result = new byte[pixelValues.GetLength(0), pixelValues.GetLength(1)];

            for (int i = 0; i < pixelValues.GetLength(0); ++i)
            {
                for (int j = 0; j < pixelValues.GetLength(1); ++j)
                {
                    if (pixelValues[i, j] < 0)
                        result[i, j] = 0;
                    else if (pixelValues[i, j] > 0)
                        result[i, j] = 255;
                    else
                        result[i, j] = 127;
                }
            }

            return result;
        }
    }
}
