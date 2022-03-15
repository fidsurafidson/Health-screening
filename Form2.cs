using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analyse
{
    public partial class Form2 : Form
    {
        Boolean clic = false;
        Point[] listePoint = new Point[14];
        Point [] endPoint = new Point[14];
        float x1 = 0;
        float y1 = 0;
        int indiceClic = 0;
        float rayon;
        float diametre;
        private Equation [] listeEquation = new Equation[14];
        Point centre;
        Functions functions = new Functions();
        Diagnostic [] diagnostic;
        PatientDetail [] resultat = null;
        Boolean temperature = false;
        Boolean tension = false;


        public Form2()
        {
            InitializeComponent();
            diametre = 450;
            rayon = diametre / 2;
            centre = new Point((int)rayon, (int)rayon);
            DiagnosticDAO diagnosticDAO = new DiagnosticDAO();
            diagnostic = diagnosticDAO.findDiagnostic();

            for (int i = 0; i < listePoint.Length; i++)
            {
                float angle = 2 * float.Parse(Convert.ToString(Math.PI)) / 14;
                x1 = rayon * (1 + float.Parse(Convert.ToString(Math.Sin(angle * i))));
                y1 = rayon * (1 - float.Parse(Convert.ToString(Math.Cos(angle * i))));
                listePoint[i] = new Point((int)x1, (int)y1);
                endPoint[i] = new Point((int)x1, (int)y1);
                Equation equation = functions.getEquation(centre, endPoint[i]);
                //MessageBox.Show("A=" + equation.A + "B=" +equation.B);
                listeEquation[i] = equation;
                diagnostic[i].Value = diagnostic[i].Maximum;
            }

        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            Pen pen = new Pen(Color.Black, 1);
            Graphics g = e.Graphics;

            Brush polygone = Brushes.Gray;
            Brush background = Brushes.DarkSlateGray;
            Brush point = Brushes.Black;
            g.FillPolygon(background, endPoint);
            g.FillPolygon(polygone, listePoint);
            

            for (int i = 0; i < endPoint.Length; i++)
            {
                g.DrawLine(pen, rayon, rayon, endPoint[i].X, endPoint[i].Y);
                e.Graphics.FillEllipse(point, listePoint[i].X - 4, listePoint[i].Y - 4, 10, 10);
                //MessageBox.Show(diagnostic[i].Designation);
                e.Graphics.DrawString(diagnostic[i].Designation +"(" + " " + diagnostic[i].Unite +")", new Font("Arial", 7), point, endPoint[i].X +3, endPoint[i].Y);
                e.Graphics.DrawString(diagnostic[i].Value.ToString(), new Font("Arial", 10), point, listePoint[i].X + 5, listePoint[i].Y + 7);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            clic = true;
            for (int i = 0; i<listePoint.Length; i++)
            {
                float distX = Math.Abs(listePoint[i].X - e.X);
                float distY = Math.Abs(listePoint[i].Y - e.Y);
                float distpointX = Math.Abs(endPoint[i].X - e.X);
                float distpointY = Math.Abs(endPoint[i].Y - e.Y);
                if (distX < 10 && distY < 10)
                {
                    indiceClic = i;
                }
            }
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (clic)
            {
                int movedPointX = e.X;
                int movedPointY = e.Y;
                Point movedPoint = new Point(movedPointX, movedPointY);
                double centreSommet = functions.mesurer(endPoint[indiceClic], centre);
                double centreMovedPoint = functions.mesurer(movedPoint, centre);
                double movedPointSommet = functions.mesurer(movedPoint, endPoint[indiceClic]);
                Diagnostic[] listeDiagnostic = new Diagnostic[diagnostic.Length];
                
                if(centreMovedPoint <= centreSommet && movedPointSommet <= centreSommet)
                {
                    if (listeEquation[indiceClic].A == centre.X)
                    {
                        movedPointX = centre.X;
                        listePoint[indiceClic].Y = movedPointY;
                    }
                    else
                    {
                        Equation equationPerpendiculaire = functions.getPerpendiculaire(listeEquation[indiceClic], movedPointX, movedPointY);
                        movedPointX = (int)(((double)listeEquation[indiceClic].B - (double)equationPerpendiculaire.B) / ((double)equationPerpendiculaire.A - (double)listeEquation[indiceClic].A));
                        movedPointY = (int)((double)listeEquation[indiceClic].A * (double)movedPointX + (double)listeEquation[indiceClic].B);
                        
                        listePoint[indiceClic].X = movedPointX;
                        listePoint[indiceClic].Y = movedPointY;
                    }


                    panel1.Refresh();
                }

                double value = Math.Round((((diagnostic[indiceClic].Maximum - diagnostic[indiceClic].Minimum) * centreMovedPoint) / centreSommet),2) + diagnostic[indiceClic].Minimum;
                diagnostic[indiceClic].Value = float.Parse(value.ToString());
                listeDiagnostic[indiceClic] = diagnostic[indiceClic];
            }
        }

        private void panel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            clic = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            PatientDetailDAO patientDetailDAO = new PatientDetailDAO();
            resultat = patientDetailDAO.findResultat(diagnostic);
            for (int i = 0; i < resultat.Length; i++)
            {
               this.dataGridView1.Rows.Add(resultat[i].NomMaladie, resultat[i].Pourcentage+" %");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String nom = textBox1.Text;
            int age = (int)numericUpDown1.Value;
            String sexe = comboBox1.Text;

            PatientDAO patientDAO = new PatientDAO();
            Patient patient = new Patient(nom, age.ToString(), sexe);
            patientDAO.insertPatient(patient);
            Patient[] patient1 = patientDAO.findLastPatient();
            int idPatient = patient1[0].Id;

            PatientDetailDAO patientDetailDAO = new PatientDetailDAO();
            for (int i = 0; i < resultat.Length; i++)
            {
                PatientDetail patientDetail = new PatientDetail(idPatient, resultat[i].Maladie, resultat[i].Pourcentage);
                patientDetailDAO.savePatientDetail(patientDetail);
            }
            MessageBox.Show("Enregistrement reussi");
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < diagnostic.Length; i++)
            {
                String designation = diagnostic[i].Designation;
                double value = diagnostic[i].Value;
                PatientDAO patientDAO = new PatientDAO();
                Patient[] lastpatient = patientDAO.findLastPatient();
                int idPatient = lastpatient[0].Id;
                DateTime dateAnalyse = DateTime.Now;
                ResultatDiagnostic resultatDiagnostic = new ResultatDiagnostic(idPatient, designation, value, dateAnalyse);
                ResultatDiagnosticDAO resultatDiagnosticDAO = new ResultatDiagnosticDAO();
                resultatDiagnosticDAO.saveDiagnostic(resultatDiagnostic);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (temperature)
            {
                temperature = false;
                panel1.Refresh();
            }
            else
            {
                temperature = true;

            }
        }
    }
}