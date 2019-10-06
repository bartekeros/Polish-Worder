using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Polish_Worder
{
    class MatchWordPatterns
    {
        public List<string> MatchingWords { get; private set; } = new List<string>();
        private string dictionaryEntry = null;


        public void FindAnagrams(string word, StreamReader sr)
        {
            int counter = 0;

            int wordLength = word.Length;
            char[] wordInChars = word.ToCharArray();
            wordInChars = wordInChars.OrderBy(o => o).ToArray();

            while((dictionaryEntry = sr.ReadLine()) != null)
            {
                if (wordLength == dictionaryEntry.Length)
                {
                    if (wordInChars.SequenceEqual(dictionaryEntry.ToCharArray().OrderBy(o => o).ToArray()))
                    {
                        MatchingWords.Add(dictionaryEntry.ToString());
                        counter++;
                    }
                }
            }
        }

        public void FindPalindromes(string word, StreamReader sr)
        {
            int counter = 0;

            while((dictionaryEntry = sr.ReadLine()) != null)
            {
                if (dictionaryEntry.StartsWith(word))
                {
                    if(dictionaryEntry == Reverse(dictionaryEntry))
                    {
                        MatchingWords.Add(dictionaryEntry.ToString());
                        counter++;
                    }
                }
            }
        }

        private string Reverse(string word)
        {
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
