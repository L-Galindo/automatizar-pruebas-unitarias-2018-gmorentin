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
            string[] nums3;
            StreamReader objReader = new StreamReader("C:\\Users\\gusta\\Downloads\\ejemplo.txt");
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
            StreamReader objReader2 = new StreamReader("C:\\Users\\gusta\\Downloads\\ejemplo.txt");
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

          /* for (int f = 0; f < resultado.GetLength(0); f++)
            {
                for (int c = 0; c < resultado.GetLength(1); c++)
                {
                 if(c==2)
                        nums = resultado[f, 2].Split(' ');
                }
                Console.WriteLine();
            }*/

           // nums = resultado[i, 2].Split(' ');
                //int[] ints = nums.Select(x => int.Parse(x)).ToArray();
                //nums2 = resultado[1, 2].Split(' ');
                //int[] ints2 = nums.Select(x => int.Parse(x)).ToArray();
                //nums3 = resultado[2, 2].Split(' ');
                //int[] ints3 = nums.Select(x => int.Parse(x)).ToArray();


                double res1 = Convert.ToDouble(resultado[0, 3]);
                double res2 = Convert.ToDouble(resultado[1, 3]);
                double res3 = Convert.ToDouble(resultado[2, 3]);
            Console.WriteLine(resultado.GetLength(0));

           /* for (int f = 0; f < resultado.GetLength(0); f++)
            {
                for (int c = 3; c < resultado.GetLength(1); c++)
                {
                    Console.Write(resultado[f, c] + " ");
                }
                Console.WriteLine();
            }*/
            Console.ReadLine();
        }
    }
}
