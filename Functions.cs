using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyse
{
    class Functions
    {
        // Equation
        public Equation getPerpendiculaire(Equation equation, int x, int y)
        {
            double a = -1 / equation.a;
            double b = y - (a * x);
            return new Equation(a, b);
        }

        public Equation getEquation(Point centre, Point quelconque)
        {
            Equation equation = new Equation();
            if (quelconque.X == centre.X)
            {
                equation.a = centre.X;
                equation.b = centre.Y;
            }
            else
            {
                double numerateur = quelconque.Y - centre.Y;
                double denominateur = quelconque.X - centre.X;
                double A = numerateur / denominateur;
                double B = centre.Y - (A * centre.X);
                equation.a = A;
                equation.b = B;
            }
            return equation;
        }

        public double mesurer(Point point1, Point point2)
        {
            double result = 0;
            result = Math.Sqrt((point2.X - point1.X) * (point2.X - point1.X) + (point2.Y - point1.Y) * (point2.Y - point1.Y));
            return result;
        }

    }
}
