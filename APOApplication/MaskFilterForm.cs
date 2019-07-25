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
    public partial class MaskFilterForm : Form
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
        private MaskProcessor filter = new MaskProcessor();
        int[,] mask;

        private UpdateImageDelegate updateImage;

        public MaskFilterForm(Bitmap image, UpdateImageDelegate updateImage)
        {
            InitializeComponent();
            Image = image;

            this.updateImage = updateImage;

            rescaleRangeRadioButton.Checked = true;
            usePredefinedMaskRadioButton.Checked = true;
            useExistingRadioButton.Checked = true;
            UpdateInterface();

            PropertyInfo[] comboBoxElements = typeof(Mask).GetProperties();
            foreach (PropertyInfo propertyInfo in comboBoxElements)
                predefinedMaskComboBox.Items.Add(propertyInfo.Name);

            predefinedMaskComboBox.SelectedIndex = 0;
        }

        private void UpdateInterface()
        {
            helpButton.Enabled = defineCustomMaskRadioButton.Checked;
            maskTextBox.Enabled = defineCustomMaskRadioButton.Checked;
            predefinedMaskComboBox.Enabled = usePredefinedMaskRadioButton.Checked;
        }

        private void EnableControls(bool state)
        {
            defineCustomMaskRadioButton.Enabled = state;
            usePredefinedMaskRadioButton.Enabled = state;
            predefinedMaskComboBox.Enabled = state;
            useExistingRadioButton.Enabled = state;
            duplicateRadioButton.Enabled = state;
            ignoreEdgesRadioButton.Enabled = state;
            rescaleRangeRadioButton.Enabled = state;
            trivalentRadioButton.Enabled = state;
            cutRadioButton.Enabled = state;
            previewButton.Enabled = state;
            saveButton.Enabled = state;
        }

        private void usePredefinedMaskRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            predefinedMaskComboBox.Enabled = usePredefinedMaskRadioButton.Checked;
            UpdateInterface();
        }

        private void defineCustomMaskRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateInterface();
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

        private void previewButton_Click(object sender, EventArgs e)
        {
            if (defineCustomMaskRadioButton.Checked)
                mask = ParseMask();

            EnableControls(false);
            imagePictureBox.Image = filter.ApplyFilter(image, mask, scalingMethod, edgeProcessingMethod);
            EnableControls(true);
        }

        private void predefinedMaskComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mask = (int[,])typeof(Mask).GetProperty(predefinedMaskComboBox.SelectedItem as string).GetValue(null);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            Image = filter.ApplyFilter(image, mask, scalingMethod, edgeProcessingMethod);
            updateImage.Invoke(Image);
            this.Close();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

        private int[,] ParseMask()
        {
            string mask = maskTextBox.Text;
            string[] lines = mask.Split('\n');
            string[] values = lines[0].Split(',');
            int[,] result = new int[lines.GetLength(0), values.GetLength(0)];

            for (int i = 0; i < lines.GetLength(0); ++i)
            {
                values = lines[i].Split(',');
                for (int j = 0; j < values.GetLength(0); j++)
                {
                    result[i, j] = Convert.ToInt32(values[j]);
                }
            }
            return result;
        }

        private void ShowHelp()
        {
            string help = "Define custom mask of size at least 3x3," + Environment.NewLine
                        + "which must look like this: " + Environment.NewLine
                        + "1, 1, 1, 1, 1" + Environment.NewLine
                        + "1, 1, 1, 1, 1" + Environment.NewLine
                        + "1, 1, 1, 1, 1" + Environment.NewLine
                        + "1, 1, 1, 1, 1" + Environment.NewLine
                        + "1, 1, 1, 1, 1";

            MessageBox.Show(help);
        }
    }
}
