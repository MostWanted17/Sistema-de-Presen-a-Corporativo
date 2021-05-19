using Sistema_de_Presença_Corporativo.Controle;
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
    public partial class EditFunc : Form
    {
        private int id;
        public int Id { get => id; set => id = value; }

        Controle.ListaFuncionario list = new Controle.ListaFuncionario();

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
        public EditFunc()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditFunc_Load(object sender, EventArgs e)
        {
            usuario.Text = list.checkFunc(id).Item2;
            textBox1.Text = list.checkFunc(id).Item3;
            textBox3.Text = list.checkFunc(id).Item4;
            if (list.checkFunc(id).Item5 == true)
            {
                comboBox1.SelectedItem = "Masculino";
            }
            else
            {
                comboBox1.SelectedItem = "Femenino";
            }
            textBox2.Text = Convert.ToString(list.checkFunc(id).Item6);
            textBox4.Text = Convert.ToString(list.checkFunc(id).Item7);
            for(int i=0; i<list.cat().Item3; i++)
            {
                comboBox2.Items.Add(list.cat().Item2[i]);
                if (list.cat().Item1[i] == list.checkFunc(id).Item8)
                {
                    comboBox2.SelectedItem = list.cat().Item2[i];
                }
            }
            


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool sexo;
            int cat=0;
            
            if (comboBox1.SelectedItem.ToString() == "Masculino")
            {
                sexo = true;
            }
            else
            {
                sexo = false;
            }
            for (int i=0; i<list.cat().Item3;i++)
            {
                if (comboBox2.SelectedItem.ToString() == list.cat().Item2[i])
                {
                    cat = list.cat().Item1[i];
                }
            }
            
            list.editFunc(Id,usuario.Text,textBox1.Text,textBox3.Text,sexo,(float)Convert.ToDouble(textBox2.Text),Convert.ToInt32(textBox4.Text),cat);
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
            else
            {
                if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == (char)Keys.Space))
                { e.Handled = true; }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
            else
            {
                if (!(Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == (char)Keys.Space))
                { e.Handled = true; }
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
