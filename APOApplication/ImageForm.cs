using OxyPlot;
using OxyPlot.Axes;
using Accord.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace APOApplication
{
    public delegate void UpdateImageDelegate(Bitmap bitmap);
    public delegate Bitmap BinaryOperation(Bitmap leftOperand, Bitmap rightOperand);

    public partial class ImageForm : Form
    {
        string about = "Aplikacja zbiorcza z ćwiczeń laboratoryjnych" + Environment.NewLine +
                            "Autor: Oleh Shatskyi" + Environment.NewLine +
                            "Prowadzący: dr inż.Marek Doros" + Environment.NewLine +
                            "Algorytmy Przetwarzania Obrazów 2019" + Environment.NewLine +
                            "Inżynieria oprogramowania grupa ID06P01";

        private Bitmap image;
        private Bitmap Image
        {
            get
            {
                return image;
            }
            set
            {
                if (value == null) throw new NoNullAllowedException("Null value is not allowed");

                if (value.PixelFormat != PixelFormat.Format8bppIndexed)
                {
                    Grayscale grayscale = new Grayscale(0.2126, 0.7152, 0.0722);
                    image = grayscale.Apply(value);
                }
                else
                {
                    image = value;
                }                    
                imagePictureBox.Image = image;
                UpdateHistogram();
            }
        }

        private UpdateImageDelegate updateImage;

        public ImageForm(Bitmap image)
        {
            InitializeComponent();

            Image = image;
            updateImage = new UpdateImageDelegate(UpdateImage);
        }

        #region Laboratorium 1
        private void stretchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramProcessing histogramProcessing = new HistogramProcessing();
            Image = histogramProcessing.StretchHistogram(Image);
        }

        private void equalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramProcessing histogramProcessing = new HistogramProcessing();
            Image = histogramProcessing.EqualizeHistogram(Image);
        }

        private void equalizeHeuresticMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramProcessing histogramProcessing = new HistogramProcessing();
            Image = histogramProcessing.EqualizeHistogramHeurestic(Image);
        }

        private void equalizeRandomMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramProcessing histogramProcessing = new HistogramProcessing();
            Image = histogramProcessing.EqualizeHistogramRandom(Image);
        }

        private void equalizeMeanMethodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramProcessing histogramProcessing = new HistogramProcessing();
            Image = histogramProcessing.EqualizeHistogramAverage(Image);
        }
        #endregion

        #region Laboratorium 2
        private void negateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArithmeticalOperations arithmeticalOperations = new ArithmeticalOperations();
            Image = arithmeticalOperations.Negate(Image);
        }

        private void logicalANDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArithmeticalOperations arithmetical = new ArithmeticalOperations();
            BinaryOperation binaryOperation = new BinaryOperation(arithmetical.Conjunct);
            ArithmeticalWindow arithmeticalWindow = new ArithmeticalWindow(Image, updateImage, binaryOperation);
            arithmeticalWindow.Owner = this;
            arithmeticalWindow.Show();
        }

        private void logicalORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArithmeticalOperations arithmetical = new ArithmeticalOperations();
            BinaryOperation binaryOperation = new BinaryOperation(arithmetical.Disjunct);
            ArithmeticalWindow arithmeticalWindow = new ArithmeticalWindow(Image, updateImage, binaryOperation);
            arithmeticalWindow.Owner = this;
            arithmeticalWindow.Show();
        }

        private void logicalXORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArithmeticalOperations arithmetical = new ArithmeticalOperations();
            BinaryOperation binaryOperation = new BinaryOperation(arithmetical.ExclusiveDisjunct);
            ArithmeticalWindow arithmeticalWindow = new ArithmeticalWindow(Image, updateImage, binaryOperation);
            arithmeticalWindow.Owner = this;
            arithmeticalWindow.Show();
        }

        private void additionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArithmeticalOperations arithmetical = new ArithmeticalOperations();
            BinaryOperation binaryOperation = new BinaryOperation(arithmetical.Add);
            ArithmeticalWindow arithmeticalWindow = new ArithmeticalWindow(Image, updateImage, binaryOperation);
            arithmeticalWindow.Owner = this;
            arithmeticalWindow.Show();
        }

        private void subtractionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArithmeticalOperations arithmetical = new ArithmeticalOperations();
            BinaryOperation binaryOperation = new BinaryOperation(arithmetical.Subtract);
            ArithmeticalWindow arithmeticalWindow = new ArithmeticalWindow(Image, updateImage, binaryOperation);
            arithmeticalWindow.Owner = this;
            arithmeticalWindow.Show();
        }

        private void multiplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArithmeticalOperations arithmetical = new ArithmeticalOperations();
            BinaryOperation binaryOperation = new BinaryOperation(arithmetical.Multiply);
            ArithmeticalWindow arithmeticalWindow = new ArithmeticalWindow(Image, updateImage, binaryOperation);
            arithmeticalWindow.Owner = this;
            arithmeticalWindow.Show();
        }

        private void divisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArithmeticalOperations arithmetical = new ArithmeticalOperations();
            BinaryOperation binaryOperation = new BinaryOperation(arithmetical.Divide);
            ArithmeticalWindow arithmeticalWindow = new ArithmeticalWindow(Image, updateImage, binaryOperation);
            arithmeticalWindow.Owner = this;
            arithmeticalWindow.Show();
        }

        private void differenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArithmeticalOperations arithmetical = new ArithmeticalOperations();
            BinaryOperation binaryOperation = new BinaryOperation(arithmetical.Difference);
            ArithmeticalWindow arithmeticalWindow = new ArithmeticalWindow(Image, updateImage, binaryOperation);
            arithmeticalWindow.Owner = this;
            arithmeticalWindow.Show();
        }

        private void binarizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinarizeForm binarizeForm = new BinarizeForm(Image, updateImage);
            binarizeForm.Owner = this;
            binarizeForm.Show();
        }

        private void posterizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PosterizeForm posterizeForm = new PosterizeForm(Image, updateImage);
            posterizeForm.Owner = this;
            posterizeForm.Show();
        }

        private void lUTModificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNotImplementedMessage();
        }

        private void stretchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNotImplementedMessage();
        }

        private void advancedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNotImplementedMessage();
        }
        #endregion

        #region Laboratorium 3
        private void medianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedianFilterForm medianFilterForm = new MedianFilterForm(Image, updateImage);
            medianFilterForm.Owner = this;
            medianFilterForm.Show();
        }

        private void maskFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaskFilterForm medianFilterForm = new MaskFilterForm(Image, updateImage);
            medianFilterForm.Owner = this;
            medianFilterForm.Show();
        }

        private void gradientFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GradientFilterForm gradientFilterForm = new GradientFilterForm(Image, updateImage);
            gradientFilterForm.Owner = this;
            gradientFilterForm.Show();
        }

        private void kirschCompassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompassFilter compassFilter = new CompassFilter();
            Image = compassFilter.KirschFilter(Image);
        }

        private void prewittCompassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompassFilter compassFilter = new CompassFilter();
            Image = compassFilter.PrewittFilter(Image);
        }
        #endregion

        #region Laboratorium 4
        short[,] rhombus = new short[,]
        {
            { 0, 1, 0 },
            { 1, 1, 1 },
            { 0, 1, 0 },
        };

        short[,] square = new short[,]
        {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 },
        };

        private void rhombusOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opening filter = new Opening(rhombus);
            Image = filter.Apply(Image);
        }

        private void squareOpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opening filter = new Opening(square);
            Image = filter.Apply(Image);
        }

        private void rhombusCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Closing filter = new Closing(rhombus);
            Image = filter.Apply(Image);
        }

        private void squareCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Closing filter = new Closing(square);
            Image = filter.Apply(Image);
        }

        private void rhombusErodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Erosion filter = new Erosion(rhombus);
            Image = filter.Apply(Image);
        }

        private void squareErodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Erosion filter = new Erosion(square);
            Image = filter.Apply(Image);
        }

        private void rhombusDilateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dilation filter = new Dilation(rhombus);
            Image = filter.Apply(Image);
        }

        private void squareDilateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dilation filter = new Dilation(square);
            Image = filter.Apply(Image);
        }

        private void watershedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryWatershed filter = new BinaryWatershed();
            Image = filter.Apply(Image);
        }

        private void thinningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleSkeletonization filter = new SimpleSkeletonization();
            Image = filter.Apply(Image);
        }
        #endregion

        #region Laboratorium 5
        private void huffmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompressionTests compressionTests = new CompressionTests();
            CompressionResults results = compressionTests.HuffmanTest(Image);
            MessageBox.Show("Size before compression: " + results.SizeUncompressed + " bytes" + Environment.NewLine +
                            "Size after compression: " + results.SizeCompressed + " bytes" + Environment.NewLine +
                            "Compression rate:" + results.CompressionRatio + Environment.NewLine);
        }

        private void rLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompressionTests compressionTests = new CompressionTests();
            CompressionResults results = compressionTests.RLETest(Image);
            MessageBox.Show("Size before compression: " + results.SizeUncompressed + " bytes" + Environment.NewLine +
                            "Size after compression: " + results.SizeCompressed + " bytes" + Environment.NewLine +
                            "Compression rate:" + results.CompressionRatio + Environment.NewLine);
        }

        private void lZWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompressionTests compressionTests = new CompressionTests();
            CompressionResults results = compressionTests.LZWTest(Image);
            MessageBox.Show("Size before compression: " + results.SizeUncompressed + " bytes" + Environment.NewLine +
                            "Size after compression: " + results.SizeCompressed + " bytes" + Environment.NewLine +
                            "Compression rate:" + results.CompressionRatio + Environment.NewLine);
        }

        private void x4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompressionTests compressionTests = new CompressionTests();
            CompressionResults results = compressionTests.BTCTest(Image, 4);
            MessageBox.Show("Size before compression: " + results.SizeUncompressed + " bytes" + Environment.NewLine +
                            "Size after compression: " + results.SizeCompressed + " bytes" + Environment.NewLine +
                            "Compression rate:" + results.CompressionRatio + Environment.NewLine);
        }

        private void x8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompressionTests compressionTests = new CompressionTests();
            CompressionResults results = compressionTests.BTCTest(Image, 8);
            MessageBox.Show("Size before compression: " + results.SizeUncompressed + " bytes" + Environment.NewLine +
                            "Size after compression: " + results.SizeCompressed + " bytes" + Environment.NewLine +
                            "Compression rate:" + results.CompressionRatio + Environment.NewLine);
        }

        private void x16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompressionTests compressionTests = new CompressionTests();
            CompressionResults results = compressionTests.BTCTest(Image, 16);
            MessageBox.Show("Size before compression: " + results.SizeUncompressed + " bytes" + Environment.NewLine +
                            "Size after compression: " + results.SizeCompressed + " bytes" + Environment.NewLine +
                            "Compression rate:" + results.CompressionRatio + Environment.NewLine);
        }

        private void x32ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompressionTests compressionTests = new CompressionTests();
            CompressionResults results = compressionTests.BTCTest(Image, 32);
            MessageBox.Show("Size before compression: " + results.SizeUncompressed + " bytes" + Environment.NewLine +
                            "Size after compression: " + results.SizeCompressed + " bytes" + Environment.NewLine +
                            "Compression rate:" + results.CompressionRatio + Environment.NewLine);
        }
        #endregion

        #region Laboratorium 6
        private void turtleAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TurtleAlgorithm turtleAlgorithm = new TurtleAlgorithm();

            Point[] points = turtleAlgorithm.PerformBorderFollowing(Image);

            if (points == null)
            {
                MessageBox.Show("Boundary following failed");
                return;
            }

            byte[,] imageBytes = turtleAlgorithm.BitmapToByteArray2D(Image);
            imageBytes = turtleAlgorithm.PutPoints(imageBytes, points);
            Image = turtleAlgorithm.ByteArrayToBitmap(imageBytes);
        }
        #endregion

        private void UpdateImage(Bitmap image)
        {
            Image = image;
        }

        private void UpdateHistogram()
        {
            HistogramProcessing histogramProcessing = new HistogramProcessing();
            int[] histogram = histogramProcessing.GetHistogram(Image);
            PlotModel histogramModel = new PlotModel();

            OxyPlot.Series.LineSeries columnSeries = new OxyPlot.Series.LineSeries()
            {
                Color = OxyColor.FromRgb(0, 0, 0),
            };

            for (int i = 0; i < histogram.Length; i++)
            {
                columnSeries.Points.Add(new DataPoint(i, histogram[i]));
            }
            histogramModel.Series.Clear();
            histogramModel.Series.Add(columnSeries);

            histogramModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = -1,
                Maximum = 257
            });
            histogramModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = -1
            });

            histogramView.Model = histogramModel;
        }

        private void ShowNotImplementedMessage()
        {
            MessageBox.Show("This function is not implemented yet");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(about);
        }
    }
}
