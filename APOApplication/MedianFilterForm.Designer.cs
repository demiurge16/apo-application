namespace APOApplication
{
    partial class MedianFilterForm
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
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskHeightComboBox = new System.Windows.Forms.ComboBox();
            this.maskWidthComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.previewButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ignoreEdgesRadioButton = new System.Windows.Forms.RadioButton();
            this.duplicateRadioButton = new System.Windows.Forms.RadioButton();
            this.useExistingRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePictureBox.Location = new System.Drawing.Point(13, 13);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(521, 450);
            this.imagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagePictureBox.TabIndex = 0;
            this.imagePictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.maskHeightComboBox);
            this.groupBox1.Controls.Add(this.maskWidthComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(540, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 174);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Define mask size";
            // 
            // maskHeightComboBox
            // 
            this.maskHeightComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maskHeightComboBox.FormattingEnabled = true;
            this.maskHeightComboBox.Location = new System.Drawing.Point(55, 45);
            this.maskHeightComboBox.Name = "maskHeightComboBox";
            this.maskHeightComboBox.Size = new System.Drawing.Size(169, 21);
            this.maskHeightComboBox.TabIndex = 3;
            this.maskHeightComboBox.SelectedIndexChanged += new System.EventHandler(this.maskHeightComboBox_SelectedIndexChanged);
            // 
            // maskWidthComboBox
            // 
            this.maskWidthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maskWidthComboBox.FormattingEnabled = true;
            this.maskWidthComboBox.Location = new System.Drawing.Point(55, 17);
            this.maskWidthComboBox.Name = "maskWidthComboBox";
            this.maskWidthComboBox.Size = new System.Drawing.Size(169, 21);
            this.maskWidthComboBox.TabIndex = 2;
            this.maskWidthComboBox.SelectedIndexChanged += new System.EventHandler(this.maskWidthComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Width:";
            // 
            // previewButton
            // 
            this.previewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previewButton.Location = new System.Drawing.Point(540, 441);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(108, 23);
            this.previewButton.TabIndex = 5;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(662, 441);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 23);
            this.saveButton.TabIndex = 7;
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
            this.groupBox3.Location = new System.Drawing.Point(540, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 88);
            this.groupBox3.TabIndex = 6;
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
            // MedianFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 475);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imagePictureBox);
            this.Name = "MedianFilterForm";
            this.Text = "MedianFilterForm";
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox maskHeightComboBox;
        private System.Windows.Forms.ComboBox maskWidthComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton ignoreEdgesRadioButton;
        private System.Windows.Forms.RadioButton duplicateRadioButton;
        private System.Windows.Forms.RadioButton useExistingRadioButton;
    }
}