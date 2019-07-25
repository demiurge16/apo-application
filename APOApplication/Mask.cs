using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOApplication
{
    public static class Mask
    {
        public static int[,] OneOverNine { get; private set; }
        public static int[,] OneOverTen { get; private set; }
        public static int[,] OneOverSixteen { get; private set; }
        public static int[,] LaplacianBasic { get; private set; }
        public static int[,] LaplacianA { get; private set; }
        public static int[,] LaplacianB { get; private set; }
        public static int[,] LaplacianC { get; private set; }
        public static int[,] LaplacianD { get; private set; }
        public static int[,] LaplacianE { get; private set; }
        public static int[,] EdgeDetectionA { get; private set; }
        public static int[,] EdgeDetectionB { get; private set; }
        public static int[,] EdgeDetectionC { get; private set; }
        public static int[,] SobelX { get; private set; }
        public static int[,] SobelY { get; private set; }
        public static int[,] RobertsX { get; private set; }
        public static int[,] RobertsY { get; private set; }
        public static int[,] PrewittX { get; private set; }
        public static int[,] PrewittY { get; private set; }
        public static int[,] PrewittN { get; private set; }
        public static int[,] PrewittNE { get; private set; }
        public static int[,] PrewittE { get; private set; }
        public static int[,] PrewittSE { get; private set; }
        public static int[,] PrewittS { get; private set; }
        public static int[,] PrewittSW { get; private set; }
        public static int[,] PrewittW { get; private set; }
        public static int[,] PrewittNW { get; private set; }
        public static int[,] KirschN { get; private set; }
        public static int[,] KirschNE { get; private set; }
        public static int[,] KirschE { get; private set; }
        public static int[,] KirschSE { get; private set; }
        public static int[,] KirschS { get; private set; }
        public static int[,] KirschSW { get; private set; }
        public static int[,] KirschW { get; private set; }
        public static int[,] KirschNW { get; private set; }

        static Mask()
        {
            OneOverNine = new int[,]
            {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };
            OneOverTen = new int[,]
            {
                { 1, 1, 1 },
                { 1, 2, 1 },
                { 1, 1, 1 }
            };
            OneOverSixteen = new int[,]
            {
                { 1, 2, 1 },
                { 2, 4, 2 },
                { 1, 2, 1 }
            };
            LaplacianBasic = new int[,]
            {
                { 0, 1, 0 },
                { 1, -4, 1 },
                { 0, 1, 0 }
            };
            LaplacianA = new int[,]
            {
                { 0, -1, 0 },
                { -1, 4, -1 },
                { 0, -1, 0 }
            };
            LaplacianB = new int[,]
            {
                { -1, -1, -1 },
                { -1, 8, -1 },
                { -1, -1, -1 }
            };
            LaplacianC = new int[,]
            {
                { 1, -2, 1 },
                { -2, 4, -2 },
                { 1, -2, 1 }
            };
            LaplacianD = new int[,]
            {
                { -1, -1, -1 },
                { -1, 9, -1 },
                { -1, -1, -1 }
            };
            LaplacianE = new int[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };
            EdgeDetectionA = new int[,]
            {
                { 1, -2, 1 },
                { -2, 5, -2 },
                { 1, -2, 1 }
            };
            EdgeDetectionB = new int[,]
            {
                { -1, -1, -1 },
                { -1, 9, -1 },
                { -1, -1, -1 }
            };
            EdgeDetectionC = new int[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };
            SobelX = new int[,]
            {
                { 1, 0, -1 },
                { 2, 0, -2 },
                { 1, 0, -1 }
            };
            SobelY = new int[,]
            {
                { -1, -2, -1 },
                { 0, 0, 0 },
                { 1, 2, 1 }
            };
            RobertsX = new int[,]
            {
                { 1, 0 },
                { 0, -1 }
            };
            RobertsY = new int[,]
            {
                { 0, -1 },
                { 1, 0 }
            };
            PrewittX = new int[,]
            {
                { 1, 0, -1 },
                { 1, 0, -1 },
                { 1, 0, -1 }
            };
            PrewittY = new int[,]
            {
                { 1, 1, 1 },
                { 0, 0, 0 },
                { -1, -1, -1 }
            };
            PrewittN = new int[,]
            {
                { 1, 1, 1 },
                { 1, -2, 1 },
                { -1, -1, -1 }
            };
            PrewittNE = new int[,]
            {
                { 1, 1, 1 },
                { -1, -2, 1 },
                { -1, -1, 1 }
            };
            PrewittE = new int[,]
            {
                { -1, 1, 1 },
                { -1, -2, 1 },
                { -1, 1, 1 }
            };
            PrewittSE = new int[,]
            {
                { -1, -1, 1 },
                { -1, -2, 1 },
                { 1, 1, 1 }
            };
            PrewittS = new int[,]
            {
                { -1, -1, -1 },
                { 1, -2, 1 },
                { 1, 1, 1 }
            };
            PrewittSW = new int[,]
            {
                { 1, -1, -1 },
                { 1, -2, -1 },
                { 1, 1, 1 }
            };
            PrewittW = new int[,]
            {
                { 1, 1, -1 },
                { 1, -2, -1 },
                { 1, 1, -1 }
            };
            PrewittNW = new int[,]
            {
                { 1, 1, 1 },
                { 1, -2, -1 },
                { 1, -1, -1 }
            };
            KirschN = new int[,]
            {
                { 3, 3, 3 },
                { 3, 0, 3 },
                { -5, -5, -5 }
            };
            KirschNE = new int[,]
            {
                { 3, 3, 3 },
                { -5, 0, 3 },
                { -5, -5, 3 }
            };
            KirschE = new int[,]
            {
                { -5, 3, 3 },
                { -5, 0, 3 },
                { -5, 3, 3 }
            };
            KirschSE = new int[,]
            {
                { -5, -5, 3 },
                { -5, 0, 3 },
                { 3, 3, 3 }
            };
            KirschS = new int[,]
            {
                { -5, -5, -5 },
                { 3, 0, 3 },
                { 3, 3, 3 }
            };
            KirschSW = new int[,]
            {
                { 3, -5, -5 },
                { 3, 0, -5 },
                { 3, 3, 3 }
            };
            KirschW = new int[,]
            {
                { 3, 3, -5 },
                { 3, 0, -5 },
                { 3, 3, -5 }
            };
            KirschNW = new int[,]
            {
                { 3, 3, 3 },
                { 3, 0, -5 },
                { 3, -5, -5 }
            };
        }
    }
}
