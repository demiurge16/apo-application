using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOApplication
{
    class TurtleAlgorithm
    {
        private static readonly object imageLock = new object();

        public TurtleAlgorithm() { }

        public unsafe Bitmap ByteArrayToBitmap(byte[,] image)
        {
            int width = image.GetLength(1);
            int height = image.GetLength(0);

            Bitmap finalImage = new Bitmap(width, height, PixelFormat.Format8bppIndexed);

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
                    finalBitmapPointer[0] = image[i, j];
                    ++finalBitmapPointer;
                }
                finalBitmapPointer += finalBitmapRemain;
            }
            finalImage.UnlockBits(finalBitmapData);

            return finalImage;
        }

        public byte[,] PutPoints(byte[,] image, Point[] points, byte level = 127)
        {
            foreach (Point item in points)
            {
                image[item.X, item.Y] = level;
            }
            return image;
        }

        public Point[] PerformBorderFollowing(Bitmap image)
        {
            int height = image.Height;
            int width = image.Width;
            byte[,] bitmapData = BitmapToByteArray2D(image);
            List<Point> points = new List<Point>();

            //find start
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; j++)
                {
                    if (bitmapData[i, j] != 0)
                    {
                        points.Add(new Point(i, j));
                        i = height;
                        j = width;
                    }
                }
            }

            if (points.Count == 0) return null;

            int k = points[0].X;
            int l = points[0].Y;
            int ks = k;
            int ls = l;
            int d = 0;

            do
            {
                if (bitmapData[k, l] != 0)
                    d = (d + 1) & 3;
                else
                    d = (d - 1) & 3;

                switch (d)
                {
                    case 0: ++l; break;
                    case 1: --k; break;
                    case 2: --l; break;
                    case 3: ++k; break;
                }

                if (k < 0 || k > height || l < 0 || k > width) return null;

                points.Add(new Point(k, l));

            } while (k != ks || l != ls);

            return points.ToArray();
        }

        public unsafe byte[,] BitmapToByteArray2D(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;
            byte[,] output = new byte[height, width];

            lock (imageLock)
            {
                BitmapData bitmapData = image.LockBits(
                    new Rectangle(0, 0, width, height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                int remain = bitmapData.Stride - bitmapData.Width;
                byte* pointer = (byte*)bitmapData.Scan0.ToPointer();

                for (int i = 0; i < height; ++i)
                {
                    for (int j = 0; j < width; ++j)
                    {
                        output[i, j] = pointer[0];
                        ++pointer;
                    }
                    pointer += remain;
                }

                image.UnlockBits(bitmapData);
            }

            return output;
        }
    }
}
