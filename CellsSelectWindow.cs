using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source_forms
{
    public partial class CellsSelectWindow : Form
    {
        public int[,] cells = new int[12, 8];
        public void ClickOnSpace(object sender, MouseEventArgs e)
        {
            // enable/disable cells
            int column = table_cells.GetColumn((Panel)sender);
            int row = table_cells.GetRow((Panel)sender);
            if (cells[column, row] == 1)
            {
                cells[column, row] = 0;
                table_cells.GetControlFromPosition(column, row).BackColor = Color.Blue;
            }
            else
            {
                cells[column, row] = 1;
                table_cells.GetControlFromPosition(column, row).BackColor = Color.Red;
            };
        }
        private void CellsSelectWindowLoad(object sender, EventArgs e){}
        public CellsSelectWindow()
        {   
            //create table with active cells
            InitializeComponent();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cells[i, j] = Data.Value[i, j];
                    Panel pan = new Panel();
                    if (cells[i, j] == 1)
                    {
                        pan.BackColor = Color.Red;
                    }
                    else
                    {
                        pan.BackColor = Color.Blue;
                    }
                    pan.Dock = DockStyle.Fill;
                    pan.Visible = true;
                    table_cells.Controls.Add(pan, i, j);
                }
            }
            foreach (Panel space in table_cells.Controls)
            {
                space.MouseClick += new MouseEventHandler(ClickOnSpace);
            }
        }
        private void SaveButtonClick(object sender, EventArgs e)
        {
            Data.Value = cells;
            MessageBox.Show("Изменения сохранены");
            Close();
        }
        private void BackButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("Выход без сохранения");
            Close();
        }
        private void TableCellsPaint(object sender, PaintEventArgs e){}
    }
}
