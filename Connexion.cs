using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analyse
{
    class Connexion
    {
        public SqlConnection ConnectToSql()
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = "Data Source=P9A-Rafidison-Harivola-Fidisoa;Initial Catalog=analyse;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion!");
            }
            try
            {
                return conn;
            }
            finally
            {
                conn.Close();
            }
        }
        public Connexion()
        {
        }
    }
}
