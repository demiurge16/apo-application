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
    public partial class PosterizeForm : Form
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

        int[] lookUpTable = GenerateLookUpTable.GenerateBinaryTable(2);
        LookUpTableProcessor lookUpTableProcessor = new LookUpTableProcessor();

        public PosterizeForm(Bitmap image, UpdateImageDelegate updateImage)
        {
            InitializeComponent();

            Image = image;
            this.updateImage = updateImage;

            for (int i = 2; i < 129; ++i)
            {
                GrayLevelsCount.Items.Add(i);
            }
            GrayLevelsCount.SelectedIndex = 0;
            imagePictureBox.Image = lookUpTableProcessor.ApplyLookUpTable(Image, lookUpTable);
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            imagePictureBox.Image = lookUpTableProcessor.ApplyLookUpTable(Image, lookUpTable);
            EnableControls(true);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            Image = lookUpTableProcessor.ApplyLookUpTable(Image, lookUpTable);
            updateImage.Invoke(Image);
            this.Close();
        }

        private void GrayLevelsCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            lookUpTable = GenerateLookUpTable.GeneratePosterizeTable((int)GrayLevelsCount.SelectedItem);
        }

        private void EnableControls(bool state)
        {
            GrayLevelsCount.Enabled = state;
            previewButton.Enabled = state;
            saveButton.Enabled = state;
        }
    }
}
