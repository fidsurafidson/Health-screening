using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    class ResultatDiagnostic
    {
        int id;
        int patient;
        String designation;
        double value;
        DateTime dateAnalyse;

        public ResultatDiagnostic() { }

        public ResultatDiagnostic(int patient, String designation, double value, DateTime dateAnalyse)
        {
            this.Patient = patient;
            this.Designation = designation;
            this.Value = value;
            this.DateAnalyse = dateAnalyse;
        }

        public int Id { get; set; }

        public int Patient { get; set; }

        public String Designation { get; set; }

        public double Value { get; set; }

        public DateTime DateAnalyse { get; set; }
    }
}
