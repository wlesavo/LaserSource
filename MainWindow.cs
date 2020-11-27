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
    public partial class MainWindow : Form
    {
        public Button button1, button2;

        public int port_selected = 0;
        public SerialPort port;
        public string save_string;
        public string description_string = "";

        // stepcount values in ticks for power, temperature and timer 
        public static int[]    low_per      = { 20, 0, 2 };       //lowest value
        public static int[]    high_per     = { 95, 255, 20 };    //highest value
        public static int[]    val_per      = { 20, 2, 5 };       //current value
        public static double[] min_val_cont = { 0.14, 18.1,  60}; //initial bias
        public static double[] step_val     = {0.066, 0.066, 60}; //step size for absolute values

        public static int stop_time    = 0;
        public static int start_time   = 0;
        public static int current_time = 0;

        // global flags for tracking of conditions
        public static bool is_stoped          = true;
        public static bool disconnection_flag = false;
        public static bool pow_changed        = false;
        public static bool temp_changed       = false;

        // normalization for power in units mW/cm^2. Maximum output power 0.066*75+0.14 = 5.09;
        public double[,] power_to_save_norm = new double[12, 8] {
            {0.016, 0.019, 0.020, 0.021, 0.022, 0.021, 0.020, 0.018},
            {0.021, 0.023, 0.025, 0.027, 0.027, 0.026, 0.024, 0.022},
            {0.024, 0.027, 0.029, 0.031, 0.031, 0.029, 0.027, 0.025},
            {0.028, 0.032, 0.033, 0.035, 0.036, 0.034, 0.031, 0.027},
            {0.030, 0.033, 0.035, 0.038, 0.038, 0.037, 0.035, 0.029},
            {0.031, 0.035, 0.037, 0.040, 0.039, 0.038, 0.035, 0.031},
            {0.031, 0.034, 0.036, 0.039, 0.039, 0.037, 0.035, 0.030},
            {0.030, 0.033, 0.033, 0.035, 0.036, 0.035, 0.033, 0.028},
            {0.025, 0.031, 0.033, 0.034, 0.034, 0.034, 0.030, 0.027},
            {0.024, 0.028, 0.029, 0.031, 0.030, 0.029, 0.027, 0.024},
            {0.021, 0.024, 0.025, 0.026, 0.027, 0.025, 0.024, 0.020},
            {0.014, 0.017, 0.018, 0.020, 0.020, 0.019, 0.017, 0.015}
        }; 
        public double[,] power_to_save      = new double[12, 8];
        
        // absolute values from stepcounts
        public double pow_value = Math.Round(min_val_cont[0] + (val_per[0] - low_per[0]) * step_val[0], 2);
        public double temp_value = Math.Round(min_val_cont[1] + (val_per[1] - low_per[1]) * step_val[1], 2);
        public double td_value = (min_val_cont[2] + (val_per[2] - low_per[2]) * step_val[2]) / 60;

        public int[,] cells = new int[12, 8];
        string path = Directory.GetCurrentDirectory();
        public Timer timer;
        
        public MainWindow()
        {   
            string[] ports = SerialPort.GetPortNames();
            port = new SerialPort();
            InitializeComponent();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cells[i,j] = 1;
                    if ((i < 3) | (i > 8) | (j < 1) | (j > 6))
                    {
                        cells[i, j] = 0;
                    }

                }
            } 
            cells[2, 3] = 1;
            cells[2, 4] = 1;
            cells[9, 3] = 1;
            cells[9, 4] = 1;
            Data.Value = cells;
            pow_value_l.Text = pow_value.ToString().Replace(',', '.');
            td_value_l.Text = td_value.ToString().Replace(',', '.');
            temp_val.Text = temp_value.ToString().Replace(',', '.');
            for (int i = 0; i < ports.Length; i++)
            {
                comboBox_comports.Items.Add(new Item(ports[i].ToString(), i));
            }
            timer = new Timer();
        }
        private void MainWindowLoad(object sender, EventArgs e)
        {
            timer.Interval = (1 * 1000); // 1 secs
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            //timer thread
            pow_value_l.Text = pow_value.ToString().Replace(',', '.');
            td_value_l.Text = td_value.ToString().Replace(',', '.');
            temp_val.Text = temp_value.ToString().Replace(',', '.');
            current_time = current_time + 1;
            if (!is_stoped)
            {
                exp_time_label.Text = (current_time - start_time).ToString().Replace(',', '.');
                exp_time_label.ForeColor = Color.Green;
            }
            else {
                exp_time_label.ForeColor = Color.Red;
            }
            if (disconnection_flag)
            {
                port.Close();
                connection_label.Text = "Not connected";
                connection_label.ForeColor = Color.Red;
            }
        }
        private void DescriptionTextChanged(object sender, EventArgs e)
        {
            description_string = richTextBox1.Text;
        }
        private void ConnectButtonClick(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();

            if (!port.IsOpen)
            {
                try
                {
                    //serial port settings
                    port.PortName = ports[port_selected];
                    port.BaudRate = 9600;
                    port.DataBits = 8;
                    port.Parity = System.IO.Ports.Parity.None;
                    port.StopBits = System.IO.Ports.StopBits.One;
                    port.ReadTimeout = 1000;
                    port.WriteTimeout = 1000;

                    port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    port.Open();
                    //MessageBox.Show("Connected to " + ports[port_selected]);
                    connection_label.Text = "Connected";
                    connection_label.ForeColor = Color.Green;
                }
                catch (Exception b)
                {
                    MessageBox.Show("ERROR: невозможно открыть порт:" + b.ToString());
                    return;
                }
            }
            //send inits
            port.Write("t");
            port.Write("p");
            port.Write("f");
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {   
            //main protocol for parameter updates and device control
            SerialPort sp = (SerialPort)sender;
            byte[] buf_single = new byte[1];
            byte[] buf_param1 = new byte[5];
            byte[] buf_param = new byte[3];
            byte[] buf_uart = new byte[5];
            byte[] buf_time = new byte[4];
            char first_char = ' ';
            string reciever = "";
            string param_value;
            try
            {
                while (first_char != '\r')
                {
                    sp.Read(buf_single, 0, buf_single.Length);
                    first_char = Convert.ToChar(buf_single[0]);
                    reciever = reciever + first_char;
                }
                if (reciever.Length > 0)
                {
                    switch (reciever[0])
                    {
                        //recieve power value
                        case 'P':
                            param_value = reciever.Split(':')[1];
                            param_value = param_value.Split(' ')[0];
                            val_per[0] = Convert.ToInt32(param_value);
                            pow_value = min_val_cont[0] + (val_per[0] - low_per[0]) * step_val[0];
                            pow_value = Math.Round(pow_value, 2);
                            if (!is_stoped)
                            {
                                pow_changed = true;
                            }
                            break;
                        //recieve temperature value
                        case 'T':
                            param_value = reciever.Split(':')[1];
                            param_value = param_value.Split(' ')[0];
                            val_per[1] = Convert.ToInt32(param_value);
                            temp_value = min_val_cont[1] + (val_per[1] - low_per[1]) * step_val[1];
                            temp_value = Math.Round(temp_value, 2);
                            if (!is_stoped)
                            {
                                temp_changed = true;
                            }
                            break;
                        //recieve time value
                        case 'F':
                            param_value = reciever.Split(':')[1];
                            param_value = param_value.Split(' ')[0];
                            val_per[2] = Convert.ToInt32(param_value);
                            td_value = (min_val_cont[2] + (val_per[2] - low_per[2]) * step_val[2]) / 60 + 1;
                            break;

                        // stop/start handler
                        case 'S':
                            param_value = reciever.Split(' ')[1];
                            if (reciever[3] == 'P')
                            {
                                stop_time = Convert.ToInt32(param_value);
                                is_stoped = true;
                                byte[] bytes_to_log = GetSaveString(stop_time - start_time);
                                //create log entry
                                if (!(Directory.Exists(path+"\\log")))
                                {
                                    Directory.CreateDirectory(path + "\\log");
                                }

                                System.IO.File.WriteAllBytes(String.Format(path + "\\log\\log{0}.csv", DateTime.Now.ToString("d-M-yyyy HH-mm-ss")), bytes_to_log);
                            } 
                            else if (reciever[3] == 'R')
                            {
                                //Start;
                                start_time = Convert.ToInt32(param_value);
                                current_time = start_time;
                                is_stoped = false;
                                temp_changed = false;
                                pow_changed = false;
                            }
                            break;
                        case 'U':
                            break;
                        case 'A':
                            break;
                        //exit handler
                        case 'E':
                            disconnection_flag = true;
                            stop_time = current_time;
                            is_stoped = true;
                            //create log entry
                            byte[] bytes_to_log2 = GetSaveString(stop_time - start_time);
                            path = Directory.GetCurrentDirectory();
                            if (!(Directory.Exists(path + "\\log")))
                            {
                                Directory.CreateDirectory(path + "\\log");
                            }
                            System.IO.File.WriteAllBytes(String.Format(path + "\\log\\log{0}.csv", DateTime.Now.ToString("d-M-yyyy HH-mm-ss")), bytes_to_log2);
                            break;
                    }
                    reciever = "";
                }
            }
            catch (Exception b)
            {
                MessageBox.Show("Ошибка: " + b.ToString());
                return;
            }
        }
        private void SerialPortBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Item itm = (Item)comboBox_comports.SelectedItem;
            port_selected= itm.Value;
        }
        private byte[] GetSaveString(int time) {

            //create csv type string with main parameters for saving

            save_string = description_string;
            if (pow_changed) {
                save_string = save_string + ';' + "WRONG SESSION, POWER WAS CHANGED DURING EXPERIMENT";
            }
            if (temp_changed)
            {
                save_string = save_string + ';' + "WRONG SESSION, TEMPERATURE WAS CHANGED DURING EXPERIMENT";
            }
            save_string = save_string + '\n' + "Мощность, Вт;" + "Температура, °С;" + "Время, с;" + "Длина волны, мкм;" + '\n' + pow_value.ToString() + ";" + temp_value.ToString() + ";" + time.ToString() + ";" + "0,83;" + '\n' + '\n';
            save_string = save_string + "Поглощенная энергия,  Дж/см^2\n\n";
            save_string = save_string + " ;1;2;3;4;5;6;7;8;9;10;11;12;\n";
            for (int j = 0; j < 8; j++)
            {
                save_string = save_string + Convert.ToChar(65 + j) + ';';
                for (int i = 0; i < 12; i++)
                {
                    power_to_save[i, j] = power_to_save_norm[i, j] * time * pow_value * Data.Value[i, j] / (0.066 * 75 + 0.14);
                    save_string = save_string + power_to_save[i, j].ToString() + ';';
                }
                save_string = save_string + '\n';
            }

            save_string = save_string + "\nПоглощенная мощность,  Вт/см^2\n\n";
            save_string = save_string + " ;1;2;3;4;5;6;7;8;9;10;11;12;\n";
            for (int j = 0; j < 8; j++)
            {
                save_string = save_string + Convert.ToChar(65 + j) + ';';
                for (int i = 0; i < 12; i++)
                {
                    
                    power_to_save[i, j] = power_to_save_norm[i, j] * pow_value * Data.Value[i,j] / (0.066 * 75 + 0.14);
                    if (time == 0) { power_to_save[i, j] = 0; }
                    save_string = save_string + power_to_save[i, j].ToString() + ';';
                }
                save_string = save_string + '\n';
            }

            save_string = save_string + "\nАктивные ячейки, 1 - активные, 0 - не активные\n\n";
            save_string = save_string + " ;1;2;3;4;5;6;7;8;9;10;11;12;\n";
            for (int j = 0; j < 8; j++)
            {
                save_string = save_string + Convert.ToChar(65 + j) + ';';
                for (int i = 0; i < 12; i++)
                {
                    save_string = save_string + Data.Value[i, j].ToString() + ';'; 
                }
                save_string = save_string + '\n';
            }

            Encoding unicode = Encoding.Unicode;
            Encoding win1251 = Encoding.GetEncoding("Windows-1251");

            byte[] win1251Bytes = unicode.GetBytes(save_string);
            byte[] utf8Bytes = Encoding.Convert(unicode, win1251, win1251Bytes);
            return utf8Bytes;

        }
        private void SaveButtonClick(object sender, EventArgs e)
        {
            //create dialog to save collected data
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
            byte[] utf8Bytes = GetSaveString(work_time);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    myStream.Close();
                }
            }
            string filename = saveFileDialog1.FileName;
            if (filename.Length>0)
            {
                File.WriteAllBytes(filename, utf8Bytes);
                MessageBox.Show("Файл сохранен");
            }
        }
        private void StartButtonClick(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.Write("s");
            }
        }
        private void StopButtonClick(object sender, EventArgs e)
        {
            if (port.IsOpen) {
                port.Write("e");
            }
        }
        private void DisconnectButtonClick(object sender, EventArgs e)
        {
            port.Close();
            connection_label.Text = "Not connected";
            connection_label.ForeColor = Color.Red;
        }
        private void ActiveCellsButtonClick(object sender, EventArgs e)
        {
            Form form2 = new CellsSelectWindow();
            form2.Show();
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
    static class Data
    {
        public static int[,] Value { get; set; }
    }
}
