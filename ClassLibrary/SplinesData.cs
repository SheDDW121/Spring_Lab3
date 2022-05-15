using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SplinesData
    {
        public MeasuredData M_Data { get; set; }
        public SplineParametres Spl_Data { get; set; }

        //public double[] nodes_uniform_arr
        //{
        //    get
        //    {
        //        int nx = Spl_Data.nx;
        //        double a = Spl_Data.start;
        //        double b = Spl_Data.end;
        //        double[] rez = new double[nx];
        //        rez[0] = a; rez[nx - 1] = b;
        //        for (int i = 1; i < nx - 1; i++)
        //        {
        //            rez[i] = a + i * (b - a) / (nx - 1);
        //        }
        //        return rez;
        //    }
        //}

        public SplinesData(MeasuredData D1, SplineParametres D2)
        {
            M_Data = D1;
            Spl_Data = D2;
        }
        public double[] Values { get; set; }
        public double[] Integrals_Values { get; set; }

        public double [] Start_MKL ()
        {
            try
            {
                double[] rez = new double[Spl_Data.nx];
                double[] coeff = new double[(M_Data.nx - 1) * 4];
                double[] deriv = new double[6];
                double[] int_val = new double[3];
                double[] int_lim = new double[3] { Spl_Data.integral_limits[0], Spl_Data.integral_limits[1], Spl_Data.integral_limits[2] };
                int error = 0;

                GetMKL(M_Data.nx, M_Data.nodes_arr, M_Data.values, Spl_Data.nx, rez, deriv, int_lim, int_val, ref error, coeff);
                Values = rez;
                Integrals_Values = int_val;
                return deriv;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [DllImport("..\\..\\..\\..\\x64\\DEBUG\\Dll_Lib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern
        bool GetMKL(int nx, double[] x, double[] y, int N, double[] values, double [] deriv, double [] int_lim, double [] int_val, ref int error, double[] coeff);
    }
}
