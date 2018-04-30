using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;


namespace Split
{
    class Program
    {
        static void Main(string[] args)
        {
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

            resultado = new String[cont, 4];
            String[] temp = new String[4];
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
            double[] resultado3 = new double[resultado.GetLength(0)];
            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                tipo[i] = Convert.ToString(resultado[i, 1]);
                if (resultado[i, 3] != "Exception")
                    resultado3[i] = Convert.ToDouble(resultado[i, 3]);
                else
                    resultado3[i] = -1;
            }

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
                    res = Medias.mediaAritmetica(valoresTemp);
                    valores[i] = res;
                }
                else if (tipo[i] == "mediaGeometrica")
                {
                    res = med.mediaGeometrica(valoresTemp);
                    valores[i] = res;
                }
                else if (tipo[i] == "mediaArmonica")
                {
                res = Medias.mediaArmonica(valoresTemp);
                valores[i] = res;

                }
                else
                {
                    valores[i] = -1;
                    Console.WriteLine("No existe");
                }
            }
            // nums = resultado[i, 2].Split(' ');
            //int[] ints = nums.Select(x => int.Parse(x)).ToArray();
            //nums2 = resultado[1, 2].Split(' ');
            //int[] ints2 = nums.Select(x => int.Parse(x)).ToArray();
            //nums3 = resultado[2, 2].Split(' ');
            //int[] ints3 = nums.Select(x => int.Parse(x)).ToArray();


            //double res1 = Convert.ToDouble(resultado[0, 3]);
            //double res2 = Convert.ToDouble(resultado[1, 3]);
            //double res3 = Convert.ToDouble(resultado[2, 3]);
            //Console.WriteLine(resultado.GetLength(0));
            Console.ReadLine();
        }
    }
}
