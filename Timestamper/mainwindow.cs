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
        // Modifier keys codes: Alt = 1, Ctrl = 2, Shift = 4, Win = 8
        // Compute the addition of each combination of the keys you want to be pressed
        // ALT+CTRL = 1 + 2 = 3 , CTRL+SHIFT = 2 + 4 = 6...
        const int intmodifier_alt = 1, intmodifier_ctrl = 2, intmodifier_shift = 4, intmodifier_win = 8;
        // Char codes corresponding to modifier keys in KeyEventArgs.KeyValue
        const int intchar_alt = 18, intchar_ctrl = 17, intchar_shift = 16, intchar_lwin = 91, intchar_rwin = 92, intchar_tab = 9, intchar_backspace = 8, intchar_capslock = 20;

        int user_hotkey = Properties.Settings.Default.user_hotkey;
        int user_modifier = Properties.Settings.Default.user_modifier;

        private void checkBox_win_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_win.Checked) user_modifier += intmodifier_win;
            else user_modifier -= intmodifier_win;
            textbox_modifier.Text = user_modifier.ToString();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.user_hotkey == user_hotkey &
            Properties.Settings.Default.user_modifier == user_modifier) return; // if no changes do nothing 
            if (RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, user_modifier, user_hotkey))
            {
                UnregisterHotKey(this.Handle, MYACTION_HOTKEY_ID);
                Properties.Settings.Default.user_hotkey = user_hotkey;
                Properties.Settings.Default.user_modifier = user_modifier;
                textbox_userhotkey.Text = "Success";
            }
            else { textbox_userhotkey.Text = "Fail. Hotkey is unusable."; }
        }

        public mainwindow()
        {
            InitializeComponent();
            // hook the keyboard shortcut
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, Properties.Settings.Default.user_modifier, Properties.Settings.Default.user_hotkey);
        }

        private void textbox_userhotkey_KeyDown(object sender, KeyEventArgs e)
        {
            Keys modifierKeys = e.Modifiers;
            Keys pressedKey = e.KeyData ^ modifierKeys; //remove modifier keys

            // if only modifier keys are pressed, do nothing
            if (e.KeyValue == intchar_alt || e.KeyValue == intchar_ctrl || e.KeyValue == intchar_shift
                || e.KeyValue == intchar_lwin || e.KeyValue == intchar_rwin
                || e.KeyValue == intchar_tab || e.KeyValue == intchar_capslock || e.KeyValue == intchar_backspace)
            {
                textbox_userhotkey.Text = e.KeyCode.ToString() + " (Not usable)";
                return;
            }

            // display which key was pressed
            var converter = new KeysConverter();
            textbox_userhotkey.Text = converter.ConvertToString(e.KeyData);
            textbox_keyintvalue.Text = e.KeyValue.ToString();

            // remember the user defined key and its modifiers
            user_hotkey = e.KeyValue;
            user_modifier = 0; // intcode_alt = 1, intcode_ctrl = 2, intcode_shift = 4, intcode_win = 8;

            checkBox_alt.Checked = false;
            checkBox_ctrl.Checked = false;
            checkBox_shift.Checked = false;
            // count which modifiers to use
            if (Control.ModifierKeys.HasFlag(Keys.Alt)) { user_modifier += intmodifier_alt; checkBox_alt.Checked = true; }
            if (Control.ModifierKeys.HasFlag(Keys.Control)) { user_modifier += intmodifier_ctrl; checkBox_ctrl.Checked = true; }
            if (Control.ModifierKeys.HasFlag(Keys.Shift)) { user_modifier += intmodifier_shift; checkBox_shift.Checked = true; }
            if (checkBox_win.Checked) user_modifier += intmodifier_win;
            
            // display which modifiers are pressed
            textbox_modifier.Text = user_modifier.ToString();
        }
    }
}