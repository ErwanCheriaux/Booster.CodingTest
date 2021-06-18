using System;
using System.Threading.Tasks;

namespace Booster.CodingTest
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var stream = new Library.WordStream();

            Task.Run(() => StreamAnalyzer.ProcessText(stream, 50));

            Console.CursorVisible = false;

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"{StreamAnalyzer.Sentence}");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine($"Number of char: {StreamAnalyzer.CountChar}");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"Number of word: {StreamAnalyzer.CountWord}");
            }
        }
    }
}