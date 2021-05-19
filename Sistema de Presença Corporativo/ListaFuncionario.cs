using iTextSharp.text;
using iTextSharp.text.pdf;
using Sistema_de_Presença_Corporativo.Controle;
using Sistema_de_Presença_Corporativo.Inputs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Presença_Corporativo
{
    public partial class ListaFuncionario : Form
    {
        Controle.ListaFuncionario lista = new Controle.ListaFuncionario();
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
        public ListaFuncionario()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "id_funcionario";
            dataGridView1.Columns[1].Name = "nome";
            dataGridView1.Columns[2].Name = "endereco";
            dataGridView1.Columns[3].Name = "sexo";
            dataGridView1.Columns[4].Name = "total_salario";
            dataGridView1.Columns[5].Name = "telefone";
            dataGridView1.Columns[6].Name = "categoria";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Categorias cat = new Categorias();
            cat.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(246, 76, 113);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ListaSalarial_Activated(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < lista.column().Item8; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);  // this line was missing
                row.Cells[0].Value = lista.column().Item1[i];
                row.Cells[1].Value = lista.column().Item2[i];
                row.Cells[2].Value = lista.column().Item3[i];
                if(lista.column().Item4[i] == true)
                {
                    row.Cells[3].Value = "Masculino";
                }
                else
                {
                    row.Cells[3].Value = "Femenino";
                }
                row.Cells[4].Value = lista.column().Item5[i];
                row.Cells[5].Value = lista.column().Item6[i];
                row.Cells[6].Value = lista.column().Item7[i];
                dataGridView1.Rows.Add(row);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MesAno check = new MesAno();
            check.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (Convert.ToInt32(id) != 1)
            {
                DialogResult dialogResult = MessageBox.Show("Tem Certeza que deseja deletar?", "Confirmação", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    lista.deletarFunc(Convert.ToInt32(id));

                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < lista.column().Item8; i++)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridView1);  // this line was missing
                        row.Cells[0].Value = lista.column().Item1[i];
                        row.Cells[1].Value = lista.column().Item2[i];
                        row.Cells[2].Value = lista.column().Item3[i];
                        if (lista.column().Item4[i] == true)
                        {
                            row.Cells[3].Value = "Masculino";
                        }
                        else
                        {
                            row.Cells[3].Value = "Femenino";
                        }
                        row.Cells[4].Value = lista.column().Item5[i];
                        row.Cells[5].Value = lista.column().Item6[i];
                        row.Cells[6].Value = lista.column().Item7[i];
                        dataGridView1.Rows.Add(row);
                    }

                }

            }
            else
            {
                MessageBox.Show("Impossivel Deletar");
            }
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            EditFunc edit = new EditFunc();
            edit.Id = Convert.ToInt32(id);
            edit.Show();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            AddFunc add = new AddFunc();
            add.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = label1.Text;
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
    }
}
