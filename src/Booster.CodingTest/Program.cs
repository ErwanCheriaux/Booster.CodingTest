using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Booster.CodingTest
{
    public class Program
    {
        static private int _countWord;

        static public int countWord
        {
            get { return _countWord; }
        }

        static private int _countChar;

        static public int countChar
        {
            get { return _countChar; }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var stream = new Library.WordStream();

            ProcessText(stream);

            Console.WriteLine("End of the program");
        }

        static public void ProcessText(Stream text)
        {
            string word = "";

            // The 10 most frequently appearing words.
            var frequencyWord = new Dictionary<string, int>();

            // Total number of characters and words.
            _countWord = 0;
            _countChar = 0;

            while (true)
            {
                int b = text.ReadByte();
                if (b == -1) break;

                char c = Convert.ToChar(b);

                if (Char.IsLetter(c))
                {
                    word += c;
                }
                else if (word != "")
                {
                    if (frequencyWord.ContainsKey(word))
                    {
                        frequencyWord[word]++;
                    }
                    else
                    {
                        frequencyWord.Add(word, 1);
                    }

                    Console.WriteLine($"{word}\t{frequencyWord[word]}");
                    Thread.Sleep(500);

                    word = "";
                    _countWord++;
                }

                _countChar++;
            }
        }
    }
}