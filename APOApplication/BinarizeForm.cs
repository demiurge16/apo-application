using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APOApplication
{
    public partial class BinarizeForm : Form
    {
        private Bitmap image;
        private Bitmap Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                imagePictureBox.Image = image;
            }
        }

        private UpdateImageDelegate updateImage;

        int[] lookUpTable = GenerateLookUpTable.GenerateBinaryTable(127);
        LookUpTableProcessor lookUpTableProcessor = new LookUpTableProcessor();

        public BinarizeForm(Bitmap image, UpdateImageDelegate updateImage)
        {
            InitializeComponent();

            Image = image;
            this.updateImage = updateImage;
            imagePictureBox.Image = lookUpTableProcessor.ApplyLookUpTable(Image, lookUpTable);
            binarizeLevel.Value = 127;
        }

        private void binarizeLevel_Scroll(object sender, EventArgs e)
        {
            lookUpTable = GenerateLookUpTable.GenerateBinaryTable(binarizeLevel.Value);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            lookUpTable = GenerateLookUpTable.GenerateBinaryTable(binarizeLevel.Value);
            Image = lookUpTableProcessor.ApplyLookUpTable(Image, lookUpTable);
            updateImage.Invoke(Image);
            this.Close();
        }

        private void EnableControls(bool state)
        {
            saveButton.Enabled = state;
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            imagePictureBox.Image = lookUpTableProcessor.ApplyLookUpTable(Image, lookUpTable);
            EnableControls(true);
        }
    }
}
