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
                Console.WriteLine($"{StreamAnalyzer.Sentence}");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine($"Number of char: {StreamAnalyzer.CountChar}");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"Number of word: {StreamAnalyzer.CountWord}");

                PrintList(StreamAnalyzer.SmallestWords, 0, 3);
                PrintList(StreamAnalyzer.LargestWords, 0, 4);
                PrintList(StreamAnalyzer.FrequentWords, 0, 5);
                PrintList(StreamAnalyzer.FrequentChars, 0, 6);
            }
        }

        private static void PrintList(List<string> l, int x, int y, string message = "")
        {
            string outcome = "";
            Console.SetCursorPosition(x, y);
            l.ForEach((e) => outcome += e + " ");
            Console.WriteLine($"{message}{outcome}");
        }

        private static void PrintList(List<char> l, int x, int y, string message = "")
        {
            string outcome = "";
            Console.SetCursorPosition(x, y);
            l.ForEach((e) => outcome += e + " ");
            Console.WriteLine($"{message}{outcome}");
        }
    }
}