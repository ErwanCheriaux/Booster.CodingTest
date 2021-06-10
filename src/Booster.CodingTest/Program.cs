using System;
using System.Collections.Generic;

namespace Booster.CodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var stream = new Library.WordStream();

            string word = "";
            var dico = new Dictionary<string, int>();

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

                    Console.WriteLine(word);
                    word = "";
                }
            }
        }
    }
}
