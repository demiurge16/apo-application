using Accord.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APOApplication
{
    public partial class ArithmeticalWindow : Form
    {
        private Bitmap sourceImage;
        private Bitmap SourceImage
        {
            get
            {
                return sourceImage;
            }
            set
            {
                if (value == null) throw new NoNullAllowedException("Null value is not allowed");

                if (value.PixelFormat != PixelFormat.Format8bppIndexed)
                {
                    Grayscale grayscale = new Grayscale(0.2126, 0.7152, 0.0722);
                    sourceImage = grayscale.Apply(value);
                }
                else
                {
                    sourceImage = value;
                }
                previewPictureBox.Image = sourceImage;
            }
        }

        private Bitmap overlayImage;
        private Bitmap OverlayImage
        {
            get
            {
                return overlayImage;
            }
            set
            {
                if (value == null) throw new NoNullAllowedException("Null value is not allowed");

                if (value.PixelFormat != PixelFormat.Format8bppIndexed)
                {
                    Grayscale grayscale = new Grayscale(0.2126, 0.7152, 0.0722);
                    overlayImage = grayscale.Apply(value);
                }
                else
                {
                    overlayImage = value;
                }
                overlayImagePictureBox.Image = overlayImage;
            }
        }

        private UpdateImageDelegate updateImage;
        private BinaryOperation operation;

        public ArithmeticalWindow(Bitmap image, UpdateImageDelegate updateImage, BinaryOperation operation)
        {
            InitializeComponent();
            SourceImage = image;
            this.updateImage = updateImage;
            this.operation = operation;

            EnableControls(false);
        }

        private void EnableControls(bool state)
        {
            previewButton.Enabled = state;
            saveButton.Enabled = state;
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Users\%username%\Images";
            openFileDialog.Filter = "bitmap files (*.bmp)|*.bmp";
            openFileDialog.Title = "Open file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                OverlayImage = bitmap;
                EnableControls(true);
            }
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            previewPictureBox.Image = operation.Invoke(sourceImage, overlayImage);
            EnableControls(true);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            sourceImage = operation.Invoke(sourceImage, overlayImage);
            updateImage.Invoke(sourceImage);
            this.Close();
        }
    }
}
