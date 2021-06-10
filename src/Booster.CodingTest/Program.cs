using System;
using System.Collections.Generic;
using System.Threading;

namespace Booster.CodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var stream = new Library.WordStream();

            string word = "";

            // The 10 most frequently appearing words.
            var dico = new Dictionary<string, int>();

            // Total number of characters and words.
            int countWord = 0;
            int countChar = 0;

            while (stream.CanRead)
            {
                int b = stream.ReadByte();
                char c = Convert.ToChar(b);

                if (Char.IsLetter(c))
                {
                    word += c;
                }
                else if (word != "")
                {
                    if (dico.ContainsKey(word))
                    {
                        dico[word]++;
                    }
                    else
                    {
                        dico.Add(word, 1);
                    }

                    Console.WriteLine($"{word}\t{dico[word]}");
                    Thread.Sleep(500);

                    word = "";
                    countWord++;
                }

                countChar++;
            }
        }
    }
}
