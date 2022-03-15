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
    class PatientDAO
    {
        public void savePatient(String nom, String age, String sexe)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                Patient patient = new Patient();
                patient.Nom = nom;
                patient.Age = age;
                patient.Sexe = sexe;
                cmd.CommandText = "insert into patient values(" + patient.Nom + "," + patient.Age + ",'" + patient.Sexe + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void insertPatient(Patient patient)
        {
            try
            {
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into patient values('" + patient.Nom+ "','" + patient.Age+ "','" + patient.Sexe+ "')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }

        public Patient[] findLastPatient()
        {
            Patient[] resultat = null;
            ArrayList listePatient = new ArrayList();
            Connexion con = new Connexion();
            SqlConnection conn = con.ConnectToSql();
            conn.Open();
            SqlCommand cmd;
            SqlDataReader reader;
            string requete = ("select * from patient order by id desc");
            cmd = new SqlCommand(requete, conn);
            reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    String nom = reader["nom"].ToString();
                    String age = reader["age"].ToString();
                    String sexe = reader["sexe"].ToString();
                    listePatient.Add(new Patient(id, nom, age, sexe));
                }
                resultat = new Patient[listePatient.Count];
                for (int i = 0; i < listePatient.Count; i++)
                {
                    resultat[i] = (Patient)listePatient[i];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
            return resultat;
        }
    }
}
