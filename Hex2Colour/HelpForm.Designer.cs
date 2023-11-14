namespace Hex2Colour
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            label_ContentGeneral = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            tabControl = new TabControl();
            General = new TabPage();
            button_Convert = new Button();
            NameFormat = new TabPage();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox3 = new TextBox();
            richTextBox1 = new RichTextBox();
            NameFormat2 = new TabPage();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            richTextBox2 = new RichTextBox();
            Arrays = new TabPage();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            richTextBox3 = new RichTextBox();
            tabControl.SuspendLayout();
            General.SuspendLayout();
            NameFormat.SuspendLayout();
            NameFormat2.SuspendLayout();
            Arrays.SuspendLayout();
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
            textBox1.Location = new Point(317, 172);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(308, 126);
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
            textBox2.Size = new Size(308, 126);
            textBox2.TabIndex = 3;
            textBox2.Text = "FF0000\r\n0xFF0000 colourRed\r\n0xFF colourGreen\r\n6DA943 colourGreen2 Grass like colour\r\n";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(General);
            tabControl.Controls.Add(NameFormat);
            tabControl.Controls.Add(NameFormat2);
            tabControl.Controls.Add(Arrays);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(636, 361);
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
            General.Size = new Size(628, 333);
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
            NameFormat.Size = new Size(628, 333);
            NameFormat.TabIndex = 2;
            NameFormat.Text = "Name Format";
            NameFormat.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox4.Location = new Point(3, 178);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(308, 126);
            textBox4.TabIndex = 5;
            textBox4.Text = "FF0000 Red\r\n00FF00";
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox5.Location = new Point(317, 178);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(308, 126);
            textBox5.TabIndex = 4;
            textBox5.Text = "const COLORREF g_colourRed = 0x0000FF;\r\nconst COLORREF g_colour1 = 0x00FF00;";
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox3.Location = new Point(525, 149);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 2;
            textBox3.Text = "g_colour{0}";
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
            // NameFormat2
            // 
            NameFormat2.Controls.Add(textBox6);
            NameFormat2.Controls.Add(textBox7);
            NameFormat2.Controls.Add(textBox8);
            NameFormat2.Controls.Add(richTextBox2);
            NameFormat2.Location = new Point(4, 24);
            NameFormat2.Name = "NameFormat2";
            NameFormat2.Padding = new Padding(3);
            NameFormat2.Size = new Size(628, 333);
            NameFormat2.TabIndex = 3;
            NameFormat2.Text = "Name Symbols";
            NameFormat2.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox6.Location = new Point(3, 178);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(308, 126);
            textBox6.TabIndex = 9;
            textBox6.Text = "FF0000 !Red\r\n00FF00 %Red";
            // 
            // textBox7
            // 
            textBox7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox7.Location = new Point(317, 178);
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(308, 126);
            textBox7.TabIndex = 8;
            textBox7.Text = "const COLORREF Red = 0x0000FF;\r\nconst COLORREF g_colourRed = 0x00FF00;";
            // 
            // textBox8
            // 
            textBox8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textBox8.Location = new Point(525, 149);
            textBox8.Name = "textBox8";
            textBox8.ReadOnly = true;
            textBox8.Size = new Size(100, 23);
            textBox8.TabIndex = 7;
            textBox8.Text = "g_colour{0}";
            // 
            // richTextBox2
            // 
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox2.Location = new Point(6, 6);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox2.Size = new Size(619, 166);
            richTextBox2.TabIndex = 10;
            richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // Arrays
            // 
            Arrays.Controls.Add(textBox9);
            Arrays.Controls.Add(textBox10);
            Arrays.Controls.Add(richTextBox3);
            Arrays.Location = new Point(4, 24);
            Arrays.Name = "Arrays";
            Arrays.Padding = new Padding(3);
            Arrays.Size = new Size(628, 333);
            Arrays.TabIndex = 4;
            Arrays.Text = "Arrays";
            Arrays.UseVisualStyleBackColor = true;
            // 
            // textBox9
            // 
            textBox9.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox9.Location = new Point(3, 88);
            textBox9.Multiline = true;
            textBox9.Name = "textBox9";
            textBox9.ReadOnly = true;
            textBox9.Size = new Size(308, 216);
            textBox9.TabIndex = 13;
            textBox9.Text = "RedArray\r\n0xFF0000\r\n0xFF0000\r\n0xFF0000\r\n\r\n0x00FF00 Green\r\n0x0000FF Blue\r\n\r\nAnother\r\n0xFF0000\r\n0xFF0000\r\n0xFF0000\r\n";
            // 
            // textBox10
            // 
            textBox10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox10.Location = new Point(317, 88);
            textBox10.Multiline = true;
            textBox10.Name = "textBox10";
            textBox10.ReadOnly = true;
            textBox10.Size = new Size(308, 216);
            textBox10.TabIndex = 12;
            textBox10.Text = resources.GetString("textBox10.Text");
            // 
            // richTextBox3
            // 
            richTextBox3.BorderStyle = BorderStyle.None;
            richTextBox3.Location = new Point(6, 6);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox3.Size = new Size(619, 76);
            richTextBox3.TabIndex = 14;
            richTextBox3.Text = resources.GetString("richTextBox3.Text");
            // 
            // Hex2ColourHelp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 361);
            Controls.Add(tabControl);
            MaximizeBox = false;
            MaximumSize = new Size(652, 400);
            MinimizeBox = false;
            MinimumSize = new Size(500, 400);
            Name = "Hex2ColourHelp";
            Text = "Hex2ColourHelp";
            tabControl.ResumeLayout(false);
            General.ResumeLayout(false);
            General.PerformLayout();
            NameFormat.ResumeLayout(false);
            NameFormat.PerformLayout();
            NameFormat2.ResumeLayout(false);
            NameFormat2.PerformLayout();
            Arrays.ResumeLayout(false);
            Arrays.PerformLayout();
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
        private TabPage NameFormat2;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private RichTextBox richTextBox2;
        private TabPage Arrays;
        private TextBox textBox9;
        private TextBox textBox10;
        private RichTextBox richTextBox3;
    }
}