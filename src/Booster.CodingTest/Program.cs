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

        static private List<char> _frequentChars = new();

        static public List<char> FrequentChars
        {
            get { return _frequentChars; }
        }

        private static readonly Dictionary<string, int> AppearingWord = new();
        private static readonly Dictionary<char, int> AppearingChar = new();

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

            _countWord = 0;
            _countChar = 0;
            _smallestWords = new();
            _largestWords = new();
            _frequentWords = new();
            _frequentChars = new();
            AppearingWord.Clear();
            AppearingChar.Clear();

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
                    if (AppearingWord.ContainsKey(word))
                    {
                        AppearingWord[word]++;
                    }
                    else
                    {
                        AppearingWord.Add(word, 1);
                    }

                    if (output)
                    {
                        Console.WriteLine($"{word}\t{AppearingWord[word]}");
                        Thread.Sleep(500);
                    }

                    UpdateWordsList(ref _smallestWords, word, 5, SmallestWord);
                    UpdateWordsList(ref _largestWords, word, 5, LargestWord);
                    UpdateWordsList(ref _frequentWords, word, 10, FrequentWord);

                    _countWord++;
                    word = "";
                }

                if (AppearingChar.ContainsKey(c))
                {
                    AppearingChar[c]++;
                }
                else
                {
                    AppearingChar.Add(c, 1);
                }

                UpdateCharList(ref _frequentChars, c, FrequentChar);
                _countChar++;
            }
        }

        private static int SmallestWord(string x, string y) => x.Length.CompareTo(y.Length);

        private static int LargestWord(string x, string y) => y.Length.CompareTo(x.Length);

        private static int FrequentWord(string x, string y) => AppearingWord[y].CompareTo(AppearingWord[x]);

        private static int FrequentChar(char x, char y) => AppearingChar[y].CompareTo(AppearingChar[x]);

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

        private static void UpdateCharList(ref List<char> charsList, char newChar, Comparison<char> compareRule)
        {
            if (!charsList.Contains(newChar))
            {
                charsList.Add(newChar);
            }

            charsList.Sort(compareRule);
        }
    }
}