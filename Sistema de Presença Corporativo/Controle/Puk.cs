using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Presença_Corporativo.Controle
{
    public class Puk
    {
        public int checkPuk(int puk)
        {
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select Count(*) from Login where puk=@puk;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@puk", puk);
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
        public int checkPukUser(int puk, string user)
        {
            int rowCount = 0;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
            {
                const string sql = "Select Count(*) from Login where puk=@puk and username=@user;";
                using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                {
                    sqlCommand.Parameters.AddWithValue("@puk", puk);
                    sqlCommand.Parameters.AddWithValue("@user", user);
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
        public int changeSenha(int puk, string senha, string username)
        {
            int numb = 0;
            if (this.checkPukUser(puk, username) == 0)
            {
                MessageBox.Show("PUK Errado");
                numb = 2;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.bdpresencaConnectionString))
                {
                    const string sql = "Update Login set senha=@senha where username=@username;";
                    using (SqlCommand sqlCommand = new SqlCommand(sql, conn))
                    {
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
                            numb = 1;
                        }
                        finally
                        {
                            conn.Close();
                            
                        }
                       
                    }
                }
                numb = 0;
            }
            return numb;
        }
        public int gerar()
        {
            Random rand = new Random();
            int puk = rand.Next(9999);
            if (this.checkPuk(puk) != 0)
            {
                gerar();
            }
            return puk;
        }
    }
}
