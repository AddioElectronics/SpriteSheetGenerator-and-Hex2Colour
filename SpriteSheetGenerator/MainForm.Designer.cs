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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pictureBox_SpriteSheet = new PictureBox();
            splitContainer_Master = new SplitContainer();
            panel_Settings = new Panel();
            button_MoveTop = new Button();
            button_MoveBottom = new Button();
            groupBox_Output = new GroupBox();
            button_Generate = new Button();
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
            trackBar_ScaleImages = new TrackBar();
            splitter_Images = new Splitter();
            flowLayoutPanel_Sprites = new FlowLayoutPanel();
            panel_SpriteSheet = new Panel();
            tableLayoutPanel_SheetInfo = new TableLayoutPanel();
            label_SheetHeight = new Label();
            label_SheetWidth = new Label();
            trackBar_ScaleSheet = new TrackBar();
            splitter_Sheet = new Splitter();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            hex2ColourToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem1 = new ToolStripMenuItem();
            exportToolStripMenuItem1 = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox_SpriteSheet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Master).BeginInit();
            splitContainer_Master.Panel1.SuspendLayout();
            splitContainer_Master.Panel2.SuspendLayout();
            splitContainer_Master.SuspendLayout();
            panel_Settings.SuspendLayout();
            groupBox_Output.SuspendLayout();
            groupBox_Rotations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Images).BeginInit();
            splitContainer_Images.Panel1.SuspendLayout();
            splitContainer_Images.Panel2.SuspendLayout();
            splitContainer_Images.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_ScaleImages).BeginInit();
            panel_SpriteSheet.SuspendLayout();
            tableLayoutPanel_SheetInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_ScaleSheet).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox_SpriteSheet
            // 
            pictureBox_SpriteSheet.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox_SpriteSheet.Location = new Point(0, -1);
            pictureBox_SpriteSheet.Name = "pictureBox_SpriteSheet";
            pictureBox_SpriteSheet.Size = new Size(198, 228);
            pictureBox_SpriteSheet.TabIndex = 1;
            pictureBox_SpriteSheet.TabStop = false;
            // 
            // splitContainer_Master
            // 
            splitContainer_Master.Dock = DockStyle.Fill;
            splitContainer_Master.Location = new Point(0, 24);
            splitContainer_Master.Name = "splitContainer_Master";
            // 
            // splitContainer_Master.Panel1
            // 
            splitContainer_Master.Panel1.Controls.Add(panel_Settings);
            splitContainer_Master.Panel1MinSize = 400;
            // 
            // splitContainer_Master.Panel2
            // 
            splitContainer_Master.Panel2.Controls.Add(splitContainer_Images);
            splitContainer_Master.Size = new Size(1525, 650);
            splitContainer_Master.SplitterDistance = 761;
            splitContainer_Master.TabIndex = 2;
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
            panel_Settings.Dock = DockStyle.Fill;
            panel_Settings.Location = new Point(0, 0);
            panel_Settings.Name = "panel_Settings";
            panel_Settings.Size = new Size(761, 650);
            panel_Settings.TabIndex = 0;
            // 
            // button_MoveTop
            // 
            button_MoveTop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_MoveTop.Location = new Point(661, 617);
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
            button_MoveBottom.Location = new Point(564, 617);
            button_MoveBottom.Name = "button_MoveBottom";
            button_MoveBottom.Size = new Size(91, 23);
            button_MoveBottom.TabIndex = 14;
            button_MoveBottom.Text = "Move Bottom";
            button_MoveBottom.UseVisualStyleBackColor = true;
            button_MoveBottom.Click += button_MoveBottom_Click;
            // 
            // groupBox_Output
            // 
            groupBox_Output.Controls.Add(button_Generate);
            groupBox_Output.Controls.Add(checkBox_AlignVert);
            groupBox_Output.Controls.Add(label_PixelFormat);
            groupBox_Output.Controls.Add(comboBox_PixelFormat);
            groupBox_Output.Location = new Point(280, 3);
            groupBox_Output.Name = "groupBox_Output";
            groupBox_Output.Size = new Size(140, 145);
            groupBox_Output.TabIndex = 12;
            groupBox_Output.TabStop = false;
            groupBox_Output.Text = "Output";
            // 
            // button_Generate
            // 
            button_Generate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Generate.Enabled = false;
            button_Generate.Location = new Point(6, 97);
            button_Generate.Name = "button_Generate";
            button_Generate.Size = new Size(128, 42);
            button_Generate.TabIndex = 14;
            button_Generate.Text = "Generate Sheet";
            button_Generate.UseVisualStyleBackColor = true;
            button_Generate.Click += button_CreateSpriteSheet_Click;
            // 
            // checkBox_AlignVert
            // 
            checkBox_AlignVert.AutoSize = true;
            checkBox_AlignVert.Location = new Point(6, 72);
            checkBox_AlignVert.Name = "checkBox_AlignVert";
            checkBox_AlignVert.Size = new Size(104, 19);
            checkBox_AlignVert.TabIndex = 13;
            checkBox_AlignVert.Text = "Align Vertically";
            checkBox_AlignVert.UseVisualStyleBackColor = true;
            // 
            // label_PixelFormat
            // 
            label_PixelFormat.AutoSize = true;
            label_PixelFormat.Location = new Point(6, 25);
            label_PixelFormat.Name = "label_PixelFormat";
            label_PixelFormat.Size = new Size(73, 15);
            label_PixelFormat.TabIndex = 12;
            label_PixelFormat.Text = "Pixel Format";
            // 
            // comboBox_PixelFormat
            // 
            comboBox_PixelFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_PixelFormat.FormattingEnabled = true;
            comboBox_PixelFormat.Location = new Point(6, 43);
            comboBox_PixelFormat.Name = "comboBox_PixelFormat";
            comboBox_PixelFormat.Size = new Size(121, 23);
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
            groupBox_Rotations.Size = new Size(269, 145);
            groupBox_Rotations.TabIndex = 11;
            groupBox_Rotations.TabStop = false;
            groupBox_Rotations.Text = "Rotations";
            // 
            // button_AllRotations
            // 
            button_AllRotations.Location = new Point(223, 116);
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
            button_Remove.Location = new Point(5, 591);
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
            button_MoveUp.Location = new Point(661, 591);
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
            listBox_Paths.Location = new Point(5, 153);
            listBox_Paths.Name = "listBox_Paths";
            listBox_Paths.SelectionMode = SelectionMode.MultiExtended;
            listBox_Paths.Size = new Size(747, 422);
            listBox_Paths.TabIndex = 0;
            listBox_Paths.KeyUp += listBox_Paths_KeyUp;
            // 
            // button_MoveDown
            // 
            button_MoveDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_MoveDown.Location = new Point(564, 591);
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
            button_Clear.Location = new Point(5, 617);
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
            splitContainer_Images.Location = new Point(0, 0);
            splitContainer_Images.Name = "splitContainer_Images";
            // 
            // splitContainer_Images.Panel1
            // 
            splitContainer_Images.Panel1.Controls.Add(trackBar_ScaleImages);
            splitContainer_Images.Panel1.Controls.Add(splitter_Images);
            splitContainer_Images.Panel1.Controls.Add(flowLayoutPanel_Sprites);
            // 
            // splitContainer_Images.Panel2
            // 
            splitContainer_Images.Panel2.Controls.Add(panel_SpriteSheet);
            splitContainer_Images.Panel2.Controls.Add(tableLayoutPanel_SheetInfo);
            splitContainer_Images.Panel2.Controls.Add(trackBar_ScaleSheet);
            splitContainer_Images.Panel2.Controls.Add(splitter_Sheet);
            splitContainer_Images.Size = new Size(760, 650);
            splitContainer_Images.SplitterDistance = 284;
            splitContainer_Images.TabIndex = 0;
            // 
            // trackBar_ScaleImages
            // 
            trackBar_ScaleImages.Dock = DockStyle.Bottom;
            trackBar_ScaleImages.Location = new Point(3, 603);
            trackBar_ScaleImages.Maximum = 100;
            trackBar_ScaleImages.Minimum = 1;
            trackBar_ScaleImages.Name = "trackBar_ScaleImages";
            trackBar_ScaleImages.Size = new Size(279, 45);
            trackBar_ScaleImages.TabIndex = 7;
            trackBar_ScaleImages.Value = 10;
            trackBar_ScaleImages.ValueChanged += trackBar_ScaleImages_ValueChanged;
            // 
            // splitter_Images
            // 
            splitter_Images.Location = new Point(0, 0);
            splitter_Images.Name = "splitter_Images";
            splitter_Images.Size = new Size(3, 648);
            splitter_Images.TabIndex = 1;
            splitter_Images.TabStop = false;
            // 
            // flowLayoutPanel_Sprites
            // 
            flowLayoutPanel_Sprites.AutoScroll = true;
            flowLayoutPanel_Sprites.Dock = DockStyle.Fill;
            flowLayoutPanel_Sprites.Location = new Point(0, 0);
            flowLayoutPanel_Sprites.Name = "flowLayoutPanel_Sprites";
            flowLayoutPanel_Sprites.Size = new Size(282, 648);
            flowLayoutPanel_Sprites.TabIndex = 0;
            // 
            // panel_SpriteSheet
            // 
            panel_SpriteSheet.AutoScroll = true;
            panel_SpriteSheet.Controls.Add(pictureBox_SpriteSheet);
            panel_SpriteSheet.Dock = DockStyle.Fill;
            panel_SpriteSheet.Location = new Point(3, 0);
            panel_SpriteSheet.Name = "panel_SpriteSheet";
            panel_SpriteSheet.Size = new Size(467, 576);
            panel_SpriteSheet.TabIndex = 7;
            // 
            // tableLayoutPanel_SheetInfo
            // 
            tableLayoutPanel_SheetInfo.ColumnCount = 2;
            tableLayoutPanel_SheetInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_SheetInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel_SheetInfo.Controls.Add(label_SheetHeight, 1, 0);
            tableLayoutPanel_SheetInfo.Controls.Add(label_SheetWidth, 0, 0);
            tableLayoutPanel_SheetInfo.Dock = DockStyle.Bottom;
            tableLayoutPanel_SheetInfo.Location = new Point(3, 576);
            tableLayoutPanel_SheetInfo.Name = "tableLayoutPanel_SheetInfo";
            tableLayoutPanel_SheetInfo.RowCount = 1;
            tableLayoutPanel_SheetInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel_SheetInfo.Size = new Size(467, 27);
            tableLayoutPanel_SheetInfo.TabIndex = 6;
            // 
            // label_SheetHeight
            // 
            label_SheetHeight.Anchor = AnchorStyles.Left;
            label_SheetHeight.AutoSize = true;
            label_SheetHeight.Location = new Point(236, 6);
            label_SheetHeight.Name = "label_SheetHeight";
            label_SheetHeight.Size = new Size(52, 15);
            label_SheetHeight.TabIndex = 1;
            label_SheetHeight.Text = "Height : ";
            // 
            // label_SheetWidth
            // 
            label_SheetWidth.Anchor = AnchorStyles.Left;
            label_SheetWidth.AutoSize = true;
            label_SheetWidth.CausesValidation = false;
            label_SheetWidth.Location = new Point(3, 6);
            label_SheetWidth.Name = "label_SheetWidth";
            label_SheetWidth.Size = new Size(51, 15);
            label_SheetWidth.TabIndex = 0;
            label_SheetWidth.Text = "Width  : ";
            // 
            // trackBar_ScaleSheet
            // 
            trackBar_ScaleSheet.Dock = DockStyle.Bottom;
            trackBar_ScaleSheet.Location = new Point(3, 603);
            trackBar_ScaleSheet.Maximum = 100;
            trackBar_ScaleSheet.Minimum = 1;
            trackBar_ScaleSheet.Name = "trackBar_ScaleSheet";
            trackBar_ScaleSheet.Size = new Size(467, 45);
            trackBar_ScaleSheet.TabIndex = 4;
            trackBar_ScaleSheet.Value = 10;
            trackBar_ScaleSheet.ValueChanged += trackBar_ScaleSheet_ValueChanged;
            // 
            // splitter_Sheet
            // 
            splitter_Sheet.Location = new Point(0, 0);
            splitter_Sheet.Name = "splitter_Sheet";
            splitter_Sheet.Size = new Size(3, 648);
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
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { hex2ColourToolStripMenuItem });
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
            helpToolStripMenuItem.Click += helpToolStripMenuItem1_Click;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1525, 674);
            Controls.Add(splitContainer_Master);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox_SpriteSheet).EndInit();
            splitContainer_Master.Panel1.ResumeLayout(false);
            splitContainer_Master.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_Master).EndInit();
            splitContainer_Master.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)trackBar_ScaleImages).EndInit();
            panel_SpriteSheet.ResumeLayout(false);
            tableLayoutPanel_SheetInfo.ResumeLayout(false);
            tableLayoutPanel_SheetInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_ScaleSheet).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_SpriteSheet;
        private SplitContainer splitContainer_Master;
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
        private Splitter splitter_Images;
        private Splitter splitter_Sheet;
        private ToolStripMenuItem importToolStripMenuItem1;
        private ToolStripMenuItem exportToolStripMenuItem1;
        private CheckBox checkBox_AlignVert;
        private Label label_SheetHeight;
        private Label label_SheetWidth;
        private TableLayoutPanel tableLayoutPanel_SheetInfo;
        private Button button_MoveTop;
        private Button button_MoveBottom;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Button button_AllRotations;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem hex2ColourToolStripMenuItem;
        private Button button_Generate;
        private Panel panel_SpriteSheet;
    }
}