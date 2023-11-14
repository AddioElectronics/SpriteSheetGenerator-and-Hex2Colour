namespace Hex2Colour
{
    partial class ColourHarvester
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
            button_Harvest = new Button();
            listBox_Colours = new ListBox();
            button_Delete = new Button();
            textBox_Text = new TextBox();
            button_Clear = new Button();
            SuspendLayout();
            // 
            // button_Harvest
            // 
            button_Harvest.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_Harvest.Location = new Point(713, 458);
            button_Harvest.Name = "button_Harvest";
            button_Harvest.Size = new Size(75, 23);
            button_Harvest.TabIndex = 1;
            button_Harvest.Text = "Harvest";
            button_Harvest.UseVisualStyleBackColor = true;
            button_Harvest.Click += button_Grab_Click;
            // 
            // listBox_Colours
            // 
            listBox_Colours.FormattingEnabled = true;
            listBox_Colours.ItemHeight = 15;
            listBox_Colours.Location = new Point(12, 12);
            listBox_Colours.Name = "listBox_Colours";
            listBox_Colours.SelectionMode = SelectionMode.MultiExtended;
            listBox_Colours.Size = new Size(156, 439);
            listBox_Colours.TabIndex = 2;
            // 
            // button_Delete
            // 
            button_Delete.Location = new Point(12, 458);
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
            textBox_Text.Location = new Point(174, 12);
            textBox_Text.Multiline = true;
            textBox_Text.Name = "textBox_Text";
            textBox_Text.Size = new Size(614, 438);
            textBox_Text.TabIndex = 4;
            // 
            // button_Clear
            // 
            button_Clear.Location = new Point(93, 458);
            button_Clear.Name = "button_Clear";
            button_Clear.Size = new Size(75, 23);
            button_Clear.TabIndex = 5;
            button_Clear.Text = "Clear";
            button_Clear.UseVisualStyleBackColor = true;
            button_Clear.Click += button_Clear_Click;
            // 
            // ColourHarvester
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 493);
            Controls.Add(button_Clear);
            Controls.Add(textBox_Text);
            Controls.Add(button_Delete);
            Controls.Add(listBox_Colours);
            Controls.Add(button_Harvest);
            Name = "ColourHarvester";
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
    }
}