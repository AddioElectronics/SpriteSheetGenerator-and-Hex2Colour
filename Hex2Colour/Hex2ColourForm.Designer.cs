
namespace Hex2Colour
{
    partial class Hex2ColourForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hex2ColourForm));
            button_Convert = new Button();
            textIn = new TextBox();
            textOut = new TextBox();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importSettingsToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            colourHarvestorToolStripMenuItem = new ToolStripMenuItem();
            spriteSheetGeneratorToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            splitContainer = new SplitContainer();
            textBox_NameFormat = new TextBox();
            label_NameFormat = new Label();
            button_Append = new Button();
            button_Clear = new Button();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // button_Convert
            // 
            button_Convert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Convert.Location = new Point(12, 489);
            button_Convert.Name = "button_Convert";
            button_Convert.Size = new Size(132, 26);
            button_Convert.TabIndex = 0;
            button_Convert.Text = "Convert";
            button_Convert.UseVisualStyleBackColor = true;
            button_Convert.Click += button_Convert_Click;
            // 
            // textIn
            // 
            textIn.Dock = DockStyle.Fill;
            textIn.Location = new Point(0, 0);
            textIn.Multiline = true;
            textIn.Name = "textIn";
            textIn.PlaceholderText = "Paste hex values here, or use \"Tools->Colour Harvestor\"";
            textIn.ScrollBars = ScrollBars.Both;
            textIn.Size = new Size(325, 456);
            textIn.TabIndex = 1;
            // 
            // textOut
            // 
            textOut.Dock = DockStyle.Fill;
            textOut.Location = new Point(0, 0);
            textOut.Multiline = true;
            textOut.Name = "textOut";
            textOut.PlaceholderText = "Code will be output here...";
            textOut.Size = new Size(604, 456);
            textOut.TabIndex = 2;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem, settingsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(957, 24);
            menuStrip.TabIndex = 3;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importSettingsToolStripMenuItem, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // importSettingsToolStripMenuItem
            // 
            importSettingsToolStripMenuItem.Name = "importSettingsToolStripMenuItem";
            importSettingsToolStripMenuItem.Size = new Size(155, 22);
            importSettingsToolStripMenuItem.Text = "Import Settings";
            importSettingsToolStripMenuItem.Click += importSettingsToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(155, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { colourHarvestorToolStripMenuItem, spriteSheetGeneratorToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // colourHarvestorToolStripMenuItem
            // 
            colourHarvestorToolStripMenuItem.Name = "colourHarvestorToolStripMenuItem";
            colourHarvestorToolStripMenuItem.Size = new Size(191, 22);
            colourHarvestorToolStripMenuItem.Text = "Colour Harvestor";
            colourHarvestorToolStripMenuItem.Click += colourHarvestorToolStripMenuItem_Click;
            // 
            // spriteSheetGeneratorToolStripMenuItem
            // 
            spriteSheetGeneratorToolStripMenuItem.Name = "spriteSheetGeneratorToolStripMenuItem";
            spriteSheetGeneratorToolStripMenuItem.Size = new Size(191, 22);
            spriteSheetGeneratorToolStripMenuItem.Text = "Sprite Sheet Generator";
            spriteSheetGeneratorToolStripMenuItem.Click += spriteSheetGeneratorToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.Location = new Point(12, 27);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(textIn);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(textOut);
            splitContainer.Size = new Size(933, 456);
            splitContainer.SplitterDistance = 325;
            splitContainer.TabIndex = 4;
            // 
            // textBox_NameFormat
            // 
            textBox_NameFormat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox_NameFormat.Location = new Point(735, 511);
            textBox_NameFormat.Name = "textBox_NameFormat";
            textBox_NameFormat.PlaceholderText = "Ex. g_colour{0}";
            textBox_NameFormat.Size = new Size(210, 23);
            textBox_NameFormat.TabIndex = 10;
            textBox_NameFormat.TextChanged += textBox_NameFormat_TextChanged;
            // 
            // label_NameFormat
            // 
            label_NameFormat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label_NameFormat.AutoSize = true;
            label_NameFormat.Location = new Point(735, 493);
            label_NameFormat.Name = "label_NameFormat";
            label_NameFormat.Size = new Size(80, 15);
            label_NameFormat.TabIndex = 11;
            label_NameFormat.Text = "Name Format";
            // 
            // button_Append
            // 
            button_Append.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Append.Location = new Point(150, 489);
            button_Append.Name = "button_Append";
            button_Append.Size = new Size(132, 26);
            button_Append.TabIndex = 13;
            button_Append.Text = "Append";
            button_Append.UseVisualStyleBackColor = true;
            button_Append.Click += button_Append_Click;
            // 
            // button_Clear
            // 
            button_Clear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Clear.Location = new Point(12, 521);
            button_Clear.Name = "button_Clear";
            button_Clear.Size = new Size(132, 26);
            button_Clear.TabIndex = 14;
            button_Clear.Text = "Clear";
            button_Clear.UseVisualStyleBackColor = true;
            button_Clear.Click += button_Clear_Click;
            // 
            // Hex2ColourForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 553);
            Controls.Add(button_Clear);
            Controls.Add(button_Append);
            Controls.Add(label_NameFormat);
            Controls.Add(textBox_NameFormat);
            Controls.Add(splitContainer);
            Controls.Add(button_Convert);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(550, 300);
            Name = "Hex2ColourForm";
            ShowIcon = false;
            Text = "Hex2Colour";
            FormClosing += Hex2ColourForm_FormClosing;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Convert;
        private TextBox textIn;
        private TextBox textOut;
        private MenuStrip menuStrip;
        private ToolStripMenuItem helpToolStripMenuItem;
        private SplitContainer splitContainer;
        private TextBox textBox_NameFormat;
        private Label label_NameFormat;
        private Button button_Append;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem importSettingsToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private Button button_Clear;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem spriteSheetGeneratorToolStripMenuItem;
        private ToolStripMenuItem colourHarvestorToolStripMenuItem;
    }
}

