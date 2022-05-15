using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SplineParametres
    {
        public int nx { get; set; } = 100;
        public double start { get; set; }
        public double end { get; set; }
        public double[] nodes_arr { get; }
        public double[] integral_limits { get; set; } = new double[3] { 0, 1, 2 };
        public SplineParametres ()
        {
            nodes_arr = null;
        }
        public SplineParametres(double a, double b, int N)
        {
            if (N <= 2)      //not really needed cause of validation in WPF, not gonna be invoked
            {                //it's also impossible to get in a bigger value than in b, cause of validation
                                //and also actually I decided to add check of value here)

                throw new ArgumentOutOfRangeException("Number of nodes in vector must be > 2");
            }
            if (a >= b)
            {
                throw new ArgumentOutOfRangeException("a must be < than b");
            }
            start = a; end = b;
            nx = N;
            nodes_arr = Get_Uniform_Values(a, b);
        }
        public double[] Get_Uniform_Values(double a, double b)
        {
            double[] rez = new double[nx];
            rez[0] = a; rez[nx - 1] = b;
            for (int i = 1; i < nx - 1; i++)
            {
                rez[i] = a + i * (b - a) / (nx - 1);
            }
            return rez;
        }
    }
}
