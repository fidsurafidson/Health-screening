using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analyse
{
    class MaladieDetailDAO
    {
        public MaladieDetail[] findMaladieDetailByMaladie(int idMaladie)
        {
            MaladieDetail[] resultat = null;
            ArrayList listeMaladieDetail = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from maladiedetail where maladie =" + idMaladie);
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int maladie = int.Parse(reader["maladie"].ToString());
                    int diagnostic = int.Parse(reader["diagnostic"].ToString());
                    float sommet = float.Parse(reader["sommet"].ToString());
                    listeMaladieDetail.Add(new MaladieDetail(id, maladie, diagnostic, sommet));
                }
                resultat = new MaladieDetail[listeMaladieDetail.Count];
                for (int i = 0; i < listeMaladieDetail.Count; i++)
                {
                    resultat[i] = (MaladieDetail)listeMaladieDetail[i];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
            return resultat;
        }
    }
}
