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

namespace Sistema_de_Presença_Corporativo
{

    public partial class Perfil : Form
    {
        public User usu;
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
        public Perfil()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            if (usu.Username == "admin")
            {
                textBox3.Text = "Não Pode Mudar";
                textBox2.Text = "Não Pode Mudar";
                textBox3.Enabled = false;
                textBox2.Enabled = false;
                button3.Enabled = false;
            }
            nome.Text = usu.Nome;
            textBox1.Text = usu.Apelido;
            textBox4.Text = usu.Endereco;
            textBox5.Text = usu.Telefone.ToString();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string olduser = textBox3.Text;
            string newuser = textBox2.Text;
            if (usu.Username == olduser)
            {
                if (usu.setUsername(newuser) == true)
                   MessageBox.Show("Mudou com Sucesso o Username");
                    
            }
            else
            {
                MessageBox.Show("Username Actual incorrecto");
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.Transparent;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.FromArgb(246, 76, 113);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usu.setNoApEnTe(nome.Text,textBox1.Text,textBox4.Text,Convert.ToInt32(textBox5.Text)) == true)
                MessageBox.Show("Mudou com Sucesso os seus detalhes");
            else
                MessageBox.Show("Erro ao Mudar");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string oldSenha = textBox7.Text;
            string newSenha = textBox6.Text;
            if (usu.Senha == oldSenha)
            {
                if (usu.setSenha(newSenha) == true)
                    MessageBox.Show("Mudou com Sucesso a Senha");
            }
            else
            {
                MessageBox.Show("Senha Actual incorrecto");
            }
        }

        private void nome_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
