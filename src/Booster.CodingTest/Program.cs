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

                PrintList(StreamAnalyzer.SmallestWords, 0, 3, "Smallest words: ");
                PrintList(StreamAnalyzer.LargestWords, 0, 4, "Largest words: ");
                PrintList(StreamAnalyzer.FrequentWords, 0, 5, "Most frequent words: ");
                
                PrintCharFrequency(0, 6, "Most frequent characters: ");
            }
        }

        private static void PrintList<T>(List<T> list, int x, int y, string message = "")
        {
            List<T> l = new(list);
            Console.SetCursorPosition(x, y);
            l.ForEach((e) => message += e + " ");
            while (message.Length < Console.WindowWidth) { message += " "; }
            Console.WriteLine($"{message}");
        }

        private static void PrintCharFrequency(int x, int y, string message = "")
        {
            Console.SetCursorPosition(x, y++);
            Console.WriteLine($"{message}");
            
            List<char> l = new(StreamAnalyzer.FrequentChars);
            
            foreach(char c in l)
            {
                Console.SetCursorPosition(x, y++);
                message = $"'{c}' {StreamAnalyzer.GetCharFrequency(c)}%";
                while (message.Length < Console.WindowWidth) { message += " "; }
                Console.WriteLine($"{message}");
            }
        }
    }
}