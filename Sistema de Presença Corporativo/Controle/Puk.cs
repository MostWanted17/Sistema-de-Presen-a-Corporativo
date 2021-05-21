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
