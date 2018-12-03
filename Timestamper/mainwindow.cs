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
        const int intcode_alt = 1, intcode_ctrl = 2, intcode_shift = 4, intcode_win = 8;
        int user_hotkey = Properties.Settings.Default.user_hotkey;
        int user_modifier = Properties.Settings.Default.user_modifier;

        private void checkBox_win_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_win.Checked) user_modifier += intcode_win;
            else user_modifier -= intcode_win;
            textbox_modifier.Text = user_modifier.ToString();
        }

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
            //textbox_userhotkey.Text = e.KeyChar.ToString();
            //int keyintvalue;
            //if (Int32.TryParse(textbox_userhotkey.Text.ToString(), out keyintvalue))
            //{
            //    textbox_userhotkey.Text = "wtf";
            //    textbox_keyintvalue.Text = keyintvalue.ToString();
            //}
        }

        private void textbox_userhotkey_KeyDown(object sender, KeyEventArgs e)
        {
            Keys modifierKeys = e.Modifiers;
            Keys pressedKey = e.KeyData ^ modifierKeys; //remove modifier keys

            var converter = new KeysConverter();
            textbox_userhotkey.Text = converter.ConvertToString(e.KeyData);
            textbox_keyintvalue.Text = e.KeyValue.ToString();

             user_hotkey = e.KeyValue;
             user_modifier = 0;
            // intcode_alt = 1, intcode_ctrl = 2, intcode_shift = 4, intcode_win = 8;
            checkBox_alt.Checked = false;
            checkBox_ctrl.Checked = false;
            checkBox_shift.Checked = false;
            //checkBox_win.Checked = false;
            if (Control.ModifierKeys.HasFlag(Keys.Alt)) { user_modifier += intcode_alt; checkBox_alt.Checked = true; }
            if (Control.ModifierKeys.HasFlag(Keys.Control)) { user_modifier += intcode_ctrl; checkBox_ctrl.Checked = true; }
            if (Control.ModifierKeys.HasFlag(Keys.Shift)) { user_modifier += intcode_shift; checkBox_shift.Checked = true; }
            //if (Control.ModifierKeys.HasFlag(Keys.LWin) || Control.ModifierKeys.HasFlag(Keys.RWin)) { user_modifier += intcode_win; checkBox_win.Checked = true; }
            if (checkBox_win.Checked) user_modifier += intcode_win; 
            textbox_modifier.Text = user_modifier.ToString();
        }
    }
}