using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
{
    class Message
    {
        // Message Warming with or without break program and clean console

        public static void Warming(string text, bool clean = true, bool stop = true)
        {
            if(clean) Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Warming: {text}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            if(stop) Environment.Exit(5);
        }

        // Message Error with or without break program and clean console

        public static void Error(string text, bool clean = true, bool stop = true)
        {
            if (clean) Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {text}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            if (stop) Environment.Exit(5);
        }

        // Message Sucess
        public static void Sucess(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Sucess: {text}");
            Console.ForegroundColor = ConsoleColor.White;
            //Console.ReadKey();
        }
    }
}
