using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    class PatientDetail
    {
        int id;
        int patient;
        int maladie;
        String nomMaladie;
        float pourcentage;

        public PatientDetail() { }

        public PatientDetail(int id, int patient, int maladie, float pourcentage)
        {
            this.Id = id;
            this.Patient = patient;
            this.Maladie = maladie;
            this.Pourcentage = pourcentage;
        }

        public PatientDetail(int id, int maladie, float pourcentage)
        {
            this.Id = id;
            this.Maladie = maladie;
            this.Pourcentage = pourcentage;
        }

        public PatientDetail(int id, String nomMaladie, float sommet)
        {
            this.Id = id;
            this.NomMaladie = nomMaladie;
            this.Pourcentage = pourcentage;
        }

        public int Id { get; set; }

        public int Patient { get; set; }

        public int Maladie { get; set; }

        public float Pourcentage { get; set; }

        public String NomMaladie { get; set; }
    }
}
