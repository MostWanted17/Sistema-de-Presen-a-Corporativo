using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Sistema_de_Presença_Corporativo.Controle;
using System.Runtime.InteropServices;

namespace Sistema_de_Presença_Corporativo
{
    public partial class Login : Form
    {
        DbCreation db;
        Conection conn;
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
        public Login()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new Conection();
            if(conn.Login(usuario.Text, senha.Text) >= 1)
            {
                this.Hide();
                Dashboard dash = new Dashboard();
                
                dash.setUser(usuario.Text);
                dash.Show();
                if (dash.IsDisposed)
                {
                    this.Close();
                }



            }
            else
            {
                MessageBox.Show("Username ou Senha estão Incorrectos");
            }
            
        }

        private void checkMostrarsenha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMostrarsenha.Checked)
            {
                senha.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;

            }
            else
            {
                senha.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
            }
        }

        private void btnlimpar_Click(object sender, EventArgs e)
        {
            usuario.Text = "";
            senha.Text = "";
        }

        private void btnfechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            db = new DbCreation();
            db.checkTable();
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
                { e.Handled = true;}
            }
        }
    }
}
