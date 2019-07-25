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
    public partial class MedianFilterForm : Form
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

        private EdgeProcessingMethod edgeProcessingMethod;
        private MedianFilter filter = new MedianFilter();
        int maskWidth;
        int maskHeight;

        private UpdateImageDelegate updateImage;

        public MedianFilterForm(Bitmap image, UpdateImageDelegate updateImage)
        {
            InitializeComponent();

            Image = image;
            this.updateImage = updateImage;

            for (int i = 3; i < 24; i += 2)
            {
                maskWidthComboBox.Items.Add(i);
                maskHeightComboBox.Items.Add(i);
            }

            maskHeightComboBox.SelectedIndex = 0;
            maskWidthComboBox.SelectedIndex = 0;
            useExistingRadioButton.Checked = true;
        }

        private void useExistingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            edgeProcessingMethod = EdgeProcessingMethod.UseExistingPixels;
        }

        private void duplicateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            edgeProcessingMethod = EdgeProcessingMethod.DuplicateEdges;
        }

        private void ignoreEdgesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            edgeProcessingMethod = EdgeProcessingMethod.IgnoreEdges;
        }

        private void EnableControls(bool state)
        {
            maskHeightComboBox.Enabled = state;
            maskWidthComboBox.Enabled = state;
            useExistingRadioButton.Enabled = state;
            duplicateRadioButton.Enabled = state;
            ignoreEdgesRadioButton.Enabled = state;
            previewButton.Enabled = state;
            saveButton.Enabled = state;
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            imagePictureBox.Image = filter.ApplyFilter(image, maskWidth, maskHeight, edgeProcessingMethod);
            EnableControls(true);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            Image = filter.ApplyFilter(image, maskWidth, maskHeight, edgeProcessingMethod);
            updateImage.Invoke(Image);
            this.Close();
        }

        private void maskWidthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            maskWidth = (int)maskWidthComboBox.SelectedItem;
        }

        private void maskHeightComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            maskHeight = (int)maskHeightComboBox.SelectedItem;
        }
    }
}
