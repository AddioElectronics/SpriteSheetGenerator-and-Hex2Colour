namespace Hex2Colour
{
    partial class ColourHarvesterForm
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
            button_Harvest = new Button();
            listBox_Colours = new ListBox();
            button_Delete = new Button();
            textBox_Text = new TextBox();
            button_Clear = new Button();
            button_OK = new Button();
            textBox_URL = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            button_Download = new Button();
            comboBox_Specifier = new ComboBox();
            checkBox_RequireNotation = new CheckBox();
            textBox_CustomPattern = new TextBox();
            checkBox_AutoHarvest = new CheckBox();
            checkBox_Append = new CheckBox();
            SuspendLayout();
            // 
            // button_Harvest
            // 
            button_Harvest.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Harvest.Location = new Point(1308, 702);
            button_Harvest.Name = "button_Harvest";
            button_Harvest.Size = new Size(75, 23);
            button_Harvest.TabIndex = 1;
            button_Harvest.Text = "Harvest";
            button_Harvest.UseVisualStyleBackColor = true;
            button_Harvest.Click += button_Harvest_Click;
            // 
            // listBox_Colours
            // 
            listBox_Colours.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBox_Colours.FormattingEnabled = true;
            listBox_Colours.ItemHeight = 15;
            listBox_Colours.Location = new Point(12, 42);
            listBox_Colours.Name = "listBox_Colours";
            listBox_Colours.SelectionMode = SelectionMode.MultiExtended;
            listBox_Colours.Size = new Size(156, 619);
            listBox_Colours.TabIndex = 2;
            listBox_Colours.KeyUp += listBox_Colours_KeyUp;
            // 
            // button_Delete
            // 
            button_Delete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Delete.Location = new Point(12, 671);
            button_Delete.Name = "button_Delete";
            button_Delete.Size = new Size(75, 23);
            button_Delete.TabIndex = 3;
            button_Delete.Text = "Delete";
            button_Delete.UseVisualStyleBackColor = true;
            button_Delete.Click += button_Delete_Click;
            // 
            // textBox_Text
            // 
            textBox_Text.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox_Text.Location = new Point(174, 42);
            textBox_Text.Multiline = true;
            textBox_Text.Name = "textBox_Text";
            textBox_Text.ScrollBars = ScrollBars.Both;
            textBox_Text.Size = new Size(1209, 652);
            textBox_Text.TabIndex = 4;
            textBox_Text.TextChanged += textBox_Text_TextChanged;
            // 
            // button_Clear
            // 
            button_Clear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Clear.Location = new Point(93, 671);
            button_Clear.Name = "button_Clear";
            button_Clear.Size = new Size(75, 23);
            button_Clear.TabIndex = 5;
            button_Clear.Text = "Clear";
            button_Clear.UseVisualStyleBackColor = true;
            button_Clear.Click += button_Clear_Click;
            // 
            // button_OK
            // 
            button_OK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_OK.Location = new Point(13, 701);
            button_OK.Name = "button_OK";
            button_OK.Size = new Size(155, 23);
            button_OK.TabIndex = 6;
            button_OK.Text = "Done. Send To Hex2Color";
            button_OK.UseVisualStyleBackColor = true;
            button_OK.Click += button_OK_Click;
            // 
            // textBox_URL
            // 
            textBox_URL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_URL.Location = new Point(12, 12);
            textBox_URL.Name = "textBox_URL";
            textBox_URL.PlaceholderText = "Enter a URL... or copy and paste text into the textbox below.";
            textBox_URL.Size = new Size(1290, 23);
            textBox_URL.TabIndex = 7;
            textBox_URL.KeyUp += textBox_URL_KeyUp;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // button_Download
            // 
            button_Download.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Download.Location = new Point(1308, 12);
            button_Download.Name = "button_Download";
            button_Download.Size = new Size(75, 23);
            button_Download.TabIndex = 9;
            button_Download.Text = "Download";
            button_Download.UseVisualStyleBackColor = true;
            button_Download.Click += button_Download_Click;
            // 
            // comboBox_Specifier
            // 
            comboBox_Specifier.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBox_Specifier.FormattingEnabled = true;
            comboBox_Specifier.Location = new Point(877, 704);
            comboBox_Specifier.Name = "comboBox_Specifier";
            comboBox_Specifier.Size = new Size(121, 23);
            comboBox_Specifier.TabIndex = 10;
            comboBox_Specifier.Text = "Enter adds item";
            comboBox_Specifier.KeyUp += comboBox_Specifier_KeyUp;
            // 
            // checkBox_RequireNotation
            // 
            checkBox_RequireNotation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox_RequireNotation.AutoSize = true;
            checkBox_RequireNotation.Checked = true;
            checkBox_RequireNotation.CheckState = CheckState.Checked;
            checkBox_RequireNotation.Location = new Point(1004, 705);
            checkBox_RequireNotation.Name = "checkBox_RequireNotation";
            checkBox_RequireNotation.Size = new Size(121, 19);
            checkBox_RequireNotation.TabIndex = 11;
            checkBox_RequireNotation.Text = "Require Notations";
            checkBox_RequireNotation.UseVisualStyleBackColor = true;
            // 
            // textBox_CustomPattern
            // 
            textBox_CustomPattern.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox_CustomPattern.Location = new Point(433, 704);
            textBox_CustomPattern.Name = "textBox_CustomPattern";
            textBox_CustomPattern.PlaceholderText = "Optional custom regex pattern";
            textBox_CustomPattern.Size = new Size(427, 23);
            textBox_CustomPattern.TabIndex = 12;
            // 
            // checkBox_AutoHarvest
            // 
            checkBox_AutoHarvest.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox_AutoHarvest.AutoSize = true;
            checkBox_AutoHarvest.Checked = true;
            checkBox_AutoHarvest.CheckState = CheckState.Checked;
            checkBox_AutoHarvest.Location = new Point(1205, 705);
            checkBox_AutoHarvest.Name = "checkBox_AutoHarvest";
            checkBox_AutoHarvest.Size = new Size(97, 19);
            checkBox_AutoHarvest.TabIndex = 13;
            checkBox_AutoHarvest.Text = "Auto-Harvest";
            checkBox_AutoHarvest.UseVisualStyleBackColor = true;
            // 
            // checkBox_Append
            // 
            checkBox_Append.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox_Append.AutoSize = true;
            checkBox_Append.Location = new Point(1131, 705);
            checkBox_Append.Name = "checkBox_Append";
            checkBox_Append.Size = new Size(68, 19);
            checkBox_Append.TabIndex = 14;
            checkBox_Append.Text = "Append";
            checkBox_Append.UseVisualStyleBackColor = true;
            // 
            // ColourHarvesterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1395, 736);
            Controls.Add(checkBox_Append);
            Controls.Add(checkBox_AutoHarvest);
            Controls.Add(textBox_CustomPattern);
            Controls.Add(checkBox_RequireNotation);
            Controls.Add(comboBox_Specifier);
            Controls.Add(button_Download);
            Controls.Add(textBox_URL);
            Controls.Add(button_OK);
            Controls.Add(button_Clear);
            Controls.Add(textBox_Text);
            Controls.Add(button_Delete);
            Controls.Add(listBox_Colours);
            Controls.Add(button_Harvest);
            MinimumSize = new Size(410, 300);
            Name = "ColourHarvesterForm";
            Text = "Colour Harvester";
            FormClosing += HttpGrabber_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_URL;
        private Button button_Harvest;
        private ListBox listBox_Colours;
        private Button button_Delete;
        private TextBox textBox_Text;
        private Button button_Clear;
        private Button button_OK;
        private TextBox textBox1;
        private ContextMenuStrip contextMenuStrip1;
        private Button button_Download;
        private ComboBox comboBox_Specifier;
        private CheckBox checkBox_RequireNotation;
        private TextBox textBox_CustomPattern;
        private CheckBox checkBox_AutoHarvest;
        private CheckBox checkBox_Append;
    }
}