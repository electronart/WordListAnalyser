/*
 * Created by SharpDevelop.
 * User: User
 * Date: 14/05/2012
 * Time: 15:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace WordListAnalyser2
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpentoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelElapsedTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelDiffCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMin = new System.Windows.Forms.NumericUpDown();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.labelFileBName = new System.Windows.Forms.Label();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.labelInverseMeanMHD = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.labelSSM = new System.Windows.Forms.Label();
            this.labelConflationClassSize = new System.Windows.Forms.Label();
            this.labelCompressionFactor = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelMeanLengthB = new System.Windows.Forms.Label();
            this.labelMeanLengthA = new System.Windows.Forms.Label();
            this.labelMeanCharsRemoved = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.StemmingErrorGroupBox = new System.Windows.Forms.GroupBox();
            this.labelERRTSOnly = new System.Windows.Forms.Label();
            this.labelSWSOnly = new System.Windows.Forms.Label();
            this.labelOverStemSOnlyL = new System.Windows.Forms.Label();
            this.labelOverStemSOnlyG = new System.Windows.Forms.Label();
            this.labelUnderStemSOnly = new System.Windows.Forms.Label();
            this.labelERRTSW = new System.Windows.Forms.Label();
            this.labelSWSW = new System.Windows.Forms.Label();
            this.labelOverStenSWL = new System.Windows.Forms.Label();
            this.labelOverStemSWG = new System.Windows.Forms.Label();
            this.labelUnderStemSW = new System.Windows.Forms.Label();
            this.labelErrorCountTitle = new System.Windows.Forms.Label();
            this.labelOIL = new System.Windows.Forms.Label();
            this.labelERRT = new System.Windows.Forms.Label();
            this.labelSW = new System.Windows.Forms.Label();
            this.labelOIG = new System.Windows.Forms.Label();
            this.labelUI = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelFileAName = new System.Windows.Forms.Label();
            this.groupBoxInputs = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.StemmingErrorGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxInputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStripMain.Size = new System.Drawing.Size(968, 28);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.TabStop = true;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpentoolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // OpentoolStripMenuItem
            // 
            this.OpentoolStripMenuItem.Name = "OpentoolStripMenuItem";
            this.OpentoolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpentoolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.OpentoolStripMenuItem.Text = "&Open...";
            this.OpentoolStripMenuItem.Click += new System.EventHandler(this.OpentoolStripMenuItemClick);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.optionsToolStripMenuItem.Text = "&Preferences";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripSeparator1,
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(53, 24);
            this.toolStripMenuItem1.Text = "&Help";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.toolStripMenuItem2.Size = new System.Drawing.Size(170, 26);
            this.toolStripMenuItem2.Text = "WebHelp";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem3.Image")));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(170, 26);
            this.toolStripMenuItem3.Text = "&About";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabelElapsedTime,
            this.toolStripStatusLabelSpring,
            this.toolStripStatusLabelVersion});
            this.statusStripMain.Location = new System.Drawing.Point(0, 816);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStripMain.Size = new System.Drawing.Size(968, 26);
            this.statusStripMain.SizingGrip = false;
            this.statusStripMain.TabIndex = 2;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(333, 20);
            this.toolStripProgressBar1.Click += new System.EventHandler(this.ToolStripProgressBar1Click);
            // 
            // toolStripStatusLabelElapsedTime
            // 
            this.toolStripStatusLabelElapsedTime.Name = "toolStripStatusLabelElapsedTime";
            this.toolStripStatusLabelElapsedTime.Size = new System.Drawing.Size(0, 21);
            // 
            // toolStripStatusLabelSpring
            // 
            this.toolStripStatusLabelSpring.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelSpring.Name = "toolStripStatusLabelSpring";
            this.toolStripStatusLabelSpring.Size = new System.Drawing.Size(613, 21);
            this.toolStripStatusLabelSpring.Spring = true;
            // 
            // toolStripStatusLabelVersion
            // 
            this.toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            this.toolStripStatusLabelVersion.Size = new System.Drawing.Size(0, 21);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelDiffCount);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericUpDownMax);
            this.groupBox2.Controls.Add(this.numericUpDownMin);
            this.groupBox2.Location = new System.Drawing.Point(461, 79);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(325, 91);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter Results by Levenshtein Distance";
            // 
            // labelDiffCount
            // 
            this.labelDiffCount.Location = new System.Drawing.Point(13, 59);
            this.labelDiffCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDiffCount.Name = "labelDiffCount";
            this.labelDiffCount.Size = new System.Drawing.Size(304, 25);
            this.labelDiffCount.TabIndex = 7;
            this.labelDiffCount.Text = "Total";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(133, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "to";
            // 
            // numericUpDownMax
            // 
            this.numericUpDownMax.BackColor = System.Drawing.SystemColors.Window;
            this.numericUpDownMax.Location = new System.Drawing.Point(165, 27);
            this.numericUpDownMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownMax.Name = "numericUpDownMax";
            this.numericUpDownMax.ReadOnly = true;
            this.numericUpDownMax.Size = new System.Drawing.Size(56, 22);
            this.numericUpDownMax.TabIndex = 2;
            this.numericUpDownMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownMax.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownMax.ValueChanged += new System.EventHandler(this.NumericUpDownMaxValueChanged);
            this.numericUpDownMax.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NumericUpDownMaxMouseClick);
            // 
            // numericUpDownMin
            // 
            this.numericUpDownMin.BackColor = System.Drawing.SystemColors.Window;
            this.numericUpDownMin.Location = new System.Drawing.Point(69, 27);
            this.numericUpDownMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownMin.Name = "numericUpDownMin";
            this.numericUpDownMin.ReadOnly = true;
            this.numericUpDownMin.Size = new System.Drawing.Size(56, 22);
            this.numericUpDownMin.TabIndex = 0;
            this.numericUpDownMin.ValueChanged += new System.EventHandler(this.NumericUpDownMinValueChanged);
            this.numericUpDownMin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NumericUpDownMinMouseClick);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(827, 769);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(133, 28);
            this.buttonCalculate.TabIndex = 4;
            this.buttonCalculate.Text = "&Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.ButtonCalculateClick);
            // 
            // labelFileBName
            // 
            this.labelFileBName.Location = new System.Drawing.Point(8, 59);
            this.labelFileBName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFileBName.Name = "labelFileBName";
            this.labelFileBName.Size = new System.Drawing.Size(421, 18);
            this.labelFileBName.TabIndex = 9;
            this.labelFileBName.Text = "File B:";
            // 
            // listViewResults
            // 
            this.listViewResults.AllowColumnReorder = true;
            this.listViewResults.AutoArrange = false;
            this.listViewResults.FullRowSelect = true;
            this.listViewResults.LabelWrap = false;
            this.listViewResults.Location = new System.Drawing.Point(13, 177);
            this.listViewResults.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewResults.MultiSelect = false;
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.ShowGroups = false;
            this.listViewResults.Size = new System.Drawing.Size(945, 365);
            this.listViewResults.TabIndex = 3;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            this.listViewResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewResultsColumnClick);
            // 
            // labelInverseMeanMHD
            // 
            this.labelInverseMeanMHD.Location = new System.Drawing.Point(13, 21);
            this.labelInverseMeanMHD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInverseMeanMHD.Name = "labelInverseMeanMHD";
            this.labelInverseMeanMHD.Size = new System.Drawing.Size(304, 17);
            this.labelInverseMeanMHD.TabIndex = 12;
            this.labelInverseMeanMHD.Text = "Inverse Mean MHD";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.saveToolStripButton,
            this.helpToolStripButton,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(968, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripButtonClick);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.saveToolStripButton.Text = "&Save As...";
            this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButtonClick);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.Click += new System.EventHandler(this.HelpToolStripButtonClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // labelSSM
            // 
            this.labelSSM.Location = new System.Drawing.Point(13, 42);
            this.labelSSM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSSM.Name = "labelSSM";
            this.labelSSM.Size = new System.Drawing.Size(304, 17);
            this.labelSSM.TabIndex = 14;
            this.labelSSM.Text = "SSM";
            // 
            // labelConflationClassSize
            // 
            this.labelConflationClassSize.Location = new System.Drawing.Point(21, 21);
            this.labelConflationClassSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConflationClassSize.Name = "labelConflationClassSize";
            this.labelConflationClassSize.Size = new System.Drawing.Size(411, 17);
            this.labelConflationClassSize.TabIndex = 17;
            this.labelConflationClassSize.Text = "Mean Conflation Class Size";
            this.labelConflationClassSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompressionFactor
            // 
            this.labelCompressionFactor.Location = new System.Drawing.Point(21, 42);
            this.labelCompressionFactor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCompressionFactor.Name = "labelCompressionFactor";
            this.labelCompressionFactor.Size = new System.Drawing.Size(411, 17);
            this.labelCompressionFactor.TabIndex = 18;
            this.labelCompressionFactor.Text = "Compression Factor";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelMeanLengthB);
            this.groupBox4.Controls.Add(this.labelMeanLengthA);
            this.groupBox4.Controls.Add(this.labelMeanCharsRemoved);
            this.groupBox4.Controls.Add(this.labelCompressionFactor);
            this.groupBox4.Controls.Add(this.labelConflationClassSize);
            this.groupBox4.Location = new System.Drawing.Point(13, 550);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(440, 142);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            // 
            // labelMeanLengthB
            // 
            this.labelMeanLengthB.Location = new System.Drawing.Point(21, 96);
            this.labelMeanLengthB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMeanLengthB.Name = "labelMeanLengthB";
            this.labelMeanLengthB.Size = new System.Drawing.Size(411, 17);
            this.labelMeanLengthB.TabIndex = 24;
            this.labelMeanLengthB.Text = "List B Mean Word Length";
            // 
            // labelMeanLengthA
            // 
            this.labelMeanLengthA.Location = new System.Drawing.Point(21, 74);
            this.labelMeanLengthA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMeanLengthA.Name = "labelMeanLengthA";
            this.labelMeanLengthA.Size = new System.Drawing.Size(411, 17);
            this.labelMeanLengthA.TabIndex = 0;
            this.labelMeanLengthA.Text = "List A Mean Word Length";
            // 
            // labelMeanCharsRemoved
            // 
            this.labelMeanCharsRemoved.Location = new System.Drawing.Point(21, 118);
            this.labelMeanCharsRemoved.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMeanCharsRemoved.Name = "labelMeanCharsRemoved";
            this.labelMeanCharsRemoved.Size = new System.Drawing.Size(411, 17);
            this.labelMeanCharsRemoved.TabIndex = 19;
            this.labelMeanCharsRemoved.Text = "Mean Characters Removed";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(13, 780);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(133, 28);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClearClick);
            // 
            // StemmingErrorGroupBox
            // 
            this.StemmingErrorGroupBox.Controls.Add(this.labelERRTSOnly);
            this.StemmingErrorGroupBox.Controls.Add(this.labelSWSOnly);
            this.StemmingErrorGroupBox.Controls.Add(this.labelOverStemSOnlyL);
            this.StemmingErrorGroupBox.Controls.Add(this.labelOverStemSOnlyG);
            this.StemmingErrorGroupBox.Controls.Add(this.labelUnderStemSOnly);
            this.StemmingErrorGroupBox.Controls.Add(this.labelERRTSW);
            this.StemmingErrorGroupBox.Controls.Add(this.labelSWSW);
            this.StemmingErrorGroupBox.Controls.Add(this.labelOverStenSWL);
            this.StemmingErrorGroupBox.Controls.Add(this.labelOverStemSWG);
            this.StemmingErrorGroupBox.Controls.Add(this.labelUnderStemSW);
            this.StemmingErrorGroupBox.Controls.Add(this.labelErrorCountTitle);
            this.StemmingErrorGroupBox.Controls.Add(this.labelOIL);
            this.StemmingErrorGroupBox.Controls.Add(this.labelERRT);
            this.StemmingErrorGroupBox.Controls.Add(this.labelSW);
            this.StemmingErrorGroupBox.Controls.Add(this.labelOIG);
            this.StemmingErrorGroupBox.Controls.Add(this.labelUI);
            this.StemmingErrorGroupBox.Location = new System.Drawing.Point(461, 555);
            this.StemmingErrorGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StemmingErrorGroupBox.Name = "StemmingErrorGroupBox";
            this.StemmingErrorGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StemmingErrorGroupBox.Size = new System.Drawing.Size(497, 183);
            this.StemmingErrorGroupBox.TabIndex = 21;
            this.StemmingErrorGroupBox.TabStop = false;
            this.StemmingErrorGroupBox.Text = "Stemming Error Count";
            // 
            // labelERRTSOnly
            // 
            this.labelERRTSOnly.Location = new System.Drawing.Point(196, 132);
            this.labelERRTSOnly.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelERRTSOnly.Name = "labelERRTSOnly";
            this.labelERRTSOnly.Size = new System.Drawing.Size(129, 17);
            this.labelERRTSOnly.TabIndex = 15;
            this.labelERRTSOnly.Text = "ERRT";
            // 
            // labelSWSOnly
            // 
            this.labelSWSOnly.Location = new System.Drawing.Point(196, 154);
            this.labelSWSOnly.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSWSOnly.Name = "labelSWSOnly";
            this.labelSWSOnly.Size = new System.Drawing.Size(129, 17);
            this.labelSWSOnly.TabIndex = 14;
            this.labelSWSOnly.Text = "SW";
            // 
            // labelOverStemSOnlyL
            // 
            this.labelOverStemSOnlyL.Location = new System.Drawing.Point(196, 107);
            this.labelOverStemSOnlyL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOverStemSOnlyL.Name = "labelOverStemSOnlyL";
            this.labelOverStemSOnlyL.Size = new System.Drawing.Size(129, 17);
            this.labelOverStemSOnlyL.TabIndex = 13;
            this.labelOverStemSOnlyL.Text = "Over Stemming Index";
            // 
            // labelOverStemSOnlyG
            // 
            this.labelOverStemSOnlyG.Location = new System.Drawing.Point(196, 82);
            this.labelOverStemSOnlyG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOverStemSOnlyG.Name = "labelOverStemSOnlyG";
            this.labelOverStemSOnlyG.Size = new System.Drawing.Size(129, 17);
            this.labelOverStemSOnlyG.TabIndex = 12;
            this.labelOverStemSOnlyG.Text = "Over Stemming Index";
            // 
            // labelUnderStemSOnly
            // 
            this.labelUnderStemSOnly.Location = new System.Drawing.Point(196, 58);
            this.labelUnderStemSOnly.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUnderStemSOnly.Name = "labelUnderStemSOnly";
            this.labelUnderStemSOnly.Size = new System.Drawing.Size(129, 17);
            this.labelUnderStemSOnly.TabIndex = 11;
            this.labelUnderStemSOnly.Text = "Under Stemming Index";
            // 
            // labelERRTSW
            // 
            this.labelERRTSW.Location = new System.Drawing.Point(333, 132);
            this.labelERRTSW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelERRTSW.Name = "labelERRTSW";
            this.labelERRTSW.Size = new System.Drawing.Size(157, 17);
            this.labelERRTSW.TabIndex = 10;
            this.labelERRTSW.Text = "ERRT";
            // 
            // labelSWSW
            // 
            this.labelSWSW.Location = new System.Drawing.Point(333, 154);
            this.labelSWSW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSWSW.Name = "labelSWSW";
            this.labelSWSW.Size = new System.Drawing.Size(157, 17);
            this.labelSWSW.TabIndex = 9;
            this.labelSWSW.Text = "SW";
            // 
            // labelOverStenSWL
            // 
            this.labelOverStenSWL.Location = new System.Drawing.Point(335, 107);
            this.labelOverStenSWL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOverStenSWL.Name = "labelOverStenSWL";
            this.labelOverStenSWL.Size = new System.Drawing.Size(156, 17);
            this.labelOverStenSWL.TabIndex = 8;
            this.labelOverStenSWL.Text = "Over Stemming Index";
            // 
            // labelOverStemSWG
            // 
            this.labelOverStemSWG.Location = new System.Drawing.Point(333, 82);
            this.labelOverStemSWG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOverStemSWG.Name = "labelOverStemSWG";
            this.labelOverStemSWG.Size = new System.Drawing.Size(157, 17);
            this.labelOverStemSWG.TabIndex = 7;
            this.labelOverStemSWG.Text = "Over Stemming Index";
            // 
            // labelUnderStemSW
            // 
            this.labelUnderStemSW.Location = new System.Drawing.Point(333, 58);
            this.labelUnderStemSW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUnderStemSW.Name = "labelUnderStemSW";
            this.labelUnderStemSW.Size = new System.Drawing.Size(157, 17);
            this.labelUnderStemSW.TabIndex = 6;
            this.labelUnderStemSW.Text = "Under Stemming Index";
            // 
            // labelErrorCountTitle
            // 
            this.labelErrorCountTitle.Location = new System.Drawing.Point(161, 20);
            this.labelErrorCountTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelErrorCountTitle.Name = "labelErrorCountTitle";
            this.labelErrorCountTitle.Size = new System.Drawing.Size(304, 17);
            this.labelErrorCountTitle.TabIndex = 5;
            this.labelErrorCountTitle.Text = "Strong                     Strong + Weak";
            this.labelErrorCountTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelOIL
            // 
            this.labelOIL.Location = new System.Drawing.Point(9, 107);
            this.labelOIL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOIL.Name = "labelOIL";
            this.labelOIL.Size = new System.Drawing.Size(177, 17);
            this.labelOIL.TabIndex = 4;
            this.labelOIL.Text = "Over Stemming Index (L)";
            // 
            // labelERRT
            // 
            this.labelERRT.Location = new System.Drawing.Point(8, 132);
            this.labelERRT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelERRT.Name = "labelERRT";
            this.labelERRT.Size = new System.Drawing.Size(177, 17);
            this.labelERRT.TabIndex = 3;
            this.labelERRT.Text = "ERRT";
            // 
            // labelSW
            // 
            this.labelSW.Location = new System.Drawing.Point(9, 154);
            this.labelSW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSW.Name = "labelSW";
            this.labelSW.Size = new System.Drawing.Size(177, 17);
            this.labelSW.TabIndex = 2;
            this.labelSW.Text = "SW ";
            // 
            // labelOIG
            // 
            this.labelOIG.Location = new System.Drawing.Point(9, 82);
            this.labelOIG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOIG.Name = "labelOIG";
            this.labelOIG.Size = new System.Drawing.Size(177, 17);
            this.labelOIG.TabIndex = 1;
            this.labelOIG.Text = "Over Stemming Index (G)";
            // 
            // labelUI
            // 
            this.labelUI.Location = new System.Drawing.Point(9, 58);
            this.labelUI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUI.Name = "labelUI";
            this.labelUI.Size = new System.Drawing.Size(177, 17);
            this.labelUI.TabIndex = 0;
            this.labelUI.Text = "Under Stemming Index";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelInverseMeanMHD);
            this.groupBox3.Controls.Add(this.labelSSM);
            this.groupBox3.Location = new System.Drawing.Point(13, 700);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(331, 73);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Similarity";
            // 
            // labelFileAName
            // 
            this.labelFileAName.Location = new System.Drawing.Point(8, 23);
            this.labelFileAName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFileAName.Name = "labelFileAName";
            this.labelFileAName.Size = new System.Drawing.Size(421, 18);
            this.labelFileAName.TabIndex = 20;
            this.labelFileAName.Text = "File A:";
            // 
            // groupBoxInputs
            // 
            this.groupBoxInputs.Controls.Add(this.labelFileBName);
            this.groupBoxInputs.Controls.Add(this.labelFileAName);
            this.groupBoxInputs.Location = new System.Drawing.Point(16, 79);
            this.groupBoxInputs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxInputs.Name = "groupBoxInputs";
            this.groupBoxInputs.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxInputs.Size = new System.Drawing.Size(437, 91);
            this.groupBoxInputs.TabIndex = 21;
            this.groupBoxInputs.TabStop = false;
            this.groupBoxInputs.Text = "Word List File Names [Word Count] [Unique Words]";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1ProgressChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 842);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.groupBoxInputs);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.StemmingErrorGroupBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Analyser";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMin)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.StemmingErrorGroupBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBoxInputs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Label labelERRT;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelElapsedTime;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label labelMeanLengthA;
		private System.Windows.Forms.Label labelMeanLengthB;
		private System.Windows.Forms.Label labelSW;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStripMain;
		private System.Windows.Forms.ToolStripMenuItem OpentoolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDownMax;
		private System.Windows.Forms.NumericUpDown numericUpDownMin;
		private System.Windows.Forms.Button buttonCalculate;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpring;
		private System.Windows.Forms.Label labelDiffCount;
		private System.Windows.Forms.Label labelFileBName;
		private System.Windows.Forms.ListView listViewResults;
		private System.Windows.Forms.Label labelInverseMeanMHD;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.Label labelSSM;
		private System.Windows.Forms.Label labelCompressionFactor;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.Label labelConflationClassSize;
		private System.Windows.Forms.GroupBox StemmingErrorGroupBox;
		private System.Windows.Forms.Label labelUI;
		private System.Windows.Forms.Label labelOIG;
		//pStemmingIndicesstem.Windows.Forms.Label labelOI;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.Label labelMeanCharsRemoved;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBoxInputs;
		private System.Windows.Forms.Label labelFileAName;
		private System.Windows.Forms.ToolStripButton helpToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
		private System.Windows.Forms.Label labelERRTSW;
		private System.Windows.Forms.Label labelSWSW;
		private System.Windows.Forms.Label labelOverStenSWL;
		private System.Windows.Forms.Label labelOverStemSWG;
		private System.Windows.Forms.Label labelUnderStemSW;
		private System.Windows.Forms.Label labelErrorCountTitle;
		private System.Windows.Forms.Label labelOIL;
		private System.Windows.Forms.Label labelERRTSOnly;
		private System.Windows.Forms.Label labelSWSOnly;
		private System.Windows.Forms.Label labelOverStemSOnlyL;
		private System.Windows.Forms.Label labelOverStemSOnlyG;
		private System.Windows.Forms.Label labelUnderStemSOnly;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		//private System.Windows.Forms.ProgressStrip ProgressBar1;
		//private System.Windows.Forms.Label labelCompressionFactor;
		//private System.Windows.Forms.Label labelAUnique;
		//private System.Windows.Forms.Label label4;
		//private System.Windows.Forms.ToolStrip toolStrip1;
		//private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		//private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		//private System.Windows.Forms.Label label3;
		//private System.Windows.Forms.Label label2;
		//private System.Windows.Forms.ListView listViewResults;
		//private System.Windows.Forms.Label labelFileBName;
		//private System.Windows.Forms.Label labelDiffCount;
		//private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpring;
		//private System.Windows.Forms.Button buttonList;
		//private System.Windows.Forms.NumericUpDown numericUpDownMin;
		//private System.Windows.Forms.NumericUpDown numericUpDownMax;
		//private System.Windows.Forms.Label label1;
		//private System.Windows.Forms.GroupBox groupBox2;
		//private System.Windows.Forms.GroupBox groupBox1;
		//private System.Windows.Forms.ToolStripMenuItem OpentoolStripMenuItem;
		//private System.Windows.Forms.StatusStrip statusStripMain;
		//private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		//private System.Windows.Forms.MenuStrip menuStripMain;
		//private System.Windows.Forms.OpenFileDialog openFileDialog1;
		
		
		
		
		
		
		
		
		
		
		
		
		
		void ToolStripProgressBar1Click(object sender, System.EventArgs e)
		{
			// TODO: Implement ToolStripProgressBar1Click
		}
	
	}
}
