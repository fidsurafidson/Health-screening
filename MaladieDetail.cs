using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    class MaladieDetail
    {
        int id;
        int maladie;
        int diagnostic;
        float sommet;

        public MaladieDetail() { }

        public MaladieDetail(int id, int maladie, int diagnostic, float sommet)
        {
            this.id = id;
            this.maladie = maladie;
            this.diagnostic = diagnostic;
            this.sommet = sommet;
        }

        public int Id { get; set; }

        public int Maladie { get; set; }

        public String NomMaladie { get; set; }

        public int Diagnostic { get; set; }

        public float Sommet { get; set; }
    }
}
