namespace Hex2Colour
{
    partial class Hex2ColourSettings
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
            checkBox_Murica = new CheckBox();
            checkBox_Clipboard = new CheckBox();
            checkBox_SwapEndian = new CheckBox();
            checkBox_AlphaMSB = new CheckBox();
            label_Language = new Label();
            comboBox_Language = new ComboBox();
            label_NameFormat = new Label();
            textBox_NameFormat = new TextBox();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            okTStripMenuItem = new ToolStripMenuItem();
            applyToolStripMenuItem = new ToolStripMenuItem();
            cancelToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // checkBox_Murica
            // 
            checkBox_Murica.AutoSize = true;
            checkBox_Murica.Location = new Point(11, 109);
            checkBox_Murica.Name = "checkBox_Murica";
            checkBox_Murica.Size = new Size(122, 19);
            checkBox_Murica.TabIndex = 18;
            checkBox_Murica.Text = "American Spelling";
            checkBox_Murica.UseVisualStyleBackColor = true;
            checkBox_Murica.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox_Clipboard
            // 
            checkBox_Clipboard.AutoSize = true;
            checkBox_Clipboard.Location = new Point(12, 86);
            checkBox_Clipboard.Name = "checkBox_Clipboard";
            checkBox_Clipboard.Size = new Size(115, 19);
            checkBox_Clipboard.TabIndex = 14;
            checkBox_Clipboard.Text = "Add to clipboard";
            checkBox_Clipboard.UseVisualStyleBackColor = true;
            checkBox_Clipboard.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox_SwapEndian
            // 
            checkBox_SwapEndian.AutoSize = true;
            checkBox_SwapEndian.Checked = true;
            checkBox_SwapEndian.CheckState = CheckState.Checked;
            checkBox_SwapEndian.Location = new Point(12, 38);
            checkBox_SwapEndian.Name = "checkBox_SwapEndian";
            checkBox_SwapEndian.Size = new Size(121, 19);
            checkBox_SwapEndian.TabIndex = 13;
            checkBox_SwapEndian.Text = "Reverse Endianess";
            checkBox_SwapEndian.UseVisualStyleBackColor = true;
            checkBox_SwapEndian.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox_AlphaMSB
            // 
            checkBox_AlphaMSB.AutoSize = true;
            checkBox_AlphaMSB.Checked = true;
            checkBox_AlphaMSB.CheckState = CheckState.Checked;
            checkBox_AlphaMSB.Location = new Point(12, 61);
            checkBox_AlphaMSB.Name = "checkBox_AlphaMSB";
            checkBox_AlphaMSB.Size = new Size(84, 19);
            checkBox_AlphaMSB.TabIndex = 17;
            checkBox_AlphaMSB.Text = "Alpha MSB";
            checkBox_AlphaMSB.UseVisualStyleBackColor = true;
            checkBox_AlphaMSB.CheckedChanged += checkBox_CheckedChanged;
            // 
            // label_Language
            // 
            label_Language.AutoSize = true;
            label_Language.Location = new Point(11, 142);
            label_Language.Name = "label_Language";
            label_Language.Size = new Size(82, 15);
            label_Language.TabIndex = 16;
            label_Language.Text = "Language/API";
            // 
            // comboBox_Language
            // 
            comboBox_Language.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Language.FormattingEnabled = true;
            comboBox_Language.Location = new Point(11, 160);
            comboBox_Language.Name = "comboBox_Language";
            comboBox_Language.Size = new Size(121, 23);
            comboBox_Language.TabIndex = 15;
            // 
            // label_NameFormat
            // 
            label_NameFormat.AutoSize = true;
            label_NameFormat.Location = new Point(11, 192);
            label_NameFormat.Name = "label_NameFormat";
            label_NameFormat.Size = new Size(80, 15);
            label_NameFormat.TabIndex = 25;
            label_NameFormat.Text = "Name Format";
            // 
            // textBox_NameFormat
            // 
            textBox_NameFormat.Location = new Point(11, 210);
            textBox_NameFormat.Name = "textBox_NameFormat";
            textBox_NameFormat.PlaceholderText = "Ex. g_colour{0}";
            textBox_NameFormat.Size = new Size(210, 23);
            textBox_NameFormat.TabIndex = 24;
            textBox_NameFormat.TextChanged += textBox_NameFormat_TextChanged;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, okTStripMenuItem, applyToolStripMenuItem, cancelToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(246, 24);
            menuStrip.TabIndex = 26;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(114, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(114, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(114, 22);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(114, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // okTStripMenuItem
            // 
            okTStripMenuItem.Name = "okTStripMenuItem";
            okTStripMenuItem.Size = new Size(35, 20);
            okTStripMenuItem.Text = "OK";
            okTStripMenuItem.Click += okTStripMenuItem_Click;
            // 
            // applyToolStripMenuItem
            // 
            applyToolStripMenuItem.Name = "applyToolStripMenuItem";
            applyToolStripMenuItem.Size = new Size(50, 20);
            applyToolStripMenuItem.Text = "Apply";
            applyToolStripMenuItem.Click += applyToolStripMenuItem_Click;
            // 
            // cancelToolStripMenuItem
            // 
            cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            cancelToolStripMenuItem.Size = new Size(55, 20);
            cancelToolStripMenuItem.Text = "Cancel";
            cancelToolStripMenuItem.Click += cancelToolStripMenuItem_Click;
            // 
            // Hex2ColourSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(246, 245);
            Controls.Add(label_NameFormat);
            Controls.Add(textBox_NameFormat);
            Controls.Add(checkBox_Murica);
            Controls.Add(checkBox_Clipboard);
            Controls.Add(checkBox_SwapEndian);
            Controls.Add(checkBox_AlphaMSB);
            Controls.Add(label_Language);
            Controls.Add(comboBox_Language);
            Controls.Add(menuStrip);
            MaximizeBox = false;
            MaximumSize = new Size(262, 284);
            MinimizeBox = false;
            MinimumSize = new Size(262, 284);
            Name = "Hex2ColourSettings";
            Text = "Hex2Colour Settings";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox_Murica;
        private CheckBox checkBox_Clipboard;
        private CheckBox checkBox_SwapEndian;
        private CheckBox checkBox_AlphaMSB;
        private Label label_Language;
        private ComboBox comboBox_Language;
        private Label label_NameFormat;
        private TextBox textBox_NameFormat;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem applyToolStripMenuItem;
        private ToolStripMenuItem cancelToolStripMenuItem;
        private ToolStripMenuItem okTStripMenuItem;
    }
}