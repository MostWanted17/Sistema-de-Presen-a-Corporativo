using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Presença_Corporativo.Controle
{
    public class Tables
    {
        public void categorias()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "CREATE TABLE Categorias ([id_categoria] INT IDENTITY(1, 1) NOT NULL,[nome_categoria] VARCHAR(30) NOT NULL,PRIMARY KEY CLUSTERED([id_categoria] ASC));";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        public void funcionarios()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "CREATE TABLE Funcionarios ([id_funcionario] INT IDENTITY(1, 1) NOT NULL,[nome] VARCHAR(50) NOT NULL,[apelido] VARCHAR(50) NOT NULL,[endereco] TEXT NULL,[sexo] BIT NOT NULL,[total_salario] FLOAT(53) NOT NULL,[telefone] INT NULL,[id_categoria] INT NOT NULL,PRIMARY KEY CLUSTERED([id_funcionario] ASC),CONSTRAINT[FK_categoria] FOREIGN KEY([id_categoria]) REFERENCES[dbo].[Categorias]([id_categoria]) ON DELETE CASCADE ON UPDATE CASCADE);";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        public void login()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "CREATE TABLE Login ([id_login] INT IDENTITY(1, 1) NOT NULL, [username] VARCHAR(40) NOT NULL,[senha] VARCHAR(40) NOT NULL, [id_funcionario] INT NOT NULL, [puk] INT NOT NULL, PRIMARY KEY CLUSTERED([id_login] ASC), CONSTRAINT[FK_funcionario] FOREIGN KEY([id_funcionario]) REFERENCES[dbo].[Funcionarios]([id_funcionario]) ON DELETE CASCADE ON UPDATE CASCADE);";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        public void presenca()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "CREATE TABLE Presenca ([id_presenca] INT NOT NULL IDENTITY(1, 1),[id_funcionario] INT NOT NULL,[status] BIT NOT NULL,[data] DATE NOT NULL,PRIMARY KEY CLUSTERED([id_presenca] ASC),CONSTRAINT[Fk_funcionario_status] FOREIGN KEY([id_funcionario]) REFERENCES[dbo].[Funcionarios]([id_funcionario]));";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        public void justificativa()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "CREATE TABLE Justificativa ([id_justificativa] INT IDENTITY (1, 1) NOT NULL,[id_falta] INT NOT NULL,[motivo] TEXT NOT NULL,[feita_justificativa] DATE NULL,PRIMARY KEY CLUSTERED ([id_justificativa] ASC),CONSTRAINT [FK_Justificativa] FOREIGN KEY ([id_falta]) REFERENCES [dbo].[Presenca] ([id_presenca]));";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

    }
}
