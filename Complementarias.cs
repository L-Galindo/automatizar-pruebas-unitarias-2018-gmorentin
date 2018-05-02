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
            StreamReader objReader = new StreamReader("C:\\Users\\gusta\\Downloads\\ejemplo2.txt");
            String[,] resultado;
            string sline = "";
            int cont = 0;

            // Se lee cuantas lienas tiene el archivo para crear la matriz
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

            //Se llena la matriz principal en base al archivo txt y separada por los delimitadores ":" para utilizar sus datos mas adelante
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


            //Se saca cual linea de valores de la matriz principal tiene mas numeros para en base a eso crear la matriz de valores enteros de abajo
            int lineaMayor = 0;
            for (int i = 0; i < resultado.GetLength(0); i++)
            {
            string[] nums;
                nums = resultado[i, 2].Split(' ');
                if (lineaMayor < nums.Length)
                    lineaMayor = nums.Length;
            }

            /*Se crea una matriz en donde se almacenarán los valores por linea que mas adelante le mandaremos los metodos de la clase 
             ademas se valida cuando el tipo de dato es diferente al que recibe la matriz*/
            int[,] resultado2 = new int[resultado.GetLength(0), lineaMayor];
            for (int columna = 0; columna < resultado.GetLength(0); columna++)
            {
            string[] nums2;
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

            /* Se crean los vectores del tipo de problema, del id del problema y de los valores que deberían de resultar de la ejecución del programa
               apartir de la matriz donde se encuentran todas las lineas del txt separadas por sus delimitadores
               ademas se valida cuando el tipo de dato es diferente al que el vector puede recibir*/
            String[] tipo = new String[resultado.GetLength(0)];
            String[] id = new String[resultado.GetLength(0)];
            double[] resultado3 = new double[resultado.GetLength(0)];
            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                id[i] = Convert.ToString(resultado[i, 0]);
                tipo[i] = Convert.ToString(resultado[i, 1]);
                if (resultado[i, 3] != "Exception")
                    resultado3[i] = Convert.ToDouble(resultado[i, 3]);
                else
                    resultado3[i] = -2;
            }

            //Problema 5
            /*Es donde se le mandan los valores de cada una de las lineas a los diferentes metodos para que se resuelvan 
            y se los resultados se van almacneando en un vector y se mide el tiempo que tardo en ejecutarse y se almacenan en un vector*/
            double[] tiempos = new double[tipo.Length];
            double[] valores = new double[tipo.Length];
            for (int i = 0; i < tipo.Length; i++)
            {
                stopWatch.Start();
                int[] valoresTemp = new int[resultado2.GetLength(1)];
                Medias med = new Medias();
                //Se almacena en un vector temporal los valores de cada una de las lineas de la matriz que representa una linea del archivo para mandarla a los metodos
                for (int j = 0; j < resultado2.GetLength(1); j++)
                {
                    //if (resultado2[i, j] != 0)
                        valoresTemp[j] = resultado2[i, j];
                }
                /*Antes de mandar los valores a los metodos se quitan los numeros que son 0 que son los que sobran en cada linea de la matriz eliminado los numeros que sean 0 
                y eliminando esos espacios del vector para que no afecte a las operaciones*/
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
                    valores[i] = -3;
                }
                else
                {
                    stopWatch.Start();
                    valores[i] = -4;
                }
                stopWatch.Stop();
                tiempos[i] = stopWatch.ElapsedMilliseconds;
            }

            //Cambio los valores de -1 a 0 porque si no me marcaba un valor raro en el vector
            for (int i = 0; i < valores.Length; i++)
            {
                if (valores[i] == -1)
                    valores[i] = 0;
            }

            //Se crea el vector de si el problema tuvo exito o error
            int fallas = 0;
            int bien = 0;
            String[] color = new String[valores.Length];
            for (int i = 0; i < valores.Length; i++)
            {
                if (valores[i] == -3 || valores[i] == -4)
                    color[i] = null;
                else if (resultado3[i] == valores[i])
                {
                    color[i] = "Exito";
                    bien++;
                }
                else
                {
                    color[i] = "Falla";
                    fallas++;
                }
            }

            //Imprimir todo en el archivo txt
            String time = DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
            StreamWriter sw = new StreamWriter("C:\\Users\\gusta\\Downloads\\" + time + ".txt");
            for (int i = 0; i < valores.Length; i++)
            {
                if(resultado3[i]==-2)
                    sw.WriteLine(id[i] + ": " + color[i] + ": " + tipo[i] + ": " + "Calculado = " + valores[i] + ":" + "Esperado = Exception");

               else if (valores[i] == -4 || valores[i] == -3)
                    sw.WriteLine(id[i] + ":" + tipo[i] + " Metodo no encontrado");
                else
            sw.WriteLine(id[i] +": " +color[i]+ ": "+ tipo[i]+": "+"Calculado = "+valores[i]+ ":" +"Esperado = "+ resultado3[i]+":"+ "Ejecución: "+ tiempos[i]+ " ms");
            }
            sw.WriteLine("Exitoso: " + bien);
            sw.WriteLine("Fallas:" + fallas);
            sw.Close();


            //Imprimir todo en Consola
            for (int i = 0; i < valores.Length; i++)
            {
                if (resultado3[i] == -2)
                {
                    Console.Write(id[i]);
                    Console.Write(": ");
                    if (color[i] == "Exito")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(color[i]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(color[i]);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(": " + tipo[i] + ": " + "Calculado = " + valores[i] + ":" + "Esperado = Exception");
                    Console.WriteLine();
                }
                else if (valores[i] == -4 || valores[i] == -3)
                    Console.WriteLine(id[i] + ":" + tipo[i] + " Metodo no encontrado");
                else
                {
                    Console.Write(id[i]);
                    Console.Write(": ");
                    if (color[i] == "Exito")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(color[i]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(color[i]);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(": " + tipo[i] + ": " + "Calculado = " + valores[i] + ":" + "Esperado = " + resultado3[i] + ":" + "Ejecución: " + tiempos[i] + " ms");
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
    }
}
