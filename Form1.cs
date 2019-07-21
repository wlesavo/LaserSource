using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace Source_forms
{
    public partial class Form1 : Form
    {

        public Button button1;
        public Button button2;
        public int port_selected = 0;
        public SerialPort port;
        public string save_string;

        
        //power temperature timer

        public static int[] low_per = { 0, 0, 2 }; 
        public static int[] high_per = { 95, 255, 20 };
        public static int[] val_per = { 2, 2, 5 };
        public static int current_time = 0;

        public static double[] min_val_cont = { 0.4, 0.41, 60}; // power @ low_per
        public static double[] step_val = {0.029, 0.029, 60}; // step per val_per

        public static bool disconnection_flag = false;

        public static int stop_time = 0;
        public static int start_time = 0;
        public static bool is_stoped = true;

        public double pow_value = min_val_cont[0] + (val_per[0] - low_per[0]) * step_val[0];
        public double temp_value = min_val_cont[1] + (val_per[1] - low_per[1]) * step_val[1];
        public double td_value = (min_val_cont[2] + (val_per[2] - low_per[2]) * step_val[2])/60;
        public double[,] power_to_save_norm = new double[12, 8] {
            {22.6353696841807, 27.9405344539105, 40.6729299012621, 40.6729299012621, 38.9045416446855, 29.0015674078565, 23.3427249868113, 18.0375602170815},
            {31.4773109670637, 47.7464829275686, 53.0516476972984, 53.0516476972984, 53.0516476972984, 47.7464829275686, 40.6729299012621, 27.5868568025952},
            {56.5884242104517, 63.6619772367581, 70.7355302630646, 72.5039185196412, 68.9671420064880, 63.6619772367581, 53.0516476972984, 45.9780946709920},
            {65.4303654933348, 74.2723067762178, 79.5774715459477, 84.8826363156775, 83.1142480591009, 77.8090832893711, 70.7355302630646, 60.1252007236049},
            {74.2723067762178, 84.8826363156775, 91.9561893419840, 95.4929658551372, 95.4929658551372, 88.4194128288307, 83.1142480591009, 72.5039185196412},
            {77.8090832893711, 88.4194128288307, 97.2613541117138, 97.2613541117138, 97.2613541117138, 91.9561893419840, 84.8826363156775, 76.0406950327944},
            {74.2723067762178, 84.8826363156775, 93.7245775985606, 97.2613541117138, 97.2613541117138, 91.9561893419840, 86.6510245722541, 74.2723067762178},
            {70.7355302630646, 79.5774715459477, 86.6510245722541, 91.9561893419840, 88.4194128288307, 86.6510245722541, 81.3458598025243, 70.7355302630646},
            {54.8200359538751, 65.4303654933348, 74.2723067762178, 79.5774715459477, 81.3458598025243, 76.0406950327944, 70.7355302630646, 60.1252007236049},
            {47.7464829275686, 56.5884242104517, 63.6619772367581, 68.9671420064880, 67.1987537499114, 63.6619772367581, 58.3568124670283, 45.9780946709920},
            {23.6964026381266, 29.3552450591718, 42.4413181578388, 45.9780946709920, 47.7464829275686, 44.2097064144154, 38.9045416446855, 26.8795014999645},
            {18.0375602170815, 20.8669814276041, 23.6964026381266, 25.1111132433879, 23.6964026381266, 21.2206590789194, 17.3302049144508, 11.3176848420903}
        }; // мВт/см^2 макс выходной мощности
        public double[,] power_to_save = new double[12, 8];




        public Timer timer;
        
        public Form1()
        {
            string[] ports = SerialPort.GetPortNames();
            port = new SerialPort();

            InitializeComponent();

            pow_value_l.Text = pow_value.ToString().Replace(',', '.');
            td_value_l.Text = td_value.ToString().Replace(',', '.');
            temp_val.Text = temp_value.ToString().Replace(',', '.');

            for (int i = 0; i < ports.Length; i++)
            {
                comboBox_comports.Items.Add(new Item(ports[i].ToString(), i));
            }
            timer = new Timer();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            
            timer.Interval = (1 * 1000); // 1 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            pow_value_l.Text = pow_value.ToString().Replace(',', '.');
            td_value_l.Text = td_value.ToString().Replace(',', '.');
            temp_val.Text = temp_value.ToString().Replace(',', '.');
            current_time = current_time + 1;
            if (disconnection_flag)
            {
                port.Close();
                connection_label.Text = "Not connected";
                connection_label.ForeColor = Color.Red;
            }

        }

        // desription change
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            save_string = richTextBox1.Text; //add whole save
        }


        
        
        

        

        private void Connect_button_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();

            if (!port.IsOpen)
            {

                try
                {
                    // настройки порта
                    port.PortName = ports[port_selected];
                    port.BaudRate = 9600;
                    port.DataBits = 8;
                    port.Parity = System.IO.Ports.Parity.None;
                    port.StopBits = System.IO.Ports.StopBits.One;
                    
                    port.ReadTimeout = 1000;
                    port.WriteTimeout = 1000;
                    port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    port.Open();
                    MessageBox.Show("Connected to " + ports[port_selected]);
                    connection_label.Text = "Connected";
                    connection_label.ForeColor = Color.Green;
                }
                catch (Exception b)
                {
                    MessageBox.Show("ERROR: невозможно открыть порт:" + b.ToString());
                    return;
                }
            }
            port.Write("t");
            port.Write("p");
            port.Write("f");
        }

        private void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            //string indata = sp.ReadExisting();
                        
            byte[] buf_single = new byte[1];
            byte[] buf_param1 = new byte[5];
            byte[] buf_param = new byte[3];
            byte[] buf_uart = new byte[5];
            byte[] buf_time = new byte[4];

            sp.Read(buf_single, 0, buf_single.Length);
            char first_char = Convert.ToChar(buf_single[0]);
            char third_char;
            string param_value;
            try
            {
                switch (first_char)
                {
                    case 'P':
                        sp.Read(buf_param1, 0, buf_param1.Length);

                        param_value = Encoding.ASCII.GetString(buf_param1);
                        param_value = param_value.Substring(1, 4);
                        param_value = param_value.Split(' ')[0];
                        //MessageBox.Show(param_value);
                        val_per[0] = Convert.ToInt32(param_value);
                        pow_value = min_val_cont[0] + (val_per[0] - low_per[0]) * step_val[0];

                        break;


                    case 'T':
                        sp.Read(buf_param1, 0, buf_param1.Length);
                        param_value = Encoding.ASCII.GetString(buf_param1);
                        param_value = param_value.Substring(1, 4);
                        param_value = param_value.Split(' ')[0];
                        
                        //MessageBox.Show(param_value);
                        val_per[1] = Convert.ToInt32(param_value);
                        temp_value = min_val_cont[1] + (val_per[1] - low_per[1]) * step_val[1];


                        break;

                    case 'F':
                        sp.Read(buf_param1, 0, buf_param1.Length);

                        param_value = Encoding.ASCII.GetString(buf_param1);
                        param_value = param_value.Substring(1, 4);
                        param_value = param_value.Split(' ')[0];

                        //MessageBox.Show(param_value);
                        val_per[2] = Convert.ToInt32(param_value);
                        td_value = (min_val_cont[2] + (val_per[2] - low_per[2]) * step_val[2]) / 60;


                        break;


                    case 'S':
                        sp.Read(buf_param, 0, buf_param.Length);

                        third_char = Convert.ToChar(buf_param[2]);
                        if (third_char == 'P')
                        {
                            //Stop;
                            sp.Read(buf_single, 0, buf_single.Length);
                            sp.Read(buf_time, 0, buf_time.Length);
                            param_value = Encoding.ASCII.GetString(buf_time);
                            stop_time = Convert.ToInt32(param_value);
                            is_stoped = true;
                        }
                        else
                        {
                            if (third_char == 'R')
                            {

                                //Start;
                                sp.Read(buf_single, 0, buf_single.Length);
                                sp.Read(buf_single, 0, buf_single.Length);
                                sp.Read(buf_time, 0, buf_time.Length);
                                param_value = Encoding.ASCII.GetString(buf_time);
                                start_time = Convert.ToInt32(param_value);
                                current_time = start_time;
                                is_stoped = false;


                            }
                        }
                        break;

                    case 'U':
                        sp.Read(buf_uart, 0, buf_uart.Length);
                        break;
                    case 'A':
                        sp.Read(buf_param, 0, buf_param.Length);
                        break;
                    case 'E':
                        sp.Read(buf_param, 0, buf_param.Length);

                        disconnection_flag = true;

                        break;

                }
            }
            catch (Exception b)
            {
                MessageBox.Show("Ошибка: " + b.ToString());
                return;
            }
            foreach (Byte b in buf_single)
            {
                Console.Write(b.ToString() + " ");
            }

            Console.WriteLine();


            //MessageBox.Show(indata);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           Item itm = (Item)comboBox_comports.SelectedItem;
            port_selected= itm.Value;
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            Stream myStream;
            int work_time;
            
            
            if (is_stoped)
            {   
                work_time = (stop_time - start_time);
            }
            else
            {
                work_time = (current_time - start_time);
            }

            save_string = richTextBox1.Text + '\n' + "Power = " + pow_value.ToString().Replace(',', '.') + " Temperature = " +
                temp_value.ToString().Replace(',', '.') + " Time = " + work_time.ToString().Replace(',', '.') + '\n';

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    power_to_save[i, j] = power_to_save_norm[i, j] * work_time * pow_value;
                    save_string = save_string + power_to_save[i, j].ToString().Replace(',', '.') + '\t';
                }
                save_string = save_string + '\n';
            }
            


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "csv files (*.csv)|*.csv|dat files (*.dat)|*.dat|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
            string filename = saveFileDialog1.FileName;
            // читаем файл в строку
            if (filename.Length>0)
            {
                File.WriteAllText(filename, save_string);
                MessageBox.Show("Файл сохранен");
            }
            

        }

        

        

        private void Start_button_Click(object sender, EventArgs e)
        {

            if (port.IsOpen)
            {
                port.Write("s");
            }
        }

        private void Stop_button_Click(object sender, EventArgs e)
        {
            if (port.IsOpen) {
                port.Write("e");
            }
            
        }

        private void Disconnect_button_Click(object sender, EventArgs e)
        {
            port.Close();
            connection_label.Text = "Not connected";
            connection_label.ForeColor = Color.Red;
        }
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name; Value = value;
            }
            public override string ToString()
            {
                // Generates the text shown in the combo box
                return Name;
            }
        }

       
    }
}
