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
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                // user defined hotkey has been pressed. 
                Clipboard.SetText(DateTime.Now.ToString("yyyy_MM_dd_HHmmssfff ")); // generate a timestamp in clipboard
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
            this.label_usermodifier = new System.Windows.Forms.Label();
            this.label_userhotkey = new System.Windows.Forms.Label();
            this.textbox_modifier = new System.Windows.Forms.TextBox();
            this.textbox_keyintvalue = new System.Windows.Forms.TextBox();
            this.textbox_userhotkey = new System.Windows.Forms.TextBox();
            this.checkBox_win = new System.Windows.Forms.CheckBox();
            this.checkBox_shift = new System.Windows.Forms.CheckBox();
            this.checkBox_alt = new System.Windows.Forms.CheckBox();
            this.checkBox_ctrl = new System.Windows.Forms.CheckBox();
            this.contextmenu_tray.SuspendLayout();
            this.mainpanel.SuspendLayout();
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
            this.textbox_userhotkey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_userhotkey_KeyPress);
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
            // mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 285);
            this.Controls.Add(this.mainpanel);
            this.Name = "mainwindow";
            this.Text = "Timestamper";
            this.contextmenu_tray.ResumeLayout(false);
            this.mainpanel.ResumeLayout(false);
            this.mainpanel.PerformLayout();
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
    }
}

