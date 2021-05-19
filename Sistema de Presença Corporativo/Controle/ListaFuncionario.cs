using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Presença_Corporativo.Controle
{
    public class ListaFuncionario
    {
        public (List<int>, List<string>, List<string>, List<bool>, List<float>, List<int>, List<string>, int) column()
        {
            List<int> id_funcionario = new List<int>();
            List<string> nome = new List<string>();
            List<string> endereco = new List<string>();
            List<bool> sexo = new List<bool>();
            List<float> total_salario = new List<float>();
            List<int> telefone = new List<int>();
            List<string> categoria = new List<string>();
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select f.id_funcionario,CONCAT(f.nome, ' ', f.apelido) as nome,f.endereco,f.sexo,f.total_salario,f.telefone,c.nome_categoria from Funcionarios f, Categorias c where f.id_categoria=c.id_categoria;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id_funcionario.Add(dataReader.GetInt32(0));
                                nome.Add(dataReader.GetString(1));
                                endereco.Add(dataReader.GetString(2));
                                sexo.Add(dataReader.GetBoolean(3));
                                total_salario.Add((float)dataReader.GetDouble(4));
                                telefone.Add(dataReader.GetInt32(5));
                                categoria.Add(dataReader.GetString(6));
                                rowCount++;
                            }
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                        return (id_funcionario,nome,endereco,sexo,total_salario,telefone,categoria,rowCount);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    
                }
            }
            return (id_funcionario, nome, endereco, sexo, total_salario, telefone, categoria,rowCount);
        }
        public void deletarFunc(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Delete from Funcionarios where id_funcionario=@id";
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
        public (int,string,string,string,bool,float,int,int) checkFunc(int id)
        {
            int id_funcionario=0;
            string nome="";
            string apelido="";
            string endereco="";
            bool sexo=true;
            float total_salario=0;
            int telefone=0;
            int categoria=0;

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select * from Funcionarios where id_funcionario = @id";
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
                                id_funcionario = dataReader.GetInt32(0);
                                nome = dataReader.GetString(1);
                                apelido = dataReader.GetString(2);
                                endereco = dataReader.GetString(3);
                                sexo = dataReader.GetBoolean(4);
                                total_salario = (float)dataReader.GetDouble(5);
                                telefone = dataReader.GetInt32(6);
                                categoria = dataReader.GetInt32(7);
                            }
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                        return (id_funcionario, nome, apelido,endereco, sexo, total_salario, telefone, categoria);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return (id_funcionario, nome, apelido, endereco, sexo, total_salario, telefone, categoria);
        }
        public (List<int>,List<string>,int) cat()
        {
            List<int> id = new List<int>();
            List<string> nome = new List<string>();
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select * from Categorias";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id.Add(dataReader.GetInt32(0));
                                nome.Add(dataReader.GetString(1));
                                rowCount++;
                            }
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                        return (id, nome, rowCount);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return (id,nome, rowCount);
        }
        public void editFunc(int id, string nome,string apelido,string endereco,bool sexo,float salario,int telefone, int cat)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Update Funcionarios set nome=@nome,apelido=@apelido,endereco=@endereco,sexo=@sexo,total_salario=@salario,telefone=@telefone,id_categoria=@id_categoria where id_funcionario=@id;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@nome", nome);
                    sqlCommand.Parameters.AddWithValue("@apelido", apelido);
                    sqlCommand.Parameters.AddWithValue("@endereco", endereco);
                    sqlCommand.Parameters.AddWithValue("@sexo", sexo);
                    sqlCommand.Parameters.AddWithValue("@salario", salario);
                    sqlCommand.Parameters.AddWithValue("@telefone", telefone);
                    sqlCommand.Parameters.AddWithValue("@id_categoria", cat);
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
        public void addFunc(string nome, string apelido, string endereco, bool sexo, float salario, int telefone, int cat)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Insert into Funcionarios (nome,apelido,endereco,sexo,total_salario,telefone,id_categoria) values (@nome,@apelido,@endereco,@sexo,@salario,@telefone,@id_categoria);";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@nome", nome);
                    sqlCommand.Parameters.AddWithValue("@apelido", apelido);
                    sqlCommand.Parameters.AddWithValue("@endereco", endereco);
                    sqlCommand.Parameters.AddWithValue("@sexo", sexo);
                    sqlCommand.Parameters.AddWithValue("@salario", salario);
                    sqlCommand.Parameters.AddWithValue("@telefone", telefone);
                    sqlCommand.Parameters.AddWithValue("@id_categoria", cat);
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
