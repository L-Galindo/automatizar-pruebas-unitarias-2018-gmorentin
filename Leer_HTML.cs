using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace Leer_HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            // StreamReader objReader = new StreamReader("C:\\Users\\gusta\\Downloads\\ejemplo.txt");
            //string text = System.IO.File.ReadAllText(@"C:\\Users\\gusta\\Downloads\\ejemplo.txt");
            //string[] lines =  File.ReadAllLines(@"C:\\Users\\gusta\\Downloads\\EJEMPLO\\nuevo.html");
            //string[] lines = File.ReadAllLines(@"C:\\Users\\gusta\\Downloads\\ejemplo.txt");

            int comment = 0;
            int totalcomment = 0;
            int sql = 0;
            int totalsql = 0;
            int hidden = 0;
            int totalhidden = 0;
            int normalComments = 0;
            int totalnormalComments = 0;
            int correo = 0;
            int totalcorreo = 0;
            int conexion = 0;
            int totalconexion = 0;
            int ip = 0;
            int totalIp = 0;
            string[] words;

            DirectoryInfo directorio = new DirectoryInfo(@"C:\\Users\\gusta\\Downloads\\EJEMPLO");
            FileInfo[] archivos = directorio.GetFiles();

            foreach (var a in archivos)
            {
                string[] lines = File.ReadAllLines(a.FullName);
                comment = 0;
                sql =0;
                hidden = 0;
                normalComments = 0;
                correo = 0;
                conexion = 0;
                ip = 0;

                foreach (string line in lines)
                {
                    words = line.Split(' ');

                    if (Array.Exists(words, element => element.StartsWith("<!--")))
                    {
                        comment++;
                        totalcomment++;
                    }

                    if (Array.Exists(words, element => element.Contains("SELECT"))|| Array.Exists(words, element => element.Contains("UPDATE")) || Array.Exists(words, element => element.Contains("INSERT")) || Array.Exists(words, element => element.Contains("DELETE")))
                    {
                        sql++;
                        totalsql++;
                    }

                    if (Array.Exists(words, element => element.Contains("input")) && Array.Exists(words, element => element.Contains("type")) && Array.Exists(words, element => element.Contains("hidden")))
                    {
                        hidden++;
                        totalhidden++;
                    }

                    if (Array.Exists(words, element => element.StartsWith("//")) || Array.Exists(words, element => element.StartsWith("/*")))
                    {
                        normalComments++;
                        totalnormalComments++;
                    }

                    if (Array.Exists(words, element => element.Contains("@gmail")) || Array.Exists(words, element => element.Contains("@ucol")) || Array.Exists(words, element => element.Contains("@hotmail")) || Array.Exists(words, element => element.Contains("@live")) || Array.Exists(words, element => element.Contains("@outlook")))
                    {
                        correo++;
                        totalcorreo++;
                    }

                    if (Array.Exists(words, element => element.Contains("Provider")) || Array.Exists(words, element => element.Contains("Data")) || Array.Exists(words, element => element.Contains("Source")) || Array.Exists(words, element => element.Contains("Driver")))
                    {
                        conexion++;
                        totalconexion++;
                    }

                    if (Array.Exists(words, element => element.Contains("1")) && Array.Exists(words, element => element.Contains(".")))
                    {
                        ip++;
                        totalIp++;
                    }
                }
                Console.WriteLine("Total del documento: " + a.Name);
                Console.WriteLine("Comentarios HTML: " + comment);
                Console.WriteLine("Sentencias SQL: " + sql);
                Console.WriteLine("Hiddens: " + hidden);
                Console.WriteLine("Comentarios de aplicación: " + normalComments);
                Console.WriteLine("Correos electrónicos: " + correo);
                Console.WriteLine("Conexión a Bases de datos: " + conexion);
                Console.WriteLine("Direcciones IP: " + ip);
                Console.WriteLine();
            }

            Console.WriteLine("------------Totales de todos los documentos------------------");
            Console.WriteLine("Comentarios totales HTML: "+totalcomment);
            Console.WriteLine("Sentencias SQL Totales: " + totalsql);
            Console.WriteLine("Hidden totales: " + totalhidden);
            Console.WriteLine("Comentarios de aplicación totales: " + totalnormalComments);
            Console.WriteLine("Conexión a Bases de datos totales: " + totalconexion);
            Console.WriteLine("Direcciones IP totales: " + totalIp);
            Console.WriteLine();


            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
