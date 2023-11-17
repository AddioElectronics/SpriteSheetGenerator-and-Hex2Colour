namespace SpriteSheetGenerator
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel_Settings = new Panel();
            button_MoveTop = new Button();
            button_MoveBottom = new Button();
            groupBox_Output = new GroupBox();
            button_GenerateVariations = new Button();
            checkBox_EqualSpacing = new CheckBox();
            checkBox_Pack = new CheckBox();
            button_CreateSheet = new Button();
            checkBox_AlignVert = new CheckBox();
            label_PixelFormat = new Label();
            comboBox_PixelFormat = new ComboBox();
            groupBox_Rotations = new GroupBox();
            button_AllRotations = new Button();
            checkBox_Rotate90MX = new CheckBox();
            checkBox_Rotate270MX = new CheckBox();
            checkBox_MirrorY = new CheckBox();
            checkBox_MirrrorX = new CheckBox();
            checkBox_Rotate90 = new CheckBox();
            checkBox_Rotate270 = new CheckBox();
            checkBox_Rotate180 = new CheckBox();
            button_Remove = new Button();
            button_MoveUp = new Button();
            listBox_Paths = new ListBox();
            button_MoveDown = new Button();
            button_Clear = new Button();
            splitContainer_Images = new SplitContainer();
            tableLayoutPanel_Images = new TableLayoutPanel();
            label_ZoomImages = new Label();
            label_Area = new Label();
            label_ImageCount = new Label();
            trackBar_ScaleImages = new TrackBar();
            flowLayoutPanel_Sprites = new FlowLayoutPanel();
            flowLayoutPanel_Generated = new FlowLayoutPanel();
            tableLayoutPanel_Generated = new TableLayoutPanel();
            label_Gen1 = new Label();
            label_Gen0 = new Label();
            label_ZoomGen = new Label();
            trackBar_ScaleSheet = new TrackBar();
            splitter_Sheet = new Splitter();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            hex2ColourToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            notificationsToolStripMenuItem = new ToolStripMenuItem();
            enableNotificationsToolStripMenuItem = new ToolStripMenuItem();
            disableNotificationsToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem1 = new ToolStripMenuItem();
            exportToolStripMenuItem1 = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            toolTip = new ToolTip(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            panel_Settings.SuspendLayout();
            groupBox_Output.SuspendLayout();
            groupBox_Rotations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Images).BeginInit();
            splitContainer_Images.Panel1.SuspendLayout();
            splitContainer_Images.Panel2.SuspendLayout();
            splitContainer_Images.SuspendLayout();
            tableLayoutPanel_Images.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_ScaleImages).BeginInit();
            tableLayoutPanel_Generated.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_ScaleSheet).BeginInit();
            menuStrip.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Settings
            // 
            panel_Settings.BorderStyle = BorderStyle.FixedSingle;
            panel_Settings.Controls.Add(button_MoveTop);
            panel_Settings.Controls.Add(button_MoveBottom);
            panel_Settings.Controls.Add(groupBox_Output);
            panel_Settings.Controls.Add(groupBox_Rotations);
            panel_Settings.Controls.Add(button_Remove);
            panel_Settings.Controls.Add(button_MoveUp);
            panel_Settings.Controls.Add(listBox_Paths);
            panel_Settings.Controls.Add(button_MoveDown);
            panel_Settings.Controls.Add(button_Clear);
            panel_Settings.Dock = DockStyle.Left;
            panel_Settings.Location = new Point(0, 24);
            panel_Settings.Name = "panel_Settings";
            panel_Settings.Size = new Size(498, 737);
            panel_Settings.TabIndex = 0;
            // 
            // button_MoveTop
            // 
            button_MoveTop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_MoveTop.Location = new Point(398, 678);
            button_MoveTop.Name = "button_MoveTop";
            button_MoveTop.Size = new Size(91, 23);
            button_MoveTop.TabIndex = 13;
            button_MoveTop.Text = "Move Top";
            button_MoveTop.UseVisualStyleBackColor = true;
            button_MoveTop.Click += button_MoveTop_Click;
            // 
            // button_MoveBottom
            // 
            button_MoveBottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_MoveBottom.Location = new Point(398, 704);
            button_MoveBottom.Name = "button_MoveBottom";
            button_MoveBottom.Size = new Size(91, 23);
            button_MoveBottom.TabIndex = 14;
            button_MoveBottom.Text = "Move Bottom";
            button_MoveBottom.UseVisualStyleBackColor = true;
            button_MoveBottom.Click += button_MoveBottom_Click;
            // 
            // groupBox_Output
            // 
            groupBox_Output.Controls.Add(button_GenerateVariations);
            groupBox_Output.Controls.Add(checkBox_EqualSpacing);
            groupBox_Output.Controls.Add(checkBox_Pack);
            groupBox_Output.Controls.Add(button_CreateSheet);
            groupBox_Output.Controls.Add(checkBox_AlignVert);
            groupBox_Output.Controls.Add(label_PixelFormat);
            groupBox_Output.Controls.Add(comboBox_PixelFormat);
            groupBox_Output.Location = new Point(280, 3);
            groupBox_Output.Name = "groupBox_Output";
            groupBox_Output.Size = new Size(211, 157);
            groupBox_Output.TabIndex = 12;
            groupBox_Output.TabStop = false;
            groupBox_Output.Text = "Output";
            // 
            // button_GenerateVariations
            // 
            button_GenerateVariations.Enabled = false;
            button_GenerateVariations.Location = new Point(6, 119);
            button_GenerateVariations.Name = "button_GenerateVariations";
            button_GenerateVariations.Size = new Size(98, 30);
            button_GenerateVariations.TabIndex = 17;
            button_GenerateVariations.Text = "Create Variants";
            button_GenerateVariations.UseVisualStyleBackColor = true;
            button_GenerateVariations.Click += button_GenerateVariations_Click;
            // 
            // checkBox_EqualSpacing
            // 
            checkBox_EqualSpacing.AutoSize = true;
            checkBox_EqualSpacing.Location = new Point(6, 47);
            checkBox_EqualSpacing.Name = "checkBox_EqualSpacing";
            checkBox_EqualSpacing.Size = new Size(100, 19);
            checkBox_EqualSpacing.TabIndex = 16;
            checkBox_EqualSpacing.Text = "Equal Spacing";
            toolTip.SetToolTip(checkBox_EqualSpacing, "Each image with its variations will always be separated by the largest height in the group.\r\nIf false they will be drawn directly on top of eachother.");
            checkBox_EqualSpacing.UseVisualStyleBackColor = true;
            // 
            // checkBox_Pack
            // 
            checkBox_Pack.AutoSize = true;
            checkBox_Pack.Location = new Point(116, 22);
            checkBox_Pack.Name = "checkBox_Pack";
            checkBox_Pack.Size = new Size(89, 19);
            checkBox_Pack.TabIndex = 15;
            checkBox_Pack.Text = "Pack Sprites";
            toolTip.SetToolTip(checkBox_Pack, "Packs all images into the smallest area possible.\r\nDoes not maintain image order.");
            checkBox_Pack.UseVisualStyleBackColor = true;
            checkBox_Pack.CheckedChanged += checkBox_Pack_CheckedChanged;
            // 
            // button_CreateSheet
            // 
            button_CreateSheet.Enabled = false;
            button_CreateSheet.Location = new Point(107, 119);
            button_CreateSheet.Name = "button_CreateSheet";
            button_CreateSheet.Size = new Size(98, 30);
            button_CreateSheet.TabIndex = 14;
            button_CreateSheet.Text = "Create Sheet";
            button_CreateSheet.UseVisualStyleBackColor = true;
            button_CreateSheet.Click += button_CreateSpriteSheet_Click;
            // 
            // checkBox_AlignVert
            // 
            checkBox_AlignVert.AutoSize = true;
            checkBox_AlignVert.Location = new Point(6, 22);
            checkBox_AlignVert.Name = "checkBox_AlignVert";
            checkBox_AlignVert.Size = new Size(104, 19);
            checkBox_AlignVert.TabIndex = 13;
            checkBox_AlignVert.Text = "Align Vertically";
            toolTip.SetToolTip(checkBox_AlignVert, "When set, an image and its generated variations will align vertically on the sheet.\r\n");
            checkBox_AlignVert.UseVisualStyleBackColor = true;
            // 
            // label_PixelFormat
            // 
            label_PixelFormat.AutoSize = true;
            label_PixelFormat.Location = new Point(6, 72);
            label_PixelFormat.Name = "label_PixelFormat";
            label_PixelFormat.Size = new Size(73, 15);
            label_PixelFormat.TabIndex = 12;
            label_PixelFormat.Text = "Pixel Format";
            // 
            // comboBox_PixelFormat
            // 
            comboBox_PixelFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_PixelFormat.FormattingEnabled = true;
            comboBox_PixelFormat.Location = new Point(6, 90);
            comboBox_PixelFormat.Name = "comboBox_PixelFormat";
            comboBox_PixelFormat.Size = new Size(199, 23);
            comboBox_PixelFormat.TabIndex = 6;
            // 
            // groupBox_Rotations
            // 
            groupBox_Rotations.Controls.Add(button_AllRotations);
            groupBox_Rotations.Controls.Add(checkBox_Rotate90MX);
            groupBox_Rotations.Controls.Add(checkBox_Rotate270MX);
            groupBox_Rotations.Controls.Add(checkBox_MirrorY);
            groupBox_Rotations.Controls.Add(checkBox_MirrrorX);
            groupBox_Rotations.Controls.Add(checkBox_Rotate90);
            groupBox_Rotations.Controls.Add(checkBox_Rotate270);
            groupBox_Rotations.Controls.Add(checkBox_Rotate180);
            groupBox_Rotations.Location = new Point(5, 3);
            groupBox_Rotations.Name = "groupBox_Rotations";
            groupBox_Rotations.Size = new Size(269, 157);
            groupBox_Rotations.TabIndex = 11;
            groupBox_Rotations.TabStop = false;
            groupBox_Rotations.Text = "Rotations";
            // 
            // button_AllRotations
            // 
            button_AllRotations.Location = new Point(230, 122);
            button_AllRotations.Name = "button_AllRotations";
            button_AllRotations.Size = new Size(33, 23);
            button_AllRotations.TabIndex = 15;
            button_AllRotations.Text = "All";
            button_AllRotations.UseVisualStyleBackColor = true;
            button_AllRotations.Click += button_AllRotations_Click;
            // 
            // checkBox_Rotate90MX
            // 
            checkBox_Rotate90MX.AutoSize = true;
            checkBox_Rotate90MX.Location = new Point(6, 97);
            checkBox_Rotate90MX.Name = "checkBox_Rotate90MX";
            checkBox_Rotate90MX.Size = new Size(126, 19);
            checkBox_Rotate90MX.TabIndex = 13;
            checkBox_Rotate90MX.Text = "Rotate 90° Mirror X";
            checkBox_Rotate90MX.UseVisualStyleBackColor = true;
            // 
            // checkBox_Rotate270MX
            // 
            checkBox_Rotate270MX.AutoSize = true;
            checkBox_Rotate270MX.Location = new Point(6, 122);
            checkBox_Rotate270MX.Name = "checkBox_Rotate270MX";
            checkBox_Rotate270MX.Size = new Size(132, 19);
            checkBox_Rotate270MX.TabIndex = 14;
            checkBox_Rotate270MX.Text = "Rotate 270° Mirror X";
            checkBox_Rotate270MX.UseVisualStyleBackColor = true;
            // 
            // checkBox_MirrorY
            // 
            checkBox_MirrorY.AutoSize = true;
            checkBox_MirrorY.Location = new Point(170, 47);
            checkBox_MirrorY.Name = "checkBox_MirrorY";
            checkBox_MirrorY.Size = new Size(69, 19);
            checkBox_MirrorY.TabIndex = 12;
            checkBox_MirrorY.Text = "Mirror Y";
            checkBox_MirrorY.UseVisualStyleBackColor = true;
            // 
            // checkBox_MirrrorX
            // 
            checkBox_MirrrorX.AutoSize = true;
            checkBox_MirrrorX.Location = new Point(170, 22);
            checkBox_MirrrorX.Name = "checkBox_MirrrorX";
            checkBox_MirrrorX.Size = new Size(69, 19);
            checkBox_MirrrorX.TabIndex = 11;
            checkBox_MirrrorX.Text = "Mirror X";
            checkBox_MirrrorX.UseVisualStyleBackColor = true;
            // 
            // checkBox_Rotate90
            // 
            checkBox_Rotate90.AutoSize = true;
            checkBox_Rotate90.Location = new Point(6, 22);
            checkBox_Rotate90.Name = "checkBox_Rotate90";
            checkBox_Rotate90.Size = new Size(80, 19);
            checkBox_Rotate90.TabIndex = 7;
            checkBox_Rotate90.Text = "Rotate 90°";
            checkBox_Rotate90.UseVisualStyleBackColor = true;
            // 
            // checkBox_Rotate270
            // 
            checkBox_Rotate270.AutoSize = true;
            checkBox_Rotate270.Location = new Point(6, 72);
            checkBox_Rotate270.Name = "checkBox_Rotate270";
            checkBox_Rotate270.Size = new Size(86, 19);
            checkBox_Rotate270.TabIndex = 10;
            checkBox_Rotate270.Text = "Rotate 270°";
            checkBox_Rotate270.UseVisualStyleBackColor = true;
            // 
            // checkBox_Rotate180
            // 
            checkBox_Rotate180.AutoSize = true;
            checkBox_Rotate180.Location = new Point(6, 47);
            checkBox_Rotate180.Name = "checkBox_Rotate180";
            checkBox_Rotate180.Size = new Size(86, 19);
            checkBox_Rotate180.TabIndex = 9;
            checkBox_Rotate180.Text = "Rotate 180°";
            checkBox_Rotate180.UseVisualStyleBackColor = true;
            // 
            // button_Remove
            // 
            button_Remove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Remove.Location = new Point(5, 678);
            button_Remove.Name = "button_Remove";
            button_Remove.Size = new Size(75, 23);
            button_Remove.TabIndex = 5;
            button_Remove.Text = "Remove";
            button_Remove.UseVisualStyleBackColor = true;
            button_Remove.Click += button_Remove_Click;
            // 
            // button_MoveUp
            // 
            button_MoveUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_MoveUp.Location = new Point(301, 678);
            button_MoveUp.Name = "button_MoveUp";
            button_MoveUp.Size = new Size(91, 23);
            button_MoveUp.TabIndex = 3;
            button_MoveUp.Text = "Move Up";
            button_MoveUp.UseVisualStyleBackColor = true;
            button_MoveUp.Click += button_MoveUp_Click;
            // 
            // listBox_Paths
            // 
            listBox_Paths.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listBox_Paths.BorderStyle = BorderStyle.FixedSingle;
            listBox_Paths.FormattingEnabled = true;
            listBox_Paths.ItemHeight = 15;
            listBox_Paths.Location = new Point(5, 168);
            listBox_Paths.Name = "listBox_Paths";
            listBox_Paths.SelectionMode = SelectionMode.MultiExtended;
            listBox_Paths.Size = new Size(484, 497);
            listBox_Paths.TabIndex = 0;
            listBox_Paths.KeyUp += listBox_Paths_KeyUp;
            // 
            // button_MoveDown
            // 
            button_MoveDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_MoveDown.Location = new Point(301, 704);
            button_MoveDown.Name = "button_MoveDown";
            button_MoveDown.Size = new Size(91, 23);
            button_MoveDown.TabIndex = 4;
            button_MoveDown.Text = "Move Down";
            button_MoveDown.UseVisualStyleBackColor = true;
            button_MoveDown.Click += button_MoveDown_Click;
            // 
            // button_Clear
            // 
            button_Clear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Clear.Location = new Point(5, 704);
            button_Clear.Name = "button_Clear";
            button_Clear.Size = new Size(75, 23);
            button_Clear.TabIndex = 1;
            button_Clear.Text = "Clear";
            button_Clear.UseVisualStyleBackColor = true;
            button_Clear.Click += button_Clear_Click;
            // 
            // splitContainer_Images
            // 
            splitContainer_Images.BorderStyle = BorderStyle.FixedSingle;
            splitContainer_Images.Dock = DockStyle.Fill;
            splitContainer_Images.Location = new Point(498, 24);
            splitContainer_Images.Name = "splitContainer_Images";
            // 
            // splitContainer_Images.Panel1
            // 
            splitContainer_Images.Panel1.Controls.Add(tableLayoutPanel_Images);
            splitContainer_Images.Panel1.Controls.Add(trackBar_ScaleImages);
            splitContainer_Images.Panel1.Controls.Add(flowLayoutPanel_Sprites);
            // 
            // splitContainer_Images.Panel2
            // 
            splitContainer_Images.Panel2.Controls.Add(flowLayoutPanel_Generated);
            splitContainer_Images.Panel2.Controls.Add(tableLayoutPanel_Generated);
            splitContainer_Images.Panel2.Controls.Add(trackBar_ScaleSheet);
            splitContainer_Images.Panel2.Controls.Add(splitter_Sheet);
            splitContainer_Images.Size = new Size(1027, 737);
            splitContainer_Images.SplitterDistance = 285;
            splitContainer_Images.TabIndex = 0;
            // 
            // tableLayoutPanel_Images
            // 
            tableLayoutPanel_Images.ColumnCount = 3;
            tableLayoutPanel_Images.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_Images.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_Images.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_Images.Controls.Add(label_ZoomImages, 2, 0);
            tableLayoutPanel_Images.Controls.Add(label_Area, 1, 0);
            tableLayoutPanel_Images.Controls.Add(label_ImageCount, 0, 0);
            tableLayoutPanel_Images.Dock = DockStyle.Bottom;
            tableLayoutPanel_Images.Location = new Point(0, 663);
            tableLayoutPanel_Images.Name = "tableLayoutPanel_Images";
            tableLayoutPanel_Images.RowCount = 1;
            tableLayoutPanel_Images.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_Images.Size = new Size(283, 27);
            tableLayoutPanel_Images.TabIndex = 8;
            // 
            // label_ZoomImages
            // 
            label_ZoomImages.Anchor = AnchorStyles.Left;
            label_ZoomImages.AutoSize = true;
            label_ZoomImages.Location = new Point(191, 6);
            label_ZoomImages.Name = "label_ZoomImages";
            label_ZoomImages.Size = new Size(63, 15);
            label_ZoomImages.TabIndex = 2;
            label_ZoomImages.Text = "Zoom :  1x";
            // 
            // label_Area
            // 
            label_Area.Anchor = AnchorStyles.Left;
            label_Area.AutoSize = true;
            label_Area.Location = new Point(97, 6);
            label_Area.Name = "label_Area";
            label_Area.Size = new Size(62, 15);
            label_Area.TabIndex = 1;
            label_Area.Text = "Area :  0px";
            // 
            // label_ImageCount
            // 
            label_ImageCount.Anchor = AnchorStyles.Left;
            label_ImageCount.AutoSize = true;
            label_ImageCount.CausesValidation = false;
            label_ImageCount.Location = new Point(3, 6);
            label_ImageCount.Name = "label_ImageCount";
            label_ImageCount.Size = new Size(58, 15);
            label_ImageCount.TabIndex = 0;
            label_ImageCount.Text = "Count  : 0";
            // 
            // trackBar_ScaleImages
            // 
            trackBar_ScaleImages.Dock = DockStyle.Bottom;
            trackBar_ScaleImages.Location = new Point(0, 690);
            trackBar_ScaleImages.Maximum = 100;
            trackBar_ScaleImages.Minimum = 1;
            trackBar_ScaleImages.Name = "trackBar_ScaleImages";
            trackBar_ScaleImages.Size = new Size(283, 45);
            trackBar_ScaleImages.TabIndex = 7;
            trackBar_ScaleImages.TickFrequency = 10;
            trackBar_ScaleImages.Value = 10;
            trackBar_ScaleImages.ValueChanged += trackBar_ScaleImages_ValueChanged;
            // 
            // flowLayoutPanel_Sprites
            // 
            flowLayoutPanel_Sprites.AutoScroll = true;
            flowLayoutPanel_Sprites.Dock = DockStyle.Fill;
            flowLayoutPanel_Sprites.Location = new Point(0, 0);
            flowLayoutPanel_Sprites.Name = "flowLayoutPanel_Sprites";
            flowLayoutPanel_Sprites.Size = new Size(283, 735);
            flowLayoutPanel_Sprites.TabIndex = 0;
            // 
            // flowLayoutPanel_Generated
            // 
            flowLayoutPanel_Generated.AutoScroll = true;
            flowLayoutPanel_Generated.Dock = DockStyle.Fill;
            flowLayoutPanel_Generated.Location = new Point(3, 0);
            flowLayoutPanel_Generated.Name = "flowLayoutPanel_Generated";
            flowLayoutPanel_Generated.Size = new Size(733, 663);
            flowLayoutPanel_Generated.TabIndex = 2;
            // 
            // tableLayoutPanel_Generated
            // 
            tableLayoutPanel_Generated.ColumnCount = 3;
            tableLayoutPanel_Generated.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_Generated.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_Generated.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel_Generated.Controls.Add(label_Gen1, 1, 0);
            tableLayoutPanel_Generated.Controls.Add(label_Gen0, 0, 0);
            tableLayoutPanel_Generated.Controls.Add(label_ZoomGen, 2, 0);
            tableLayoutPanel_Generated.Dock = DockStyle.Bottom;
            tableLayoutPanel_Generated.Location = new Point(3, 663);
            tableLayoutPanel_Generated.Name = "tableLayoutPanel_Generated";
            tableLayoutPanel_Generated.RowCount = 1;
            tableLayoutPanel_Generated.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_Generated.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_Generated.Size = new Size(733, 27);
            tableLayoutPanel_Generated.TabIndex = 6;
            tableLayoutPanel_Generated.Visible = false;
            // 
            // label_Gen1
            // 
            label_Gen1.Anchor = AnchorStyles.Left;
            label_Gen1.AutoSize = true;
            label_Gen1.Location = new Point(247, 6);
            label_Gen1.Name = "label_Gen1";
            label_Gen1.Size = new Size(74, 15);
            label_Gen1.TabIndex = 1;
            label_Gen1.Text = "Height :  0px";
            // 
            // label_Gen0
            // 
            label_Gen0.Anchor = AnchorStyles.Left;
            label_Gen0.AutoSize = true;
            label_Gen0.CausesValidation = false;
            label_Gen0.Location = new Point(3, 6);
            label_Gen0.Name = "label_Gen0";
            label_Gen0.Size = new Size(73, 15);
            label_Gen0.TabIndex = 0;
            label_Gen0.Text = "Width  :  0px";
            // 
            // label_ZoomGen
            // 
            label_ZoomGen.Anchor = AnchorStyles.Left;
            label_ZoomGen.AutoSize = true;
            label_ZoomGen.Location = new Point(491, 6);
            label_ZoomGen.Name = "label_ZoomGen";
            label_ZoomGen.Size = new Size(63, 15);
            label_ZoomGen.TabIndex = 3;
            label_ZoomGen.Text = "Zoom :  1x";
            // 
            // trackBar_ScaleSheet
            // 
            trackBar_ScaleSheet.Dock = DockStyle.Bottom;
            trackBar_ScaleSheet.Location = new Point(3, 690);
            trackBar_ScaleSheet.Maximum = 100;
            trackBar_ScaleSheet.Minimum = 1;
            trackBar_ScaleSheet.Name = "trackBar_ScaleSheet";
            trackBar_ScaleSheet.Size = new Size(733, 45);
            trackBar_ScaleSheet.TabIndex = 4;
            trackBar_ScaleSheet.TickFrequency = 10;
            trackBar_ScaleSheet.Value = 10;
            trackBar_ScaleSheet.ValueChanged += trackBar_ScaleSheet_ValueChanged;
            // 
            // splitter_Sheet
            // 
            splitter_Sheet.Location = new Point(0, 0);
            splitter_Sheet.Name = "splitter_Sheet";
            splitter_Sheet.Size = new Size(3, 735);
            splitter_Sheet.TabIndex = 2;
            splitter_Sheet.TabStop = false;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem, importToolStripMenuItem1, exportToolStripMenuItem1, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1525, 24);
            menuStrip.TabIndex = 6;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(103, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { hex2ColourToolStripMenuItem, optionsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // hex2ColourToolStripMenuItem
            // 
            hex2ColourToolStripMenuItem.Name = "hex2ColourToolStripMenuItem";
            hex2ColourToolStripMenuItem.Size = new Size(137, 22);
            hex2ColourToolStripMenuItem.Text = "Hex2Colour";
            hex2ColourToolStripMenuItem.Click += hex2ColourToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { notificationsToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(137, 22);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // notificationsToolStripMenuItem
            // 
            notificationsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { enableNotificationsToolStripMenuItem, disableNotificationsToolStripMenuItem });
            notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            notificationsToolStripMenuItem.Size = new Size(142, 22);
            notificationsToolStripMenuItem.Text = "Notifications";
            notificationsToolStripMenuItem.Click += notificationsToolStripMenuItem_Click;
            // 
            // enableNotificationsToolStripMenuItem
            // 
            enableNotificationsToolStripMenuItem.Name = "enableNotificationsToolStripMenuItem";
            enableNotificationsToolStripMenuItem.Size = new Size(112, 22);
            enableNotificationsToolStripMenuItem.Text = "Enable";
            enableNotificationsToolStripMenuItem.Click += notificationsToolStripMenuItem_Click;
            // 
            // disableNotificationsToolStripMenuItem
            // 
            disableNotificationsToolStripMenuItem.Name = "disableNotificationsToolStripMenuItem";
            disableNotificationsToolStripMenuItem.Size = new Size(112, 22);
            disableNotificationsToolStripMenuItem.Text = "Disable";
            disableNotificationsToolStripMenuItem.Click += notificationsToolStripMenuItem_Click;
            // 
            // importToolStripMenuItem1
            // 
            importToolStripMenuItem1.Name = "importToolStripMenuItem1";
            importToolStripMenuItem1.Size = new Size(55, 20);
            importToolStripMenuItem1.Text = "Import";
            importToolStripMenuItem1.Click += importToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem1
            // 
            exportToolStripMenuItem1.Enabled = false;
            exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            exportToolStripMenuItem1.Size = new Size(53, 20);
            exportToolStripMenuItem1.Text = "Export";
            exportToolStripMenuItem1.Click += button_Export_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(label1, 2, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(200, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(135, 35);
            label1.Name = "label1";
            label1.Size = new Size(51, 30);
            label1.TabIndex = 2;
            label1.Text = "Zoom :  1x";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(69, 35);
            label2.Name = "label2";
            label2.Size = new Size(43, 30);
            label2.TabIndex = 1;
            label2.Text = "Area :  0px";
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1525, 761);
            Controls.Add(splitContainer_Images);
            Controls.Add(panel_Settings);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(683, 348);
            Name = "MainForm";
            ShowIcon = false;
            Text = "Sprite Sheet Generator";
            FormClosing += PalettizerForm_FormClosing;
            DragDrop += MainForm_DragDrop;
            DragEnter += MainForm_DragEnter;
            panel_Settings.ResumeLayout(false);
            groupBox_Output.ResumeLayout(false);
            groupBox_Output.PerformLayout();
            groupBox_Rotations.ResumeLayout(false);
            groupBox_Rotations.PerformLayout();
            splitContainer_Images.Panel1.ResumeLayout(false);
            splitContainer_Images.Panel1.PerformLayout();
            splitContainer_Images.Panel2.ResumeLayout(false);
            splitContainer_Images.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Images).EndInit();
            splitContainer_Images.ResumeLayout(false);
            tableLayoutPanel_Images.ResumeLayout(false);
            tableLayoutPanel_Images.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_ScaleImages).EndInit();
            tableLayoutPanel_Generated.ResumeLayout(false);
            tableLayoutPanel_Generated.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_ScaleSheet).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel_Settings;
        private Button button_Clear;
        private ListBox listBox_Paths;
        private SplitContainer splitContainer_Images;
        private FlowLayoutPanel flowLayoutPanel_Sprites;
        private Button button_MoveDown;
        private Button button_MoveUp;
        private TrackBar trackBar_ScaleSheet;
        private Button button_Remove;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ComboBox comboBox_PixelFormat;
        private GroupBox groupBox_Rotations;
        private CheckBox checkBox_Rotate90;
        private CheckBox checkBox_Rotate270;
        private CheckBox checkBox_Rotate180;
        private Label label_PixelFormat;
        private TrackBar trackBar_ScaleImages;
        private GroupBox groupBox_Output;
        private CheckBox checkBox_Rotate90MX;
        private CheckBox checkBox_Rotate270MX;
        private CheckBox checkBox_MirrorY;
        private CheckBox checkBox_MirrrorX;
        private Splitter splitter_Sheet;
        private ToolStripMenuItem importToolStripMenuItem1;
        private ToolStripMenuItem exportToolStripMenuItem1;
        private CheckBox checkBox_AlignVert;
        private Label label_Gen1;
        private Label label_Gen0;
        private TableLayoutPanel tableLayoutPanel_Generated;
        private Button button_MoveTop;
        private Button button_MoveBottom;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Button button_AllRotations;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem hex2ColourToolStripMenuItem;
        private Button button_CreateSheet;
        private CheckBox checkBox_Pack;
        private TableLayoutPanel tableLayoutPanel_Images;
        private Label label_Area;
        private Label label_ImageCount;
        private ToolTip toolTip;
        private CheckBox checkBox_EqualSpacing;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem notificationsToolStripMenuItem;
        private ToolStripMenuItem enableNotificationsToolStripMenuItem;
        private ToolStripMenuItem disableNotificationsToolStripMenuItem;
        private Label label_ZoomImages;
        private Label label_ZoomGen;
        private Button button_GenerateVariations;
        private FlowLayoutPanel flowLayoutPanel_Generated;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
    }
}