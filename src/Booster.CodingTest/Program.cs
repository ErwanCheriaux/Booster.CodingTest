using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Booster.CodingTest
{
    public class Program
    {
        #region "properties"

        static private int _countWord = 0;

        static public int CountWord
        {
            get { return _countWord; }
        }

        static private int _countChar = 0;

        static public int CountChar
        {
            get { return _countChar; }
        }

        static private List<string> _smallestWords = new();

        static public List<String> SmallestWords
        {
            get { return _smallestWords; }
        }

        static private List<string> _largestWords = new();

        static public List<String> LargestWords
        {
            get { return _largestWords; }
        }

        static private List<string> _frequentWords = new();

        static public List<string> FrequentWords
        {
            get { return _frequentWords; }
        }

        #endregion "properties"

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var stream = new Library.WordStream();

            ProcessText(stream, true);

            Console.WriteLine("End of the program");
        }

        public static void ProcessText(Stream text, bool output = false)
        {
            string word = "";

            // The 10 most frequently appearing words.
            var dico = new Dictionary<string, int>();
            _frequentWords = new();

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

                    if (output)
                    {
                        Console.WriteLine($"{word}\t{dico[word]}");
                        Thread.Sleep(500);
                    }

                    _countWord++;
                    _frequentWords = GetMostFrequencyWord(dico, _frequentWords, word, 10);
                    _smallestWords = GetSmallestWord(_smallestWords, word, 5);
                    _largestWords = GetLargestWord(_largestWords, word, 5);

                    word = "";
                }

                _countChar++;
            }
        }

        private static List<string> GetSmallestWord(List<string> smallestWordsList, string newWord, int count)
        {
            if (smallestWordsList.Contains(newWord))
            {
                return smallestWordsList;
            }

            smallestWordsList.Add(newWord);

            if (smallestWordsList.Count > count)
            {
                smallestWordsList.Sort((x, y) => x.Length.CompareTo(y.Length));
                smallestWordsList.RemoveAt(count);
            }

            return smallestWordsList;
        }

        private static List<string> GetLargestWord(List<string> largestWordsList, string newWord, int count)
        {
            if (largestWordsList.Contains(newWord))
            {
                return largestWordsList;
            }

            largestWordsList.Add(newWord);

            if (largestWordsList.Count > count)
            {
                largestWordsList.Sort((x, y) => y.Length.CompareTo(x.Length));
                largestWordsList.RemoveAt(count);
            }

            return largestWordsList;
        }

        /// <summary>
        /// Gets the most frequency word.
        /// </summary>
        /// <param name="dico">Dictionary of every words and frequency.</param>
        /// <param name="frequentWordsList">The frequent words list.</param>
        /// <param name="newWord">The new word to compare withe the frequent words list.</param>
        /// <param name="count">The number of word in the frequent words list.</param>
        /// <returns>List of the most frequency word.</returns>
        private static List<string> GetMostFrequencyWord(Dictionary<string, int> dico, List<string> frequentWordsList, string newWord, int count)
        {
            if (frequentWordsList.Contains(newWord))
            {
                return frequentWordsList;
            }

            frequentWordsList.Add(newWord);

            if (frequentWordsList.Count > count)
            {
                frequentWordsList.Sort((x, y) => dico[y].CompareTo(dico[x]));
                frequentWordsList.RemoveAt(count);
            }

            return frequentWordsList;
        }
    }
}