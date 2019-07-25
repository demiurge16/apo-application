namespace APOApplication
{
    partial class MaskFilterForm
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
            this.helpButton = new System.Windows.Forms.Button();
            this.maskTextBox = new System.Windows.Forms.TextBox();
            this.defineCustomMaskRadioButton = new System.Windows.Forms.RadioButton();
            this.predefinedMaskComboBox = new System.Windows.Forms.ComboBox();
            this.usePredefinedMaskRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cutRadioButton = new System.Windows.Forms.RadioButton();
            this.trivalentRadioButton = new System.Windows.Forms.RadioButton();
            this.rescaleRangeRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ignoreEdgesRadioButton = new System.Windows.Forms.RadioButton();
            this.duplicateRadioButton = new System.Windows.Forms.RadioButton();
            this.useExistingRadioButton = new System.Windows.Forms.RadioButton();
            this.saveButton = new System.Windows.Forms.Button();
            this.previewButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.imagePictureBox.Size = new System.Drawing.Size(540, 469);
            this.imagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagePictureBox.TabIndex = 0;
            this.imagePictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.helpButton);
            this.groupBox1.Controls.Add(this.maskTextBox);
            this.groupBox1.Controls.Add(this.defineCustomMaskRadioButton);
            this.groupBox1.Controls.Add(this.predefinedMaskComboBox);
            this.groupBox1.Controls.Add(this.usePredefinedMaskRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(560, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 272);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Define mask";
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(134, 69);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(90, 22);
            this.helpButton.TabIndex = 4;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // maskTextBox
            // 
            this.maskTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskTextBox.Location = new System.Drawing.Point(7, 96);
            this.maskTextBox.Multiline = true;
            this.maskTextBox.Name = "maskTextBox";
            this.maskTextBox.Size = new System.Drawing.Size(217, 141);
            this.maskTextBox.TabIndex = 3;
            // 
            // defineCustomMaskRadioButton
            // 
            this.defineCustomMaskRadioButton.AutoSize = true;
            this.defineCustomMaskRadioButton.Location = new System.Drawing.Point(7, 72);
            this.defineCustomMaskRadioButton.Name = "defineCustomMaskRadioButton";
            this.defineCustomMaskRadioButton.Size = new System.Drawing.Size(121, 17);
            this.defineCustomMaskRadioButton.TabIndex = 2;
            this.defineCustomMaskRadioButton.TabStop = true;
            this.defineCustomMaskRadioButton.Text = "Define custom mask";
            this.defineCustomMaskRadioButton.UseVisualStyleBackColor = true;
            this.defineCustomMaskRadioButton.CheckedChanged += new System.EventHandler(this.defineCustomMaskRadioButton_CheckedChanged);
            // 
            // predefinedMaskComboBox
            // 
            this.predefinedMaskComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.predefinedMaskComboBox.FormattingEnabled = true;
            this.predefinedMaskComboBox.Location = new System.Drawing.Point(7, 44);
            this.predefinedMaskComboBox.Name = "predefinedMaskComboBox";
            this.predefinedMaskComboBox.Size = new System.Drawing.Size(217, 21);
            this.predefinedMaskComboBox.TabIndex = 1;
            this.predefinedMaskComboBox.SelectedIndexChanged += new System.EventHandler(this.predefinedMaskComboBox_SelectedIndexChanged);
            // 
            // usePredefinedMaskRadioButton
            // 
            this.usePredefinedMaskRadioButton.AutoSize = true;
            this.usePredefinedMaskRadioButton.Location = new System.Drawing.Point(7, 20);
            this.usePredefinedMaskRadioButton.Name = "usePredefinedMaskRadioButton";
            this.usePredefinedMaskRadioButton.Size = new System.Drawing.Size(125, 17);
            this.usePredefinedMaskRadioButton.TabIndex = 0;
            this.usePredefinedMaskRadioButton.TabStop = true;
            this.usePredefinedMaskRadioButton.Text = "Use predefined mask";
            this.usePredefinedMaskRadioButton.UseVisualStyleBackColor = true;
            this.usePredefinedMaskRadioButton.CheckedChanged += new System.EventHandler(this.usePredefinedMaskRadioButton_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cutRadioButton);
            this.groupBox2.Controls.Add(this.trivalentRadioButton);
            this.groupBox2.Controls.Add(this.rescaleRangeRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(560, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 93);
            this.groupBox2.TabIndex = 2;
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
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.ignoreEdgesRadioButton);
            this.groupBox3.Controls.Add(this.duplicateRadioButton);
            this.groupBox3.Controls.Add(this.useExistingRadioButton);
            this.groupBox3.Location = new System.Drawing.Point(560, 364);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(230, 88);
            this.groupBox3.TabIndex = 3;
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
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(682, 459);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // previewButton
            // 
            this.previewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previewButton.Location = new System.Drawing.Point(560, 459);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(108, 23);
            this.previewButton.TabIndex = 3;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // MaskFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 487);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imagePictureBox);
            this.Name = "MaskFilterForm";
            this.Text = "MaskFilter";
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox predefinedMaskComboBox;
        private System.Windows.Forms.RadioButton usePredefinedMaskRadioButton;
        private System.Windows.Forms.TextBox maskTextBox;
        private System.Windows.Forms.RadioButton defineCustomMaskRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton cutRadioButton;
        private System.Windows.Forms.RadioButton trivalentRadioButton;
        private System.Windows.Forms.RadioButton rescaleRangeRadioButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton ignoreEdgesRadioButton;
        private System.Windows.Forms.RadioButton duplicateRadioButton;
        private System.Windows.Forms.RadioButton useExistingRadioButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button previewButton;
    }
}