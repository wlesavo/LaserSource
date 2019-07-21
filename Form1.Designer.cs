namespace Source_forms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.stop_button = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Power_label = new System.Windows.Forms.Label();
            this.time_label = new System.Windows.Forms.Label();
            this.temp_value_l = new System.Windows.Forms.Label();
            this.start_button = new System.Windows.Forms.Button();
            this.comboBox_comports = new System.Windows.Forms.ComboBox();
            this.connect_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pow_value_l = new System.Windows.Forms.Label();
            this.td_value_l = new System.Windows.Forms.Label();
            this.temp_val = new System.Windows.Forms.Label();
            this.cur_time_l = new System.Windows.Forms.Label();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.disconnect_button = new System.Windows.Forms.Button();
            this.connection_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // stop_button
            // 
            this.stop_button.BackColor = System.Drawing.Color.Red;
            this.stop_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stop_button.Location = new System.Drawing.Point(436, 260);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(114, 82);
            this.stop_button.TabIndex = 4;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = false;
            this.stop_button.Click += new System.EventHandler(this.Stop_button_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(603, 259);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(155, 82);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            // 
            // Power_label
            // 
            this.Power_label.AutoSize = true;
            this.Power_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Power_label.Location = new System.Drawing.Point(12, 45);
            this.Power_label.Name = "Power_label";
            this.Power_label.Size = new System.Drawing.Size(91, 31);
            this.Power_label.TabIndex = 6;
            this.Power_label.Text = "Power";
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_label.Location = new System.Drawing.Point(371, 45);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(74, 31);
            this.time_label.TabIndex = 7;
            this.time_label.Text = "Time";
            // 
            // temp_value_l
            // 
            this.temp_value_l.AutoSize = true;
            this.temp_value_l.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.temp_value_l.Location = new System.Drawing.Point(155, 45);
            this.temp_value_l.Name = "temp_value_l";
            this.temp_value_l.Size = new System.Drawing.Size(169, 31);
            this.temp_value_l.TabIndex = 8;
            this.temp_value_l.Text = "Temperature";
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.Lime;
            this.start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_button.Location = new System.Drawing.Point(307, 260);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(104, 81);
            this.start_button.TabIndex = 9;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = false;
            this.start_button.Click += new System.EventHandler(this.Start_button_Click);
            // 
            // comboBox_comports
            // 
            this.comboBox_comports.FormattingEnabled = true;
            this.comboBox_comports.Location = new System.Drawing.Point(511, 57);
            this.comboBox_comports.Name = "comboBox_comports";
            this.comboBox_comports.Size = new System.Drawing.Size(121, 21);
            this.comboBox_comports.TabIndex = 11;
            this.comboBox_comports.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // connect_button
            // 
            this.connect_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connect_button.Location = new System.Drawing.Point(638, 45);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(97, 41);
            this.connect_button.TabIndex = 12;
            this.connect_button.Text = "connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.Connect_button_Click);
            // 
            // save_button
            // 
            this.save_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save_button.Location = new System.Drawing.Point(603, 358);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(154, 43);
            this.save_button.TabIndex = 13;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(635, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Description";
            // 
            // pow_value_l
            // 
            this.pow_value_l.AutoSize = true;
            this.pow_value_l.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pow_value_l.Location = new System.Drawing.Point(38, 76);
            this.pow_value_l.Name = "pow_value_l";
            this.pow_value_l.Size = new System.Drawing.Size(64, 31);
            this.pow_value_l.TabIndex = 15;
            this.pow_value_l.Text = "pow";
            // 
            // td_value_l
            // 
            this.td_value_l.AutoSize = true;
            this.td_value_l.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.td_value_l.Location = new System.Drawing.Point(386, 76);
            this.td_value_l.Name = "td_value_l";
            this.td_value_l.Size = new System.Drawing.Size(37, 31);
            this.td_value_l.TabIndex = 16;
            this.td_value_l.Text = "td";
            // 
            // temp_val
            // 
            this.temp_val.AutoSize = true;
            this.temp_val.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.temp_val.Location = new System.Drawing.Point(217, 76);
            this.temp_val.Name = "temp_val";
            this.temp_val.Size = new System.Drawing.Size(74, 31);
            this.temp_val.TabIndex = 17;
            this.temp_val.Text = "temp";
            // 
            // cur_time_l
            // 
            this.cur_time_l.AutoSize = true;
            this.cur_time_l.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cur_time_l.Location = new System.Drawing.Point(12, 260);
            this.cur_time_l.Name = "cur_time_l";
            this.cur_time_l.Size = new System.Drawing.Size(163, 31);
            this.cur_time_l.TabIndex = 18;
            this.cur_time_l.Text = "Current time";
            this.cur_time_l.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(Source_forms.Program);
            // 
            // disconnect_button
            // 
            this.disconnect_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.disconnect_button.Location = new System.Drawing.Point(638, 92);
            this.disconnect_button.Name = "disconnect_button";
            this.disconnect_button.Size = new System.Drawing.Size(97, 38);
            this.disconnect_button.TabIndex = 19;
            this.disconnect_button.Text = "disconnect";
            this.disconnect_button.UseVisualStyleBackColor = true;
            this.disconnect_button.Click += new System.EventHandler(this.Disconnect_button_Click);
            // 
            // connection_label
            // 
            this.connection_label.AutoSize = true;
            this.connection_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connection_label.ForeColor = System.Drawing.Color.Red;
            this.connection_label.Location = new System.Drawing.Point(534, 9);
            this.connection_label.Name = "connection_label";
            this.connection_label.Size = new System.Drawing.Size(190, 31);
            this.connection_label.TabIndex = 20;
            this.connection_label.Text = "Not connected";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 425);
            this.Controls.Add(this.connection_label);
            this.Controls.Add(this.disconnect_button);
            this.Controls.Add(this.cur_time_l);
            this.Controls.Add(this.temp_value_l);
            this.Controls.Add(this.td_value_l);
            this.Controls.Add(this.pow_value_l);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.connect_button);
            this.Controls.Add(this.comboBox_comports);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.temp_val);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.Power_label);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.stop_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button stop_button;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label Power_label;
        private System.Windows.Forms.Label time_label;
        private System.Windows.Forms.Label temp_value_l;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.ComboBox comboBox_comports;
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.Button connect_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pow_value_l;
        private System.Windows.Forms.Label td_value_l;
        private System.Windows.Forms.Label temp_val;
        private System.Windows.Forms.Label cur_time_l;
        private System.Windows.Forms.Button disconnect_button;
        private System.Windows.Forms.Label connection_label;
    }
}

