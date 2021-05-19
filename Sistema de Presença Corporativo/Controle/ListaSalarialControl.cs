using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Presença_Corporativo.Controle
{
    public class ListaSalarialControl
    {
        public (List<int>,List<string>,List<string>,List<int>,List<float>,int) column()
        {
            List<int> id = new List<int>();
            List<string> nome = new List<string>();
            List<string> categoria = new List<string>();
            List<float> salario = new List<float>();
            List<int> telefone = new List<int>();
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select id_funcionario, Concat(nome, ' ', apelido) as Nome, c.nome_categoria, f.telefone,f.total_salario from Funcionarios f, Categorias c where f.id_categoria=c.id_categoria;";
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
                                categoria.Add(dataReader.GetString(2));
                                telefone.Add(dataReader.GetInt32(3));
                                salario.Add((float)dataReader.GetDouble(4));
                                rowCount++;
                            }
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro na Base de dados column", "Erro");
                        return (id,nome,categoria,telefone,salario, rowCount);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return (id,nome,categoria,telefone,salario, rowCount);
        }
        public int presenca(int id,int month, int year)
        {
            int presenca = 0;
            
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select Count(*) from Presenca where id_funcionario = @id and status = 'True' and MONTH(data) = @month and YEAR(data) = @year;";
               
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@month", month);
                    sqlCommand.Parameters.AddWithValue("@year", year);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                presenca = dataReader.GetInt32(0);
                            }
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                        return (presenca);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return (presenca);
        }
        public int id_falta(int id, int month, int year)
        {
            int presenca = 0;

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select id_presenca from Presenca where id_funcionario = @id and status = 'False' and MONTH(data) = @month and YEAR(data) = @year;";

                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@month", month);
                    sqlCommand.Parameters.AddWithValue("@year", year);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                presenca = dataReader.GetInt32(0);
                            }
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                        return (presenca);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return (presenca);
        }
        public int pagarJustificativa(int id_falta)
        {
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select Count(*) from Justificativa j, Presenca p where j.id_falta=p.id_presenca and j.id_falta=@id_falta and DAY(j.feita_justificativa) <= DAY(p.data)+3;";

                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@id_falta", id_falta);
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
                        return (rowCount);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }

            return (rowCount);
        }
        public int todas_justificada(int id_funcionario)
        {
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select Count(*) from Justificativa j, Presenca p where p.id_funcionario=@id_funcionario and p.id_presenca=j.id_falta;";

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
                        return (rowCount);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }

            return (rowCount);
        }
    }
}
