using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Imaging.Filters;

namespace APOApplication
{
    public unsafe class ArithmeticalOperations
    {
        private static readonly object imageLock = new object();

        public ArithmeticalOperations() { }

        public Bitmap Negate(Bitmap leftOperand)
        {
            Bitmap finalBitmap = new Bitmap(
                leftOperand.Width,
                leftOperand.Height,
                leftOperand.PixelFormat);

            ColorPalette finalPalette = finalBitmap.Palette;
            for (int i = 0; i < 256; ++i)
            {
                finalPalette.Entries[i] = Color.FromArgb(i, i, i);
            }
            finalBitmap.Palette = finalPalette;

            lock (imageLock)
            {
                BitmapData leftOperandData = leftOperand.LockBits(
                new Rectangle(0, 0, leftOperand.Width, leftOperand.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format8bppIndexed);
                BitmapData finalBitmapData = finalBitmap.LockBits(
                    new Rectangle(0, 0, finalBitmap.Width, finalBitmap.Height),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format8bppIndexed);

                int originalImageRemain = leftOperandData.Stride - leftOperandData.Width;
                int finalImageRemain = finalBitmapData.Stride - finalBitmapData.Width;

                byte* originalImagePointer = (byte*)leftOperandData.Scan0.ToPointer();
                byte* finalImagePointer = (byte*)finalBitmapData.Scan0.ToPointer();

                for (int i = 0; i < leftOperandData.Height; ++i)
                {
                    for (int j = 0; j < leftOperandData.Width; ++j)
                    {
                        finalImagePointer[0] = (byte)(255 - originalImagePointer[0]);
                        ++originalImagePointer;
                        ++finalImagePointer;
                    }
                    originalImagePointer += originalImageRemain;
                    finalImagePointer += finalImageRemain;
                }
                leftOperand.UnlockBits(leftOperandData);
                finalBitmap.UnlockBits(finalBitmapData);
            }

            return finalBitmap;
        }

        public Bitmap Conjunct(Bitmap leftOperand, Bitmap rightOperand)
        {
            ResizeBilinear resize = new ResizeBilinear(leftOperand.Width, leftOperand.Height);
            rightOperand = resize.Apply(rightOperand);

            Bitmap finalImage = new Bitmap(
                leftOperand.Width,
                leftOperand.Height,
                PixelFormat.Format8bppIndexed);

            ColorPalette colorPalette = finalImage.Palette;
            for (int i = 0; i < 256; ++i)
                colorPalette.Entries[i] = Color.FromArgb(i, i, i);
            finalImage.Palette = colorPalette;

            lock (imageLock)
            {
                BitmapData leftOperandData = leftOperand.LockBits(
                    new Rectangle(0, 0, leftOperand.Width, leftOperand.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                BitmapData rightOperandData = rightOperand.LockBits(
                    new Rectangle(0, 0, rightOperand.Width, rightOperand.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                BitmapData finalImageData = finalImage.LockBits(
                    new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                int leftOperandRemain = leftOperandData.Stride - leftOperandData.Width;
                int rightOperandRemain = rightOperandData.Stride - rightOperandData.Width;
                int finalImageRemain = finalImageData.Stride - finalImageData.Width;

                byte* leftOperandPointer = (byte*)leftOperandData.Scan0.ToPointer();
                byte* rightOperandPointer = (byte*)rightOperandData.Scan0.ToPointer();
                byte* finalImagePointer = (byte*)finalImageData.Scan0.ToPointer();

                for (int i = 0; i < leftOperand.Height; ++i)
                {
                    for (int j = 0; j < leftOperand.Width; ++j)
                    {
                        finalImagePointer[0] = (byte)(leftOperandPointer[0] & rightOperandPointer[0]);

                        ++leftOperandPointer;
                        ++rightOperandPointer;
                        ++finalImagePointer;
                    }
                    leftOperandPointer += leftOperandRemain;
                    rightOperandPointer += rightOperandRemain;
                    finalImagePointer += finalImageRemain;
                }

                finalImage.UnlockBits(finalImageData);
                leftOperand.UnlockBits(leftOperandData);
                rightOperand.UnlockBits(rightOperandData);
            }

            return finalImage;
        }

        public Bitmap Disjunct(Bitmap leftOperand, Bitmap rightOperand)
        {
            ResizeBilinear resize = new ResizeBilinear(leftOperand.Width, leftOperand.Height);
            rightOperand = resize.Apply(rightOperand);

            Bitmap finalImage = new Bitmap(
                leftOperand.Width,
                leftOperand.Height,
                PixelFormat.Format8bppIndexed);

            ColorPalette colorPalette = finalImage.Palette;
            for (int i = 0; i < 256; ++i)
                colorPalette.Entries[i] = Color.FromArgb(i, i, i);
            finalImage.Palette = colorPalette;

            lock (imageLock)
            {
                BitmapData leftOperandData = leftOperand.LockBits(
                    new Rectangle(0, 0, leftOperand.Width, leftOperand.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                BitmapData rightOperandData = rightOperand.LockBits(
                    new Rectangle(0, 0, rightOperand.Width, rightOperand.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                BitmapData finalImageData = finalImage.LockBits(
                    new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                int leftOperandRemain = leftOperandData.Stride - leftOperandData.Width;
                int rightOperandRemain = rightOperandData.Stride - rightOperandData.Width;
                int finalImageRemain = finalImageData.Stride - finalImageData.Width;

                byte* leftOperandPointer = (byte*)leftOperandData.Scan0.ToPointer();
                byte* rightOperandPointer = (byte*)rightOperandData.Scan0.ToPointer();
                byte* finalImagePointer = (byte*)finalImageData.Scan0.ToPointer();

                for (int i = 0; i < leftOperand.Height; ++i)
                {
                    for (int j = 0; j < leftOperand.Width; ++j)
                    {
                        finalImagePointer[0] = (byte)(leftOperandPointer[0] | rightOperandPointer[0]);

                        ++leftOperandPointer;
                        ++rightOperandPointer;
                        ++finalImagePointer;
                    }
                    leftOperandPointer += leftOperandRemain;
                    rightOperandPointer += rightOperandRemain;
                    finalImagePointer += finalImageRemain;
                }

                finalImage.UnlockBits(finalImageData);
                leftOperand.UnlockBits(leftOperandData);
                rightOperand.UnlockBits(rightOperandData);
            }
            return finalImage;
        }

        public Bitmap ExclusiveDisjunct(Bitmap leftOperand, Bitmap rightOperand)
        {
            ResizeBilinear resize = new ResizeBilinear(leftOperand.Width, leftOperand.Height);
            rightOperand = resize.Apply(rightOperand);

            Bitmap finalImage = new Bitmap(
                leftOperand.Width,
                leftOperand.Height,
                PixelFormat.Format8bppIndexed);

            ColorPalette colorPalette = finalImage.Palette;
            for (int i = 0; i < 256; ++i)
                colorPalette.Entries[i] = Color.FromArgb(i, i, i);
            finalImage.Palette = colorPalette;

            lock (imageLock)
            {
                BitmapData leftOperandData = leftOperand.LockBits(
                    new Rectangle(0, 0, leftOperand.Width, leftOperand.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                BitmapData rightOperandData = rightOperand.LockBits(
                    new Rectangle(0, 0, rightOperand.Width, rightOperand.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                BitmapData finalImageData = finalImage.LockBits(
                    new Rectangle(0, 0, finalImage.Width, finalImage.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                int leftOperandRemain = leftOperandData.Stride - leftOperandData.Width;
                int rightOperandRemain = rightOperandData.Stride - rightOperandData.Width;
                int finalImageRemain = finalImageData.Stride - finalImageData.Width;

                byte* leftOperandPointer = (byte*)leftOperandData.Scan0.ToPointer();
                byte* rightOperandPointer = (byte*)rightOperandData.Scan0.ToPointer();
                byte* finalImagePointer = (byte*)finalImageData.Scan0.ToPointer();

                for (int i = 0; i < leftOperand.Height; ++i)
                {
                    for (int j = 0; j < leftOperand.Width; ++j)
                    {
                        finalImagePointer[0] = (byte)(leftOperandPointer[0] | rightOperandPointer[0]);

                        ++leftOperandPointer;
                        ++rightOperandPointer;
                        ++finalImagePointer;
                    }
                    leftOperandPointer += leftOperandRemain;
                    rightOperandPointer += rightOperandRemain;
                    finalImagePointer += finalImageRemain;
                }

                finalImage.UnlockBits(finalImageData);
                leftOperand.UnlockBits(leftOperandData);
                rightOperand.UnlockBits(rightOperandData);
            }
            return finalImage;
        }

        public Bitmap Add(Bitmap leftOperand, Bitmap rightOperand)
        {
            ResizeBilinear resize = new ResizeBilinear(leftOperand.Width, leftOperand.Height);
            rightOperand = resize.Apply(rightOperand);
            Add filter = new Add(rightOperand);
            return filter.Apply(leftOperand);
        }

        public Bitmap Subtract(Bitmap leftOperand, Bitmap rightOperand)
        {
            ResizeBilinear resize = new ResizeBilinear(leftOperand.Width, leftOperand.Height);
            rightOperand = resize.Apply(rightOperand);
            Subtract filter = new Subtract(rightOperand);
            return filter.Apply(leftOperand);
        }

        public Bitmap Multiply(Bitmap leftOperand, Bitmap rightOperand)
        {
            ResizeBilinear resize = new ResizeBilinear(leftOperand.Width, leftOperand.Height);
            rightOperand = resize.Apply(rightOperand);
            Multiply filter = new Multiply(rightOperand);
            return filter.Apply(leftOperand);
        }

        public Bitmap Divide(Bitmap leftOperand, Bitmap rightOperand)
        {
            ResizeBilinear resize = new ResizeBilinear(leftOperand.Width, leftOperand.Height);
            rightOperand = resize.Apply(rightOperand);
            Divide filter = new Divide(rightOperand);
            return filter.Apply(leftOperand);
        }

        public Bitmap Difference(Bitmap leftOperand, Bitmap rightOperand)
        {
            ResizeBilinear resize = new ResizeBilinear(leftOperand.Width, leftOperand.Height);
            rightOperand = resize.Apply(rightOperand);
            Difference filter = new Difference(rightOperand);
            return filter.Apply(leftOperand);
        }
    }
}
