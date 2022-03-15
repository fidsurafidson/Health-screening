using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    class Patient
    {
        int id;
        String nom;
        String age;
        String sexe;

        public Patient() { }

        public Patient(String nom)
        {
            this.Nom = nom;
        }

        public Patient(int id, String nom, String age, String sexe)
        {
            this.Id = id;
            this.Nom = nom;
            this.Age = age;
            this.Sexe = sexe;
        }

        public Patient(String nom, String age, String sexe)
        {
            this.Nom = nom;
            this.Age = age;
            this.Sexe = sexe;
        }

        public int Id { get; set; }

        public String Nom { get; set; }

        public String Age { get; set; }

        public String Sexe { get; set; }
    }
}
