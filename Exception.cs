using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Collections;


namespace Split
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            string[] nums;
            string[] nums2;
            StreamReader objReader = new StreamReader("C:\\Users\\gusta\\Downloads\\ejemplo2.txt");
            string sline = "";
            int cont = 0;
            String[,] resultado;

            while (sline != null)
            {
                sline = objReader.ReadLine();
                if (sline != null)
                cont++;
            }

            String[] temp = new String[4];
            resultado = new String[cont, 4];
            int cont2 = 0;
            objReader.Close();
            StreamReader objReader2 = new StreamReader("C:\\Users\\gusta\\Downloads\\ejemplo2.txt");
            sline = "";

            while ((sline = objReader2.ReadLine()) != null)
            {
                temp = sline.Split(':');

                for (int i = 0; i < resultado.GetLength(1); i++)
                {
                    resultado[cont2, i] = temp[i];
                }
                cont2++;
            }
            objReader2.Close();

            int lineaMayor = 0;
            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                nums = resultado[i, 2].Split(' ');
                if (lineaMayor < nums.Length)
                    lineaMayor = nums.Length;
            }

            int[,] resultado2 = new int[resultado.GetLength(0), lineaMayor];
            for (int columna = 0; columna < resultado.GetLength(0); columna++)
            {
                nums2 = resultado[columna, 2].Split(' ');

                for (int fila = 0; fila < nums2.Length; fila++)
                {
                    //Problema 6
                    if (nums2[fila] != "NULL")
                        resultado2[columna, fila] = Convert.ToInt32(nums2[fila]);
                    else
                        resultado2[columna, fila] = -1;
                }
            }

            String[] tipo = new String[resultado.GetLength(0)];
            String[] id = new String[resultado.GetLength(0)];
            double[] resultado3 = new double[resultado.GetLength(0)];
            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                id[i] = Convert.ToString(resultado[i, 0]);
                tipo[i] = Convert.ToString(resultado[i, 1]);
                //Problema 7
                if (resultado[i, 3] != "Exception")
                    resultado3[i] = Convert.ToDouble(resultado[i, 3]);
                else
                    resultado3[i] = -2;
            }

                double[] tiempos = new double[tipo.Length];
            //Problema 5
            double[] valores = new double[tipo.Length];
            for (int i = 0; i < tipo.Length; i++)
            {
                int[] valoresTemp = new int[resultado2.GetLength(1)];
                Medias med = new Medias();

                for (int j = 0; j < resultado2.GetLength(1); j++)
                {
                    if (resultado2[i, j] != 0)
                    {
                        valoresTemp[j] = resultado2[i, j];
                    }
                }
                valoresTemp = valoresTemp.Where(num => num != 0).ToArray();

                double res = 0;
                if (tipo[i] == "mediaAritmetica")
                {
                    stopWatch.Start();
                    res = Medias.mediaAritmetica(valoresTemp);
                    valores[i] = res;
                    stopWatch.Stop();
                    tiempos[i] = stopWatch.ElapsedMilliseconds;
                }
                else if (tipo[i] == "mediaGeometrica")
                {
                    stopWatch.Start();
                    res = med.mediaGeometrica(valoresTemp);
                    valores[i] = res;
                    stopWatch.Stop();
                    tiempos[i] = stopWatch.ElapsedMilliseconds;
                }
                else if (tipo[i] == "mediaArmonica")
                {
                    //res = Medias.mediaArmonica(valoresTemp);
                    stopWatch.Start();
                    valores[i] = -3;
                    stopWatch.Stop();
                    tiempos[i] = stopWatch.ElapsedMilliseconds;

                }
                else
                {
                    stopWatch.Start();
                    valores[i] = -4;
                    stopWatch.Stop();
                    tiempos[i] = stopWatch.ElapsedMilliseconds;
                }
            }

            for (int i = 0; i < valores.Length; i++)
            {
                if (valores[i] == -1)
                    valores[i] = 0;
            }
            Console.ReadLine();
        }
    }
}
