using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOApplication
{
    class GenerateLookUpTable
    {
        public static int[] GenerateBinaryTable(int splitValue)
        {
            int[] lookUpTable = new int[256];

            for (int i = 0; i < lookUpTable.Length; ++i)
            {
                lookUpTable[i] = i < splitValue ? 0 : 255;
            }

            return lookUpTable;
        }

        public static int[] GeneratePosterizeTable(int levelsCount)
        {
            double colorStep = 255.0 / (levelsCount - 1);
            double tableStep = 256.0 / levelsCount;
            int[] lookUpTable = new int[256];

            Console.Write("LUT " + levelsCount + ": ");

            for (int i = 0; i < 256; ++i)
            {
                byte temp = (byte)(i / tableStep);
                lookUpTable[i] = (byte)(temp * colorStep);

                Console.Write(i + ": " + (byte)(temp * colorStep) + ", ");
            }
            Console.WriteLine();

            return lookUpTable;
        }
    }
}
