using Colors.Net;
using static Colors.Net.StringStaticMethods;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booster.CodingTest
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var stream = new Library.WordStream();

            Task.Run(() => StreamAnalyzer.ProcessText(stream, 50));

            Console.Clear();
            Console.CursorVisible = false;

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                ColoredConsole.WriteLine($"{Cyan(StreamAnalyzer.Sentence)}");
                Console.SetCursorPosition(0, 1);
                ColoredConsole.WriteLine($"{DarkCyan("Number of char: ")}{StreamAnalyzer.CountChar}");
                Console.SetCursorPosition(0, 2);
                ColoredConsole.WriteLine($"{DarkCyan("Number of word: ")}{StreamAnalyzer.CountWord}");

                PrintList(StreamAnalyzer.SmallestWords, 0, 3, "Smallest words: ");
                PrintList(StreamAnalyzer.LargestWords, 0, 4, "Largest words: ");
                PrintList(StreamAnalyzer.FrequentWords, 0, 5, "Most frequent words: ");

                PrintCharFrequency(0, 6, "Most frequent characters: ");
            }
        }

        private static void PrintList<T>(List<T> list, int x, int y, string message = "")
        {
            string outcome = "";
            List<T> l = new(list);
            Console.SetCursorPosition(x, y);
            l.ForEach((e) => outcome += e + " ");
            while (outcome.Length < Console.WindowWidth) { outcome += " "; }
            ColoredConsole.WriteLine($"{DarkCyan(message)}{outcome}");
        }

        private static void PrintCharFrequency(int x, int y, string message = "")
        {
            Console.SetCursorPosition(x, y++);
            while (message.Length < Console.WindowWidth) { message += " "; }
            ColoredConsole.WriteLine($"{DarkCyan(message)}");

            List<char> l = new(StreamAnalyzer.FrequentChars);

            foreach (char c in l)
            {
                Console.SetCursorPosition(x, y++);
                message = $"{StreamAnalyzer.GetCharFrequency(c)}%";
                while (message.Length < Console.WindowWidth) { message += " "; }
                ColoredConsole.WriteLine($"'{Red(c.ToString())}' {message}");
            }
        }
    }
}