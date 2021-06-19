using Sistema_de_Presença_Corporativo.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Presença_Corporativo.Inputs
{
    public partial class EsqueceuSenha : Form
    {
        public EsqueceuSenha()
        {
            InitializeComponent();
        }

        private void EsqueceuSenha_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Peça ao Administrador do Sistema!");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox4.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if(textBox2.Text == textBox3.Text)
                {
                    Puk senha = new Puk();
                    int numb = senha.changeSenha(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox4.Text);
                    if (numb == 1)
                    {
                        MessageBox.Show("Erro de Conexao");
                    }
                    else if(numb == 0)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Senhas Diferentes");
                }
            }
            else
            {

                MessageBox.Show("Prencha todos os campos vazios!");
            }

        }
    }
}
