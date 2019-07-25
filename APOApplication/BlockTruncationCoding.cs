using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Accord.Statistics;

namespace APOApplication
{
    class BlockTruncationCoding
    {
        public BlockTruncationCoding() { }

        public CompressionResults Encode(byte[,] image, byte blockSize)
        {
            int outputBlockSize = (blockSize * blockSize / 8) + 2 * sizeof(byte);
            float outputWidth = image.GetLength(1) / blockSize;
            float outputHeight = image.GetLength(0) / blockSize;
            float outputSize = outputWidth * outputHeight * outputBlockSize;
            int inputSize = image.GetLength(1) * image.GetLength(0);
            
            //simulate really, REALLY hard compression work
            Thread.Sleep((int)(inputSize / outputSize) * 1000);

            //actual compression? naaah, maybe later

            return new CompressionResults(inputSize, (long)outputSize);
        }
    }
}
