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
        static readonly string[] commonNotations = new string[]
        {
            "0x",
            "#"
        };


        List<string> notations = new List<string>()
        {
            commonNotations[0],
            commonNotations[1]
        };


        public ColourHarvester()
        {
            InitializeComponent();
            comboBox_Specifier.Items.AddRange(notations.ToArray());
        }

        public List<string> GrabbedStrings { get; set; } = new List<string>();


        string NotationPatten
        {
            get
            {
                string pattern = '(' + string.Join('|', notations) + ')';

                return checkBox_RequireNotation.Checked ? pattern : pattern + '?';
            }
        }

        void HarvestColours(string text)
        {
            try
            {
                string pattern = textBox_CustomPattern.Text != string.Empty ? textBox_CustomPattern.Text : $"({NotationPatten}((?:[0-9a-fA-F]{{6}})|(?:[0-9a-fA-F]{{8}})))";

                Regex regex = new Regex(pattern);
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

        private void DownloadText()
        {
            if (textBox_URL.Text == string.Empty)
                return;

            try
            {
                WebClient client = new WebClient();
                textBox_Text.Text = client.DownloadString(textBox_URL.Text);
            }
            catch
            {
                MessageBox.Show("Failed to download webpage");
            }
        }

        private void DeleteSelectedColourItems()
        {
            if (listBox_Colours.SelectedIndex == -1)
                return;

            var selected = listBox_Colours.SelectedItems;

            for (int i = selected.Count - 1; i >= 0; i--)
                listBox_Colours.Items.Remove(selected[i]);
        }


        private void textBox_URL_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DownloadText();
            }
        }

        private void button_Grab_Click(object sender, EventArgs e)
        {
            HarvestColours(textBox_Text.Text);
        }

        private void button_Harvest_Click(object sender, EventArgs e)
        {
            DownloadText();

        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            DeleteSelectedColourItems();
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

        private void button_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void listBox_Colours_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteSelectedColourItems();
            else if (e.Control)
            {
                if (e.KeyCode == Keys.C)
                {
                    string colours = string.Join("\r\n", listBox_Colours.SelectedItems.OfType<string>().ToArray());
                    Clipboard.SetText(colours);
                }
                else if(e.KeyCode == Keys.X)
                {
                    string colours = string.Join("\r\n", listBox_Colours.SelectedItems.OfType<string>().ToArray());
                    Clipboard.SetText(colours);
                    DeleteSelectedColourItems();
                }
                else if(e.KeyCode == Keys.A)
                {
                    var items = listBox_Colours.Items;

                    for(int i = 0; i < items.Count; i++)
                    {
                        listBox_Colours.SelectedItems.Add(items[i]);
                    }
                }
            }
        }

        private void comboBox_Specifier_KeyUp(object sender, KeyEventArgs e)
        {
            string spec = comboBox_Specifier.Text;
            if (e.KeyCode == Keys.Enter)
            {
                if (!notations.Contains(spec))
                {
                    notations.Add(spec);
                    comboBox_Specifier.Items.Add(spec);
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (notations.Contains(spec) && Array.IndexOf(commonNotations, spec) == -1)
                {
                    notations.Remove(spec);
                    comboBox_Specifier.Items.Remove(spec);
                }
            }
        }
    }
}
