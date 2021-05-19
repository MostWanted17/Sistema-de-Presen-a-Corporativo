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

namespace Sistema_de_Presença_Corporativo.Configuration
{
    public partial class InsertDetails : Form
    {
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
        public InsertDetails()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Deseja Cancelar a Configuração?", "Cancelar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (nome.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.GetItemText(comboBox1.SelectedItem) != "")
            {
                DbCreation db = new DbCreation();
                int combo;
                if (comboBox1.GetItemText(comboBox1.SelectedItem) == "Masculino")
                {
                    combo = 1;
                }
                else
                {
                    combo = 0;
                }
                db.insertAdmin(usuario.Text, textBox1.Text, nome.Text, textBox2.Text, textBox4.Text, combo, (float)Convert.ToDouble(textBox3.Text), (int)Convert.ToInt32(textBox5.Text));
                MessageBox.Show("Usuário: " + usuario.Text +"\nSenha: " + textBox1.Text,"Login");
                this.Close();
            }
            else
            {
                MessageBox.Show("Preencha todos os Campos");
            }
            
            
            
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
            pictureBox4.BackColor = Color.FromArgb(246, 76, 113);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void InsertDetails_Load(object sender, EventArgs e)
        {

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
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void checkMostrarsenha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMostrarsenha.Checked)
            {
                textBox1.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;

            }
            else
            {
                textBox1.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
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
