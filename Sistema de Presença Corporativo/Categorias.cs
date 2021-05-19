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
    public partial class Categorias : Form
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
        public Categorias()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {

            pictureBox4.BackColor = Color.FromArgb(76, 51, 130);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bdpresencaDataSet.Categorias'. Você pode movê-la ou removê-la conforme necessário.
            this.categoriasTableAdapter.Fill(this.bdpresencaDataSet.Categorias);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;
            string value = dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString();
            if (Convert.ToInt32(value) == 1)
            {
                MessageBox.Show("Impossivel Deletar", "Erro");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Tem Certeza que deseja deletar? Se fizer isto todos os funcionários e credenciais desta categoria irão ser deletados", "Confirmação", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    man.deleteCat(Convert.ToInt32(value));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;
            string value = dataGridView1.Rows[rowindex].Cells[columnindex].Value.ToString();
            EditCategoria edit = new EditCategoria();
            edit.Id_cat = Convert.ToInt32(value);
            edit.ShowDialog();
        }

        private void Categorias_Activated(object sender, EventArgs e)
        {
            this.categoriasTableAdapter.Fill(this.bdpresencaDataSet.Categorias);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCategoria add = new AddCategoria();
            add.ShowDialog();
        }
    }
}
