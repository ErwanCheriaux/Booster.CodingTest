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
                string outcome = "";
                
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"{StreamAnalyzer.Sentence}");
                Console.SetCursorPosition(0, 1);
                Console.WriteLine($"Number of char: {StreamAnalyzer.CountChar}");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine($"Number of word: {StreamAnalyzer.CountWord}");

                outcome = "";
                Console.SetCursorPosition(0, 3);
                StreamAnalyzer.SmallestWords.ForEach((e) => outcome += e + " ");
                Console.WriteLine($"Smallest words: {outcome}");

                outcome = "";
                Console.SetCursorPosition(0, 4);
                StreamAnalyzer.LargestWords.ForEach((e) => outcome += e + " ");
                Console.WriteLine($"Largest words: {outcome}");

                outcome = "";
                Console.SetCursorPosition(0, 5);
                StreamAnalyzer.FrequentWords.ForEach((e) => outcome += e + " ");
                Console.WriteLine($"Frequent words: {outcome}");

                outcome = "";
                Console.SetCursorPosition(0, 6);
                StreamAnalyzer.FrequentChars.ForEach((e) => outcome += e + " ");
                Console.WriteLine($"Frequent chars: {outcome}");
            }
        }
    }
}