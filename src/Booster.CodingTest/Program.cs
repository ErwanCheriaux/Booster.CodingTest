using System;
using System.Threading;
using System.Threading.Tasks;

namespace Booster.CodingTest
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var stream = new Library.WordStream();

            Task.Run(() => StreamAnalyzer.ProcessText(stream, 500));

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Number of char: {StreamAnalyzer.CountChar}");
                Console.WriteLine($"Number of word: {StreamAnalyzer.CountWord}");
                Thread.Sleep(500);
            }
        }
    }
}