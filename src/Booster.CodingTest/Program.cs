using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Booster.CodingTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var stream = new Library.WordStream();

            processText(stream);

            Console.WriteLine("End of the program");
        }

        static public void processText(Stream text)
        {
            string word = "";

            // The 10 most frequently appearing words.
            var dico = new Dictionary<string, int>();

            // Total number of characters and words.
            int countWord = 0;
            int countChar = 0;

            while (text.CanRead)
            {
                int b = text.ReadByte();
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