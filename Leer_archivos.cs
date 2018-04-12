using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
           StreamReader objReader = new StreamReader("C:\\Users\\gusta\\Downloads\\ejemplo.txt");
            string sline = "";

            while (sline != null)
            {
                sline = objReader.ReadLine();
                if (sline != null)
                   Console.WriteLine(sline);
            }
            objReader.Close();
            Console.ReadLine();
        }
    }
}
