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
            string[] words;

            DirectoryInfo directorio = new DirectoryInfo(@"C:\\Users\\gusta\\Downloads\\EJEMPLO");
            FileInfo[] archivos = directorio.GetFiles();

            foreach (var a in archivos)
            {
                string[] lines = File.ReadAllLines(a.FullName);
                comment = 0;
                sql =0;
                hidden = 0;
                foreach (string line in lines)
                {
                    words = line.Split(' ');
                    if (Array.Exists(words, element => element.StartsWith("<!--")))
                    {
                        comment++;
                        totalcomment++;
                    }
                    if (Array.Exists(words, element => element.StartsWith("SELECT"))|| Array.Exists(words, element => element.StartsWith("UPDATE")) || Array.Exists(words, element => element.StartsWith("INSERT")) || Array.Exists(words, element => element.StartsWith("DELETE")))
                    {
                        sql++;
                        totalsql++;
                    }
                    if (Array.Exists(words, element => element.Contains("input")) && Array.Exists(words, element => element.Contains("type")) && Array.Exists(words, element => element.Contains("hidden")))
                    {
                        hidden++;
                        totalhidden++;
                    }
                }
                Console.WriteLine("Comentarios HTML de " + a.Name +"= "+ comment);
                Console.WriteLine("Sentencias SQL de "+ a.Name + "= "+ sql);
                Console.WriteLine("Hidden: " + a.Name + "= " + hidden);

                Console.WriteLine();
            }
            Console.WriteLine("Comentarios totales HTML: "+totalcomment);
            Console.WriteLine("Sentencias SQL Totales: " + totalsql);
            Console.WriteLine("Hidden: " + totalhidden);

            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
