namespace Timestamper
{
    partial class window_options
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
            this.textbox_datetime_userstring = new System.Windows.Forms.TextBox();
            this.label_textbox_datetime_userstring = new System.Windows.Forms.Label();
            this.label_customtimestamp_explanation_numbers = new System.Windows.Forms.Label();
            this.linkLabel_msdoc_datetime = new System.Windows.Forms.LinkLabel();
            this.label_customtimestamp_explanation_names = new System.Windows.Forms.Label();
            this.button_options_timestamp_save = new System.Windows.Forms.Button();
            this.textbox_customtimestamp_example = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textbox_datetime_userstring
            // 
            this.textbox_datetime_userstring.Location = new System.Drawing.Point(12, 12);
            this.textbox_datetime_userstring.Name = "textbox_datetime_userstring";
            this.textbox_datetime_userstring.Size = new System.Drawing.Size(692, 22);
            this.textbox_datetime_userstring.TabIndex = 0;
            this.textbox_datetime_userstring.TextChanged += new System.EventHandler(this.textbox_datetime_userstring_TextChanged);
            // 
            // label_textbox_datetime_userstring
            // 
            this.label_textbox_datetime_userstring.AutoSize = true;
            this.label_textbox_datetime_userstring.Location = new System.Drawing.Point(12, 37);
            this.label_textbox_datetime_userstring.Name = "label_textbox_datetime_userstring";
            this.label_textbox_datetime_userstring.Size = new System.Drawing.Size(460, 17);
            this.label_textbox_datetime_userstring.TabIndex = 1;
            this.label_textbox_datetime_userstring.Text = "Customize the time stamp. Use the codes below to add dates and times.";
            // 
            // label_customtimestamp_explanation_numbers
            // 
            this.label_customtimestamp_explanation_numbers.Location = new System.Drawing.Point(12, 108);
            this.label_customtimestamp_explanation_numbers.Name = "label_customtimestamp_explanation_numbers";
            this.label_customtimestamp_explanation_numbers.Size = new System.Drawing.Size(333, 194);
            this.label_customtimestamp_explanation_numbers.TabIndex = 2;
            this.label_customtimestamp_explanation_numbers.Text = "placeholder text numbers explanation";
            // 
            // linkLabel_msdoc_datetime
            // 
            this.linkLabel_msdoc_datetime.AutoSize = true;
            this.linkLabel_msdoc_datetime.Location = new System.Drawing.Point(12, 69);
            this.linkLabel_msdoc_datetime.Name = "linkLabel_msdoc_datetime";
            this.linkLabel_msdoc_datetime.Size = new System.Drawing.Size(408, 17);
            this.linkLabel_msdoc_datetime.TabIndex = 3;
            this.linkLabel_msdoc_datetime.TabStop = true;
            this.linkLabel_msdoc_datetime.Text = "See Microsoft documentation on Date and Time string modifiers";
            this.linkLabel_msdoc_datetime.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_msdoc_datetime_LinkClicked);
            // 
            // label_customtimestamp_explanation_names
            // 
            this.label_customtimestamp_explanation_names.Location = new System.Drawing.Point(374, 108);
            this.label_customtimestamp_explanation_names.Name = "label_customtimestamp_explanation_names";
            this.label_customtimestamp_explanation_names.Size = new System.Drawing.Size(330, 194);
            this.label_customtimestamp_explanation_names.TabIndex = 4;
            this.label_customtimestamp_explanation_names.Text = "placeholder text names explanation";
            // 
            // button_options_timestamp_save
            // 
            this.button_options_timestamp_save.Location = new System.Drawing.Point(549, 50);
            this.button_options_timestamp_save.Name = "button_options_timestamp_save";
            this.button_options_timestamp_save.Size = new System.Drawing.Size(154, 35);
            this.button_options_timestamp_save.TabIndex = 6;
            this.button_options_timestamp_save.Text = "Save";
            this.button_options_timestamp_save.UseVisualStyleBackColor = true;
            this.button_options_timestamp_save.Click += new System.EventHandler(this.button_options_timestamp_save_Click);
            // 
            // textbox_customtimestamp_example
            // 
            this.textbox_customtimestamp_example.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textbox_customtimestamp_example.Location = new System.Drawing.Point(15, 305);
            this.textbox_customtimestamp_example.Multiline = true;
            this.textbox_customtimestamp_example.Name = "textbox_customtimestamp_example";
            this.textbox_customtimestamp_example.ReadOnly = true;
            this.textbox_customtimestamp_example.Size = new System.Drawing.Size(688, 77);
            this.textbox_customtimestamp_example.TabIndex = 7;
            this.textbox_customtimestamp_example.Text = "placeholder text example";
            // 
            // window_options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 394);
            this.Controls.Add(this.textbox_customtimestamp_example);
            this.Controls.Add(this.button_options_timestamp_save);
            this.Controls.Add(this.label_customtimestamp_explanation_names);
            this.Controls.Add(this.linkLabel_msdoc_datetime);
            this.Controls.Add(this.label_customtimestamp_explanation_numbers);
            this.Controls.Add(this.label_textbox_datetime_userstring);
            this.Controls.Add(this.textbox_datetime_userstring);
            this.Name = "window_options";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_datetime_userstring;
        private System.Windows.Forms.Label label_textbox_datetime_userstring;
        private System.Windows.Forms.Label label_customtimestamp_explanation_numbers;
        private System.Windows.Forms.LinkLabel linkLabel_msdoc_datetime;
        private System.Windows.Forms.Label label_customtimestamp_explanation_names;
        private System.Windows.Forms.Button button_options_timestamp_save;
        private System.Windows.Forms.TextBox textbox_customtimestamp_example;
    }
}