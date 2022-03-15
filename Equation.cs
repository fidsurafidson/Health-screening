using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    class Equation
    {
        public double a;
        public double b;

        public Equation()
        {

        }

        public Equation(double a, double b)
        {
            this.A = a;
            this.B = b;
        }

        public double B
        {
            get { return b; }
            set { b = value; }
        }

        public double A
        {
            get { return a; }
            set { a = value; }
        }
    }
}
