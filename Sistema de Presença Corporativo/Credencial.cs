﻿using Sistema_de_Presença_Corporativo.Controle;
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
    public partial class Credencial : Form
    {
        Manipulation man = new Manipulation();
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
        public Credencial()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Credencial_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdpresencaDataSet.Funcionarios'. Você pode movê-la ou removê-la conforme necessário.
            this.funcionariosTableAdapter.Fill(this.bdpresencaDataSet.Funcionarios);
            // TODO: esta linha de código carrega dados na tabela 'bdpresencaDataSet.Login'. Você pode movê-la ou removê-la conforme necessário.
            this.loginTableAdapter.Fill(this.bdpresencaDataSet.Login);
            // TODO: esta linha de código carrega dados na tabela 'bdpresencaDataSet.Login'. Você pode movê-la ou removê-la conforme necessário.
            this.loginTableAdapter.Fill(this.bdpresencaDataSet.Login);

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;
            string value = dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString();
            EditCredencial edit = new EditCredencial();
            edit.Id = Convert.ToInt32(value);
            edit.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;
            string value = dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString();
            if (Convert.ToInt32(value) == 1)
            {
                MessageBox.Show("Impossivel Deletar","Erro");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Tem Certeza que deseja deletar?", "Confirmação", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    man.delete(Convert.ToInt32(value));
                    // TODO: esta linha de código carrega dados na tabela 'bdpresencaDataSet.Funcionarios'. Você pode movê-la ou removê-la conforme necessário.
                    this.funcionariosTableAdapter.Fill(this.bdpresencaDataSet.Funcionarios);
                    // TODO: esta linha de código carrega dados na tabela 'bdpresencaDataSet.Login'. Você pode movê-la ou removê-la conforme necessário.
                    this.loginTableAdapter.Fill(this.bdpresencaDataSet.Login);
                    // TODO: esta linha de código carrega dados na tabela 'bdpresencaDataSet.Login'. Você pode movê-la ou removê-la conforme necessário.
                    this.loginTableAdapter.Fill(this.bdpresencaDataSet.Login);
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddCredencial add = new AddCredencial();
            add.ShowDialog();
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(246, 76, 113);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void login_pukToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.loginTableAdapter.login_puk(this.bdpresencaDataSet.Login);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.loginTableAdapter.FillBy(this.bdpresencaDataSet.Login);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void Credencial_Load_1(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdpresencaDataSet1.Login'. Você pode movê-la ou removê-la conforme necessário.
            this.loginTableAdapter.Fill(this.bdpresencaDataSet1.Login);

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.loginTableAdapter.FillBy1(this.bdpresencaDataSet.Login);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
