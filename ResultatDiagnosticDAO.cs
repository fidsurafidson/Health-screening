using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analyse
{
    class ResultatDiagnosticDAO
    {
        public void saveDiagnostic(ResultatDiagnostic resultatDiagnostic)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into resultatdiagnostic(patient, designation, valeur, dateAnalyse) values('" + resultatDiagnostic.Patient+ "','" + resultatDiagnostic.Designation + "','" + resultatDiagnostic.Value + "','" + resultatDiagnostic.DateAnalyse+"')";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Diagnostic saved");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
