namespace Hex2Colour
{
    partial class Hex2ColourHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hex2ColourHelp));
            label_ContentGeneral = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            tabControl = new TabControl();
            General = new TabPage();
            button_Convert = new Button();
            NameFormat = new TabPage();
            richTextBox1 = new RichTextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox3 = new TextBox();
            tabControl.SuspendLayout();
            General.SuspendLayout();
            NameFormat.SuspendLayout();
            SuspendLayout();
            // 
            // label_ContentGeneral
            // 
            label_ContentGeneral.Location = new Point(6, 6);
            label_ContentGeneral.Name = "label_ContentGeneral";
            label_ContentGeneral.Size = new Size(464, 105);
            label_ContentGeneral.TabIndex = 0;
            label_ContentGeneral.Text = resources.GetString("label_ContentGeneral.Text");
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox1.Location = new Point(243, 172);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(224, 126);
            textBox1.TabIndex = 2;
            textBox1.Text = "const COLORREF colour1 = 0xFF;\r\nconst COLORREF colourRed = 0xFF;\r\nconst COLORREF colourGreen = 0xFF0000;\r\nconst COLORREF colourGreen2 = 0x43A96D; //For grass\r\n";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox2.Location = new Point(3, 172);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(224, 126);
            textBox2.TabIndex = 3;
            textBox2.Text = "FF0000\r\n0xFF0000 colourRed\r\n0xFF colourGreen\r\n6DA943 colourGreen2 Grass like colour\r\n";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(General);
            tabControl.Controls.Add(NameFormat);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(484, 361);
            tabControl.TabIndex = 4;
            // 
            // General
            // 
            General.Controls.Add(button_Convert);
            General.Controls.Add(textBox2);
            General.Controls.Add(label_ContentGeneral);
            General.Controls.Add(textBox1);
            General.Location = new Point(4, 24);
            General.Name = "General";
            General.Padding = new Padding(3);
            General.Size = new Size(476, 333);
            General.TabIndex = 0;
            General.Text = "General";
            General.UseVisualStyleBackColor = true;
            // 
            // button_Convert
            // 
            button_Convert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_Convert.Location = new Point(3, 304);
            button_Convert.Name = "button_Convert";
            button_Convert.Size = new Size(75, 23);
            button_Convert.TabIndex = 4;
            button_Convert.Text = "Convert";
            button_Convert.UseVisualStyleBackColor = true;
            // 
            // NameFormat
            // 
            NameFormat.Controls.Add(textBox4);
            NameFormat.Controls.Add(textBox5);
            NameFormat.Controls.Add(textBox3);
            NameFormat.Controls.Add(richTextBox1);
            NameFormat.Location = new Point(4, 24);
            NameFormat.Name = "NameFormat";
            NameFormat.Padding = new Padding(3);
            NameFormat.Size = new Size(476, 333);
            NameFormat.TabIndex = 2;
            NameFormat.Text = "Name Format";
            NameFormat.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Location = new Point(6, 6);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(461, 183);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox4.Location = new Point(3, 178);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(224, 149);
            textBox4.TabIndex = 5;
            textBox4.Text = "FF0000 Red\r\n00FF00";
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox5.Location = new Point(243, 178);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(224, 149);
            textBox5.TabIndex = 4;
            textBox5.Text = "const COLORREF g_colourRed = 0x0000FF;\r\nconst COLORREF g_colour1 = 0x00FF00;";
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox3.Location = new Point(367, 149);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            textBox3.Text = "g_colour{0}";
            // 
            // Hex2ColourHelp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 361);
            Controls.Add(tabControl);
            MaximizeBox = false;
            MaximumSize = new Size(500, 400);
            MinimizeBox = false;
            MinimumSize = new Size(500, 400);
            Name = "Hex2ColourHelp";
            Text = "Hex2ColourHelp";
            tabControl.ResumeLayout(false);
            General.ResumeLayout(false);
            General.PerformLayout();
            NameFormat.ResumeLayout(false);
            NameFormat.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label_ContentGeneral;
        private TextBox textBox1;
        private TextBox textBox2;
        private TabControl tabControl;
        private TabPage General;
        private Button button_Convert;
        private TabPage NameFormat;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox3;
        private RichTextBox richTextBox1;
    }
}