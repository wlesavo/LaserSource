namespace Source_forms
{
    partial class MainWindow
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
            this.disconnect_button = new System.Windows.Forms.Button();
            this.connection_label = new System.Windows.Forms.Label();
            this.exp_time_label = new System.Windows.Forms.Label();
            this.Active_cells_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // stop_button
            // 
            this.stop_button.BackColor = System.Drawing.Color.Red;
            this.stop_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stop_button.Location = new System.Drawing.Point(142, 310);
            this.stop_button.Name = "stop_button";
            this.stop_button.Size = new System.Drawing.Size(114, 82);
            this.stop_button.TabIndex = 4;
            this.stop_button.Text = "Stop";
            this.stop_button.UseVisualStyleBackColor = false;
            this.stop_button.Click += new System.EventHandler(this.StopButtonClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(580, 249);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(155, 82);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.DescriptionTextChanged);
            // 
            // Power_label
            // 
            this.Power_label.AutoSize = true;
            this.Power_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Power_label.Location = new System.Drawing.Point(12, 27);
            this.Power_label.Name = "Power_label";
            this.Power_label.Size = new System.Drawing.Size(188, 31);
            this.Power_label.TabIndex = 6;
            this.Power_label.Text = "Мощность, Вт";
            // 
            // time_label
            // 
            this.time_label.AutoSize = true;
            this.time_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time_label.Location = new System.Drawing.Point(12, 175);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(160, 31);
            this.time_label.TabIndex = 7;
            this.time_label.Text = "Время, мин";
            // 
            // temp_value_l
            // 
            this.temp_value_l.AutoSize = true;
            this.temp_value_l.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.temp_value_l.Location = new System.Drawing.Point(12, 101);
            this.temp_value_l.Name = "temp_value_l";
            this.temp_value_l.Size = new System.Drawing.Size(227, 31);
            this.temp_value_l.TabIndex = 8;
            this.temp_value_l.Text = "Температура, °С";
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.Lime;
            this.start_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.start_button.Location = new System.Drawing.Point(13, 310);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(104, 81);
            this.start_button.TabIndex = 9;
            this.start_button.Text = "Start";
            this.start_button.UseVisualStyleBackColor = false;
            this.start_button.Click += new System.EventHandler(this.StartButtonClick);
            // 
            // comboBox_comports
            // 
            this.comboBox_comports.FormattingEnabled = true;
            this.comboBox_comports.Location = new System.Drawing.Point(511, 74);
            this.comboBox_comports.Name = "comboBox_comports";
            this.comboBox_comports.Size = new System.Drawing.Size(121, 21);
            this.comboBox_comports.TabIndex = 11;
            this.comboBox_comports.SelectedIndexChanged += new System.EventHandler(this.SerialPortBoxSelectedIndexChanged);
            // 
            // connect_button
            // 
            this.connect_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connect_button.Location = new System.Drawing.Point(638, 63);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(97, 41);
            this.connect_button.TabIndex = 12;
            this.connect_button.Text = "connect";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.ConnectButtonClick);
            // 
            // save_button
            // 
            this.save_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save_button.Location = new System.Drawing.Point(580, 348);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(154, 43);
            this.save_button.TabIndex = 13;
            this.save_button.Text = "Save";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(612, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Описание";
            // 
            // pow_value_l
            // 
            this.pow_value_l.AutoSize = true;
            this.pow_value_l.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pow_value_l.Location = new System.Drawing.Point(12, 58);
            this.pow_value_l.Name = "pow_value_l";
            this.pow_value_l.Size = new System.Drawing.Size(64, 31);
            this.pow_value_l.TabIndex = 15;
            this.pow_value_l.Text = "pow";
            // 
            // td_value_l
            // 
            this.td_value_l.AutoSize = true;
            this.td_value_l.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.td_value_l.Location = new System.Drawing.Point(12, 206);
            this.td_value_l.Name = "td_value_l";
            this.td_value_l.Size = new System.Drawing.Size(37, 31);
            this.td_value_l.TabIndex = 16;
            this.td_value_l.Text = "td";
            // 
            // temp_val
            // 
            this.temp_val.AutoSize = true;
            this.temp_val.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.temp_val.Location = new System.Drawing.Point(12, 132);
            this.temp_val.Name = "temp_val";
            this.temp_val.Size = new System.Drawing.Size(74, 31);
            this.temp_val.TabIndex = 17;
            this.temp_val.Text = "temp";
            // 
            // cur_time_l
            // 
            this.cur_time_l.AutoSize = true;
            this.cur_time_l.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cur_time_l.Location = new System.Drawing.Point(238, 148);
            this.cur_time_l.Name = "cur_time_l";
            this.cur_time_l.Size = new System.Drawing.Size(339, 31);
            this.cur_time_l.TabIndex = 18;
            this.cur_time_l.Text = "Время эксперимента, сек";
            this.cur_time_l.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // disconnect_button
            // 
            this.disconnect_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.disconnect_button.Location = new System.Drawing.Point(638, 110);
            this.disconnect_button.Name = "disconnect_button";
            this.disconnect_button.Size = new System.Drawing.Size(97, 38);
            this.disconnect_button.TabIndex = 19;
            this.disconnect_button.Text = "disconnect";
            this.disconnect_button.UseVisualStyleBackColor = true;
            this.disconnect_button.Click += new System.EventHandler(this.DisconnectButtonClick);
            // 
            // connection_label
            // 
            this.connection_label.AutoSize = true;
            this.connection_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connection_label.ForeColor = System.Drawing.Color.Red;
            this.connection_label.Location = new System.Drawing.Point(534, 27);
            this.connection_label.Name = "connection_label";
            this.connection_label.Size = new System.Drawing.Size(190, 31);
            this.connection_label.TabIndex = 20;
            this.connection_label.Text = "Not connected";
            // 
            // exp_time_label
            // 
            this.exp_time_label.AutoSize = true;
            this.exp_time_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exp_time_label.ForeColor = System.Drawing.Color.Red;
            this.exp_time_label.Location = new System.Drawing.Point(353, 192);
            this.exp_time_label.Name = "exp_time_label";
            this.exp_time_label.Size = new System.Drawing.Size(57, 63);
            this.exp_time_label.TabIndex = 21;
            this.exp_time_label.Text = "0";
            // 
            // Active_cells_button
            // 
            this.Active_cells_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Active_cells_button.Location = new System.Drawing.Point(330, 348);
            this.Active_cells_button.Name = "Active_cells_button";
            this.Active_cells_button.Size = new System.Drawing.Size(173, 43);
            this.Active_cells_button.TabIndex = 22;
            this.Active_cells_button.Text = "Активные ячейки";
            this.Active_cells_button.UseVisualStyleBackColor = true;
            this.Active_cells_button.Click += new System.EventHandler(this.ActiveCellsButtonClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 31);
            this.label2.TabIndex = 23;
            this.label2.Text = "Длина волны, мкм";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 31);
            this.label3.TabIndex = 24;
            this.label3.Text = "0.83";
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(Source_forms.Program);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 425);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Active_cells_button);
            this.Controls.Add(this.exp_time_label);
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
            this.Text = "Laser";
            this.Load += new System.EventHandler(this.MainWindowLoad);
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
        private System.Windows.Forms.Label exp_time_label;
        private System.Windows.Forms.Button Active_cells_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

