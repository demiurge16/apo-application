using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APOApplication
{
    public partial class GradientFilterForm : Form
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
        private ScalingMethod scalingMethod;
        private GradientFiltering filter = new GradientFiltering();
        int[,] maskX;
        int[,] maskY;

        private UpdateImageDelegate updateImage;

        public GradientFilterForm(Bitmap image, UpdateImageDelegate updateImage)
        {
            InitializeComponent();
            Image = image;
            this.updateImage = updateImage;

            PropertyInfo[] comboBoxElements = typeof(Mask).GetProperties();
            foreach (PropertyInfo propertyInfo in comboBoxElements)
            {
                xMaskComboBox.Items.Add(propertyInfo.Name);
                yMaskComboBox.Items.Add(propertyInfo.Name);
            }

            xMaskComboBox.SelectedIndex = 0;
            yMaskComboBox.SelectedIndex = 0;
            useExistingRadioButton.Checked = true;
            rescaleRangeRadioButton.Checked = true;
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

        private void rescaleRangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            scalingMethod = ScalingMethod.RangeRescale;
        }

        private void trivalentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            scalingMethod = ScalingMethod.Trivalent;
        }

        private void cutRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            scalingMethod = ScalingMethod.Cutting;
        }

        private void EnableControls(bool state)
        {
            xMaskComboBox.Enabled = state;
            yMaskComboBox.Enabled = state;
            useExistingRadioButton.Enabled = state;
            duplicateRadioButton.Enabled = state;
            ignoreEdgesRadioButton.Enabled = state;
            rescaleRangeRadioButton.Enabled = state;
            trivalentRadioButton.Enabled = state;
            cutRadioButton.Enabled = state;
            previewButton.Enabled = state;
            saveButton.Enabled = state;
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            imagePictureBox.Image = filter.ApplyFilter(image, maskX, maskY, scalingMethod, edgeProcessingMethod);
            EnableControls(true);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            Image = filter.ApplyFilter(image, maskX, maskY, scalingMethod, edgeProcessingMethod);
            updateImage.Invoke(Image);
            this.Close();
        }

        private void xMaskComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            maskX = (int[,])typeof(Mask).GetProperty(xMaskComboBox.SelectedItem as string).GetValue(null);
        }

        private void yMaskComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            maskY = (int[,])typeof(Mask).GetProperty(yMaskComboBox.SelectedItem as string).GetValue(null);
        }
    }
}
