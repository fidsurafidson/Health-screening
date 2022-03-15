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
    class Diagnostic
    {
        int id;
        String designation;
        String unite;
        float maximum;
        float minimum;
        float normalMax;
        float normalMin;
        float value;
    
        public Diagnostic() { }

        public Diagnostic(int id, String designation, String unite, float maximum, float minimum, float normalMax, float normalMin, float value)
        {
            this.Id = id;
            this.Designation = designation;
            this.Unite = unite;
            this.Maximum = maximum;
            this.Minimum = minimum;
            this.NormalMax = normalMax;
            this.NormalMin = normalMin;
            this.Value = value;
        }

        public Diagnostic(int id, string designation, string unite, float maximum, float minimum, float normalMax, float normalMin)
        {
            this.Id = id;
            this.Designation = designation;
            this.Unite = unite;
            this.Maximum = maximum;
            this.Minimum = minimum;
            this.NormalMax = normalMax;
            this.NormalMin = normalMin;
        }

        public int Id { get; set; }

        public String Designation { get; set; }

        public String Unite { get; set; }

        public float Maximum { get; set; }

        public float Minimum { get; set; }

        public float NormalMax { get; set; }

        public float NormalMin { get; set; }

        public float Value { get; set; }
    }
}
