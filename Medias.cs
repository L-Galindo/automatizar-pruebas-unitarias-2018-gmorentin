using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split
{
    class Medias
    {
        public static double mediaAritmetica(int[] vals)
        {
            string res2 = "";
            double suma = 0;
            double res = 0;
            for (int cont = 0; cont < vals.Length; cont++)
            {
                suma = suma + vals[cont];
            }
            res = suma / vals.Length;
            res2=String.Format("{0:0.0000}", res);
            Convert.ToDouble(res2);
            return Convert.ToDouble(res2); 
        }


        private static double raizEnesima(double x, int n)
        {
            if (n == 0)
               return 0;
            else
            {
            decimal num = (decimal)1 / n;
            return Math.Pow(x, Convert.ToDouble(num));
            }
        }

        public double mediaGeometrica(int[] vals)
        {
            string res2 = "";
            double suma = 1;
            for (int cont = 0; cont < vals.Length; cont++)
            {
                suma = suma * vals[cont];
            }
            double res = raizEnesima(suma, vals.Length);
            res2 = String.Format("{0:0.0000}", res);
            Convert.ToDouble(res2);
            return Convert.ToDouble(res2);
        }

        public static double mediaArmonica(int[] vals)
        {
            string res2 = "";
            double suma = 0;
            double res = 0;
            for (int cont = 0; cont < vals.Length; cont++)
            {
                suma = suma + ((double)1 / vals[cont]);
            }
            res = vals.Length / suma;
            res2 = String.Format("{0:0.0000}", res);
            Convert.ToDouble(res2);
            return Convert.ToDouble(res2);

        }
    }
}
