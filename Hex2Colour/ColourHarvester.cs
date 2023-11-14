using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Hex2Colour
{
    public partial class ColourHarvester : Form
    {
        public ColourHarvester()
        {
            InitializeComponent();
        }

        public List<string> GrabbedStrings { get; set; } = new List<string>();

        void GrabColours()
        {
            try
            {
                string text = textBox_Text.Text;
                Regex regex = new Regex("((0x|#)?([0-9a-fA-F]{6,8}))");
                var matches = regex.Matches(text);

                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        listBox_Colours.Items.Add(match.Groups[1].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to harvest colours");
            }
        }


        private void textBox_URL_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GrabColours();
            }
        }

        private void button_Grab_Click(object sender, EventArgs e)
        {
            GrabColours();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selected = new ListBox.SelectedObjectCollection(listBox_Colours);
            selected = listBox_Colours.SelectedItems;

            if (listBox_Colours.SelectedIndex != -1)
            {
                for (int i = selected.Count - 1; i >= 0; i--)
                    listBox_Colours.Items.Remove(selected[i]);
            }
        }

        private void HttpGrabber_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (string item in listBox_Colours.Items)
            {
                GrabbedStrings.Add(item);
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            listBox_Colours.Items.Clear();
        }
    }
}
