using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MeasuredData
    {
        public int nx { get; set; }
        public bool Uniform { get; set; }
        public double start { get; set; }
        public double end { get; set; }
        public Spf function { get; set; }
        public double[] nodes_arr { get; }
        public double[] values { get; set; }

        public MeasuredData(int N, double a, double b, bool Uni, Spf Fun)
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
            Uniform = Uni;
            function = Fun;
            nodes_arr = Get_nx_Values(a, b);
            values = Get_Values();
        }

        public double[] Get_nx_Values(double a, double b)
        {
            if (!Uniform)
            {
                Random rd = new Random();
                double[] rez = new double[nx];
                rez[0] = a; rez[1] = b;
                for (int i = 2; i < nx; i++)
                {
                    rez[i] = (rd.NextDouble() * (b - a)) + a;
                }
                Array.Sort(rez);
                return rez;
            }
            else
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
        public double[] Get_Values()
        {
            if (function == Spf.Linear)
            {
                double[] y = new double[nx];
                for (int i = 0; i < nx; i++)
                {
                    y[i] = nodes_arr[i] * 2 + 1; // 2x + 1
                }
                return y;
            }
            else if (function == Spf.Cubic)
            {
                double[] y = new double[nx];
                for (int i = 0; i < nx; i++)
                {
                    y[i] = 2 * nodes_arr[i] * nodes_arr[i] * nodes_arr[i] + 3 * nodes_arr[i] * nodes_arr[i] - 1; // 2 x^3 + 3x^2 - 1
                }
                return y;
            }
            else
            {
                Random rd = new Random();
                double[] y = new double[nx];
                for (int i = 0; i < nx; i++)
                {
                    y[i] = (rd.NextDouble() * 10); // random in [0, 10]
                }
                return y;
            }
        }
        public override string ToString()
        {
            return $"a = {start} ; b = {end} ; nx = {nx} ; function = {function} ; Uniform = {Uniform}";
        }
    }
    public enum Spf
    {
        Random, Linear, Cubic
    }
}