using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Presença_Corporativo.Controle
{
    public class Manipulation
    {
        public (string, string) check(int id)
        {
            string username = "";
            string senha = "";
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "SELECT * FROM Login where id_login=@id;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                username = dataReader.GetString(1);
                                senha = dataReader.GetString(2);
                            }
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                        return ("", "");
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return (username,senha);
        }
        public void edit(string username,string senha, int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Update Login set username = @username, senha = @senha where id_login=@id;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@senha", senha);
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
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
        }
        public void delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Delete from Login where id_login=@id";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
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
        }
        public bool checkExistFuncWithCre(int id_funcionario)
        {
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select COUNT(id_funcionario) from Login where id_funcionario = @id_funcionario;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@id_funcionario", id_funcionario);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                rowCount = dataReader.GetInt32(0);
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
            if(rowCount >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public (List<int>,List<string>,int) addFunc()
        {
            List<int> id = new List<int>();
            List<string> name = new List<string>();
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select id_funcionario,Concat(nome,' ', apelido) as nome from Funcionarios;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id.Add(dataReader.GetInt32(0)-1);
                                name.Add(dataReader.GetString(1));
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
            return (id,name,rowCount);
        }
        public void addCredencial(string username,string senha,int id)
        {
            if (checkExistFuncWithCre(id) == true)
            {
                MessageBox.Show("Este Funcionário já tem uma Credencial");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
                {
                    Puk puk = new Puk();
                    const string sql = "Insert into Login (username,senha,id_funcionario,puk) values (@username,@senha,@id_funcionario,@puk);";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                    {
                        sqlCommand.Parameters.AddWithValue("@username", username);
                        sqlCommand.Parameters.AddWithValue("@senha", senha);
                        sqlCommand.Parameters.AddWithValue("@id_funcionario", id);
                        sqlCommand.Parameters.AddWithValue("@puk", puk.gerar());
                        try
                        {
                            conn.Open();
                            sqlCommand.ExecuteNonQuery();
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
            }
           
        }
        public void deleteCat(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Delete from Categorias where id_categoria=@id";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
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
        }
        public (int, string) checkCat(int id)
        {
            string nomeCat = "";
            int idCat = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "SELECT * FROM Categorias where id_categoria=@id;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                idCat = dataReader.GetInt32(0);
                                nomeCat = dataReader.GetString(1);
                            }
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                        return (0, "");
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return (idCat, nomeCat);
        }
        public bool checkNameCat(string name)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "SELECT COUNT(*) FROM Categorias where nome_categoria=@nome;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@nome", name);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                count = dataReader.GetInt32(0);
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
            if (count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void editCat(string nome, int id)
        {
            if (checkNameCat(nome) == true)
            {
                MessageBox.Show("Este Categoria já existe");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
                {
                    const string sql = "Update Categorias set nome_categoria = @nome where id_categoria=@id;";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                    {
                        sqlCommand.Parameters.AddWithValue("@id", id);
                        sqlCommand.Parameters.AddWithValue("@nome", nome);
                        try
                        {
                            conn.Open();
                            sqlCommand.ExecuteNonQuery();
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
            }
        }
        public void addCategoria(string nome)
        {
            if (checkNameCat(nome) == true)
            {
                MessageBox.Show("Categoria já existe");
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
                {
                    const string sql = "Insert into Categorias (nome_categoria) values (@nome);";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                    {
                        sqlCommand.Parameters.AddWithValue("@nome", nome);
                        try
                        {
                            conn.Open();
                            sqlCommand.ExecuteNonQuery();
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
            }
        }
    }
}
