using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    class Maladie
    {
        int id;
        String nom;

        public Maladie() { }

        public Maladie(int id, String nom)
        {
            this.Id = id;
            this.Nom = nom;
        }

        public int Id { get; set; }

        public String Nom { get; set; }
    }
}
