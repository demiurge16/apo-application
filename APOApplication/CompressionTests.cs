using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOApplication
{
    struct CompressionResults
    {
        public CompressionResults(long sizeC, long sizeU)
        {
            SizeUncompressed = sizeU;
            SizeCompressed = sizeC;
            CompressionRatio = (double)SizeUncompressed / SizeCompressed;
        }
        public long SizeUncompressed { get; private set; }
        public long SizeCompressed { get; private set; }
        public double CompressionRatio { get; private set; }
    }

    class CompressionTests
    {
        private static readonly object imageLock = new object();

        public CompressionTests() { }

        public CompressionResults HuffmanTest(Bitmap image)
        {
            byte[] byteArray = BitmapToByteArray(image);
            Huffman<byte> huffman = new Huffman<byte>(byteArray);

            List<int> encoding = huffman.Encode(byteArray);
            List<byte> decoding = huffman.Decode(encoding);

            return new CompressionResults(encoding.Count, decoding.Count * 8);
        }

        public CompressionResults RLETest(Bitmap image)
        {
            byte[] byteArray = BitmapToByteArray(image);
            RLE rle = new RLE();
            byte[] encoded = rle.Encode(byteArray);

            return new CompressionResults(encoded.Length, byteArray.Length);
        }

        public CompressionResults LZWTest(Bitmap image)
        {
            byte[] byteArray = BitmapToByteArray(image);
            string input = byteArray.GetBinaryString();

            LZWEncoder encoder = new LZWEncoder();
            byte[] output = encoder.EncodeToByteList(input);

            return new CompressionResults(output.Length, byteArray.Length);
        }

        public CompressionResults BTCTest(Bitmap image, byte blockSize)
        {
            byte[,] byteArray = BitmapToByteArray2D(image);
            return new BlockTruncationCoding().Encode(byteArray, blockSize);
        }

        private unsafe byte[] BitmapToByteArray(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;
            byte[] output = new byte[width * height];

            lock (imageLock)
            {
                BitmapData bitmapData = image.LockBits(
                    new Rectangle(0, 0, width, height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format8bppIndexed);

                int remain = bitmapData.Stride - bitmapData.Width;
                byte* pointer = (byte*)bitmapData.Scan0.ToPointer();

                for (int i = 0, c = 0; i < height; ++i)
                {
                    for (int j = 0; j < width; ++j)
                    {
                        output[c] = pointer[0];
                        ++pointer;
                        ++c;
                    }
                    pointer += remain;
                }

                image.UnlockBits(bitmapData);
            }

            return output;
        }
        private unsafe byte[,] BitmapToByteArray2D(Bitmap image)
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
                        output[i,j] = pointer[0];
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
