namespace APOApplication
{
    partial class GradientFilterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.previewButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ignoreEdgesRadioButton = new System.Windows.Forms.RadioButton();
            this.duplicateRadioButton = new System.Windows.Forms.RadioButton();
            this.useExistingRadioButton = new System.Windows.Forms.RadioButton();
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yMaskComboBox = new System.Windows.Forms.ComboBox();
            this.xMaskComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cutRadioButton = new System.Windows.Forms.RadioButton();
            this.trivalentRadioButton = new System.Windows.Forms.RadioButton();
            this.rescaleRangeRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // previewButton
            // 
            this.previewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previewButton.Location = new System.Drawing.Point(558, 419);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(108, 23);
            this.previewButton.TabIndex = 8;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(680, 419);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ignoreEdgesRadioButton);
            this.groupBox3.Controls.Add(this.duplicateRadioButton);
            this.groupBox3.Controls.Add(this.useExistingRadioButton);
            this.groupBox3.Location = new System.Drawing.Point(558, 171);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 88);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Edge Processing";
            // 
            // ignoreEdgesRadioButton
            // 
            this.ignoreEdgesRadioButton.AutoSize = true;
            this.ignoreEdgesRadioButton.Location = new System.Drawing.Point(7, 68);
            this.ignoreEdgesRadioButton.Name = "ignoreEdgesRadioButton";
            this.ignoreEdgesRadioButton.Size = new System.Drawing.Size(87, 17);
            this.ignoreEdgesRadioButton.TabIndex = 2;
            this.ignoreEdgesRadioButton.TabStop = true;
            this.ignoreEdgesRadioButton.Text = "Ignore edges";
            this.ignoreEdgesRadioButton.UseVisualStyleBackColor = true;
            this.ignoreEdgesRadioButton.CheckedChanged += new System.EventHandler(this.ignoreEdgesRadioButton_CheckedChanged);
            // 
            // duplicateRadioButton
            // 
            this.duplicateRadioButton.AutoSize = true;
            this.duplicateRadioButton.Location = new System.Drawing.Point(7, 44);
            this.duplicateRadioButton.Name = "duplicateRadioButton";
            this.duplicateRadioButton.Size = new System.Drawing.Size(93, 17);
            this.duplicateRadioButton.TabIndex = 1;
            this.duplicateRadioButton.TabStop = true;
            this.duplicateRadioButton.Text = "Unwrap image";
            this.duplicateRadioButton.UseVisualStyleBackColor = true;
            this.duplicateRadioButton.CheckedChanged += new System.EventHandler(this.duplicateRadioButton_CheckedChanged);
            // 
            // useExistingRadioButton
            // 
            this.useExistingRadioButton.AutoSize = true;
            this.useExistingRadioButton.Location = new System.Drawing.Point(7, 20);
            this.useExistingRadioButton.Name = "useExistingRadioButton";
            this.useExistingRadioButton.Size = new System.Drawing.Size(111, 17);
            this.useExistingRadioButton.TabIndex = 0;
            this.useExistingRadioButton.TabStop = true;
            this.useExistingRadioButton.Text = "Use existing pixels";
            this.useExistingRadioButton.UseVisualStyleBackColor = true;
            this.useExistingRadioButton.CheckedChanged += new System.EventHandler(this.useExistingRadioButton_CheckedChanged);
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePictureBox.Location = new System.Drawing.Point(13, 13);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(539, 425);
            this.imagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagePictureBox.TabIndex = 11;
            this.imagePictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.yMaskComboBox);
            this.groupBox1.Controls.Add(this.xMaskComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(558, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 152);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose masks";
            // 
            // yMaskComboBox
            // 
            this.yMaskComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yMaskComboBox.FormattingEnabled = true;
            this.yMaskComboBox.Location = new System.Drawing.Point(30, 44);
            this.yMaskComboBox.Name = "yMaskComboBox";
            this.yMaskComboBox.Size = new System.Drawing.Size(194, 21);
            this.yMaskComboBox.TabIndex = 3;
            this.yMaskComboBox.SelectedIndexChanged += new System.EventHandler(this.yMaskComboBox_SelectedIndexChanged);
            // 
            // xMaskComboBox
            // 
            this.xMaskComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xMaskComboBox.FormattingEnabled = true;
            this.xMaskComboBox.Location = new System.Drawing.Point(30, 17);
            this.xMaskComboBox.Name = "xMaskComboBox";
            this.xMaskComboBox.Size = new System.Drawing.Size(194, 21);
            this.xMaskComboBox.TabIndex = 2;
            this.xMaskComboBox.SelectedIndexChanged += new System.EventHandler(this.xMaskComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cutRadioButton);
            this.groupBox2.Controls.Add(this.trivalentRadioButton);
            this.groupBox2.Controls.Add(this.rescaleRangeRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(558, 265);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 93);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scaling Method";
            // 
            // cutRadioButton
            // 
            this.cutRadioButton.AutoSize = true;
            this.cutRadioButton.Location = new System.Drawing.Point(7, 68);
            this.cutRadioButton.Name = "cutRadioButton";
            this.cutRadioButton.Size = new System.Drawing.Size(75, 17);
            this.cutRadioButton.TabIndex = 2;
            this.cutRadioButton.TabStop = true;
            this.cutRadioButton.Text = "Cut values";
            this.cutRadioButton.UseVisualStyleBackColor = true;
            this.cutRadioButton.CheckedChanged += new System.EventHandler(this.cutRadioButton_CheckedChanged);
            // 
            // trivalentRadioButton
            // 
            this.trivalentRadioButton.AutoSize = true;
            this.trivalentRadioButton.Location = new System.Drawing.Point(7, 44);
            this.trivalentRadioButton.Name = "trivalentRadioButton";
            this.trivalentRadioButton.Size = new System.Drawing.Size(66, 17);
            this.trivalentRadioButton.TabIndex = 1;
            this.trivalentRadioButton.TabStop = true;
            this.trivalentRadioButton.Text = "Trivalent";
            this.trivalentRadioButton.UseVisualStyleBackColor = true;
            this.trivalentRadioButton.CheckedChanged += new System.EventHandler(this.trivalentRadioButton_CheckedChanged);
            // 
            // rescaleRangeRadioButton
            // 
            this.rescaleRangeRadioButton.AutoSize = true;
            this.rescaleRangeRadioButton.Location = new System.Drawing.Point(7, 20);
            this.rescaleRangeRadioButton.Name = "rescaleRangeRadioButton";
            this.rescaleRangeRadioButton.Size = new System.Drawing.Size(99, 17);
            this.rescaleRangeRadioButton.TabIndex = 0;
            this.rescaleRangeRadioButton.TabStop = true;
            this.rescaleRangeRadioButton.Text = "Rescale Range";
            this.rescaleRangeRadioButton.UseVisualStyleBackColor = true;
            this.rescaleRangeRadioButton.CheckedChanged += new System.EventHandler(this.rescaleRangeRadioButton_CheckedChanged);
            // 
            // GradientFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imagePictureBox);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox3);
            this.Name = "GradientFilterForm";
            this.Text = "GradientFilterForm";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton ignoreEdgesRadioButton;
        private System.Windows.Forms.RadioButton duplicateRadioButton;
        private System.Windows.Forms.RadioButton useExistingRadioButton;
        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox xMaskComboBox;
        private System.Windows.Forms.ComboBox yMaskComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton cutRadioButton;
        private System.Windows.Forms.RadioButton trivalentRadioButton;
        private System.Windows.Forms.RadioButton rescaleRangeRadioButton;
    }
}