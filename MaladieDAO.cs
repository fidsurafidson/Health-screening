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
    class MaladieDAO
    {
        public Maladie[] findMaladie()
        {
            Maladie[] resultat = null;
            ArrayList listeMaladie = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from maladie");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nom = reader["nom"].ToString();
                    listeMaladie.Add(new Maladie(id, nom));
                }
                resultat = new Maladie[listeMaladie.Count];
                for (int i = 0; i < listeMaladie.Count; i++)
                {
                    resultat[i] = (Maladie)listeMaladie[i];
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
