using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico.auxClass
{
    class Table
    {
        // Center string in element
        private static string centeredString(string s, int width)
        {
            if (s.Length >= width)
            {
                return s;
            }

            int leftPadding = (width - s.Length) / 2;
            int rightPadding = width - s.Length - leftPadding;

            return new string(' ', leftPadding) + s + new string(' ', rightPadding);
        }

        // Title 
        public static void title(string cabecalho, int tamTable = 50)
        {
            Console.WriteLine(String.Format("#{0}#", centeredString(cabecalho, tamTable)));
        }

        // Simple line
        public static void line(int width = 50)
        {
            string line = "";
            for (int i = 0; i <= width; i++)
            {
                line += '-';
            }
            Console.WriteLine(line);
        }

        // Line with width and break line
        public static void dataLine(string txt, int tam = 50, bool redColor = false)
        {
            if (redColor)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(String.Format("{0}", txt));
            if (redColor)
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        // BreakLine
        public static void tr()
        {
            Console.WriteLine();
        }

        // Line with width no break
        public static void td(string txt, int tam = 10, bool whiteColor = false)
        {
            if (whiteColor)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }

            Console.Write(String.Format("|{0}|", centeredString(txt, tam)));

            if (whiteColor)
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }

        }
    }
}
