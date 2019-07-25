namespace APOApplication
{
    partial class ImageForm
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
            this.histogramView = new OxyPlot.WindowsForms.PlotView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsCsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsXlsxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizeHeuresticMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizeRandomMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalizeMeanMethodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morphologicalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rhombusOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rhombusCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rhombusErodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareErodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rhombusDilateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareDilateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watershedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thinningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posterizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binarizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lUTModificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arithmeticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logicalANDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logicalORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logicalXORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.divisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.differenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maskFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kirschCompassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prewittCompassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.huffmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lZWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bTCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x16ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x32ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boundaryFollowingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turtleAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePictureBox.Location = new System.Drawing.Point(14, 27);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(529, 411);
            this.imagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagePictureBox.TabIndex = 0;
            this.imagePictureBox.TabStop = false;
            // 
            // histogramView
            // 
            this.histogramView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.histogramView.Location = new System.Drawing.Point(549, 27);
            this.histogramView.Name = "histogramView";
            this.histogramView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.histogramView.Size = new System.Drawing.Size(239, 162);
            this.histogramView.TabIndex = 1;
            this.histogramView.Text = "plotView1";
            this.histogramView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.histogramView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.histogramView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.morphologicalToolStripMenuItem,
            this.tresholdingToolStripMenuItem,
            this.arithmeticsToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.compressionToolStripMenuItem,
            this.boundaryFollowingToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(814, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsCsvToolStripMenuItem,
            this.saveAsXlsxToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsCsvToolStripMenuItem
            // 
            this.saveAsCsvToolStripMenuItem.Name = "saveAsCsvToolStripMenuItem";
            this.saveAsCsvToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.saveAsCsvToolStripMenuItem.Text = "Save as csv";
            // 
            // saveAsXlsxToolStripMenuItem
            // 
            this.saveAsXlsxToolStripMenuItem.Name = "saveAsXlsxToolStripMenuItem";
            this.saveAsXlsxToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.saveAsXlsxToolStripMenuItem.Text = "Save as xlsx";
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stretchToolStripMenuItem,
            this.equalizeToolStripMenuItem,
            this.equalizeHeuresticMethodToolStripMenuItem,
            this.equalizeRandomMethodToolStripMenuItem,
            this.equalizeMeanMethodToolStripMenuItem});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // stretchToolStripMenuItem
            // 
            this.stretchToolStripMenuItem.Name = "stretchToolStripMenuItem";
            this.stretchToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.stretchToolStripMenuItem.Text = "Stretch";
            this.stretchToolStripMenuItem.Click += new System.EventHandler(this.stretchToolStripMenuItem_Click);
            // 
            // equalizeToolStripMenuItem
            // 
            this.equalizeToolStripMenuItem.Name = "equalizeToolStripMenuItem";
            this.equalizeToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.equalizeToolStripMenuItem.Text = "Equalize";
            this.equalizeToolStripMenuItem.Click += new System.EventHandler(this.equalizeToolStripMenuItem_Click);
            // 
            // equalizeHeuresticMethodToolStripMenuItem
            // 
            this.equalizeHeuresticMethodToolStripMenuItem.Name = "equalizeHeuresticMethodToolStripMenuItem";
            this.equalizeHeuresticMethodToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.equalizeHeuresticMethodToolStripMenuItem.Text = "Equalize (Heurestic Method)";
            this.equalizeHeuresticMethodToolStripMenuItem.Click += new System.EventHandler(this.equalizeHeuresticMethodToolStripMenuItem_Click);
            // 
            // equalizeRandomMethodToolStripMenuItem
            // 
            this.equalizeRandomMethodToolStripMenuItem.Name = "equalizeRandomMethodToolStripMenuItem";
            this.equalizeRandomMethodToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.equalizeRandomMethodToolStripMenuItem.Text = "Equalize (Random Method)";
            this.equalizeRandomMethodToolStripMenuItem.Click += new System.EventHandler(this.equalizeRandomMethodToolStripMenuItem_Click);
            // 
            // equalizeMeanMethodToolStripMenuItem
            // 
            this.equalizeMeanMethodToolStripMenuItem.Name = "equalizeMeanMethodToolStripMenuItem";
            this.equalizeMeanMethodToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.equalizeMeanMethodToolStripMenuItem.Text = "Equalize (Mean Method)";
            this.equalizeMeanMethodToolStripMenuItem.Click += new System.EventHandler(this.equalizeMeanMethodToolStripMenuItem_Click);
            // 
            // morphologicalToolStripMenuItem
            // 
            this.morphologicalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.erodeToolStripMenuItem,
            this.dilateToolStripMenuItem,
            this.watershedToolStripMenuItem,
            this.thinningToolStripMenuItem});
            this.morphologicalToolStripMenuItem.Name = "morphologicalToolStripMenuItem";
            this.morphologicalToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.morphologicalToolStripMenuItem.Text = "Morphological";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rhombusOpenToolStripMenuItem,
            this.squareOpenToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // rhombusOpenToolStripMenuItem
            // 
            this.rhombusOpenToolStripMenuItem.Name = "rhombusOpenToolStripMenuItem";
            this.rhombusOpenToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.rhombusOpenToolStripMenuItem.Text = "Rhombus";
            this.rhombusOpenToolStripMenuItem.Click += new System.EventHandler(this.rhombusOpenToolStripMenuItem_Click);
            // 
            // squareOpenToolStripMenuItem
            // 
            this.squareOpenToolStripMenuItem.Name = "squareOpenToolStripMenuItem";
            this.squareOpenToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.squareOpenToolStripMenuItem.Text = "Square";
            this.squareOpenToolStripMenuItem.Click += new System.EventHandler(this.squareOpenToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rhombusCloseToolStripMenuItem,
            this.squareCloseToolStripMenuItem});
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // rhombusCloseToolStripMenuItem
            // 
            this.rhombusCloseToolStripMenuItem.Name = "rhombusCloseToolStripMenuItem";
            this.rhombusCloseToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.rhombusCloseToolStripMenuItem.Text = "Rhombus";
            this.rhombusCloseToolStripMenuItem.Click += new System.EventHandler(this.rhombusCloseToolStripMenuItem_Click);
            // 
            // squareCloseToolStripMenuItem
            // 
            this.squareCloseToolStripMenuItem.Name = "squareCloseToolStripMenuItem";
            this.squareCloseToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.squareCloseToolStripMenuItem.Text = "Square";
            this.squareCloseToolStripMenuItem.Click += new System.EventHandler(this.squareCloseToolStripMenuItem_Click);
            // 
            // erodeToolStripMenuItem
            // 
            this.erodeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rhombusErodeToolStripMenuItem,
            this.squareErodeToolStripMenuItem});
            this.erodeToolStripMenuItem.Name = "erodeToolStripMenuItem";
            this.erodeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.erodeToolStripMenuItem.Text = "Erode";
            // 
            // rhombusErodeToolStripMenuItem
            // 
            this.rhombusErodeToolStripMenuItem.Name = "rhombusErodeToolStripMenuItem";
            this.rhombusErodeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.rhombusErodeToolStripMenuItem.Text = "Rhombus";
            this.rhombusErodeToolStripMenuItem.Click += new System.EventHandler(this.rhombusErodeToolStripMenuItem_Click);
            // 
            // squareErodeToolStripMenuItem
            // 
            this.squareErodeToolStripMenuItem.Name = "squareErodeToolStripMenuItem";
            this.squareErodeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.squareErodeToolStripMenuItem.Text = "Square";
            this.squareErodeToolStripMenuItem.Click += new System.EventHandler(this.squareErodeToolStripMenuItem_Click);
            // 
            // dilateToolStripMenuItem
            // 
            this.dilateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rhombusDilateToolStripMenuItem,
            this.squareDilateToolStripMenuItem});
            this.dilateToolStripMenuItem.Name = "dilateToolStripMenuItem";
            this.dilateToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.dilateToolStripMenuItem.Text = "Dilate";
            // 
            // rhombusDilateToolStripMenuItem
            // 
            this.rhombusDilateToolStripMenuItem.Name = "rhombusDilateToolStripMenuItem";
            this.rhombusDilateToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.rhombusDilateToolStripMenuItem.Text = "Rhombus";
            this.rhombusDilateToolStripMenuItem.Click += new System.EventHandler(this.rhombusDilateToolStripMenuItem_Click);
            // 
            // squareDilateToolStripMenuItem
            // 
            this.squareDilateToolStripMenuItem.Name = "squareDilateToolStripMenuItem";
            this.squareDilateToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.squareDilateToolStripMenuItem.Text = "Square";
            this.squareDilateToolStripMenuItem.Click += new System.EventHandler(this.squareDilateToolStripMenuItem_Click);
            // 
            // watershedToolStripMenuItem
            // 
            this.watershedToolStripMenuItem.Name = "watershedToolStripMenuItem";
            this.watershedToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.watershedToolStripMenuItem.Text = "Watershed";
            this.watershedToolStripMenuItem.Click += new System.EventHandler(this.watershedToolStripMenuItem_Click);
            // 
            // thinningToolStripMenuItem
            // 
            this.thinningToolStripMenuItem.Name = "thinningToolStripMenuItem";
            this.thinningToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.thinningToolStripMenuItem.Text = "Thinning";
            this.thinningToolStripMenuItem.Click += new System.EventHandler(this.thinningToolStripMenuItem_Click);
            // 
            // tresholdingToolStripMenuItem
            // 
            this.tresholdingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.posterizeToolStripMenuItem,
            this.binarizeToolStripMenuItem,
            this.lUTModificationToolStripMenuItem,
            this.stretchingToolStripMenuItem,
            this.advancedToolStripMenuItem});
            this.tresholdingToolStripMenuItem.Name = "tresholdingToolStripMenuItem";
            this.tresholdingToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.tresholdingToolStripMenuItem.Text = "Tresholding";
            // 
            // posterizeToolStripMenuItem
            // 
            this.posterizeToolStripMenuItem.Name = "posterizeToolStripMenuItem";
            this.posterizeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.posterizeToolStripMenuItem.Text = "Posterize";
            this.posterizeToolStripMenuItem.Click += new System.EventHandler(this.posterizeToolStripMenuItem_Click);
            // 
            // binarizeToolStripMenuItem
            // 
            this.binarizeToolStripMenuItem.Name = "binarizeToolStripMenuItem";
            this.binarizeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.binarizeToolStripMenuItem.Text = "Binarize";
            this.binarizeToolStripMenuItem.Click += new System.EventHandler(this.binarizeToolStripMenuItem_Click);
            // 
            // lUTModificationToolStripMenuItem
            // 
            this.lUTModificationToolStripMenuItem.Name = "lUTModificationToolStripMenuItem";
            this.lUTModificationToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.lUTModificationToolStripMenuItem.Text = "LUT Modification";
            this.lUTModificationToolStripMenuItem.Click += new System.EventHandler(this.lUTModificationToolStripMenuItem_Click);
            // 
            // stretchingToolStripMenuItem
            // 
            this.stretchingToolStripMenuItem.Name = "stretchingToolStripMenuItem";
            this.stretchingToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.stretchingToolStripMenuItem.Text = "Stretching";
            this.stretchingToolStripMenuItem.Click += new System.EventHandler(this.stretchingToolStripMenuItem_Click);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.advancedToolStripMenuItem.Text = "Advanced";
            this.advancedToolStripMenuItem.Click += new System.EventHandler(this.advancedToolStripMenuItem_Click);
            // 
            // arithmeticsToolStripMenuItem
            // 
            this.arithmeticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.negateToolStripMenuItem,
            this.logicalANDToolStripMenuItem,
            this.logicalORToolStripMenuItem,
            this.logicalXORToolStripMenuItem,
            this.additionToolStripMenuItem,
            this.subtractionToolStripMenuItem,
            this.multiplicationToolStripMenuItem,
            this.divisionToolStripMenuItem,
            this.differenceToolStripMenuItem});
            this.arithmeticsToolStripMenuItem.Name = "arithmeticsToolStripMenuItem";
            this.arithmeticsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.arithmeticsToolStripMenuItem.Text = "Arithmetics";
            // 
            // negateToolStripMenuItem
            // 
            this.negateToolStripMenuItem.Name = "negateToolStripMenuItem";
            this.negateToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.negateToolStripMenuItem.Text = "Negate";
            this.negateToolStripMenuItem.Click += new System.EventHandler(this.negateToolStripMenuItem_Click);
            // 
            // logicalANDToolStripMenuItem
            // 
            this.logicalANDToolStripMenuItem.Name = "logicalANDToolStripMenuItem";
            this.logicalANDToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.logicalANDToolStripMenuItem.Text = "Logical AND";
            this.logicalANDToolStripMenuItem.Click += new System.EventHandler(this.logicalANDToolStripMenuItem_Click);
            // 
            // logicalORToolStripMenuItem
            // 
            this.logicalORToolStripMenuItem.Name = "logicalORToolStripMenuItem";
            this.logicalORToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.logicalORToolStripMenuItem.Text = "Logical OR";
            this.logicalORToolStripMenuItem.Click += new System.EventHandler(this.logicalORToolStripMenuItem_Click);
            // 
            // logicalXORToolStripMenuItem
            // 
            this.logicalXORToolStripMenuItem.Name = "logicalXORToolStripMenuItem";
            this.logicalXORToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.logicalXORToolStripMenuItem.Text = "Logical XOR";
            this.logicalXORToolStripMenuItem.Click += new System.EventHandler(this.logicalXORToolStripMenuItem_Click);
            // 
            // additionToolStripMenuItem
            // 
            this.additionToolStripMenuItem.Name = "additionToolStripMenuItem";
            this.additionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.additionToolStripMenuItem.Text = "Addition";
            this.additionToolStripMenuItem.Click += new System.EventHandler(this.additionToolStripMenuItem_Click);
            // 
            // subtractionToolStripMenuItem
            // 
            this.subtractionToolStripMenuItem.Name = "subtractionToolStripMenuItem";
            this.subtractionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.subtractionToolStripMenuItem.Text = "Subtraction";
            this.subtractionToolStripMenuItem.Click += new System.EventHandler(this.subtractionToolStripMenuItem_Click);
            // 
            // multiplicationToolStripMenuItem
            // 
            this.multiplicationToolStripMenuItem.Name = "multiplicationToolStripMenuItem";
            this.multiplicationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.multiplicationToolStripMenuItem.Text = "Multiplication";
            this.multiplicationToolStripMenuItem.Click += new System.EventHandler(this.multiplicationToolStripMenuItem_Click);
            // 
            // divisionToolStripMenuItem
            // 
            this.divisionToolStripMenuItem.Name = "divisionToolStripMenuItem";
            this.divisionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.divisionToolStripMenuItem.Text = "Division";
            this.divisionToolStripMenuItem.Click += new System.EventHandler(this.divisionToolStripMenuItem_Click);
            // 
            // differenceToolStripMenuItem
            // 
            this.differenceToolStripMenuItem.Name = "differenceToolStripMenuItem";
            this.differenceToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.differenceToolStripMenuItem.Text = "Difference";
            this.differenceToolStripMenuItem.Click += new System.EventHandler(this.differenceToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.medianToolStripMenuItem,
            this.maskFilterToolStripMenuItem,
            this.gradientFilterToolStripMenuItem,
            this.kirschCompassToolStripMenuItem,
            this.prewittCompassToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // medianToolStripMenuItem
            // 
            this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
            this.medianToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.medianToolStripMenuItem.Text = "Median filter";
            this.medianToolStripMenuItem.Click += new System.EventHandler(this.medianToolStripMenuItem_Click);
            // 
            // maskFilterToolStripMenuItem
            // 
            this.maskFilterToolStripMenuItem.Name = "maskFilterToolStripMenuItem";
            this.maskFilterToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.maskFilterToolStripMenuItem.Text = "Mask filter";
            this.maskFilterToolStripMenuItem.Click += new System.EventHandler(this.maskFilterToolStripMenuItem_Click);
            // 
            // gradientFilterToolStripMenuItem
            // 
            this.gradientFilterToolStripMenuItem.Name = "gradientFilterToolStripMenuItem";
            this.gradientFilterToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.gradientFilterToolStripMenuItem.Text = "Gradient filter";
            this.gradientFilterToolStripMenuItem.Click += new System.EventHandler(this.gradientFilterToolStripMenuItem_Click);
            // 
            // kirschCompassToolStripMenuItem
            // 
            this.kirschCompassToolStripMenuItem.Name = "kirschCompassToolStripMenuItem";
            this.kirschCompassToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.kirschCompassToolStripMenuItem.Text = "Kirsch compass";
            this.kirschCompassToolStripMenuItem.Click += new System.EventHandler(this.kirschCompassToolStripMenuItem_Click);
            // 
            // prewittCompassToolStripMenuItem
            // 
            this.prewittCompassToolStripMenuItem.Name = "prewittCompassToolStripMenuItem";
            this.prewittCompassToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.prewittCompassToolStripMenuItem.Text = "Prewitt compass";
            this.prewittCompassToolStripMenuItem.Click += new System.EventHandler(this.prewittCompassToolStripMenuItem_Click);
            // 
            // compressionToolStripMenuItem
            // 
            this.compressionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.huffmanToolStripMenuItem,
            this.rLEToolStripMenuItem,
            this.lZWToolStripMenuItem,
            this.bTCToolStripMenuItem});
            this.compressionToolStripMenuItem.Name = "compressionToolStripMenuItem";
            this.compressionToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.compressionToolStripMenuItem.Text = "Compression";
            // 
            // huffmanToolStripMenuItem
            // 
            this.huffmanToolStripMenuItem.Name = "huffmanToolStripMenuItem";
            this.huffmanToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.huffmanToolStripMenuItem.Text = "Huffman";
            this.huffmanToolStripMenuItem.Click += new System.EventHandler(this.huffmanToolStripMenuItem_Click);
            // 
            // rLEToolStripMenuItem
            // 
            this.rLEToolStripMenuItem.Name = "rLEToolStripMenuItem";
            this.rLEToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.rLEToolStripMenuItem.Text = "RLE";
            this.rLEToolStripMenuItem.Click += new System.EventHandler(this.rLEToolStripMenuItem_Click);
            // 
            // lZWToolStripMenuItem
            // 
            this.lZWToolStripMenuItem.Name = "lZWToolStripMenuItem";
            this.lZWToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.lZWToolStripMenuItem.Text = "LZW";
            this.lZWToolStripMenuItem.Click += new System.EventHandler(this.lZWToolStripMenuItem_Click);
            // 
            // bTCToolStripMenuItem
            // 
            this.bTCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x4ToolStripMenuItem,
            this.x8ToolStripMenuItem,
            this.x16ToolStripMenuItem,
            this.x32ToolStripMenuItem});
            this.bTCToolStripMenuItem.Name = "bTCToolStripMenuItem";
            this.bTCToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.bTCToolStripMenuItem.Text = "BTC";
            // 
            // x4ToolStripMenuItem
            // 
            this.x4ToolStripMenuItem.Name = "x4ToolStripMenuItem";
            this.x4ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.x4ToolStripMenuItem.Text = "4x4";
            this.x4ToolStripMenuItem.Click += new System.EventHandler(this.x4ToolStripMenuItem_Click);
            // 
            // x8ToolStripMenuItem
            // 
            this.x8ToolStripMenuItem.Name = "x8ToolStripMenuItem";
            this.x8ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.x8ToolStripMenuItem.Text = "8x8";
            this.x8ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
            // 
            // x16ToolStripMenuItem
            // 
            this.x16ToolStripMenuItem.Name = "x16ToolStripMenuItem";
            this.x16ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.x16ToolStripMenuItem.Text = "16x16";
            this.x16ToolStripMenuItem.Click += new System.EventHandler(this.x16ToolStripMenuItem_Click);
            // 
            // x32ToolStripMenuItem
            // 
            this.x32ToolStripMenuItem.Name = "x32ToolStripMenuItem";
            this.x32ToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.x32ToolStripMenuItem.Text = "32x32";
            this.x32ToolStripMenuItem.Click += new System.EventHandler(this.x32ToolStripMenuItem_Click);
            // 
            // boundaryFollowingToolStripMenuItem
            // 
            this.boundaryFollowingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.turtleAlgorithmToolStripMenuItem});
            this.boundaryFollowingToolStripMenuItem.Name = "boundaryFollowingToolStripMenuItem";
            this.boundaryFollowingToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.boundaryFollowingToolStripMenuItem.Text = "Boundary Following";
            // 
            // turtleAlgorithmToolStripMenuItem
            // 
            this.turtleAlgorithmToolStripMenuItem.Name = "turtleAlgorithmToolStripMenuItem";
            this.turtleAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.turtleAlgorithmToolStripMenuItem.Text = "Turtle Algorithm";
            this.turtleAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.turtleAlgorithmToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.histogramView);
            this.Controls.Add(this.imagePictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ImageForm";
            this.Text = "ImageForm";
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imagePictureBox;
        private OxyPlot.WindowsForms.PlotView histogramView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsCsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsXlsxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stretchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalizeHeuresticMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalizeRandomMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalizeMeanMethodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem morphologicalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rhombusOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rhombusCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rhombusErodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareErodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rhombusDilateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareDilateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tresholdingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posterizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binarizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lUTModificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arithmeticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logicalANDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logicalORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logicalXORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem additionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtractionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem divisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem differenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stretchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem watershedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thinningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maskFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradientFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kirschCompassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prewittCompassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem huffmanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rLEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lZWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bTCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x16ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x32ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boundaryFollowingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turtleAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}