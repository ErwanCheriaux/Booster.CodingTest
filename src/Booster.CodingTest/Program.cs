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

        private static readonly Dictionary<string, int> Dico = new();

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
            _frequentWords = new();
            Dico.Clear();

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
                    if (Dico.ContainsKey(word))
                    {
                        Dico[word]++;
                    }
                    else
                    {
                        Dico.Add(word, 1);
                    }

                    if (output)
                    {
                        Console.WriteLine($"{word}\t{Dico[word]}");
                        Thread.Sleep(500);
                    }

                    UpdateWordsList(ref _smallestWords, word, 5, SmallestWord);
                    UpdateWordsList(ref _largestWords, word, 5, LargestWord);
                    UpdateWordsList(ref _frequentWords, word, 10, FrequentWord);

                    _countWord++;
                    word = "";
                }

                _countChar++;
            }
        }

        private static int SmallestWord(string x, string y) => x.Length.CompareTo(y.Length);
        private static int LargestWord(string x, string y) => y.Length.CompareTo(x.Length);
        private static int FrequentWord(string x, string y) => Dico[y].CompareTo(Dico[x]);

        /// <summary>
        /// Updates the words list.
        /// </summary>
        /// <param name="wordsList">The words list to update.</param>
        /// <param name="newWord">The new word to compare with the words list.</param>
        /// <param name="sizeList">The max size of the word list.</param>
        /// <param name="compareRule">The comparing rule: smallestWord, largestWord or FrequentWord</param>
        private static void UpdateWordsList(ref List<string> wordsList, string newWord, int sizeList, Comparison<string> compareRule)
        {
            if (!wordsList.Contains(newWord))
            {
                wordsList.Add(newWord);

                if (wordsList.Count > sizeList)
                {
                    wordsList.Sort(compareRule);
                    wordsList.RemoveAt(sizeList);
                }
            }
        }
    }
}