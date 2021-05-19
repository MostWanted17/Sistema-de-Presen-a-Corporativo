using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Presença_Corporativo.Controle
{
    public class Conection
    {
        List<string> categoria;
        public int Login(string user, string senha)
        {
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "SELECT * FROM Login where username = @username and senha = @senha;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@username", user);
                    sqlCommand.Parameters.AddWithValue("@senha", senha);
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
            return rowCount;
        }
        public List<string> Categorias()
        {
            categoria = new List<string>();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "SELECT nome_categoria FROM Categorias;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {

                    try
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                categoria.Add(dataReader.GetString(0));
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
            return categoria;
        }
        public User Perfil(string userna)
        {
            User user = new User();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "SELECT l.username,l.senha,f.nome,f.apelido,f.endereco,f.sexo,f.total_salario,f.telefone,c.nome_categoria FROM Login l, Funcionarios f, Categorias c where l.id_funcionario=f.id_funcionario and f.id_categoria=c.id_categoria and l.username = @username;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@username", userna);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                user.Username = dataReader.GetString(0);
                                user.Senha = dataReader.GetString(1);
                                user.Nome = dataReader.GetString(2);
                                user.Apelido = dataReader.GetString(3);
                                user.Endereco = dataReader.GetString(4);
                                user.Sexo = dataReader.GetBoolean(5);
                                user.Total_salario = (float)dataReader.GetDouble(6);
                                user.Telefone = dataReader.GetInt32(7);
                                user.Nome_categoria = dataReader.GetString(8);
                            }
                            dataReader.Close();
                        }
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
            return user;
        }
        public bool setUsername(string newuser, string olduser)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Update Login set username = @newusername where username = @oldusername;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                { 
                    sqlCommand.Parameters.AddWithValue("@newusername",newuser);
                    sqlCommand.Parameters.AddWithValue("@oldusername", olduser);
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return true;
                }
            }
        }
        public bool setSenha(string newsenha, string user)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Update Login set senha = @newsenha where username = @username;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@newsenha", newsenha);
                    sqlCommand.Parameters.AddWithValue("@username", user);
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return true;
                }
            }
        }
        public bool setInfo(string newnome, string newapelido, string newendereco, int newtelefone, string user)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Update Funcionarios set nome = @nome, apelido = @apelido, endereco = @endereco, telefone = @telefone where id_funcionario = (Select id_funcionario from Login where username=@username);";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@nome", newnome);
                    sqlCommand.Parameters.AddWithValue("@apelido", newapelido);
                    sqlCommand.Parameters.AddWithValue("@endereco", newendereco);
                    sqlCommand.Parameters.AddWithValue("@telefone", newtelefone);
                    sqlCommand.Parameters.AddWithValue("@username", user);
                    try
                    {
                        conn.Open();
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return true;
                }
            }
        }
    }

}
