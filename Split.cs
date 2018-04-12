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

            for (int f = 0; f < resultado.GetLength(0); f++)
            {
                for (int c = 0; c < resultado.GetLength(1); c++)
                {
                    Console.Write(resultado[f, c] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
