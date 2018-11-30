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
    public partial class mainwindow : Form
    {
        public mainwindow()
        {
            InitializeComponent();
            // Modifier keys codes: Alt = 1, Ctrl = 2, Shift = 4, Win = 8
            // Compute the addition of each combination of the keys you want to be pressed
            // ALT+CTRL = 1 + 2 = 3 , CTRL+SHIFT = 2 + 4 = 6...
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, Properties.Settings.Default.user_modifier, Properties.Settings.Default.user_hotkey);
        }

        private void textbox_userhotkey_KeyPress(object sender, KeyPressEventArgs e)
        {
            textbox_userhotkey.Text = e.KeyChar.ToString();
            int keyintvalue;
            if (Int32.TryParse(textbox_userhotkey.Text.ToString(), out keyintvalue))
            {
                textbox_userhotkey.Text = "wtf";
                textbox_keyintvalue.Text = keyintvalue.ToString();
            }
        }
    }
}
