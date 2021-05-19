using Sistema_de_Presença_Corporativo.Controle;
using Sistema_de_Presença_Corporativo.Inputs;
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
    public partial class Dashboard : Form
    {
        Conection conn;
        private string user;
        public User usu;
        private List<string> cat;
        public void setUser(string user)
        {
            this.user = user;
        }
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
        public Dashboard()
        {
            InitializeComponent();
            personalizarDesign();
            //this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            


        }
        private void personalizarDesign()
        {

            panelcategoriasubmenu.Visible = false;
            panelplaylistsubmenu.Visible = false;

            //..
        }
        private void hideSubMenu()
        {

            if (panelcategoriasubmenu.Visible == true)
                panelcategoriasubmenu.Visible = false;

            if (panelplaylistsubmenu.Visible == true)
                panelplaylistsubmenu.Visible = false;


        }
        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {

                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            showSubmenu(panelcategoriasubmenu);
            if (panelcategoriasubmenu.Visible == true)
            {
                btnCategoria.Image = Properties.Resources.arrow_up_filled_triangle;
            }
            else
            {
                btnCategoria.Image = Properties.Resources.arrow_down_filled_triangle;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }



        private void button9_Click(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Perfil perf = new Perfil();
            perf.usu = usu;
            perf.ShowDialog();
            hideSubMenu();
        }





        private void button15_Click(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void btnhelp_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Sobre sobre = new Sobre();
            sobre.ShowDialog();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pictureBox4.Visible = false;
            pictureBox6.Visible = true;
        }

        private void btnplaylist_Click(object sender, EventArgs e)
        {
            showSubmenu(panelplaylistsubmenu);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //..
            //seu cod
            //..
            hideSubMenu();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            conn = new Conection();

            if (user == "admin")
            {
                panelplaylistsubmenu.Size = new System.Drawing.Size(250, 160);
                for (int i = 0; i <= 1; i++)
                {
                    Button newButton = new Button();
                    {
                        newButton.Name = string.Format("credencial" + i, i);
                        if (i == 0)
                        {
                            newButton.Text = "Credencial";
                        }
                        else
                        {
                            newButton.Text = "Lista de Funcionários";
                        }

                        newButton.FlatStyle = FlatStyle.Flat;
                        newButton.FlatAppearance.BorderSize = 0;
                        newButton.ForeColor = Color.LightGray;
                        newButton.Font = new Font(FontFamily.GenericSansSerif, 10F);
                        newButton.TextAlign = ContentAlignment.MiddleLeft;
                        newButton.Padding = new Padding(35, 0, 0, 0);
                        newButton.Location = new System.Drawing.Point(0, 40 * (i + 1));
                        newButton.Size = new System.Drawing.Size(250, 40);
                        if (newButton.Text == "Credencial")
                        {
                            newButton.Click += credencial;
                        }
                        else
                        {
                            newButton.Click += lista_salarial;
                        }
                        this.Controls.Add(newButton);

                    }
                    panelplaylistsubmenu.Controls.Add(newButton);
                }
                btnLogout.Location = new System.Drawing.Point(0, 120);

            }




        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
            if (log.IsDisposed)
            {
                this.Close();
            }
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

        private void Dashboard_Activated(object sender, EventArgs e)
        {
            conn = new Conection();
            cat = conn.Categorias();
            for (int i = 0; i < cat.Count(); i++)
            {

                panelcategoriasubmenu.Size = new System.Drawing.Size(250, 40 * (i + 1));

                Button newButton = new Button();
                {
                    newButton.Name = string.Format(cat[i], i);
                    newButton.Text = string.Format(cat[i], i);
                    newButton.FlatStyle = FlatStyle.Flat;
                    newButton.FlatAppearance.BorderSize = 0;
                    newButton.Location = new System.Drawing.Point(0, 40 * i);
                    newButton.ForeColor = Color.LightGray;
                    newButton.Font = new Font(FontFamily.GenericSansSerif, 10F);
                    newButton.Size = new System.Drawing.Size(250, 40);
                    newButton.Click += categoria;
                    this.Controls.Add(newButton);
                }
                panelcategoriasubmenu.Controls.Add(newButton);
            }
            usu = conn.Perfil(user);
            label3.Text = usu.Username;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void credencial(object sender, EventArgs e)
        {
            Credencial cre = new Credencial();
            cre.ShowDialog();
        }
        private void lista_salarial(object sender, EventArgs e)
        {
            ListaFuncionario lista = new ListaFuncionario();
            lista.ShowDialog();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBox4.Visible = true;
            pictureBox6.Visible = false;
        }


        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Dashboard_Paint(object sender, PaintEventArgs e)
        {

        }
        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(76, 51, 130);
        }
        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.FromArgb(76, 51, 130);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.Transparent;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.FromArgb(76, 51, 130);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void btnminimizar_MouseEnter(object sender, EventArgs e)
        {
            btnminimizar.BackColor = Color.FromArgb(76, 51, 130);
        }

        private void btnminimizar_MouseLeave(object sender, EventArgs e)
        {
            btnminimizar.BackColor = Color.Transparent;
        }

        //Ver Categorias

        List<VerCategoria> lista = new List<VerCategoria>();
        private void categoria(object sender, EventArgs e)
        {
           

            if (lista.Count() > 0)
            {
                for (int i = 0; i < lista.Count(); i++)
                {
                    lista[i].Close();
                    lista.Remove(lista[i]);
                    lista.Add(new VerCategoria((sender as Button).Text));
                    lista[i].TopLevel = false;
                    panel3.Controls.Add(lista[i]);
                    panel3.Tag = lista[i].Nome_categoria;
                    lista[i].Show();
                    lista[i].Dock = DockStyle.Fill;
                    lista[i].BringToFront();
                    
                }
            }
            else
            {
                lista.Add(new VerCategoria((sender as Button).Text));
                lista[0].TopLevel = false;
                panel3.Controls.Add(lista[0]);
                panel3.Tag = lista[0].Nome_categoria;
                lista[0].Show();
                lista[0].Dock = DockStyle.Fill;
                lista[0].BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        // Fim Ver Categoria
    }
}
