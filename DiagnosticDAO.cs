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
    class DiagnosticDAO
    {
        public Diagnostic[] findDiagnostic()
        {
            Diagnostic[] resultat = null;
            ArrayList listeDiagnostic = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from diagnostic");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String designation = reader["designation"].ToString();
                    String unite = reader["unite"].ToString();
                    float minimum = float.Parse(reader["minimum"].ToString());
                    float maximum = float.Parse(reader["maximum"].ToString());
                    float normalMax = float.Parse(reader["normalmax"].ToString());
                    float normalMin = float.Parse(reader["normalmin"].ToString());
                    listeDiagnostic.Add(new Diagnostic(id, designation, unite, maximum, minimum, normalMax, normalMin));
                    //MessageBox.Show(designation);
                }
                resultat = new Diagnostic[listeDiagnostic.Count];
                for (int i = 0; i < listeDiagnostic.Count; i++)
                {
                    resultat[i] = (Diagnostic)listeDiagnostic[i];
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
