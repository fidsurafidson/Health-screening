using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analyse
{
    class PatientDetailDAO
    {
        public PatientDetail[] findResultat (Diagnostic[] diagnostic)
        {

            MaladieDetailDAO maladieDetailDAO = new MaladieDetailDAO();
            MaladieDAO maladieDAO = new MaladieDAO();
            Maladie[] listeMaladie = maladieDAO.findMaladie();
            PatientDetail[] patientDetail = new PatientDetail[listeMaladie.Length];
            for (int i=0; i<listeMaladie.Length; i++)
            {
                MaladieDetail[] listeMaladieDetail = maladieDetailDAO.findMaladieDetailByMaladie(listeMaladie[i].Id);
                float pourcentage = 0;
                for (int j=0; j<listeMaladieDetail.Length; j++)
                {
                    for (int k=0; k<diagnostic.Length; k++)
                    {
                        if (listeMaladieDetail[j].Diagnostic == diagnostic[k].Id)
                        {
                            if ( diagnostic[k].NormalMax >= diagnostic[k].Value && diagnostic[k].NormalMin <= diagnostic[k].Value)
                            {
                                pourcentage = pourcentage + 0;
                            }
                            else
                            {
                                 if ( ( listeMaladieDetail[j].Sommet < diagnostic[k].NormalMin && diagnostic[k].Value > diagnostic[k].NormalMax ) || ( diagnostic[k].Value < diagnostic[k].NormalMin && listeMaladieDetail[j].Sommet > diagnostic[k].NormalMax ) )
                                {
                                    pourcentage = pourcentage + 0;
                                }
                                else
                                {
                                    if (listeMaladieDetail[j].Sommet < diagnostic[k].NormalMin)
                                    {
                                        if (diagnostic[k].Value < listeMaladieDetail[j].Sommet)
                                        {
                                            float calcul = float.Parse(Convert.ToString((1 * (diagnostic[k].Value - diagnostic[k].Minimum) / (listeMaladieDetail[j].Sommet - diagnostic[k].Minimum)))) * 100;
                                            pourcentage = pourcentage + calcul;
                                        }
                                        else
                                        {
                                            float calcul = float.Parse(Convert.ToString((1 * (diagnostic[k].NormalMin - diagnostic[k].Value) / (diagnostic[k].NormalMin - listeMaladieDetail[j].Sommet)))) * 100;
                                            pourcentage = pourcentage + calcul;
                                        }
                                    }
                                    else
                                    {
                                        if (diagnostic[k].Value < listeMaladieDetail[j].Sommet)
                                        {
                                            float calcul = float.Parse(Convert.ToString((1 * (diagnostic[k].Value) - diagnostic[k].NormalMax) / (listeMaladieDetail[j].Sommet - diagnostic[k].NormalMax))) * 100;
                                            pourcentage = pourcentage + calcul;
                                        }
                                        else
                                        {
                                            float calcul = float.Parse(Convert.ToString((1 * (diagnostic[k].Maximum- diagnostic[k].Value) / (diagnostic[k].Maximum - listeMaladieDetail[j].Sommet)))) * 100;
                                            pourcentage = pourcentage + calcul;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                float pourcentageMaladie = (float)Math.Round(pourcentage / listeMaladieDetail.Length, 2);
                patientDetail[i] = new PatientDetail(listeMaladie[i].Id, listeMaladie[i].Nom, pourcentageMaladie);
            }

            return patientDetail;
        }

        public void savePatientDetail(PatientDetail patientDetail)
        {
            try
            {
                String pourcentage = patientDetail.Pourcentage.ToString().Replace(",", ".");
                Connexion con = new Connexion();
                SqlConnection conn = con.ConnectToSql();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into patientDetail values('" + patientDetail.Id + "','" + patientDetail.Maladie + "','" + pourcentage + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
    }
}
}
