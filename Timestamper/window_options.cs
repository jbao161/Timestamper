using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timestamper
{
    public partial class window_options : Form
    {
        public window_options()
        {
            InitializeComponent();
            textbox_datetime_userstring.Text = Properties.Settings.Default.user_timestamp;
            string explanation_string_numbers =
                "Numbers:" + "\n\n" +
                "yyyy year" + "\n" +
                "yy year" + "\n" +
                "MM month" + "\n" +
                "dd day" + "\n" +
                "HH hour (24hr)" + "\n" +
                "mm minute" + "\n" +
                "ss second" + "\n" +
                "f tenth of second" + "\n" +
                "ff hundredth of second" + "\n" +
                "fff millisecond" + "\n";
            string explanation_string_words =
                "Words:" + "\n\n" +
                "ddd abbreviated name of day" + "\n" +
                "dddd name of day" + "\n" +
                "MMM abbreviated name of month" + "\n" +
                "MMMM name of month" + "\n" +
                "tt AM or PM" + "\n" +
                " " + "\n" +
                "\" \" use quotes around custom text" + "\n";
            string explanation_example = "Example: " + Environment.NewLine + Environment.NewLine + 
                "yyyy_MM_dd_HHmmssfff " + " creates a timestamp like this: " + "2018_12_31_235959123 " + Environment.NewLine +
                "\"Time Stamper\" MMMM d, yyyy hh:mm:ss tt " + " creates a timestamp like this: " + "Time Stamper December 31, 2018 11:59:59 PM" + "\n";
            this.label_customtimestamp_explanation_numbers.Text = explanation_string_numbers;
            this.label_customtimestamp_explanation_names.Text = explanation_string_words;
            this.textbox_customtimestamp_example.Text = explanation_example;
        }

        private void linkLabel_msdoc_datetime_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            this.linkLabel_msdoc_datetime.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings");
        }

        private void button_options_timestamp_save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.user_timestamp = textbox_datetime_userstring.Text;
            Properties.Settings.Default.Save();
            button_options_timestamp_save.Enabled = false;
        }

        private void textbox_datetime_userstring_TextChanged(object sender, EventArgs e)
        {
            button_options_timestamp_save.Enabled = true;
        }
    }
}
