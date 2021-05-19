using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Presença_Corporativo.Controle
{
    public class Ver_Categoria
    {
        public (List<int>, List<string>, List<int>, List<bool>, int) checkFunc(string nomeCat)
        {
            List<int> id = new List<int>();
            List<string> nome = new List<string>();
            List<int> telefone = new List<int>();
            List<bool> sexo = new List<bool>();
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select f.id_funcionario,Concat(f.nome, ' ', f.apelido),f.telefone,f.sexo from Funcionarios f, Categorias c where f.id_categoria=c.id_categoria and c.nome_categoria=@nome;";

                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    try
                    {
                        sqlCommand.Parameters.AddWithValue("@nome", nomeCat);
                        conn.Open();
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                id.Add(dataReader.GetInt32(0));
                                nome.Add(dataReader.GetString(1));
                                telefone.Add(dataReader.GetInt32(2));
                                sexo.Add(dataReader.GetBoolean(3));
                                rowCount++;

                            }
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                        return (id, nome, telefone, sexo, rowCount);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return (id, nome, telefone, sexo, rowCount);
        }
        public int checkQuanP(int id, int dia, int mes, int ano)
        {
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select Count(*) from Presenca where id_funcionario=@id and Day(data)=@dia and Month(data) = @mes and Year(data) = @ano";

                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    try
                    {
                        sqlCommand.Parameters.AddWithValue("@id", id);
                        sqlCommand.Parameters.AddWithValue("@dia", dia);
                        sqlCommand.Parameters.AddWithValue("@mes", mes);
                        sqlCommand.Parameters.AddWithValue("@ano", ano);
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
                        return rowCount;
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return rowCount;
        }
        public (int, int) checkP(int id, int dia, int mes, int ano)
        {
            if (this.checkQuanP(id, dia, mes, ano) == 0)
            {
                return (0, -1);
            }
            else
            {
                int rowCount = 0;
                int id_P = 0;
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
                {
                    const string sql = "Select id_presenca,status from Presenca where id_funcionario=@id and Day(data)=@dia and Month(data) = @mes and Year(data) = @ano";

                    using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                    {
                        try
                        {
                            sqlCommand.Parameters.AddWithValue("@id", id);
                            sqlCommand.Parameters.AddWithValue("@dia", dia);
                            sqlCommand.Parameters.AddWithValue("@mes", mes);
                            sqlCommand.Parameters.AddWithValue("@ano", ano);
                            conn.Open();
                            using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    id_P = dataReader.GetInt32(0);
                                    if (dataReader.GetBoolean(1) == true)
                                        rowCount = 1;
                                    else
                                        rowCount = 2;
                                }
                                dataReader.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Erro na Base de dados", "Erro");
                            return (id_P, rowCount);
                        }
                        finally
                        {
                            conn.Close();
                        }

                    }
                }
                return (id_P, rowCount);
            }
        }

        /*
         * 
         * Insert
         * 
         */
        public void insertP(int id, bool status, int dia, int mes, int ano)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Insert into Presenca (id_funcionario,status,data) values (@id,@status,@date);";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    string date = ano.ToString() + '-' + mes.ToString() + '-' + dia.ToString();
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@date", date);
                    sqlCommand.Parameters.AddWithValue("@status", status);
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
        public void insertJ(int id, string motivo, int dia, int mes, int ano)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Insert into Justificativa (id_falta,motivo,feita_justificativa) values (@id,@motivo,@date);";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    string date = ano.ToString() + '-' + mes.ToString() + '-' + dia.ToString();
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@date", date);
                    sqlCommand.Parameters.AddWithValue("@motivo", motivo);
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
        public int selectJ(int id)
        {
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select Count(*) from Justificativa where id_falta=@id;";
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
                                rowCount = dataReader.GetInt32(0);
                            }
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                        return rowCount;
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return rowCount;
        }
        public void editFP(int id, bool status)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Update Presenca set status = @status where id_presenca=@id;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.Parameters.AddWithValue("@status", status);
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
        public string seeJ(int id)
        {
            string motivo = "";
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select motivo from Justificativa where id_falta=@id;";
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
                                motivo = dataReader.GetString(0);
                            }
                            dataReader.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Erro na Base de dados", "Erro");
                        return motivo;
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return motivo;
        }
    }
}
