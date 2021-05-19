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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Presença_Corporativo
{
    public partial class VerCategoria : Form
    {
        private string nome_categoria;
        public string Nome_categoria { get => nome_categoria; set => nome_categoria = value; }

        public int dia;
        public int mes;
        public int ano;
        DateTime thisDay = DateTime.Today;
        private Ver_Categoria lista = new Ver_Categoria();
        public VerCategoria(string name)
        {
            InitializeComponent();
            Nome_categoria = name;
            
        }

        private void VerCategoria_Load(object sender, EventArgs e)
        {
            label1.Text = Nome_categoria.ToUpper();
            DateTime now = DateTime.Today;
            for (int i = 2021; i <= now.Year; i++)
            {

                comboBox3.Items.Add(i);
            }
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                gridExecute();
                button1.Visible = true;
            }
            else
            {
                MessageBox.Show("Preencha todos os campos vazios");
            }
            
        }
        private void gridExecute()
        {
            dataGridView1.Rows.Clear();
            dia = Convert.ToInt32(comboBox2.SelectedItem.ToString());
            mes = Convert.ToInt32(comboBox1.SelectedItem.ToString());
            ano = Convert.ToInt32(comboBox3.SelectedItem.ToString());

            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Nome";
            dataGridView1.Columns[2].Name = "Telefone";
            dataGridView1.Columns[3].Name = "Sexo";
            dataGridView1.Columns[4].Name = "ID Status";
            dataGridView1.Columns[5].Name = "Status";
            dataGridView1.Columns[6].Name = "Justificado???";

            if (thisDay.Day == dia && thisDay.Month == mes && thisDay.Year == ano)
            {
                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                {
                    button.HeaderText = "Marcar";
                    button.Text = "P/F";
                    button.Name = "Presenca";
                    button.UseColumnTextForButtonValue = true; //dont forget this line
                    dataGridView1.Columns.Insert(7, button);
                }
            }
            DataGridViewButtonColumn jus = new DataGridViewButtonColumn();
            if (thisDay.Day == dia && thisDay.Month == mes && thisDay.Year == ano)
            {
                {
                    jus.HeaderText = "Justificativa";
                    jus.Text = "Justificar";
                    jus.Name = "Justificativa";
                    jus.UseColumnTextForButtonValue = true; //dont forget this line
                    dataGridView1.Columns.Insert(8, jus);
                }
            }else if(thisDay.Day > dia || thisDay.Month > mes || thisDay.Year > ano)
            {
                {
                    jus.HeaderText = "Justificativa";
                    jus.Text = "Justificar";
                    jus.Name = "Justificativa";
                    jus.UseColumnTextForButtonValue = true; //dont forget this line
                    dataGridView1.Columns.Insert(7, jus);
                }
            }
            for (int i = 0; i < lista.checkFunc(Nome_categoria).Item5; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);  // this line was missing
                row.Cells[0].Value = lista.checkFunc(Nome_categoria).Item1[i];
                row.Cells[1].Value = lista.checkFunc(Nome_categoria).Item2[i];
                row.Cells[2].Value = lista.checkFunc(Nome_categoria).Item3[i];
                if (lista.checkFunc(Nome_categoria).Item4[i] == true)
                {
                    row.Cells[3].Value = "Masculino";
                }
                else
                {
                    row.Cells[3].Value = "Femenino";
                }
                

                if (lista.checkP(lista.checkFunc(Nome_categoria).Item1[i],dia,mes,ano).Item2 == 1)
                {
                    row.Cells[5].Value = "Presente";
                    row.Cells[5].Style.BackColor = Color.FromArgb(95, 179, 130);

                }
                else if (lista.checkP(lista.checkFunc(Nome_categoria).Item1[i],dia,mes,ano).Item2 == 2)
                {
                    row.Cells[5].Value = "Faltou";
                    row.Cells[5].Style.BackColor = Color.FromArgb(231, 66, 107);
                }
                else
                {
                    row.Cells[5].Value = "";
                }
                row.Cells[4].Value = lista.checkP(lista.checkFunc(Nome_categoria).Item1[i], dia, mes, ano).Item1;
                if (lista.selectJ(lista.checkP(lista.checkFunc(Nome_categoria).Item1[i], dia, mes, ano).Item1) == 0)
                {
                    row.Cells[6].Value = "";
                }
                else
                {
                    row.Cells[6].Value = "Justificado";
                }
                
                dataGridView1.Rows.Add(row);

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == 7 && senderGrid.Columns[e.ColumnIndex].Name.ToString() == "Presenca" && e.RowIndex >= 0)
            {
                if (this.dataGridView1[5, e.RowIndex].Value.ToString() == "Presente")
                {
                    DialogResult editarFP = MessageBox.Show("Deseja editar?", "Atenção",
                MessageBoxButtons.YesNo);
                    if(editarFP == DialogResult.Yes)
                    {
                        DialogResult dialog = MessageBox.Show("Yes para Presença, No para falta", "Atenção",
                MessageBoxButtons.YesNoCancel);
                        if (dialog == DialogResult.Yes) 
                        { 
                            lista.editFP(lista.checkP(Convert.ToInt32(this.dataGridView1[0, e.RowIndex].Value), dia, mes, ano).Item1, true);
                        }
                        else if(dialog == DialogResult.No)
                        {
                            lista.editFP(lista.checkP(Convert.ToInt32(this.dataGridView1[0, e.RowIndex].Value), dia, mes, ano).Item1, false);
                        }
                    }
                    gridExecute();
                }
                else if (this.dataGridView1[5, e.RowIndex].Value.ToString() == "Faltou")
                {
                    DialogResult editarFP = MessageBox.Show("Deseja editar?", "Atenção",
               MessageBoxButtons.YesNo);
                    if (editarFP == DialogResult.Yes)
                    {
                        DialogResult dialog = MessageBox.Show("Yes para Presença, No para falta", "Atenção",
                MessageBoxButtons.YesNoCancel);
                        if (dialog == DialogResult.Yes)
                        {
                            lista.editFP(lista.checkP(Convert.ToInt32(this.dataGridView1[0, e.RowIndex].Value), dia, mes, ano).Item1, true);
                        }
                        else if (dialog == DialogResult.No)
                        {
                            lista.editFP(lista.checkP(Convert.ToInt32(this.dataGridView1[0, e.RowIndex].Value), dia, mes, ano).Item1, false);
                        }
                    }
                    gridExecute();
                }
                else
                {
                    DialogResult dialog = MessageBox.Show("Yes para Presença, No para falta", "Atenção",
                MessageBoxButtons.YesNoCancel);
                    if (dialog == DialogResult.Yes)
                    {
                        lista.insertP(Convert.ToInt32(this.dataGridView1[0, e.RowIndex].Value.ToString()), true, dia, mes, ano);
                    }
                    else if (dialog == DialogResult.No)
                    {
                        lista.insertP(Convert.ToInt32(this.dataGridView1[0, e.RowIndex].Value.ToString()), false, dia, mes, ano);
                    }
                    gridExecute();
                }
                    
            }
            if ((e.ColumnIndex == 7 && senderGrid.Columns[e.ColumnIndex].Name.ToString() == "Justificativa" && e.RowIndex >= 0) || (e.ColumnIndex == 8 && senderGrid.Columns[e.ColumnIndex].Name.ToString() == "Justificativa" && e.RowIndex >= 0))
            {
                if (this.dataGridView1[5, e.RowIndex].Value.ToString() == "Presente")
                {
                    MessageBox.Show("Não pode justificar porque esta com status Presente");
                }else if (this.dataGridView1[5, e.RowIndex].Value.ToString() == "Faltou" && this.dataGridView1[6, e.RowIndex].Value.ToString() != "Justificado")
                {
                    Add_jus jus = new Add_jus(lista.checkP(Convert.ToInt32(this.dataGridView1[0, e.RowIndex].Value), dia, mes, ano).Item1,dia,mes,ano);
                    jus.ShowDialog();
                }
                else if (this.dataGridView1[6, e.RowIndex].Value.ToString() == "Justificado")
                {
                    MessageBox.Show("Já justificado");
                }
                else
                {
                    MessageBox.Show("Marque falta ou presença");
                }
                gridExecute();
            }
            if (e.ColumnIndex == 6 && this.dataGridView1[6, e.RowIndex].Value.ToString() != "" && e.RowIndex >= 0)
            {
                MessageBox.Show("Justificativa: " + lista.seeJ(lista.checkP(Convert.ToInt32(this.dataGridView1[0, e.RowIndex].Value), dia, mes, ano).Item1));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = label1.Text + " Lista de Presença " + dia + "-" + mes + "-" + ano;
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

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(76, 51, 130);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Transparent;
        }
    }
}
