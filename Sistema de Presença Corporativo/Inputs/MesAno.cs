using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Presença_Corporativo.Inputs
{
    public partial class MesAno : Form
    {
        private DateTime now = DateTime.Today;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public MesAno()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
            for (int i = 2021; i <= now.Year; i++)
            {

                comboBox2.Items.Add(i);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListaSalarial lista = new ListaSalarial();
            int mes = 0;
            if (comboBox1.SelectedItem.ToString() == "Janeiro")
            {
                mes = 1;
            }
            else if (comboBox1.SelectedItem.ToString() == "Fevereiro")
            {
                mes = 2;
            }
            else if (comboBox1.SelectedItem.ToString() == "Março")
            {
                mes = 3;
            }
            else if (comboBox1.SelectedItem.ToString() == "Abril")
            {
                mes = 4;
            }
            else if (comboBox1.SelectedItem.ToString() == "Maio")
            {
                mes = 5;
            }
            else if (comboBox1.SelectedItem.ToString() == "Junho")
            {
                mes = 6;
            }
            else if (comboBox1.SelectedItem.ToString() == "Julho")
            {
                mes = 7;
            }
            else if (comboBox1.SelectedItem.ToString() == "Agosto")
            {
                mes = 8;
            }
            else if (comboBox1.SelectedItem.ToString() == "Setembro")
            {
                mes = 9;
            }
            else if (comboBox1.SelectedItem.ToString() == "Outubro")
            {
                mes = 10;
            }
            else if (comboBox1.SelectedItem.ToString() == "Novembro")
            {
                mes = 11;
            }
            else if (comboBox1.SelectedItem.ToString() == "Dezembro")
            {
                mes = 12;
            }
            lista.Mes = mes;
            lista.Ano = Convert.ToInt32(comboBox2.SelectedItem.ToString());
            lista.ShowDialog();
            this.Close();
            
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(169, 150, 198);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }
    }
}
