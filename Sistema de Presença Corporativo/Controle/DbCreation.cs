using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Presença_Corporativo.Configuration;

namespace Sistema_de_Presença_Corporativo.Controle
{
    public class DbCreation
    {
        private Tables table = new Tables();
        
        private int check(string tabela)
        {
            int i = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "SELECT Count(*) FROM information_schema.tables WHERE table_schema = 'dbo' AND table_name = @tabela;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@tabela", tabela);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                i = dataReader.GetInt32(0);
                            }
                            dataReader.Close();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro na Base de dados","Erro");
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return i;
        }
        private void insertCatAdmin()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Insert into Categorias (nome_categoria) values ('Administrador');";
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
        private void insertFuncAdmin(string nome, string apelido, string endereco, int sexo, float salario, int telefone)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Insert into Funcionarios (nome,apelido,endereco,sexo,total_salario,telefone,id_categoria)values(@nome, @apelido, @endereco, @sexo, @salario, @telefone, 1); ";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@nome",nome);
                    sqlCommand.Parameters.AddWithValue("@apelido", apelido);
                    sqlCommand.Parameters.AddWithValue("@endereco", endereco);
                    sqlCommand.Parameters.AddWithValue("@sexo", sexo);
                    sqlCommand.Parameters.AddWithValue("@salario", salario);
                    sqlCommand.Parameters.AddWithValue("@telefone", telefone);
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
        private bool checkLogAdmin()
        {
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "SELECT * FROM Login where username='admin';";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                rowCount++;
                            }
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                    }
                    finally
                    {
                        conn.Close();
                    }

                }

            }
            if (rowCount == 1)
                return true;
            else
                return false;
            
        }
        private void insertLog(string username, string senha)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                Puk puk = new Puk();
                int puk_numb = puk.gerar();
                const string sql = "Insert into Login (username, senha, id_funcionario, puk)values(@username,@senha,1,@puk);";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    sqlCommand.Parameters.AddWithValue("@senha", senha);
                    sqlCommand.Parameters.AddWithValue("@puk", puk_numb);
                    
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
        public void insertAdmin(string username, string senha, string nome, string apelido, string endereco, int sexo, float salario, int telefone)
        {
            table.categorias();
            table.funcionarios();
            table.login();
            table.presenca();
            table.justificativa();
            if (this.checkLogAdmin() == false)
            {
                this.insertCatAdmin();
                this.insertFuncAdmin(nome, apelido, endereco, sexo, salario, telefone);
                this.insertLog(username, senha);
            }
            
        }
        public void checkTable()
        {
            if (this.check("Categorias") == 0 && this.check("Funcionarios") == 0 && this.check("Login") == 0 && this.check("Presenca") == 0 && this.check("Justificativa") == 0)
            {
                Config conf = new Config();
                conf.ShowDialog();
            }
        }
        
        
    }
}
