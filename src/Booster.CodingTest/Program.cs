using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Booster.CodingTest
{
    public class Program
    {
        static private int _countWord;

        static public int CountWord
        {
            get { return _countWord; }
        }

        static private int _countChar;

        static public int CountChar
        {
            get { return _countChar; }
        }

        static private List<string> _frequentWords;

        static public List<string> FrequentWords
        {
            get { return _frequentWords; }
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var stream = new Library.WordStream();

            ProcessText(stream);

            Console.WriteLine("End of the program");
        }

        public static void ProcessText(Stream text)
        {
            string word = "";

            // The 10 most frequently appearing words.
            var dico = new Dictionary<string, int>();

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
                    word += Char.ToLower(c);
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
                    //Thread.Sleep(500);

                    word = "";
                    _countWord++;
                    //_frequentWords = GetMostFrequencyWord(dico, 10);
                }

                _countChar++;
            }
            _frequentWords = GetMostFrequencyWord(dico, 10);
        }

        private static List<string> GetMostFrequencyWord(Dictionary<string, int> dico, int countMostFrequencyWords)
        {
            var dicoToList = dico.ToList();
            dicoToList.Sort((x, y) => y.Value.CompareTo(x.Value));
            List<string> wordList = new();

            foreach (var item in dicoToList)
            {
                wordList.Add(item.Key);
                if (--countMostFrequencyWords == 0) break;
            }

            return wordList;
        }
    }
}