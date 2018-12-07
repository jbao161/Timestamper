using System;
using System.Runtime.InteropServices; //required for dll import
using System.Windows.Forms;

namespace Timestamper
{
    partial class mainwindow
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        // begin deletion: simulate a key press programmatically. unfortunately, this didn't work to "cancel out" a user's holding down alt key
        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        //const int keybd_key_shift = 0x10;
        //const int keybd_key_control = 0x11;
        //const int keybd_key_alt = 0x12;
        //const int keybd_state_pressed = 1;
        //const int keybd_state_unpressed = 2;
        // end deletion
        const int wait_ticks_onesecond = (int)TimeSpan.TicksPerSecond; // wait one second for alt key to be released

        const int MYACTION_HOTKEY_ID = 0; // hotkey unassigned

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
        protected override void WndProc(ref Message m)
        { // monitor keyboard input for the hotkey combination
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID) // user defined hotkey has been pressed. 
            {
                Clipboard.SetText(DateTime.Now.ToString("yyyy_MM_dd_HHmmssfff ")); // generate a timestamp in clipboard
               // alt messes up the control + V paste shortcut, so wait until it's released or timeout
                long currentTick = DateTime.Now.Ticks;
                while (ModifierKeys.HasFlag(Keys.Alt)&
                    (DateTime.Now.Ticks - currentTick) < 5*wait_ticks_onesecond) { } // wait. do nothing.
                SendKeys.Send("^V"); // paste clipboard contents
            }
            base.WndProc(ref m);
        }

        private void trayicon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void tray_open_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void tray_close_Click(object sender, EventArgs e)
        {
            Close();
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainwindow));
            this.trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextmenu_tray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tray_open = new System.Windows.Forms.ToolStripMenuItem();
            this.tray_close = new System.Windows.Forms.ToolStripMenuItem();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.label_textbox_userhotkey = new System.Windows.Forms.Label();
            this.label_textbox_status = new System.Windows.Forms.Label();
            this.textbox_status = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.label_usermodifier = new System.Windows.Forms.Label();
            this.label_userhotkey = new System.Windows.Forms.Label();
            this.textbox_modifier = new System.Windows.Forms.TextBox();
            this.textbox_keyintvalue = new System.Windows.Forms.TextBox();
            this.textbox_userhotkey = new System.Windows.Forms.TextBox();
            this.checkBox_win = new System.Windows.Forms.CheckBox();
            this.checkBox_shift = new System.Windows.Forms.CheckBox();
            this.checkBox_alt = new System.Windows.Forms.CheckBox();
            this.checkBox_ctrl = new System.Windows.Forms.CheckBox();
            this.picturebox_mainsplash = new System.Windows.Forms.PictureBox();
            this.contextmenu_tray.SuspendLayout();
            this.mainpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_mainsplash)).BeginInit();
            this.SuspendLayout();
            // 
            // trayicon
            // 
            this.trayicon.ContextMenuStrip = this.contextmenu_tray;
            this.trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicon.Icon")));
            this.trayicon.Text = "TrayDemo";
            this.trayicon.Visible = true;
            this.trayicon.DoubleClick += new System.EventHandler(this.trayicon_DoubleClick);
            // 
            // contextmenu_tray
            // 
            this.contextmenu_tray.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextmenu_tray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tray_open,
            this.tray_close});
            this.contextmenu_tray.Name = "contextmenu_tray";
            this.contextmenu_tray.Size = new System.Drawing.Size(115, 52);
            // 
            // tray_open
            // 
            this.tray_open.Name = "tray_open";
            this.tray_open.Size = new System.Drawing.Size(114, 24);
            this.tray_open.Text = "Open";
            this.tray_open.Click += new System.EventHandler(this.tray_open_Click);
            // 
            // tray_close
            // 
            this.tray_close.Name = "tray_close";
            this.tray_close.Size = new System.Drawing.Size(114, 24);
            this.tray_close.Text = "Close";
            this.tray_close.Click += new System.EventHandler(this.tray_close_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainpanel.Controls.Add(this.picturebox_mainsplash);
            this.mainpanel.Controls.Add(this.label_textbox_userhotkey);
            this.mainpanel.Controls.Add(this.label_textbox_status);
            this.mainpanel.Controls.Add(this.textbox_status);
            this.mainpanel.Controls.Add(this.button_save);
            this.mainpanel.Controls.Add(this.label_usermodifier);
            this.mainpanel.Controls.Add(this.label_userhotkey);
            this.mainpanel.Controls.Add(this.textbox_modifier);
            this.mainpanel.Controls.Add(this.textbox_keyintvalue);
            this.mainpanel.Controls.Add(this.textbox_userhotkey);
            this.mainpanel.Controls.Add(this.checkBox_win);
            this.mainpanel.Controls.Add(this.checkBox_shift);
            this.mainpanel.Controls.Add(this.checkBox_alt);
            this.mainpanel.Controls.Add(this.checkBox_ctrl);
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(0, 0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(504, 285);
            this.mainpanel.TabIndex = 1;
            // 
            // label_textbox_userhotkey
            // 
            this.label_textbox_userhotkey.AutoSize = true;
            this.label_textbox_userhotkey.Location = new System.Drawing.Point(333, 114);
            this.label_textbox_userhotkey.Name = "label_textbox_userhotkey";
            this.label_textbox_userhotkey.Size = new System.Drawing.Size(136, 17);
            this.label_textbox_userhotkey.TabIndex = 12;
            this.label_textbox_userhotkey.Text = "<- Type hotkey here";
            // 
            // label_textbox_status
            // 
            this.label_textbox_status.AutoSize = true;
            this.label_textbox_status.Location = new System.Drawing.Point(425, 219);
            this.label_textbox_status.Name = "label_textbox_status";
            this.label_textbox_status.Size = new System.Drawing.Size(48, 17);
            this.label_textbox_status.TabIndex = 11;
            this.label_textbox_status.Text = "Status";
            // 
            // textbox_status
            // 
            this.textbox_status.Enabled = false;
            this.textbox_status.Location = new System.Drawing.Point(167, 214);
            this.textbox_status.Name = "textbox_status";
            this.textbox_status.Size = new System.Drawing.Size(250, 22);
            this.textbox_status.TabIndex = 10;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(244, 242);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(74, 30);
            this.button_save.TabIndex = 9;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label_usermodifier
            // 
            this.label_usermodifier.AutoSize = true;
            this.label_usermodifier.Location = new System.Drawing.Point(324, 182);
            this.label_usermodifier.Name = "label_usermodifier";
            this.label_usermodifier.Size = new System.Drawing.Size(93, 17);
            this.label_usermodifier.TabIndex = 8;
            this.label_usermodifier.Text = "Modifier code";
            // 
            // label_userhotkey
            // 
            this.label_userhotkey.AutoSize = true;
            this.label_userhotkey.Location = new System.Drawing.Point(324, 154);
            this.label_userhotkey.Name = "label_userhotkey";
            this.label_userhotkey.Size = new System.Drawing.Size(67, 17);
            this.label_userhotkey.TabIndex = 7;
            this.label_userhotkey.Text = "Key code";
            // 
            // textbox_modifier
            // 
            this.textbox_modifier.Enabled = false;
            this.textbox_modifier.Location = new System.Drawing.Point(167, 182);
            this.textbox_modifier.Name = "textbox_modifier";
            this.textbox_modifier.Size = new System.Drawing.Size(151, 22);
            this.textbox_modifier.TabIndex = 6;
            this.textbox_modifier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textbox_keyintvalue
            // 
            this.textbox_keyintvalue.Enabled = false;
            this.textbox_keyintvalue.Location = new System.Drawing.Point(167, 154);
            this.textbox_keyintvalue.Name = "textbox_keyintvalue";
            this.textbox_keyintvalue.Size = new System.Drawing.Size(151, 22);
            this.textbox_keyintvalue.TabIndex = 5;
            this.textbox_keyintvalue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textbox_userhotkey
            // 
            this.textbox_userhotkey.Location = new System.Drawing.Point(167, 114);
            this.textbox_userhotkey.Name = "textbox_userhotkey";
            this.textbox_userhotkey.ReadOnly = true;
            this.textbox_userhotkey.Size = new System.Drawing.Size(151, 22);
            this.textbox_userhotkey.TabIndex = 4;
            this.textbox_userhotkey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textbox_userhotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_userhotkey_KeyDown);
            // 
            // checkBox_win
            // 
            this.checkBox_win.AutoSize = true;
            this.checkBox_win.Location = new System.Drawing.Point(69, 196);
            this.checkBox_win.Name = "checkBox_win";
            this.checkBox_win.Size = new System.Drawing.Size(54, 21);
            this.checkBox_win.TabIndex = 3;
            this.checkBox_win.Text = "Win";
            this.checkBox_win.UseVisualStyleBackColor = true;
            this.checkBox_win.CheckedChanged += new System.EventHandler(this.checkBox_win_CheckedChanged);
            // 
            // checkBox_shift
            // 
            this.checkBox_shift.AutoSize = true;
            this.checkBox_shift.Enabled = false;
            this.checkBox_shift.Location = new System.Drawing.Point(69, 168);
            this.checkBox_shift.Name = "checkBox_shift";
            this.checkBox_shift.Size = new System.Drawing.Size(58, 21);
            this.checkBox_shift.TabIndex = 2;
            this.checkBox_shift.Text = "Shift";
            this.checkBox_shift.UseVisualStyleBackColor = true;
            // 
            // checkBox_alt
            // 
            this.checkBox_alt.AutoSize = true;
            this.checkBox_alt.Enabled = false;
            this.checkBox_alt.Location = new System.Drawing.Point(69, 141);
            this.checkBox_alt.Name = "checkBox_alt";
            this.checkBox_alt.Size = new System.Drawing.Size(46, 21);
            this.checkBox_alt.TabIndex = 1;
            this.checkBox_alt.Text = "Alt";
            this.checkBox_alt.UseVisualStyleBackColor = true;
            // 
            // checkBox_ctrl
            // 
            this.checkBox_ctrl.AutoSize = true;
            this.checkBox_ctrl.Enabled = false;
            this.checkBox_ctrl.Location = new System.Drawing.Point(69, 114);
            this.checkBox_ctrl.Name = "checkBox_ctrl";
            this.checkBox_ctrl.Size = new System.Drawing.Size(51, 21);
            this.checkBox_ctrl.TabIndex = 0;
            this.checkBox_ctrl.Text = "Ctrl";
            this.checkBox_ctrl.UseVisualStyleBackColor = true;
            // 
            // picturebox_mainsplash
            // 
            this.picturebox_mainsplash.Image = global::Timestamper.Properties.Resources.mainsplash;
            this.picturebox_mainsplash.Location = new System.Drawing.Point(11, 11);
            this.picturebox_mainsplash.Name = "picturebox_mainsplash";
            this.picturebox_mainsplash.Size = new System.Drawing.Size(480, 97);
            this.picturebox_mainsplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox_mainsplash.TabIndex = 13;
            this.picturebox_mainsplash.TabStop = false;
            // 
            // mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 285);
            this.Controls.Add(this.mainpanel);
            this.Name = "mainwindow";
            this.Text = "Timestamper";
            this.Load += new System.EventHandler(this.mainwindow_Load);
            this.contextmenu_tray.ResumeLayout(false);
            this.mainpanel.ResumeLayout(false);
            this.mainpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_mainsplash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon trayicon;
        private System.Windows.Forms.ContextMenuStrip contextmenu_tray;
        private System.Windows.Forms.ToolStripMenuItem tray_open;
        private System.Windows.Forms.ToolStripMenuItem tray_close;
        private Panel mainpanel;
        private CheckBox checkBox_ctrl;
        private CheckBox checkBox_alt;
        private CheckBox checkBox_win;
        private CheckBox checkBox_shift;
        private TextBox textbox_userhotkey;
        private TextBox textbox_keyintvalue;
        private Label label_usermodifier;
        private Label label_userhotkey;
        private TextBox textbox_modifier;
        private Button button_save;
        private Label label_textbox_userhotkey;
        private Label label_textbox_status;
        private TextBox textbox_status;
        private PictureBox picturebox_mainsplash;
    }
}

